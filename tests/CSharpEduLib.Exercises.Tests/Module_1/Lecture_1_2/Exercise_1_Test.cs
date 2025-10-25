using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_2
{
    [TestFixture]
    public class Exercise_1_Test
    {
        [Test]
        public void Should_Sum_Two_Ints()
        {
            string code = @"using System; class Program { static void Main(){ int a=2,b=3; Console.WriteLine(a+b); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("5", stdout);
        }
    }
}