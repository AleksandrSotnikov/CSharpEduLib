using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_1
{
    [TestFixture]
    public class Exercise_4_Test
    {
        [Test]
        public void Should_Print_Square()
        {
            string code = @"using System; class Program { static void Main(){ int n = 7; Console.WriteLine(n*n); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("49", stdout);
        }
    }
}
