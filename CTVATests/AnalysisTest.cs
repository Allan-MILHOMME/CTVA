using BarelyFunctionnal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarelyFunctionnalUnitTest
{
    [TestClass]
    public class AnalysisTest
    {
        [TestMethod]
        public void TestFibonacciLoop()
        {
            TestProgram(true, "tests/natural.bf", "tests/fibonacciLoops.bf");
        }

        [TestMethod]
        public void TestFibonacciTerminates()
        {
            TestProgram(true, "tests/natural.bf", "tests/fibonacciTerminates.bf");
        }

        [TestMethod]
        public void TestSimpleLoop()
        {
            TestProgram(false, "tests/simpleLoop.bf");
        }

        [TestMethod]
        public void TestRotation()
        {
            TestProgram(false, "tests/rotation.bf");
        }

        [TestMethod]
        public void TestTranslation()
        {
            TestProgram(true, "tests/translation.bf");
        }

        [TestMethod]
        public void TestSubtract()
        {
            TestProgram(true, "tests/natural.bf", "tests/subtract.bf");
        }

        public void TestProgram(bool doesProgramTerminate, params string[] args)
        {
            var program = Program.GetProgram(args);
            var result = program.Analyse([], new(program));
            Assert.AreEqual(result, doesProgramTerminate);
        }
    }
}