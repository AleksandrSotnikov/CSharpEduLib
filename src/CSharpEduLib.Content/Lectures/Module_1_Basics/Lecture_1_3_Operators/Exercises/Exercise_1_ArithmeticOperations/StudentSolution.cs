using System;
using NUnit.Framework;

namespace CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_3_Operators.Exercises.Exercise_1_ArithmeticOperations
{
    /// <summary>
    /// Упражнение 1: Арифметические операции с двумя числами
    /// 
    /// Задача:
    /// Создайте программу, которая выполняет все основные арифметические операции 
    /// (+, -, *, /, %) с двумя заданными числами.
    /// 
    /// Ожидаемый результат:
    /// Программа должна вывести результаты всех арифметических операций для чисел 15 и 4.
    /// 
    /// Подсказка:
    /// - Используйте операторы +, -, *, /, %
    /// - Выводите результаты в консоль с описанием операции
    /// - Обратите внимание на целочисленное деление
    /// </summary>
    public class StudentSolution
    {
        /// <summary>
        /// Метод для выполнения арифметических операций с двумя числами
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Строка с результатами всех операций</returns>
        public static string Run(int a, int b)
        {
            // TODO: Реализуйте выполнение всех арифметических операций
            // Верните строку с результатами в формате:
            // "Сложение: 15 + 4 = 19\nВычитание: 15 - 4 = 11\n..."
            
            throw new NotImplementedException("Упражнение еще не выполнено. Реализуйте арифметические операции.");
        }
    }
    
    [TestFixture]
    public class Exercise1Tests
    {
        [Test]
        public void TestArithmeticOperations_WithPositiveNumbers()
        {
            // Arrange
            int a = 15, b = 4;
            string expected = "Сложение: 15 + 4 = 19\nВычитание: 15 - 4 = 11\nУмножение: 15 * 4 = 60\nДеление: 15 / 4 = 3\nОстаток: 15 % 4 = 3";
            
            // Act & Assert
            Assert.DoesNotThrow(() => StudentSolution.Run(a, b));
            string result = StudentSolution.Run(a, b);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void TestArithmeticOperations_WithDifferentNumbers()
        {
            // Arrange
            int a = 10, b = 3;
            string expected = "Сложение: 10 + 3 = 13\nВычитание: 10 - 3 = 7\nУмножение: 10 * 3 = 30\nДеление: 10 / 3 = 3\nОстаток: 10 % 3 = 1";
            
            // Act
            string result = StudentSolution.Run(a, b);
            
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}