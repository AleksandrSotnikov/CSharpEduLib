using System;
using System.IO;
using NUnit.Framework;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_1.Exercises.Exercise_7_Constants;

namespace CSharpEduLib.Tests.Exercises.Module_1_Basics.Lecture_1_1
{
    [TestFixture]
    public class Exercise7Tests
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
        [Description("Проверяет использование констант")]
        public void StudentSolution_ShouldOutput_Constants()
        {
            // Arrange - соответствует constants из Examples.json
            const string EXPECTED_OUTPUT = "Добро пожаловать!\nРадиус: 5\nПлощадь круга: 78.54\nМаксимум пользователей: 100\n";
            
            // Act
            try
            {
                StudentSolution.Run();
            }
            catch (NotImplementedException)
            {
                Assert.Fail("Метод еще не реализован");
            }
            
            // Assert
            string actualOutput = _stringWriter.ToString();
            string normalizedActual = NormalizeLineEndings(actualOutput);
            string normalizedExpected = NormalizeLineEndings(EXPECTED_OUTPUT);
            
            Assert.AreEqual(normalizedExpected, normalizedActual);
        }
    }
}