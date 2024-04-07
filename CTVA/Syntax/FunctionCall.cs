using System.Collections.Generic;
using System.Linq;
using BarelyFunctionnal.Analysis;
using CGVA.Analysis;

namespace BarelyFunctionnal.Syntax
{
    public class FunctionCall : Instruction
    {
        public ValueExpression Called { get; }
        public List<ValueExpression> Parameters { get; }

        public FunctionCall(ValueExpression called, List<ValueExpression> parameters)
        {
            Called = called;
            Parameters = parameters;
        }

        public bool Analyse(Environment environement, ClosureTree path)
        {
            var closure = Called.GetValue(environement);
            var currentPath = path.AddChild(closure);

            if (currentPath.HasExtendedParentLoop())
                return false;

            var paras = Parameters.Select(p => p.GetValue(environement)).ToList();
            if (!closure.Analyse(paras, currentPath))
                return false;
            return true;
        }

        public void Compile(List<Name> currentNames)
        {
            Called.Compile(currentNames);
            foreach (var param in Parameters)
                param.Compile(currentNames);
        }

        public override string? ToString()
        {
            return Called.ToString();
        }
    }
}
