using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_2
{
    [TestFixture]
    public class Exercise_3_Test
    {
        [Test]
        public void Should_Use_TryParse()
        {
            string code = @"using System; class Program { static void Main(){ string s=\"x\"; if(int.TryParse(s,out var n)) Console.WriteLine(n); else Console.WriteLine(\"error\"); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("error", stdout);
        }
    }
}