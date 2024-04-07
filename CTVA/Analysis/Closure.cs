using System.Collections.Generic;
using BarelyFunctionnal.Analysis;
using BarelyFunctionnal.Syntax;

namespace CGVA.Analysis
{
    public class Closure
    {
        public static Closure Empty { get; } = new(new(new(), null), Function.Empty);

        public Environment Environment { get; }
        public Function Function { get; }

        public Closure(Environment env, Function function)
        {
            Environment = env;
            Function = function;
        }

        public bool Analyse(List<Closure> parameters, ClosureTree path)
        {
            var paras = Function.ParametersToDictionary(parameters);
            var newEnv = new Environment(paras, Environment);

            foreach (var inst in Function.Instructions)
                if (!inst.Analyse(newEnv, path))
                    return false;

            return true;
        }
    }
}
