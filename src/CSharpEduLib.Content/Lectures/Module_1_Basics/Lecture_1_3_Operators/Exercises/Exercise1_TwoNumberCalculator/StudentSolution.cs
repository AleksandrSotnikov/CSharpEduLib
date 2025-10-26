using System;

namespace CSharpEduLib.Content.Lectures.Module1.Lecture13.Exercises.Exercise1
{
    /// <summary>
    /// Упражнение 1: Калькулятор двух чисел
    /// Реализуйте операции +, -, *, /, % с обработкой ошибок
    /// </summary>
    public class TwoNumberCalculator
    {
        /// <summary>
        /// Выполняет вычисление для двух целых чисел в зависимости от операции
        /// </summary>
        /// <param name="a">Первый операнд</param>
        /// <param name="b">Второй операнд</param>
        /// <param name="op">Операция: '+', '-', '*', '/', '%'</param>
        /// <returns>Результат вычисления</returns>
        /// <exception cref="DivideByZeroException">При делении на ноль</exception>
        /// <exception cref="ArgumentException">Для неизвестной операции</exception>
        public int Calculate(int a, int b, char op)
        {
            // TODO: Реализуйте согласно требованиям из Exercises.json
            throw new NotImplementedException();
        }
    }
}
