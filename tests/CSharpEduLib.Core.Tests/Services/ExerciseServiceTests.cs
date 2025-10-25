using NUnit.Framework;

namespace CSharpEduLib.Core.Tests.Services
{
    [TestFixture]
    public class ExerciseServiceTests
    {
        [Test]
        public void GetTotalExerciseCount_Should_Be_Zero_For_Empty()
        {
            var service = new CSharpEduLib.Core.Services.ExerciseService();
            var count = service.GetTotalExerciseCount(new System.Collections.Generic.List<CSharpEduLib.Core.Models.Lecture>());
            Assert.AreEqual(0, count);
        }
    }
}