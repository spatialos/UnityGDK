using System.Collections.Generic;
using System.Linq;
using Improbable.Gdk.CodeGeneration;
using Improbable.Gdk.CodeGeneration.Model.Details;
using NLog;

namespace Improbable.Gdk.CodeGenerator
{
    public partial class CommandDiffStorageGenerator
    {
        private string qualifiedNamespace;
        private UnityComponentDetails details;

        private Logger logger = LogManager.GetCurrentClassLogger();

        public string Generate(UnityComponentDetails details, string package)
        {
            qualifiedNamespace = package;
            this.details = details;

            return TransformText();
        }

        private UnityComponentDetails GetComponentDetails()
        {
            return details;
        }

        private IReadOnlyList<UnityCommandDetails> GetCommandDetailsList()
        {
            return details.CommandDetails;
        }
    }
}
