using System;
using System.Collections.Generic;
using CGVA.Analysis;
using Environment = CGVA.Analysis.Environment;

namespace BarelyFunctionnal.Syntax
{
    public class Name : ValueExpression
    {
        public string Value { get; }

        public Name(string value)
        {
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Name name &&
                   Value == name.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }

        public void Compile(List<Name> currentNames)
        {
            if (!currentNames.Contains(this))
                throw new Exception("Unknown name : " + Value);
        }

        public Closure GetValue(Environment stack)
        {
            return stack[this];
        }
    }
}
