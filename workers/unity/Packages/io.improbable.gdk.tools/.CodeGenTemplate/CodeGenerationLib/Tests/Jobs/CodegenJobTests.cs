using System;
using System.Collections.Generic;
using System.Linq;
using CodeGeneration.Tests.FileHandling;
using Improbable.Gdk.CodeGeneration.FileHandling;
using Improbable.Gdk.CodeGeneration.Jobs;
using Improbable.Gdk.CodeGeneration.Model;
using Improbable.Gdk.CodeGeneration.Model.Details;
using Improbable.Gdk.CodeGeneration.Tests.Model.SchemaBundleV1;
using NLog;
using NUnit.Framework;

namespace CodeGeneration.Tests.Jobs
{
    [TestFixture]
    public class CodegenJobTests
    {
        [Test]
        public void MarkAsDirty_triggers_override()
        {
            var job = CodegenStub.GetCleanInstance();
            job.MarkAsDirty();

            Assert.IsTrue(job.IsDirty());
        }

        [Test]
        public void IsDirty_returns_true_for_0_input_files()
        {
            var job = CodegenStub.GetCleanInstance();
            job.AddOutputFile("my/filepath", DateTime.Now, true);

            Assert.IsTrue(job.IsDirty());
        }

        [Test]
        public void IsDirty_returns_true_for_0_output_files()
        {
            var job = CodegenStub.GetCleanInstance();
            job.AddInputFile("my/filepath", DateTime.Now);

            Assert.IsTrue(job.IsDirty());
        }

        [Test]
        public void IsDirty_returns_true_if_missing_output_files()
        {
            var job = CodegenStub.GetCleanInstance();
            job.AddInputFile("input/file.schema", DateTime.Now);
            job.AddOutputFile("output/test.cs", DateTime.Now, true);
            job.AddOutputFile("output/test2.cs", DateTime.Now, false);

            Assert.IsTrue(job.IsDirty());
        }

        [Test]
        public void IsDirty_returns_false_if_input_least_recently_changed()
        {
            var job = CodegenStub.GetCleanInstance();
            job.AddInputFile("input/file.schema", DateTime.Now);
            job.AddOutputFile("output/test.cs", DateTime.Now, true);
            job.AddOutputFile("output/test2.cs", DateTime.Now, true);

            Assert.IsFalse(job.IsDirty());
        }

        [Test]
        public void IsDirty_returns_true_if_input_most_recently_changed()
        {
            var job = CodegenStub.GetCleanInstance();
            job.AddOutputFile("output/test.cs", DateTime.Now, true);
            job.AddOutputFile("output/test2.cs", DateTime.Now, true);
            job.AddInputFile("input/file.schema", DateTime.Now);

            Assert.IsTrue(job.IsDirty());
        }

        [Test]
        public void Clean_deletes_all_output_files()
        {
            var job = CodegenStub.GetCleanInstance();
            job.AddOutputFile("output/test.cs", DateTime.Now, true);
            job.AddOutputFile("output/test2.cs", DateTime.Now, true);

            job.Clean();

            var files = job.MyFileSystem.GetFilesInDirectory("output").Cast<MockFile>();

            foreach (var file in files)
            {
                Assert.IsTrue(file.WasDeleted);
            }
        }

        [IgnoreCodegenJob]
        public class CodegenStub : CodegenJob
        {
            public static CodegenStub GetCleanInstance()
            {
                var json = JsonParsingTests.GetBundleContents();
                return new CodegenStub(new CodegenJobOptions("", "", false), new MockFileSystem(), new DetailsStore(SchemaBundle.LoadBundle(json), new List<string>(), new MockFileTree()));
            }

            internal readonly MockFileSystem MyFileSystem;

            public CodegenStub(CodegenJobOptions options, IFileSystem fileSystem, DetailsStore detailsStore)
                : base(options, fileSystem, detailsStore)
            {
                MyFileSystem = (MockFileSystem) fileSystem;
            }

            public void AddInputFile(string path, DateTime timestamp)
            {
                base.AddInputFile(path);
                MyFileSystem.AddFile(path, timestamp);
            }

            public void AddOutputFile(string path, DateTime timestamp, bool shouldExist)
            {
                AddJobTarget(path, () => string.Empty);
                if (shouldExist)
                {
                    MyFileSystem.AddFile(path, timestamp);
                }
            }
        }
    }
}
