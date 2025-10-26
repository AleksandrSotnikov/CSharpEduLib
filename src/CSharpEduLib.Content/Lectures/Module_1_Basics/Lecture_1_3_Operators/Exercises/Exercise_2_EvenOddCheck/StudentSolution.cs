using System;
using NUnit.Framework;

namespace CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_3_Operators.Exercises.Exercise_2_EvenOddCheck
{
    /// <summary>
    /// Упражнение 2: Определение четности числа
    /// 
    /// Задача:
    /// Напишите программу, которая проверяет, является ли число четным или нечетным,
    /// используя оператор остатка от деления (%).
    /// 
    /// Ожидаемый результат:
    /// Программа должна возвращать true, если число четное, и false, если нечетное.
    /// 
    /// Подсказка:
    /// - Четное число делится на 2 без остатка
    /// - Используйте оператор % (остаток от деления)
    /// - Сравните результат с 0
    /// </summary>
    public class StudentSolution
    {
        /// <summary>
        /// Метод для проверки четности числа
        /// </summary>
        /// <param name="number">Число для проверки</param>
        /// <returns>true, если число четное; false, если нечетное</returns>
        public static bool Run(int number)
        {
            // TODO: Реализуйте проверку четности числа
            // Используйте оператор % для получения остатка от деления на 2
            // Верните true, если остаток равен 0, иначе false
            
            throw new NotImplementedException("Упражнение еще не выполнено. Реализуйте проверку четности.");
        }
        
        /// <summary>
        /// Дополнительный метод: возвращает строковое описание четности
        /// </summary>
        /// <param name="number">Число для проверки</param>
        /// <returns>Строка "четное" или "нечетное"</returns>
        public static string GetEvenOddDescription(int number)
        {
            // TODO: Реализуйте метод, который возвращает описание четности
            // Используйте метод Run() и верните соответствующую строку
            
            throw new NotImplementedException("Упражнение еще не выполнено. Реализуйте описание четности.");
        }
    }
    
    [TestFixture]
    public class Exercise2Tests
    {
        [Test]
        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(10, true)]
        [TestCase(0, true)]
        public void TestEvenNumbers_ReturnsTrue(int number, bool expected)
        {
            // Act
            bool result = StudentSolution.Run(number);
            
            // Assert
            Assert.AreEqual(expected, result, $"Число {number} должно быть четным");
        }
        
        [Test]
        [TestCase(1, false)]
        [TestCase(3, false)]
        [TestCase(7, false)]
        [TestCase(15, false)]
        public void TestOddNumbers_ReturnsFalse(int number, bool expected)
        {
            // Act
            bool result = StudentSolution.Run(number);
            
            // Assert
            Assert.AreEqual(expected, result, $"Число {number} должно быть нечетным");
        }
        
        [Test]
        [TestCase(-2, true)]
        [TestCase(-1, false)]
        [TestCase(-10, true)]
        [TestCase(-7, false)]
        public void TestNegativeNumbers_WorksCorrectly(int number, bool expected)
        {
            // Act
            bool result = StudentSolution.Run(number);
            
            // Assert
            Assert.AreEqual(expected, result, $"Отрицательное число {number} обработано неверно");
        }
        
        [Test]
        [TestCase(4, "четное")]
        [TestCase(7, "нечетное")]
        [TestCase(0, "четное")]
        [TestCase(-3, "нечетное")]
        public void TestEvenOddDescription_ReturnsCorrectString(int number, string expected)
        {
            // Act
            string result = StudentSolution.GetEvenOddDescription(number);
            
            // Assert
            Assert.AreEqual(expected, result, $"Описание для числа {number} должно быть '{expected}'");
        }
    }
}