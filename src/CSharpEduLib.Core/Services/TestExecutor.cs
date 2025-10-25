using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CSharpEduLib.Core.Interfaces;
using CSharpEduLib.Core.Models;

namespace CSharpEduLib.Core.Services
{
    /// <summary>
    /// Сервис для выполнения и тестирования кода (заглушка для будущей интеграции с Roslyn)
    /// </summary>
    public class TestExecutor : ITestExecutor
    {
        /// <summary>
        /// Нормализация переносов строк для кросс-платформенности (общая утилита)
        /// </summary>
        /// <param name="text">Текст для нормализации</param>
        /// <returns>Нормализованный текст с \n переносами</returns>
        public static string NormalizeLineEndings(string text)
        {
            return text?.Replace("\r\n", "\n").Replace("\r", "\n") ?? string.Empty;
        }
        
        /// <summary>
        /// Компиляция C# кода (заглушка)
        /// </summary>
        /// <param name="sourceCode">Исходный C# код</param>
        /// <param name="references">Ссылки на сборки</param>
        /// <returns>Результат компиляции</returns>
        public TestResult CompileCode(string sourceCode, string[] references = null)
        {
            // Валидация входных параметров
            if (string.IsNullOrWhiteSpace(sourceCode))
            {
                return new TestResult
                {
                    Success = false,
                    Message = "Исходный код не может быть пустым",
                    CompilationErrors = new List<string> { "Отсутствует исходный код" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            // Проверка на NotImplementedException в коде
            if (sourceCode.Contains("NotImplementedException"))
            {
                return new TestResult
                {
                    Success = false,
                    Message = "Код содержит NotImplementedException - необходимо реализовать метод",
                    CompilationErrors = new List<string> { "Метод не реализован" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            // Заглушка: будущая интеграция с Roslyn
            return new TestResult
            {
                Success = false,
                Message = "Not Implemented: Компиляция кода будет реализована в следующих версиях (работа с Roslyn)",
                CompilationErrors = new List<string>(),
                ExecutionTime = TimeSpan.Zero
            };
        }
        
        /// <summary>
        /// Запуск скомпилированного кода (заглушка)
        /// </summary>
        /// <param name="compiledAssembly">Скомпилированная сборка</param>
        /// <param name="methodName">Название метода для выполнения</param>
        /// <param name="parameters">Параметры метода</param>
        /// <returns>Результат выполнения</returns>
        public TestResult ExecuteCode(object compiledAssembly, string methodName, object[] parameters = null)
        {
            // Валидация входных параметров
            if (compiledAssembly == null)
            {
                return new TestResult
                {
                    Success = false,
                    Message = "Отсутствует скомпилированная сборка",
                    RuntimeErrors = new List<string> { "Нулевая ссылка на сборку" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            if (string.IsNullOrWhiteSpace(methodName))
            {
                return new TestResult
                {
                    Success = false,
                    Message = "Не указано имя метода для выполнения",
                    RuntimeErrors = new List<string> { "Пустое имя метода" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            // Заглушка: будущая интеграция с Roslyn
            return new TestResult
            {
                Success = false,
                Message = "Not Implemented: Выполнение кода будет реализовано в следующих версиях (работа с Reflection)",
                RuntimeErrors = new List<string>(),
                Output = string.Empty,
                ExecutionTime = TimeSpan.Zero
            };
        }
        
        /// <summary>
        /// Компиляция и запуск в одном методе (заглушка)
        /// </summary>
        /// <param name="sourceCode">Исходный C# код</param>
        /// <param name="methodName">Название метода</param>
        /// <param name="parameters">Параметры</param>
        /// <returns>Результат компиляции и выполнения</returns>
        public TestResult CompileAndExecute(string sourceCode, string methodName, object[] parameters = null)
        {
            // Предварительная проверка
            if (string.IsNullOrWhiteSpace(sourceCode))
            {
                return new TestResult
                {
                    Success = false,
                    Message = "Отсутствует исходный код",
                    CompilationErrors = new List<string> { "Пустой исходный код" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            // Проверка на NotImplementedException
            if (sourceCode.Contains("NotImplementedException"))
            {
                return new TestResult
                {
                    Success = false,
                    Message = "Метод не реализован - уберите NotImplementedException и добавьте свою реализацию",
                    CompilationErrors = new List<string>(),
                    RuntimeErrors = new List<string> { "Найден NotImplementedException" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            // Заглушка: будущая интеграция с Roslyn
            return new TestResult
            {
                Success = false,
                Message = "Not Implemented: Полная компиляция и выполнение будут реализованы в следующих версиях (интеграция с Roslyn Compiler API)",
                CompilationErrors = new List<string>(),
                RuntimeErrors = new List<string>(),
                Output = string.Empty,
                ExecutionTime = TimeSpan.Zero
            };
        }
        
        /// <summary>
        /// Запуск NUnit тестов для конкретного упражнения (заглушка)
        /// </summary>
        /// <param name="exercise">Упражнение для тестирования</param>
        /// <param name="studentCode">Код студента</param>
        /// <returns>Результат тестирования</returns>
        public TestResult RunExerciseTests(Exercise exercise, string studentCode)
        {
            // Валидация входных параметров
            if (exercise == null)
            {
                return new TestResult
                {
                    Success = false,
                    Message = "Отсутствует упражнение для тестирования",
                    RuntimeErrors = new List<string> { "Нулевая ссылка на упражнение" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            if (string.IsNullOrWhiteSpace(studentCode))
            {
                return new TestResult
                {
                    Success = false,
                    Message = "Отсутствует код студента",
                    CompilationErrors = new List<string> { "Пустой код студента" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            // Проверка на NotImplementedException
            if (studentCode.Contains("NotImplementedException"))
            {
                return new TestResult
                {
                    Success = false,
                    Message = $"Упражнение '{exercise.Title}' ещё не реализовано. Уберите NotImplementedException и добавьте свою реализацию.",
                    RuntimeErrors = new List<string> { $"Найден NotImplementedException в {exercise.Id}" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            // Проверка наличия тестового файла
            if (string.IsNullOrWhiteSpace(exercise.TestFile) || !File.Exists(exercise.TestFile))
            {
                return new TestResult
                {
                    Success = false,
                    Message = $"Не найден тестовый файл для упражнения '{exercise.Title}'",
                    RuntimeErrors = new List<string> { $"Отсутствует {exercise.TestFile}" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            // Заглушка: будущая интеграция с NUnit и Roslyn
            return new TestResult
            {
                Success = false,
                Message = $"Not Implemented: Запуск NUnit тестов для '{exercise.Title}' будет реализован в следующих версиях (интеграция с NUnit.Engine)",
                CompilationErrors = new List<string>(),
                RuntimeErrors = new List<string>(),
                Output = string.Empty,
                TestsPassed = 0,
                TestsFailed = 0,
                TestsTotal = 0,
                ExecutionTime = TimeSpan.Zero
            };
        }
        
        /// <summary>
        /// Проверка кода на синтаксис и базовые ошибки (заглушка)
        /// </summary>
        /// <param name="sourceCode">Исходный код</param>
        /// <returns>Результат проверки</returns>
        public TestResult ValidateCode(string sourceCode)
        {
            if (string.IsNullOrWhiteSpace(sourceCode))
            {
                return new TestResult
                {
                    Success = false,
                    Message = "Отсутствует код для проверки",
                    CompilationErrors = new List<string> { "Пустой исходный код" },
                    ExecutionTime = TimeSpan.Zero
                };
            }
            
            // Простые проверки
            var errors = new List<string>();
            
            if (sourceCode.Contains("NotImplementedException"))
            {
                errors.Add("Код содержит NotImplementedException");
            }
            
            if (!sourceCode.Contains("using System"))
            {
                errors.Add("Отсутствует 'using System;'");
            }
            
            bool success = errors.Count == 0;
            
            return new TestResult
            {
                Success = success,
                Message = success ? "Код прошёл базовую проверку" : "Обнаружены проблемы в коде",
                CompilationErrors = errors,
                ExecutionTime = TimeSpan.Zero
            };
        }
    }
}