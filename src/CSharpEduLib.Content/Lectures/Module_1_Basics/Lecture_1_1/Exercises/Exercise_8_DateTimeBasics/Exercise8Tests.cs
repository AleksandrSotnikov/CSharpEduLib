using System;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_1.Exercises.Exercise_8_DateTimeBasics;

namespace CSharpEduLib.Tests.Exercises.Module_1_Basics.Lecture_1_1
{
    [TestFixture]
    public class Exercise8Tests
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
        [Description("Проверяет формат вывода с DateTime - DYNAMIC контент")]
        public void StudentSolution_ShouldOutput_DateTimeInfo()
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
            
            // Проверяем формат даты: dd.MM.yyyy
            var datePattern = @"Сегодня: \d{2}\.\d{2}\.\d{4}";
            Assert.IsTrue(Regex.IsMatch(actualOutput, datePattern), $"Ожидался формат 'Сегодня: dd.MM.yyyy', но получили: {actualOutput}");
            
            // Проверяем день недели
            var dayPattern = @"День недели: (Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday)";
            Assert.IsTrue(Regex.IsMatch(actualOutput, dayPattern), $"Ожидался день недели на английском, но получили: {actualOutput}");
            
            // Проверяем день года (1-366)
            var dayOfYearPattern = @"День года: ([1-9]|[1-9]\d|[12]\d{2}|3[0-5]\d|36[0-6])";
            Assert.IsTrue(Regex.IsMatch(actualOutput, dayOfYearPattern), $"Ожидался день года 1-366, но получили: {actualOutput}");
        }
    }
}