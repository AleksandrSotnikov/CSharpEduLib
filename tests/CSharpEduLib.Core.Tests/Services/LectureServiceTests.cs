using NUnit.Framework;

namespace CSharpEduLib.Core.Tests.Services
{
    [TestFixture]
    public class LectureServiceTests
    {
        [Test]
        public void GetTotalLectureCount_Should_Return_Zero_When_Empty()
        {
            var service = new CSharpEduLib.Core.Services.LectureService();
            Assert.AreEqual(0, service.GetTotalLectureCount());
        }
    }
}