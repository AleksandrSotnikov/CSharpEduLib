using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpEduLib.Core.Models;
using CSharpEduLib.Core.Services;

namespace CSharpEduLib.Samples
{
    /// <summary>
    /// Пример использования CSharpEduLib
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в CSharpEduLib!");
            Console.WriteLine("Комплексная библиотека для изучения C# с нуля.");
            Console.WriteLine();
            
            try
            {
                // Пример создания лекции
                DemoCreateLecture();
                
                Console.WriteLine();
                
                // Пример создания задания
                DemoCreateExercise();
                
                Console.WriteLine();
                
                // Пример использования сервисов
                DemoServices();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        
        /// <summary>
        /// Пример создания лекции
        /// </summary>
        static void DemoCreateLecture()
        {
            Console.WriteLine("=== Пример создания лекции ===");
            
            var lecture = new Lecture
            {
                Id = "module-1-lecture-1",
                Title = "Введение в C#",
                Description = "Основы языка программирования C#",
                ModuleNumber = 1,
                LectureNumber = 1,
                TheoryContent = "C# - это современный язык программирования, разработанный компанией Microsoft.",
                EstimatedMinutes = 45
            };
            
            // Добавляем пример кода
            lecture.Examples.Add(new CodeExample
            {
                Id = "example-1",
                Title = "Привет, мир!",
                Description = "Первая программа на C#",
                Code = "using System;\nclass Program\n{\n    static void Main()\n    {\n        Console.WriteLine(\"Hello, World!\");\n    }\n}",
                ExpectedOutput = "Hello, World!",
                Order = 1
            });
            
            // Добавляем задание
            lecture.Exercises.Add(new Exercise
            {
                Id = "exercise-1",
                Title = "Создайте программу приветствия",
                Description = "Напишите программу, которая выводит приветствие на экран",
                Requirements = "Используйте Console.WriteLine() для вывода текста",
                Example = "Console.WriteLine(\"Hello, World!\");",
                MaxScore = 10,
                Difficulty = 1,
                Order = 1
            });
            
            Console.WriteLine($"Лекция создана: {lecture.Title}");
            Console.WriteLine($"Модуль: {lecture.ModuleNumber}, Лекция: {lecture.LectureNumber}");
            Console.WriteLine($"Количество примеров: {lecture.Examples.Count}");
            Console.WriteLine($"Количество заданий: {lecture.Exercises.Count}");
        }
        
        /// <summary>
        /// Пример создания задания
        /// </summary>
        static void DemoCreateExercise()
        {
            Console.WriteLine("=== Пример создания задания ===");
            
            var exercise = new Exercise
            {
                Id = "variables-exercise-1",
                Title = "Работа с переменными",
                Description = "Создайте переменные разных типов и выведите их на экран",
                Requirements = "Используйте int, string, bool и double",
                Example = "int number = 42;\nstring text = \"Hello\";\nbool flag = true;",
                MaxScore = 15,
                Difficulty = 2,
                Order = 1
            };
            
            // Добавляем подсказки
            exercise.Hints.Add("Начните с объявления целого числа");
            exercise.Hints.Add("Используйте кавычки для строковых литералов");
            exercise.Hints.Add("Булевы значения: true или false");
            
            Console.WriteLine($"Задание создано: {exercise.Title}");
            Console.WriteLine($"Максимальные баллы: {exercise.MaxScore}");
            Console.WriteLine($"Сложность: {exercise.Difficulty}/5");
            Console.WriteLine($"Количество подсказок: {exercise.Hints.Count}");
        }
        
        /// <summary>
        /// Пример использования сервисов
        /// </summary>
        static void DemoServices()
        {
            Console.WriteLine("=== Пример использования сервисов ===");
            
            // Создаем сервисы
            var lectureService = new LectureService();
            var exerciseService = new ExerciseService();
            var progressTracker = new ProgressTracker();
            
            Console.WriteLine("Сервисы инициализированы:");
            Console.WriteLine($"- LectureService: Общее количество лекций: {lectureService.GetTotalLectureCount()}");
            Console.WriteLine($"- LectureService: Общее количество модулей: {lectureService.GetTotalModuleCount()}");
            
            // Пример работы с прогрессом
            string studentId = "student-123";
            var progress = progressTracker.GetProgress(studentId);
            
            Console.WriteLine($"Прогресс студента {studentId}:");
            Console.WriteLine($"- Завершено лекций: {progress.CompletedLectures}/{progress.TotalLectures}");
            Console.WriteLine($"- Процент завершения: {progress.CompletionPercentage:F1}%");
            Console.WriteLine($"- Общий балл: {progress.TotalScore}");
            
            // Пример выполнения тестов
            var testExecutor = new TestExecutor();
            var testResult = testExecutor.ExecuteTests("test-exercise", "Console.WriteLine(\"Test\");");
            
            Console.WriteLine("Результат тестирования:");
            Console.WriteLine($"- Успешно: {(testResult.Success ? "Да" : "Нет")}");
            Console.WriteLine($"- Прошло тестов: {testResult.PassedTests}/{testResult.TotalTests}");
            Console.WriteLine($"- Балл: {testResult.Score}/{testResult.MaxScore}");
            Console.WriteLine($"- Время выполнения: {testResult.ExecutionTimeMs} мс");
        }
    }
}