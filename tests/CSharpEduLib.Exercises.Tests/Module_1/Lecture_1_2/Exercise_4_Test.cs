using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_2
{
    [TestFixture]
    public class Exercise_4_Test
    {
        [Test]
        public void Should_Average_Double()
        {
            string code = @"using System; class Program { static void Main(){ double a=1.0,b=3.0; Console.WriteLine((a+b)/2); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("2", stdout);
        }
    }
}