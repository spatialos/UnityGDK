using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Improbable.Gdk.CodeGeneration.FileHandling;
using Improbable.Gdk.CodeGeneration.Jobs;
using Improbable.Gdk.CodeGeneration.Model;
using Improbable.Gdk.CodeGeneration.Model.Details;
using Improbable.Gdk.CodeGeneration.Utils;

namespace Improbable.Gdk.CodeGenerator
{
    public class CodeGenerator
    {
        private readonly CodeGeneratorOptions options;
        private readonly IFileSystem fileSystem;

        public static int Main(string[] args)
        {
            try
            {
                var options = CodeGeneratorOptions.ParseArguments(args);
                var generator = new CodeGenerator(options, new MetaDataCompatibleFileSystem());

                return generator.Run();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Code generation failed with exception: {0}", e);
                if (e.InnerException != null)
                {
                    Console.Error.WriteLine(e.InnerException);
                }

                Console.Error.WriteLine(e.StackTrace);
            }

            return 1;
        }

        public CodeGenerator(CodeGeneratorOptions options, IFileSystem fileSystem)
        {
            this.options = options;
            this.fileSystem = fileSystem;
        }

        public int Run()
        {
            if (options.ShouldShowHelp)
            {
                ShowHelpMessage();
                return 0;
            }

            if (!ValidateOptions())
            {
                ShowHelpMessage();
                return 1;
            }

            var bundlePath = GenerateBundle();
            var schemaBundle = SchemaBundle.LoadBundle(File.ReadAllText(bundlePath));
            var fileTree = new FileTree(options.SchemaInputDirs);
            var store = new DetailsStore(schemaBundle, options.SerializationOverrides, fileTree);

            var jobs = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly =>
                {
                    try
                    {
                        return assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException e)
                    {
                        Console.Error.WriteLine($"Failed to load assembly {assembly.FullName} with error {e}");
                        return Enumerable.Empty<Type>();
                    }
                })
                .Where(type => typeof(CodegenJob).IsAssignableFrom(type))
                .Where(type => !type.IsAbstract)
                .Where(type => !type.GetCustomAttributes(typeof(IgnoreCodegenJobAttribute)).Any())
                .Select(type =>
                    (CodegenJob) Activator.CreateInstance(type, options.NativeOutputDirectory, fileSystem, store))
                .ToArray();

            new JobRunner(fileSystem).Run(jobs);
            return 0;
        }

        private string GenerateBundle()
        {
            var inputPaths = options.SchemaInputDirs.Select(dir => $"--schema_path=\"{dir}\"");

            SystemTools.EnsureDirectoryEmpty(options.JsonDirectory);

            var bundlePath = Path.Join(options.JsonDirectory, "bundle.json");

            var descriptorPath = Path.Join(options.DescriptorDirectory, "schema.descriptor");

            var arguments = new[]
            {
                "--load_all_schema_on_schema_path",
                $"--bundle_json_out=\"{bundlePath}\"",
                $"--descriptor_set_out=\"{descriptorPath}\""
            }.Union(inputPaths).ToList();

            SystemTools.RunRedirected(options.SchemaCompilerPath, arguments);

            return bundlePath;
        }

        private void ShowHelpMessage()
        {
            Console.WriteLine("Usage: ");
            Console.WriteLine(options.HelpText);
        }

        private bool ValidateOptions()
        {
            if (string.IsNullOrEmpty(options.NativeOutputDirectory))
            {
                Console.WriteLine("Native output directory not specified");
                return false;
            }

            if (options.SchemaInputDirs == null || options.SchemaInputDirs.Count == 0)
            {
                Console.WriteLine("Schema input directories not specified");
                return false;
            }

            if (string.IsNullOrEmpty(options.SchemaCompilerPath))
            {
                Console.WriteLine("Schema compiler location not specified");
                return false;
            }

            if (!File.Exists(options.SchemaCompilerPath))
            {
                Console.WriteLine($"Schema compiler does not exist at '{options.SchemaCompilerPath}'");
                return false;
            }

            return true;
        }
    }
}
