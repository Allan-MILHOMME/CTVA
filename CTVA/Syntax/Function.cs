﻿using System.Collections.Generic;
using System.Linq;
using CGVA.Analysis;

namespace BarelyFunctionnal.Syntax
{
    public class Function : ValueExpression
    {
        public static Function Empty { get; } = new(new(), new());

        public List<Name> ParametersNames { get; }
        public List<Instruction> Instructions { get; }

        public Function(List<Name> parametersNames, List<Instruction> instructions)
        {
            ParametersNames = parametersNames;
            Instructions = instructions;
        }

        public void Compile(List<Name> currentNames)
        {
            var nameList = currentNames.Concat(ParametersNames).ToList();

            foreach (var instruction in Instructions)
                instruction.Compile(nameList);
        }

        public Closure GetValue(Environment stack)
        {
            return new Closure(stack, this);
        }

        public Dictionary<Name, Closure> ParametersToDictionary(List<Closure> parameters)
        {
            var paras = new Dictionary<Name, Closure>();
            for (var i = 0; i < ParametersNames.Count; i++)
            {
                if (parameters.Count > i)
                    paras[ParametersNames[i]] = parameters[i];
                else
                    paras[ParametersNames[i]] = Closure.Empty;
            }
            return paras;
        }
    }
}
