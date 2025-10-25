using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_1
{
    [TestFixture]
    public class Exercise_11_Test
    {
        [Test]
        public void Should_Increment()
        {
            string code = @"using System; class Program { static void Main(){ int n=99; Console.WriteLine(n+1); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("100", stdout);
        }
    }
}
