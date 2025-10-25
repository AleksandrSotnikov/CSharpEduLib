using NUnit.Framework;
using System.IO;
using CSharpEduLib.Core.Services;

namespace CSharpEduLib.Core.Tests.Services
{
    [TestFixture]
    public class ContentLoaderTests
    {
        [Test]
        public void LoadLectureExercises_Should_Merge_Main_And_More()
        {
            var tmp = Path.Combine(Path.GetTempPath(), "CSharpEduLib_Test_L1_1");
            Directory.CreateDirectory(tmp);
            File.WriteAllText(Path.Combine(tmp, "Exercises.json"), "[{\"Id\":\"e1\",\"Title\":\"T1\",\"Description\":\"D\",\"MaxScore\":10,\"Difficulty\":1,\"Order\":1}]");
            File.WriteAllText(Path.Combine(tmp, "Exercises.more.json"), "[{\"Id\":\"e2\",\"Title\":\"T2\",\"Description\":\"D\",\"MaxScore\":10,\"Difficulty\":1,\"Order\":2}]");

            var loader = new ContentLoader();
            var items = loader.LoadLectureExercises(tmp);

            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("e1", items[0].Id);
            Assert.AreEqual("e2", items[1].Id);
        }
    }
}
