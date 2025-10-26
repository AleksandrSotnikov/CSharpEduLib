using NUnit.Framework;
using CSharpEduLib.Content.Module1.Lecture12.Exercises;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Exercise_3_ParseTryParse_Tests
    {
        [TestCase("10","5", ExpectedResult=15)]
        [TestCase("abc","5", ExpectedResult=5)]
        [TestCase("","", ExpectedResult=0)]
        public int ShouldParseAndTryParse(string a, string b)
        {
            return Exercise_3_ParseTryParse.Run(a, b);
        }
    }
}
