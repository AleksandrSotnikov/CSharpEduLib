using System;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_1.Exercises.Exercise_10_RandomNumbers;

namespace CSharpEduLib.Tests.Exercises.Module_1_Basics.Lecture_1_1
{
    [TestFixture]
    public class Exercise10Tests
    {
        private StringWriter _stringWriter;
        private TextWriter _originalConsoleOut;
        
        private static string NormalizeLineEndings(string text)
        {
            return text?.Replace("\r\n", "\n").Replace("\r", "\n") ?? string.Empty;
        }
        
        [SetUp]
        public void SetUp()
        {
            _originalConsoleOut = Console.Out;
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }
        
        [TearDown]
        public void TearDown()
        {
            Console.SetOut(_originalConsoleOut);
            _stringWriter?.Dispose();
        }
        
        [Test]
        [Description("Проверяет формат и диапазоны случайных чисел - DYNAMIC контент")]
        public void StudentSolution_ShouldOutput_RandomNumbers()
        {
            // Act
            try
            {
                StudentSolution.Run();
            }
            catch (NotImplementedException)
            {
                Assert.Fail("Метод еще не реализован");
            }
            
            // Assert - паттерн-матчинг для DYNAMIC контента
            string actualOutput = NormalizeLineEndings(_stringWriter.ToString());
            
            // Проверяем формат случайного числа 0-100
            var randomIntPattern = @"Случайное число \(0-100\): (\d|[1-9]\d|100)";
            Assert.IsTrue(Regex.IsMatch(actualOutput, randomIntPattern), $"Ожидался формат 'Случайное число (0-100): [0-100]', но получили: {actualOutput}");
            
            // Проверяем формат дробного с 3 знаками
            var randomDoublePattern = @"Случайное дробное \(0\.0-1\.0\): 0\.\d{3}";
            Assert.IsTrue(Regex.IsMatch(actualOutput, randomDoublePattern), $"Ожидался формат 'Случайное дробное (0.0-1.0): 0.xxx', но получили: {actualOutput}");
            
            // Проверяем бросок кубика 1-6
            var dicePattern = @"Бросок кубика: [1-6]";
            Assert.IsTrue(Regex.IsMatch(actualOutput, dicePattern), $"Ожидался формат 'Бросок кубика: [1-6]', но получили: {actualOutput}");
            
            // Проверяем пять случайных чисел 1-10
            var fiveNumbersPattern = @"5 случайных чисел: ((?:[1-9]|10)\s){5}";
            Assert.IsTrue(Regex.IsMatch(actualOutput, fiveNumbersPattern), $"Ожидался формат '5 случайных чисел: [1-10] [1-10] [1-10] [1-10] [1-10] ', но получили: {actualOutput}");
        }
    }
}