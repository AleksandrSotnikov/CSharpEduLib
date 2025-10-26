using NUnit.Framework;
using CSharpEduLib.Content.Module1.Lecture12.Exercises;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_1_DeclaringVariables_Tests
    {
        [Test]
        public void ShouldDeclareBasicTypes()
        {
            var result = Exercise_1_DeclaringVariables.Run();
            Assert.IsTrue(result.StartsWith("10|3.14|text|True|A"));
        }
    }
}
