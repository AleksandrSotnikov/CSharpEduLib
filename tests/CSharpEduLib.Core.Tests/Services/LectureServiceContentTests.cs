using NUnit.Framework;
using System.IO;
using CSharpEduLib.Core.Services;

namespace CSharpEduLib.Core.Tests.Services
{
    [TestFixture]
    public class LectureServiceContentTests
    {
        [Test]
        public void LoadLectureFromDirectory_Should_Populate_Theory_Examples_Exercises()
        {
            var tmp = Path.Combine(Path.GetTempPath(), "CSharpEduLib_Test_Lect");
            Directory.CreateDirectory(tmp);
            File.WriteAllText(Path.Combine(tmp, "Theory.md"), "# Theory");
            File.WriteAllText(Path.Combine(tmp, "CodeExamples.md"), "```csharp\nConsole.WriteLine(\"Hello\");\n```");
            File.WriteAllText(Path.Combine(tmp, "Exercises.json"), "[{\"Id\":\"e1\",\"Title\":\"T1\",\"Description\":\"D\",\"MaxScore\":10,\"Difficulty\":1,\"Order\":1}]");

            var svc = new LectureService();
            var lecture = svc.LoadLectureFromDirectory(tmp, 1, 1);

            Assert.IsNotNull(lecture);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(lecture.TheoryContent));
            Assert.IsTrue(lecture.Examples.Count > 0);
            Assert.AreEqual(1, lecture.Exercises.Count);
        }
    }
}
