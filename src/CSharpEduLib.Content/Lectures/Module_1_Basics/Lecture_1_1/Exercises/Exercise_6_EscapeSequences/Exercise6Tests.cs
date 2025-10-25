using System;
using System.IO;
using NUnit.Framework;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_1.Exercises.Exercise_6_EscapeSequences;

namespace CSharpEduLib.Tests.Exercises.Module_1_Basics.Lecture_1_1
{
    [TestFixture]
    public class Exercise6Tests
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
        [Description("Проверяет использование escape-последовательностей")]
        public void StudentSolution_ShouldOutput_EscapeSequences()
        {
            // Arrange - часть escape-sequences из Examples.json
            const string EXPECTED_OUTPUT = "Строка с \"кавычками\"\nСтрока с \\\\обратным слешем\\\\\nСтрока\nс переносом строки\nСтрока\tс табуляцией\n";
            
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