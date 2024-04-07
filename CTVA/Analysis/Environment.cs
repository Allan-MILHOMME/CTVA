using System.Collections.Generic;
using BarelyFunctionnal.Syntax;

namespace CGVA.Analysis
{
    public class Environment
    {
        public static Environment Empty { get; } = new(new(), null);
        public Dictionary<Name, Closure> Values { get; }
        public Environment? ParentEnvironment { get; }

        public Environment(Dictionary<Name, Closure> values, Environment? parentEnvironment)
        {
            Values = values;
            ParentEnvironment = parentEnvironment;
        }

        public Closure this[Name name]
        {
            get
            {
                if (Values.TryGetValue(name, out var value))
                    return value;
                return ParentEnvironment![name];
            }
            set
            {
                if (Values.ContainsKey(name))
                    Values[name] = value;
                else
                    ParentEnvironment![name] = value;
            }
        }
    }
}
