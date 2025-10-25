using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_1
{
    [TestFixture]
    public class Exercise_10_Test
    {
        [Test]
        public void Should_Print_Quoted_String()
        {
            string code = @"using System; class Program { static void Main(){ Console.WriteLine(\"\\\"C#\\\"\"); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("\"C#\"", stdout);
        }
    }
}
