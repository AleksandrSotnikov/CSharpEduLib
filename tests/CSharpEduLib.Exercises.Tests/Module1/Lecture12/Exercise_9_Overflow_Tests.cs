using NUnit.Framework;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_9_Overflow_Tests
    {
        [Test]
        public void ShouldOverflowInUnchecked()
        {
            unchecked
            {
                int max = int.MaxValue;
                int wrap = max + 1;
                Assert.Less(wrap, 0);
            }
        }
    }
}
