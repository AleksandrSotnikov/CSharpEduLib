using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_1
{
    [TestFixture]
    public class Exercise_1_Test
    {
        [Test]
        public void Should_Print_Name_And_Surname()
        {
            string studentCode = @"using System; class Program { static void Main(){ Console.WriteLine(\"Ivanov\"); Console.WriteLine(\"Ivan\"); } }";
            var (success, stdout, stderr) = Runner.Run(studentCode);
            Assert.IsTrue(success, $"Compilation/Run failed: {stderr}");
            StringAssert.Contains("Ivanov", stdout);
            StringAssert.Contains("Ivan", stdout);
        }
    }
}