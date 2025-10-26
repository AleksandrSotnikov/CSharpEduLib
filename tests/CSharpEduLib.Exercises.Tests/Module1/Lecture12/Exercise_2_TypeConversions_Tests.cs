using NUnit.Framework;
using CSharpEduLib.Content.Module1.Lecture12.Exercises;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_2_TypeConversions_Tests
    {
        [Test]
        public void ShouldConvertTypesCorrectly()
        {
            var (implicitDouble, explicitInt) = Exercise_2_TypeConversions.Run();
            Assert.AreEqual(42d, implicitDouble);
            Assert.AreEqual(42, explicitInt);
        }
    }
}
