using System.Collections.Generic;
using BarelyFunctionnal.Analysis;
using CGVA.Analysis;

namespace BarelyFunctionnal.Syntax
{
    public class Assignment : Instruction
    {
        public Name Name { get; }
        public ValueExpression Value { get; }

        public Assignment(Name name, ValueExpression value)
        {
            Name = name;
            Value = value;
        }

        public bool Analyse(Environment environement, ClosureTree path)
        {
            path.Children.Add(null);
            Execute(environement);
            return true;
        }

        public void Compile(List<Name> currentNames)
        {
            Name.Compile(currentNames);
            Value.Compile(currentNames);
        }

        public void Execute(Environment stack)
        {
            stack[Name] = Value.GetValue(stack);
        }
    }
}
