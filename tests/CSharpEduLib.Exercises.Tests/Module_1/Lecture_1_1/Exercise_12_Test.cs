using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_1
{
    [TestFixture]
    public class Exercise_12_Test
    {
        [Test]
        public void Should_Convert_C_To_F()
        {
            string code = @"using System; class Program { static void Main(){ double c=0; Console.WriteLine(c*9/5+32); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("32", stdout);
        }
    }
}
