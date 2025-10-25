using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpEduLib.Core.Models;
using CSharpEduLib.Core.Services;
using CSharpEduLib.Core.Utils;

namespace CSharpEduLib.Core.Utils
{
    /// <summary>
    /// Вспомогательные методы и утилиты
    /// </summary>
    public static class Helpers
    {
        public static string FormatExecutionTime(long milliseconds)
        {
            if (milliseconds < 1000)
                return $"{milliseconds} мс";
            
            if (milliseconds < 60000)
                return $"{milliseconds / 1000.0:F2} с";
            
            var minutes = milliseconds / 60000;
            var seconds = (milliseconds % 60000) / 1000.0;
            return $"{minutes} мин {seconds:F2} с";
        }
        
        public static double CalculatePercentage(int value, int total)
        {
            if (total == 0) return 0;
            return (double)value / total * 100;
        }
        
        public static string FormatPercentage(double percentage)
        {
            return $"{percentage:F1}%";
        }
        
        public static string GetGradeByPercentage(double percentage)
        {
            if (percentage >= 90) return "Отлично";
            if (percentage >= 75) return "Хорошо";
            if (percentage >= 60) return "Удовлетворительно";
            if (percentage >= 40) return "Неудовлетворительно";
            return "Низкий уровень";
        }
        
        public static string GetColorByPercentage(double percentage)
        {
            if (percentage >= 90) return "Green";
            if (percentage >= 75) return "LightGreen";
            if (percentage >= 60) return "Yellow";
            if (percentage >= 40) return "Orange";
            return "Red";
        }
        
        public static string GenerateId(string prefix = "id")
        {
            // Заменяем индексный оператор ^ и срезы на совместимые с C# 7.3 конструкции
            var guid = Guid.NewGuid().ToString("N");
            var shortGuid = guid.Substring(0, Math.Min(8, guid.Length));
            return $"{prefix}_{DateTime.Now:yyyyMMdd_HHmmss}_{shortGuid}";
        }
        
        public static string CleanCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return string.Empty;
            
            var lines = code.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(line => line.Trim())
                           .Where(line => !string.IsNullOrEmpty(line))
                           .ToList();
            
            return string.Join(Environment.NewLine, lines);
        }
        
        public static string GetShortErrorDescription(Exception exception)
        {
            if (exception == null) return "Неизвестная ошибка";
            
            var message = exception.Message;
            if (message.Length > 100)
                message = message.Substring(0, 97) + "...";
            
            return $"{exception.GetType().Name}: {message}";
        }
        
        public static bool IsValidCSharpIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                return false;
            
            if (!char.IsLetter(identifier[0]) && identifier[0] != '_')
                return false;
            
            for (int i = 1; i < identifier.Length; i++)
            {
                if (!char.IsLetterOrDigit(identifier[i]) && identifier[i] != '_')
                    return false;
            }
            
            var reservedKeywords = new HashSet<string>
            {
                "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
                "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum",
                "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto",
                "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace",
                "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public",
                "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string",
                "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked",
                "unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
            };
            
            return !reservedKeywords.Contains(identifier.ToLower());
        }
        
        public static Dictionary<string, object> GetTestStatistics(TestResult testResult)
        {
            if (testResult == null)
                return new Dictionary<string, object>();
            
            // Заменяем обращения к несуществующим полям на универсальные
            var total = testResult.TestsTotal;
            var passed = testResult.TestsPassed;
            var successRate = CalculatePercentage(passed, total);
            
            var execTimeMs = (long) (testResult.ExecutionTime.TotalMilliseconds);
            
            return new Dictionary<string, object>
            {
                ["SuccessRate"] = successRate,
                ["Grade"] = GetGradeByPercentage(successRate),
                ["Color"] = GetColorByPercentage(successRate),
                ["FormattedTime"] = FormatExecutionTime(execTimeMs),
                ["HasErrors"] = (testResult.CompilationErrors != null && testResult.CompilationErrors.Any()) ||
                                 (testResult.RuntimeErrors != null && testResult.RuntimeErrors.Any()),
                ["ErrorCount"] = (testResult.CompilationErrors?.Count ?? 0) + (testResult.RuntimeErrors?.Count ?? 0)
            };
        }
    }
}
