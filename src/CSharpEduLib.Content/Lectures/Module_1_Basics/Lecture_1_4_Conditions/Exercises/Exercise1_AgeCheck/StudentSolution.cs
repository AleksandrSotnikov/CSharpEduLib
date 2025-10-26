using System;

namespace CSharpEduLib.Content.Lectures.Module1.Lecture14.Exercises.Exercise1
{
    /// <summary>
    /// Упражнение 1: Проверка возраста
    /// Определяет, является ли человек совершеннолетним
    /// </summary>
    public class AgeCheckExercise
    {
        /// <summary>
        /// Проверяет возраст и возвращает соответствующее сообщение
        /// </summary>
        /// <param name="age">Возраст для проверки</param>
        /// <returns>Статус совершеннолетия</returns>
        public string CheckAge(int age)
        {
            // TODO: Реализуйте логику проверки возраста
            // Если возраст < 0, верните "Некорректный возраст"
            // Если возраст >= 18, верните "Совершеннолетний"
            // Иначе верните "Несовершеннолетний"
            
            throw new NotImplementedException("Необходимо реализовать метод CheckAge");
        }
        
        /// <summary>
        /// Метод для запуска и тестирования решения
        /// </summary>
        public void Run()
        {
            // Примеры для тестирования
            Console.WriteLine($"CheckAge(25): {CheckAge(25)}"); // Ожидаем: Совершеннолетний
            Console.WriteLine($"CheckAge(16): {CheckAge(16)}"); // Ожидаем: Несовершеннолетний
            Console.WriteLine($"CheckAge(-5): {CheckAge(-5)}"); // Ожидаем: Некорректный возраст
            Console.WriteLine($"CheckAge(18): {CheckAge(18)}"); // Ожидаем: Совершеннолетний
        }
    }
}