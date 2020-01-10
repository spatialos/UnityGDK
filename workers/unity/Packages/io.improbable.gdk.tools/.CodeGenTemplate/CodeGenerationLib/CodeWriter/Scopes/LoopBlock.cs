using System;

namespace Improbable.Gdk.CodeGeneration.CodeWriter.Scopes
{
    /// <summary>
    /// Scope with mandatory declaration for defining loops.
    /// </summary>
    public class LoopBlock : ScopeBody
    {
        internal LoopBlock(string declaration, Action<LoopBlock> populate) : base(declaration)
        {
            populate(this);
        }

        public void Continue()
        {
            WriteLine("continue;");
        }

        public void Break()
        {
            WriteLine("break;");
        }
    }
}