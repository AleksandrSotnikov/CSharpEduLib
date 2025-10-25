using System;
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
        /// <summary>
        /// Форматировать время выполнения
        /// </summary>
        /// <param name="milliseconds">Миллисекунды</param>
        /// <returns>Отформатированная строка</returns>
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
        
        /// <summary>
        /// Форматировать процент
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="total">Общее значение</param>
        /// <returns>Процент</returns>
        public static double CalculatePercentage(int value, int total)
        {
            if (total == 0) return 0;
            return (double)value / total * 100;
        }
        
        /// <summary>
        /// Форматировать процент как строку
        /// </summary>
        /// <param name="percentage">Процент</param>
        /// <returns>Отформатированная строка</returns>
        public static string FormatPercentage(double percentage)
        {
            return $"{percentage:F1}%";
        }
        
        /// <summary>
        /// Получить оценку по процентам
        /// </summary>
        /// <param name="percentage">Процент выполнения</param>
        /// <returns>Оценка</returns>
        public static string GetGradeByPercentage(double percentage)
        {
            if (percentage >= 90) return "Отлично";
            if (percentage >= 75) return "Хорошо";
            if (percentage >= 60) return "Удовлетворительно";
            if (percentage >= 40) return "Неудовлетворительно";
            return "Низкий уровень";
        }
        
        /// <summary>
        /// Получить цвет по оценке
        /// </summary>
        /// <param name="percentage">Процент</param>
        /// <returns>Название цвета</returns>
        public static string GetColorByPercentage(double percentage)
        {
            if (percentage >= 90) return "Green";
            if (percentage >= 75) return "LightGreen";
            if (percentage >= 60) return "Yellow";
            if (percentage >= 40) return "Orange";
            return "Red";
        }
        
        /// <summary>
        /// Сгенерировать случайный ID
        /// </summary>
        /// <param name="prefix">Префикс</param>
        /// <returns>Уникальный идентификатор</returns>
        public static string GenerateId(string prefix = "id")
        {
            return $"{prefix}_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString("N")[..8]}";
        }
        
        /// <summary>
        /// Очистить код от лишних пробелов и символов
        /// </summary>
        /// <param name="code">Код</param>
        /// <returns>Очищенный код</returns>
        public static string CleanCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return string.Empty;
            
            // Удаляем лишние пробелы и переносы строк
            var lines = code.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(line => line.Trim())
                           .Where(line => !string.IsNullOrEmpty(line))
                           .ToList();
            
            return string.Join(Environment.NewLine, lines);
        }
        
        /// <summary>
        /// Получить краткое описание ошибки
        /// </summary>
        /// <param name="exception">Исключение</param>
        /// <returns>Краткое описание</returns>
        public static string GetShortErrorDescription(Exception exception)
        {
            if (exception == null) return "Неизвестная ошибка";
            
            var message = exception.Message;
            if (message.Length > 100)
                message = message.Substring(0, 97) + "...";
            
            return $"{exception.GetType().Name}: {message}";
        }
        
        /// <summary>
        /// Проверить, является ли строка валидным идентификатором C#
        /// </summary>
        /// <param name="identifier">Идентификатор</param>
        /// <returns>True, если валидный</returns>
        public static bool IsValidCSharpIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                return false;
            
            // Проверяем первый символ
            if (!char.IsLetter(identifier[0]) && identifier[0] != '_')
                return false;
            
            // Проверяем остальные символы
            for (int i = 1; i < identifier.Length; i++)
            {
                if (!char.IsLetterOrDigit(identifier[i]) && identifier[i] != '_')
                    return false;
            }
            
            // Проверяем, не является ли зарезервированным словом
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
        
        /// <summary>
        /// Получить статистику по тестам
        /// </summary>
        /// <param name="testResult">Результат теста</param>
        /// <returns>Статистика</returns>
        public static Dictionary<string, object> GetTestStatistics(TestResult testResult)
        {
            if (testResult == null)
                return new Dictionary<string, object>();
            
            var successRate = CalculatePercentage(testResult.PassedTests, testResult.TotalTests);
            var scoreRate = CalculatePercentage(testResult.Score, testResult.MaxScore);
            
            return new Dictionary<string, object>
            {
                ["SuccessRate"] = successRate,
                ["ScoreRate"] = scoreRate,
                ["Grade"] = GetGradeByPercentage(scoreRate),
                ["Color"] = GetColorByPercentage(scoreRate),
                ["FormattedTime"] = FormatExecutionTime(testResult.ExecutionTimeMs),
                ["HasErrors"] = testResult.Errors.Any(),
                ["ErrorCount"] = testResult.Errors.Count
            };
        }
    }
}