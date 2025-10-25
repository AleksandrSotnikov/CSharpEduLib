using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_1
{
    [TestFixture]
    public class Exercise_2_Test
    {
        [Test]
        public void Should_Print_Sum_2_and_3()
        {
            string studentCode = @"using System; class Program { static void Main(){ Console.WriteLine(2+3); } }";
            var (success, stdout, stderr) = Runner.Run(studentCode);
            Assert.IsTrue(success, $"Compilation/Run failed: {stderr}");
            StringAssert.Contains("5", stdout);
        }
    }
}