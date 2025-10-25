using System.Collections.Generic;
using CSharpEduLib.Core.Models;

namespace CSharpEduLib.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для выполнения и проверки тестов
    /// </summary>
    public interface ITestExecutor
    {
        /// <summary>
        /// Запустить тесты для упражнения
        /// </summary>
        /// <param name="exercise">Упражнение</param>
        /// <param name="studentCode">Код студента</param>
        /// <returns>Результат выполнения тестов</returns>
        TestResult RunTests(Exercise exercise, string studentCode);
        
        /// <summary>
        /// Компиляция кода студента
        /// </summary>
        /// <param name="code">Код для компиляции</param>
        /// <returns>Результат компиляции</returns>
        CompilationResult CompileCode(string code);
        
        /// <summary>
        /// Выполнить отдельный тест
        /// </summary>
        /// <param name="testCode">Код теста</param>
        /// <param name="studentCode">Код студента</param>
        /// <returns>Результат выполнения теста</returns>
        TestCaseResult RunSingleTest(string testCode, string studentCode);
        
        /// <summary>
        /// Проверить синтаксис кода
        /// </summary>
        /// <param name="code">Код для проверки</param>
        /// <returns>Список ошибок синтаксиса</returns>
        List<SyntaxError> ValidateSyntax(string code);
        
        /// <summary>
        /// Получить ошибки времени выполнения
        /// </summary>
        /// <param name="code">Код для анализа</param>
        /// <returns>Список ошибок времени выполнения</returns>
        List<RuntimeError> GetRuntimeErrors(string code);
    }
    
    /// <summary>
    /// Результат компиляции
    /// </summary>
    public class CompilationResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public List<string> Warnings { get; set; } = new List<string>();
        public string CompiledAssemblyPath { get; set; }
    }
    
    /// <summary>
    /// Результат выполнения отдельного теста
    /// </summary>
    public class TestCaseResult
    {
        public string TestName { get; set; }
        public bool Passed { get; set; }
        public string ErrorMessage { get; set; }
        public string ExpectedOutput { get; set; }
        public string ActualOutput { get; set; }
        public double ExecutionTimeMs { get; set; }
    }
    
    /// <summary>
    /// Ошибка синтаксиса
    /// </summary>
    public class SyntaxError
    {
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; } // Error, Warning, Info
    }
    
    /// <summary>
    /// Ошибка времени выполнения
    /// </summary>
    public class RuntimeError
    {
        public string ExceptionType { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public int LineNumber { get; set; }
    }
}