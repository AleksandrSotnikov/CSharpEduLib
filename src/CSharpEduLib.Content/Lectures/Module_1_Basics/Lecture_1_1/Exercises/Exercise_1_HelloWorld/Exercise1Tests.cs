using System;
using System.IO;
using NUnit.Framework;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_1.Exercises.Exercise_1_HelloWorld;

namespace CSharpEduLib.Tests.Exercises.Module_1_Basics.Lecture_1_1
{
    /// <summary>
    /// NUnit тесты для Упражнения 1: Hello World
    /// 
    /// Проверяет точность вывода на консоль с нормализацией переносов строк
    /// </summary>
    [TestFixture]
    public class Exercise1Tests
    {
        private StringWriter _stringWriter;
        private TextWriter _originalConsoleOut;
        
        /// <summary>
        /// Нормализация переносов строк для кросс-платформенности
        /// </summary>
        private static string NormalizeLineEndings(string text)
        {
            return text?.Replace("\r\n", "\n").Replace("\r", "\n") ?? string.Empty;
        }
        
        [SetUp]
        public void SetUp()
        {
            // Сохраняем оригинальный Console.Out
            _originalConsoleOut = Console.Out;
            
            // Перенаправляем вывод на StringWriter
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }
        
        [TearDown]
        public void TearDown()
        {
            // Восстанавливаем оригинальный Console.Out
            Console.SetOut(_originalConsoleOut);
            _stringWriter?.Dispose();
        }
        
        /// <summary>
        /// Проверка точного соответствия вывода эталонному результату из Examples.json
        /// </summary>
        [Test]
        [Description("Проверяет, что программа выводит 'Привет, мир!' на консоль")]
        public void StudentSolution_ShouldOutput_HelloWorldMessage()
        {
            // Arrange
            const string EXPECTED_OUTPUT = "Привет, мир!\n"; // Точный OLD_STR из Examples.json
            
            // Act
            try
            {
                StudentSolution.Run();
            }
            catch (NotImplementedException)
            {
                Assert.Fail("Метод StudentSolution.Run() еще не реализован. Уберите NotImplementedException и добавьте свою реализацию.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Неожиданная ошибка: {ex.Message}");
            }
            
            // Assert
            string actualOutput = _stringWriter.ToString();
            string normalizedActual = NormalizeLineEndings(actualOutput);
            string normalizedExpected = NormalizeLineEndings(EXPECTED_OUTPUT);
            
            Assert.AreEqual(
                normalizedExpected,
                normalizedActual,
                $"Ожидался: '{EXPECTED_OUTPUT.Replace("\n", "\\n")}', а получили: '{actualOutput.Replace("\n", "\\n")}'"
            );
        }
        
        /// <summary>
        /// Проверка, что метод не выбрасывает исключение после реализации
        /// </summary>
        [Test]
        [Description("Проверяет, что метод выполняется без ошибок")]
        public void StudentSolution_ShouldRun_WithoutExceptions()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => {
                try 
                {
                    StudentSolution.Run();
                }
                catch (NotImplementedException)
                {
                    // NotImplementedException ожидаем, пока метод не реализован
                    throw; // Перебрасываем для внешнего обработчика
                }
            }, "Метод StudentSolution.Run() должен выполняться без ошибок после реализации");
        }
    }
}
