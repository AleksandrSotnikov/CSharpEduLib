using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_1
{
    [TestFixture]
    public class Exercise_6_Test
    {
        [Test]
        public void Should_Concat_Strings()
        {
            string code = @"using System; class Program { static void Main(){ string a=\"Hello\", b=\"C#\"; Console.WriteLine(a+\" \"+b); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("Hello C#", stdout);
        }
    }
}
