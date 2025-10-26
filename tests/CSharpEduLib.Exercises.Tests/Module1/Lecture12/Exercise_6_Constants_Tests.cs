using NUnit.Framework;
using CSharpEduLib.Content.Module1.Lecture12.Exercises;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_6_Constants_Tests
    {
        [Test]
        public void ShouldHaveConstantPi()
        {
            Assert.That(Exercise_6_Constants.Run(), Is.GreaterThan(3.14).And.LessThan(3.142));
        }
    }
}
