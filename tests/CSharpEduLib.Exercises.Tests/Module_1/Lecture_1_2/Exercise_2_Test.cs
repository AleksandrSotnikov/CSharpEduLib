using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_2
{
    [TestFixture]
    public class Exercise_2_Test
    {
        [Test]
        public void Should_Rectangle_Area()
        {
            string code = @"using System; class Program { static void Main(){ int w=3,h=4; Console.WriteLine(w*h); } }";
            var (ok, stdout, err) = Runner.Run(code);
            Assert.IsTrue(ok, err);
            StringAssert.Contains("12", stdout);
        }
    }
}