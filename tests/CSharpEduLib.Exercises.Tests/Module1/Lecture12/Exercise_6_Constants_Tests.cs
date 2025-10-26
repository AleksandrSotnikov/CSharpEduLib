using NUnit.Framework;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_6_Constants_Tests
    {
        [Test]
        public void ShouldHaveConstantPi()
        {
            const double Pi = 3.14159;
            Assert.That(Pi, Is.GreaterThan(3.14).And.LessThan(3.142));
        }
    }
}
