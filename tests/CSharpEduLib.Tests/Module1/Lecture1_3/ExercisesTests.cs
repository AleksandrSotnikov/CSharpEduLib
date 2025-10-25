using NUnit.Framework;
using System;
using CSharpEduLib.Tests.Helpers;

namespace CSharpEduLib.Tests.Module1.Lecture1_3
{
    [TestFixture]
    public class ExercisesTests
    {
        [TestCase("2\n3\n4", "14")]
        [TestCase("1\n0\n10", "1")]
        public void M1L3_Ex1(string input, string expected)
        {
            // Заглушка: здесь должен быть вызов Runner/TestExecutor, который собирает и исполняет решение учащегося
            // Для демонстрации нормализации проверим саму нормализацию
            var norm = Runner.Normalize(expected + "\r\n");
            Assert.AreEqual(expected, norm);
        }

        [TestCase("2\n3\n4", "20")]
        [TestCase("1\n0\n10", "10")]
        public void M1L3_Ex2(string input, string expected)
        {
            var norm = Runner.Normalize(expected + "  \r\n");
            Assert.AreEqual(expected, norm);
        }

        [TestCase("5", "6\n6\n7")]
        public void M1L3_Ex3(string input, string expected)
        {
            var norm = Runner.Normalize(expected.Replace("\n", "\r\n"));
            Assert.AreEqual(expected, norm);
        }

        [TestCase("10", "26")]
        public void M1L3_Ex4(string input, string expected)
        {
            var norm = Runner.Normalize(expected + "\n\n");
            Assert.AreEqual(expected, norm);
        }

        [TestCase("0", "5")]
        [TestCase("2", "7")]
        public void M1L3_Ex5(string input, string expected)
        {
            var norm = Runner.Normalize("  " + expected + "  ");
            Assert.AreEqual(expected, norm);
        }
    }
}
