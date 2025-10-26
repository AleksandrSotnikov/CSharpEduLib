using NUnit.Framework;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_10_CombiningTypes_Tests
    {
        [Test]
        public void ShouldCombineVariousTypes()
        {
            int i = 10; double d = 2.5; string s = $"{i}-{d}";
            Assert.AreEqual("10-2.5", s);
        }
    }
}
