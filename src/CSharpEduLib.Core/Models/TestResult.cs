using System;
using System.Collections.Generic;

namespace CSharpEduLib.Core.Models
{
    /// <summary>
    /// Представляет результат выполнения тестов (расширен для совместимости с сервисами)
    /// </summary>
    public class TestResult
    {
        // Старые поля (сохраняем для обратной совместимости)
        public bool Success { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public int PassedTests { get; set; }
        public int TotalTests { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public List<TestDetail> TestDetails { get; set; } = new List<TestDetail>();
        public long ExecutionTimeMs { get; set; }

        // Новые поля, ожидаемые сервисами
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public List<string> CompilationErrors { get; set; } = new List<string>();
        public List<string> RuntimeErrors { get; set; } = new List<string>();
        public string Output { get; set; }
        public int TestsPassed { get; set; }
        public int TestsFailed { get; set; }
        public int TestsTotal { get; set; }
    }
    
    public class TestDetail
    {
        public string TestName { get; set; }
        public bool Passed { get; set; }
        public string ErrorMessage { get; set; }
        public long ExecutionTimeMs { get; set; }
    }
}
