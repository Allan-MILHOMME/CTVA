using System;
using System.Collections.Generic;
using System.IO;
using BarelyFunctionnal.Syntax;
using CGVA.Analysis;
using Environment = CGVA.Analysis.Environment;

namespace BarelyFunctionnal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = GetProgram(args);
            var analysisResult = program.Analyse(new(), new(program));
            Console.WriteLine("Analysis result : " + (analysisResult ? "Will terminate" : "Can never terminate"));
        }

        public static Closure GetProgram(params string[] args)
        {
            var names = new List<Name>();
            var functions = new List<Function>();
            var instructions = new List<Instruction>();
            foreach (var arg in args)
            {
                var program = File.ReadAllText(arg);
                var function = Parser.Parse(program);
                functions.Add(function);
                function.Compile(names);
                names.AddRange(function.ParametersNames);
                instructions.AddRange(function.Instructions);
            }

            var mergedFunction = new Function(names, instructions);
            var environment = Environment.Empty;
            return new Closure(environment, mergedFunction);
        }
    }
}
