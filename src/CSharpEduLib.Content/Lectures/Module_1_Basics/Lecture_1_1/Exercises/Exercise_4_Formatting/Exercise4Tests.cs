using System;
using System.IO;
using NUnit.Framework;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_1.Exercises.Exercise_4_Formatting;

namespace CSharpEduLib.Tests.Exercises.Module_1_Basics.Lecture_1_1
{
    [TestFixture]
    public class Exercise4Tests
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
        [Description("Проверяет различные способы форматирования")]
        public void StudentSolution_ShouldOutput_FormattedStrings()
        {
            // Arrange - соответствует formatting-output из Examples.json
            const string EXPECTED_OUTPUT = "Pi = 3.14159265358979\nPi с 2 знаками: 3.14\nЧисло в шестнадцатеричном: 2A\nЧисло с заполнением нулями: 00042\nPi = 3.142\nПроцент: 75.00 %\n";
            
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