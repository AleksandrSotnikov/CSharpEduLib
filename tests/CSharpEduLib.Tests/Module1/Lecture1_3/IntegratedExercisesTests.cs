using NUnit.Framework;
using System;
using System.IO;
using CSharpEduLib.Runner;
using CSharpEduLib.Runner.Templates;

namespace CSharpEduLib.Tests.Module1.Lecture1_3
{
    [TestFixture]
    public class IntegratedExercisesTests
    {
        private string _tempRoot;
        private ICompilerAdapter _compiler;

        [SetUp]
        public void Setup()
        {
            _tempRoot = Path.Combine(Path.GetTempPath(), "CSharpEduLibTests", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_tempRoot);
            _compiler = new CscCompilerAdapter();
        }

        [TearDown]
        public void Teardown()
        {
            try { Directory.Delete(_tempRoot, true); } catch { }
        }

        [TestCase("int a=int.Parse(Console.ReadLine()); int b=int.Parse(Console.ReadLine()); int c=int.Parse(Console.ReadLine()); Console.WriteLine(a + b * c);", "2\n3\n4", "14")]
        [TestCase("int a=int.Parse(Console.ReadLine()); int b=int.Parse(Console.ReadLine()); int c=int.Parse(Console.ReadLine()); Console.WriteLine((a + b) * c);", "2\n3\n4", "20")]
        [TestCase("int n=int.Parse(Console.ReadLine()); Console.WriteLine(++n); Console.WriteLine(n++); Console.WriteLine(n);", "5", "6\n6\n7")]
        [TestCase("int x=int.Parse(Console.ReadLine()); x+=5; x*=2; x-=4; Console.WriteLine(x);", "10", "26")]
        [TestCase("int p=int.Parse(Console.ReadLine()); p|=1; p|=4; Console.WriteLine(p);", "2", "7")]
        public void Integrated_From_Exercises(string userCode, string input, string expected)
        {
            var code = ConsoleTemplate.Wrap(userCode);
            var src = Path.Combine(_tempRoot, "main.cs");
            File.WriteAllText(src, code);

            var compile = _compiler.Compile(src, _tempRoot);
            Assert.IsTrue(compile.Success, $"Compilation failed: {compile.StdErr}\n{compile.StdOut}");

            var exec = TestExecutor.Run(compile.OutputExePath, input, 5000);
            Assert.IsFalse(exec.TimedOut, "Execution timed out");
            var actual = TestExecutor.Normalize(exec.StdOut);
            Assert.AreEqual(expected, actual);
        }
    }
}
