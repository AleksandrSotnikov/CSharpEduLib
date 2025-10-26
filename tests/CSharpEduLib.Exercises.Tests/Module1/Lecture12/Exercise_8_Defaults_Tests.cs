using NUnit.Framework;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_8_Defaults_Tests
    {
        [Test]
        public void ShouldHaveDefaultValues()
        {
            int i = default;
            bool b = default;
            Assert.AreEqual(0, i);
            Assert.IsFalse(b);
        }
    }
}
