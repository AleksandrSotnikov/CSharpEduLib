using NUnit.Framework;
using CSharpEduLib.Content.Module1.Lecture12.Exercises;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_9_Overflow_Tests
    {
        [Test]
        public void ShouldOverflowInUnchecked()
        {
            int wrap = Exercise_9_Overflow.Run();
            Assert.Less(wrap, 0);
        }
    }
}
