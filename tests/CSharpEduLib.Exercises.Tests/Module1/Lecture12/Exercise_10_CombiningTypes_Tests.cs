using NUnit.Framework;
using CSharpEduLib.Content.Module1.Lecture12.Exercises;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_10_CombiningTypes_Tests
    {
        [Test]
        public void ShouldCombineVariousTypes()
        {
            var s = Exercise_10_CombiningTypes.Run(10, 2.5);
            Assert.AreEqual("10-2.5", s);
        }
    }
}
