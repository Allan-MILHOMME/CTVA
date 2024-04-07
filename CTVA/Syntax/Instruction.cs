using System.Collections.Generic;
using BarelyFunctionnal.Analysis;
using CGVA.Analysis;

namespace BarelyFunctionnal.Syntax
{
    public interface Instruction
    {
        public abstract void Compile(List<Name> currentNames);
        public abstract bool Analyse(Environment environement, ClosureTree path);
    }
}
