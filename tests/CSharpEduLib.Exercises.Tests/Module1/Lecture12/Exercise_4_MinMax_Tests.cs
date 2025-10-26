using NUnit.Framework;
using System.Globalization;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_4_MinMax_Tests
    {
        [Test]
        public void ShouldExposeCorrectMinMaxForIntAndLong()
        {
            // TODO: заменить на реальные вызовы решений
            Assert.That(int.MinValue, Is.LessThan(0));
            Assert.That(long.MaxValue, Is.GreaterThan(0));
        }
    }
}
