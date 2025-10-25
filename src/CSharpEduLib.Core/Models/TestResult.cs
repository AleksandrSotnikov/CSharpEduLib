using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEduLib.Core.Models
{
    /// <summary>
    /// Представляет результат выполнения тестов
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// Успешно ли выполнено задание
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// Полученные баллы
        /// </summary>
        public int Score { get; set; }
        
        /// <summary>
        /// Максимально возможные баллы
        /// </summary>
        public int MaxScore { get; set; }
        
        /// <summary>
        /// Количество прошедших тестов
        /// </summary>
        public int PassedTests { get; set; }
        
        /// <summary>
        /// Общее количество тестов
        /// </summary>
        public int TotalTests { get; set; }
        
        /// <summary>
        /// Ошибки, возникшие при выполнении
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
        
        /// <summary>
        /// Детали выполнения тестов
        /// </summary>
        public List<TestDetail> TestDetails { get; set; } = new List<TestDetail>();
        
        /// <summary>
        /// Время выполнения в миллисекундах
        /// </summary>
        public long ExecutionTimeMs { get; set; }
    }
    
    /// <summary>
    /// Детали выполнения отдельного теста
    /// </summary>
    public class TestDetail
    {
        public string TestName { get; set; }
        public bool Passed { get; set; }
        public string ErrorMessage { get; set; }
        public long ExecutionTimeMs { get; set; }
    }
}