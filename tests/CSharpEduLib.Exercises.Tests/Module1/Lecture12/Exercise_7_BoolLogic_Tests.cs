using NUnit.Framework;
using CSharpEduLib.Content.Module1.Lecture12.Exercises;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_7_BoolLogic_Tests
    {
        [Test]
        public void ShouldEvaluateBoolExpressions()
        {
            Assert.IsTrue(Exercise_7_BoolLogic.Run(true, false));
            Assert.IsFalse(Exercise_7_BoolLogic.Run(false, false));
        }
    }
}
