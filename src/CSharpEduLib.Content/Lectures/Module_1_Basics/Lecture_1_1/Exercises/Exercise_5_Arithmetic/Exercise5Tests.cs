using System;
using System.IO;
using NUnit.Framework;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_1.Exercises.Exercise_5_Arithmetic;

namespace CSharpEduLib.Tests.Exercises.Module_1_Basics.Lecture_1_1
{
    [TestFixture]
    public class Exercise5Tests
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
        [Description("Проверяет арифметические операции")]
        public void StudentSolution_ShouldOutput_ArithmeticOperations()
        {
            // Arrange - соответствует arithmetic-operations из Examples.json
            const string EXPECTED_OUTPUT = "10 + 5 = 15\n10 - 5 = 5\n10 * 5 = 50\n10 / 5 = 2\n";
            
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