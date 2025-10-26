using NUnit.Framework;
using CSharpEduLib.Content.Module1.Lecture12.Exercises;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_8_Defaults_Tests
    {
        [Test]
        public void ShouldHaveDefaultValues()
        {
            var (i, b) = Exercise_8_Defaults.Run();
            Assert.AreEqual(0, i);
            Assert.IsFalse(b);
        }
    }
}
