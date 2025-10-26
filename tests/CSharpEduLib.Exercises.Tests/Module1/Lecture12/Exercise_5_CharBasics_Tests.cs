using NUnit.Framework;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_5_CharBasics_Tests
    {
        [Test]
        public void ShouldMapCharFromCode()
        {
            char c = (char)65;
            Assert.AreEqual('A', c);
        }
    }
}
