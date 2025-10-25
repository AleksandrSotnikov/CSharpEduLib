using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_1
{
    [TestFixture]
    public class Exercise_3_Test
    {
        [Test]
        public void Should_Greet_By_Name()
        {
            string code = @"using System; class Program { static void Main(){ var name = \"Alex\"; Console.WriteLine(\"Hi, \"+name+\"!\"); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("Hi, Alex!", stdout);
        }
    }
}
