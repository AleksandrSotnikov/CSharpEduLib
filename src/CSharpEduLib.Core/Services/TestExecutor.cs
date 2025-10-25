using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        /// Запустить тесты для упражнения
        /// </summary>
        /// <param name="exercise">Упражнение</param>
        /// <param name="studentCode">Код студента</param>
        /// <returns>Результат выполнения тестов</returns>
        public TestResult RunTests(Exercise exercise, string studentCode)
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
        /// Компиляция кода студента
        /// </summary>
        /// <param name="code">Код для компиляции</param>
        /// <returns>Результат компиляции</returns>
        public CompilationResult CompileCode(string code)
        {
            // Валидация входных параметров
            if (string.IsNullOrWhiteSpace(code))
            {
                return new CompilationResult
                {
                    Success = false,
                    Errors = new List<string> { "Отсутствует исходный код" }
                };
            }
            
            // Проверка на NotImplementedException в коде
            if (code.Contains("NotImplementedException"))
            {
                return new CompilationResult
                {
                    Success = false,
                    Errors = new List<string> { "Код содержит NotImplementedException - необходимо реализовать метод" }
                };
            }
            
            // Заглушка: будущая интеграция с Roslyn
            return new CompilationResult
            {
                Success = false,
                Errors = new List<string> { "Not Implemented: Компиляция кода будет реализована в следующих версиях (работа с Roslyn)" },
                Warnings = new List<string>(),
                CompiledAssemblyPath = null
            };
        }
        
        /// <summary>
        /// Выполнить отдельный тест
        /// </summary>
        /// <param name="testCode">Код теста</param>
        /// <param name="studentCode">Код студента</param>
        /// <returns>Результат выполнения теста</returns>
        public TestCaseResult RunSingleTest(string testCode, string studentCode)
        {
            // Валидация входных параметров
            if (string.IsNullOrWhiteSpace(testCode))
            {
                return new TestCaseResult
                {
                    TestName = "Unknown",
                    Passed = false,
                    ErrorMessage = "Отсутствует код теста",
                    ExecutionTimeMs = 0
                };
            }
            
            if (string.IsNullOrWhiteSpace(studentCode))
            {
                return new TestCaseResult
                {
                    TestName = "Unknown",
                    Passed = false,
                    ErrorMessage = "Отсутствует код студента",
                    ExecutionTimeMs = 0
                };
            }
            
            // Проверка на NotImplementedException
            if (studentCode.Contains("NotImplementedException"))
            {
                return new TestCaseResult
                {
                    TestName = "Implementation Check",
                    Passed = false,
                    ErrorMessage = "Метод не реализован - уберите NotImplementedException и добавьте свою реализацию",
                    ExecutionTimeMs = 0
                };
            }
            
            // Заглушка: будущая интеграция с NUnit и Roslyn
            return new TestCaseResult
            {
                TestName = "SingleTest",
                Passed = false,
                ErrorMessage = "Not Implemented: Запуск отдельного теста будет реализован в следующих версиях (интеграция с NUnit.Engine)",
                ExpectedOutput = string.Empty,
                ActualOutput = string.Empty,
                ExecutionTimeMs = 0
            };
        }
        
        /// <summary>
        /// Проверить синтаксис кода
        /// </summary>
        /// <param name="code">Код для проверки</param>
        /// <returns>Список ошибок синтаксиса</returns>
        public List<SyntaxError> ValidateSyntax(string code)
        {
            var errors = new List<SyntaxError>();
            
            if (string.IsNullOrWhiteSpace(code))
            {
                errors.Add(new SyntaxError
                {
                    LineNumber = 1,
                    ColumnNumber = 1,
                    Message = "Отсутствует код для проверки",
                    Severity = "Error"
                });
                return errors;
            }
            
            // Простые проверки
            if (code.Contains("NotImplementedException"))
            {
                errors.Add(new SyntaxError
                {
                    LineNumber = GetLineNumber(code, "NotImplementedException"),
                    ColumnNumber = 1,
                    Message = "Код содержит NotImplementedException",
                    Severity = "Error"
                });
            }
            
            if (!code.Contains("using System"))
            {
                errors.Add(new SyntaxError
                {
                    LineNumber = 1,
                    ColumnNumber = 1,
                    Message = "Отсутствует 'using System;'",
                    Severity = "Warning"
                });
            }
            
            // Заглушка: будущая интеграция с Roslyn для полной проверки синтаксиса
            
            return errors;
        }
        
        /// <summary>
        /// Получить ошибки времени выполнения
        /// </summary>
        /// <param name="code">Код для анализа</param>
        /// <returns>Список ошибок времени выполнения</returns>
        public List<RuntimeError> GetRuntimeErrors(string code)
        {
            var errors = new List<RuntimeError>();
            
            if (string.IsNullOrWhiteSpace(code))
            {
                errors.Add(new RuntimeError
                {
                    ExceptionType = "ArgumentNullException",
                    Message = "Отсутствует код для анализа",
                    StackTrace = string.Empty,
                    LineNumber = 1
                });
                return errors;
            }
            
            // Проверка на NotImplementedException
            if (code.Contains("NotImplementedException"))
            {
                errors.Add(new RuntimeError
                {
                    ExceptionType = "NotImplementedException",
                    Message = "Метод не реализован",
                    StackTrace = string.Empty,
                    LineNumber = GetLineNumber(code, "NotImplementedException")
                });
            }
            
            // Заглушка: будущая интеграция с Roslyn для статического анализа
            
            return errors;
        }
        
        // Помощники методы (для обратной совместимости)
        
        /// <summary>
        /// Компиляция C# кода (заглушка)
        /// </summary>
        /// <param name="sourceCode">Исходный C# код</param>
        /// <param name="references">Ссылки на сборки</param>
        /// <returns>Результат компиляции</returns>
        [Obsolete("Use CompileCode method instead")]
        public TestResult CompileCode(string sourceCode, string[] references = null)
        {
            var compilationResult = CompileCode(sourceCode);
            
            return new TestResult
            {
                Success = compilationResult.Success,
                Message = compilationResult.Success ? "Компиляция прошла успешно" : "Ошибка компиляции",
                CompilationErrors = compilationResult.Errors,
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
        [Obsolete("This method is deprecated and will be removed in future versions")]
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
        [Obsolete("This method is deprecated and will be removed in future versions")]
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
        [Obsolete("Use RunTests method instead")]
        public TestResult RunExerciseTests(Exercise exercise, string studentCode)
        {
            return RunTests(exercise, studentCode);
        }
        
        /// <summary>
        /// Проверка кода на синтаксис и базовые ошибки (заглушка)
        /// </summary>
        /// <param name="sourceCode">Исходный код</param>
        /// <returns>Результат проверки</returns>
        [Obsolete("Use ValidateSyntax method instead")]
        public TestResult ValidateCode(string sourceCode)
        {
            var syntaxErrors = ValidateSyntax(sourceCode);
            bool success = syntaxErrors.Count == 0;
            
            return new TestResult
            {
                Success = success,
                Message = success ? "Код прошёл базовую проверку" : "Обнаружены проблемы в коде",
                CompilationErrors = syntaxErrors.Where(e => e.Severity == "Error").Select(e => e.Message).ToList(),
                ExecutionTime = TimeSpan.Zero
            };
        }
        
        /// <summary>
        /// Получить номер строки, где находится текст
        /// </summary>
        /// <param name="code">Код для поиска</param>
        /// <param name="searchText">Текст для поиска</param>
        /// <returns>Номер строки (начиная с 1) или 1, если не найдено</returns>
        private static int GetLineNumber(string code, string searchText)
        {
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(searchText))
                return 1;
                
            var lines = code.Split(new[] { '\n', '\r' }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(searchText))
                {
                    return i + 1; // Номер строки начинается с 1
                }
            }
            return 1;
        }
    }
}