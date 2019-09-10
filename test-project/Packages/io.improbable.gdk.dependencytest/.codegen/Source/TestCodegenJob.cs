using System.IO;
using Improbable.Gdk.CodeGeneration.FileHandling;
using Improbable.Gdk.CodeGeneration.Jobs;
using Improbable.Gdk.CodeGeneration.Model.Details;

namespace Improbable.Gdk.CodeGenerator
{
    public class TestCodegenJob : CodegenJob
    {
        private readonly string relativeOutputPath = Path.Combine("improbable", "modular-codegen-tests", "Test.cs");
        private readonly string relativeTemplateOutputPath = Path.Combine("improbable", "modular-codegen-tests", "TemplateTest.cs");

        private readonly string testContent = @"
namespace Improbable.Gdk.ModularCodegenTests 
{
    public class Test
    {

    }
}
";

        public TestCodegenJob(string baseOutputDir, IFileSystem fileSystem, DetailsStore detailsStore) : base(
            baseOutputDir, fileSystem, detailsStore)
        {
            OutputFiles.Add(relativeOutputPath);
            OutputFiles.Add(relativeTemplateOutputPath);
        }

        protected override void RunImpl()
        {
            Content.Add(relativeOutputPath, testContent);
            Content.Add(relativeTemplateOutputPath, new ModularCodegenTestGenerator().Generate());
        }
    }
}
