using NUnit.Framework;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_7_BoolLogic_Tests
    {
        [Test]
        public void ShouldEvaluateBoolExpressions()
        {
            bool a = true, b = false;
            Assert.IsTrue(a && !b);
        }
    }
}
