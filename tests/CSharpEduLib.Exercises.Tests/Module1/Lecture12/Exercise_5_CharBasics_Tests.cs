using NUnit.Framework;
using CSharpEduLib.Content.Module1.Lecture12.Exercises;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_5_CharBasics_Tests
    {
        [Test]
        public void ShouldMapCharFromCode()
        {
            var c = Exercise_5_CharBasics.Run(65);
            Assert.AreEqual('A', c);
        }
    }
}
