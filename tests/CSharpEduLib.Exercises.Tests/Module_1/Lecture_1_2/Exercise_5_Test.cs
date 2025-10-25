using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_2
{
    [TestFixture]
    public class Exercise_5_Test
    {
        [Test]
        public void Should_Format_Output()
        {
            string code = @"using System; class Program { static void Main(){ int n=42; Console.WriteLine($\"Ответ: {n}\"); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("Ответ: 42", stdout);
        }
    }
}