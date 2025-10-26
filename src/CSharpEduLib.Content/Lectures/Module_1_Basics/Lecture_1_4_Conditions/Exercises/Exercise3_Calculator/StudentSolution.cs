using System;

namespace CSharpEduLib.Content.Lectures.Module1.Lecture14.Exercises.Exercise3
{
    /// <summary>
    /// Упражнение 3: Калькулятор
    /// Выполняет арифметические операции на основе символа операции
    /// </summary>
    public class CalculatorExercise
    {
        /// <summary>
        /// Выполняет вычисление на основе двух чисел и операции
        /// </summary>
        /// <param name="num1">Первое число</param>
        /// <param name="num2">Второе число</param>
        /// <param name="operation">Операция (+, -, *, /)</param>
        /// <returns>Результат вычисления</returns>
        public double Calculate(double num1, double num2, char operation)
        {
            // TODO: Реализуйте калькулятор с помощью switch-конструкции
            // Поддерживаемые операции:
            // '+': сложение
            // '-': вычитание
            // '*': умножение
            // '/': деление (при делении на 0 вернуть double.NaN)
            // При неизвестной операции вернуть double.NaN
            
            throw new NotImplementedException("Необходимо реализовать метод Calculate");
        }
        
        /// <summary>
        /// Метод для запуска и тестирования решения
        /// </summary>
        public void Run()
        {
            Console.WriteLine($"Calculate(10, 5, '+'): {Calculate(10, 5, '+')}"); // 15
            Console.WriteLine($"Calculate(10, 3, '-'): {Calculate(10, 3, '-')}"); // 7
            Console.WriteLine($"Calculate(4, 5, '*'): {Calculate(4, 5, '*')}"); // 20
            Console.WriteLine($"Calculate(15, 3, '/'): {Calculate(15, 3, '/')}"); // 5
            Console.WriteLine($"Calculate(10, 0, '/'): {Calculate(10, 0, '/')}"); // NaN
            Console.WriteLine($"Calculate(5, 2, '%'): {Calculate(5, 2, '%')}"); // NaN
        }
    }
}