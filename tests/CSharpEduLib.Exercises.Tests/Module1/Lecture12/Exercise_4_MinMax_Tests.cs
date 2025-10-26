using NUnit.Framework;
using CSharpEduLib.Content.Module1.Lecture12.Exercises;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_4_MinMax_Tests
    {
        [Test]
        public void ShouldExposeCorrectMinMaxForIntAndLong()
        {
            var (imin, imax, lmin, lmax) = Exercise_4_MinMax.Run();
            Assert.AreEqual(int.MinValue, imin);
            Assert.AreEqual(int.MaxValue, imax);
            Assert.AreEqual(long.MinValue, lmin);
            Assert.AreEqual(long.MaxValue, lmax);
        }
    }
}
