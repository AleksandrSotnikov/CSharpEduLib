using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSharpEduLib.Core.Validators
{
    /// <summary>
    /// Валидатор для проверки кода C#
    /// </summary>
    public class CodeValidator
    {
        private readonly List<string> _forbiddenKeywords;
        private readonly List<string> _requiredUsings;
        
        public CodeValidator()
        {
            _forbiddenKeywords = new List<string>
            {
                "unsafe", "fixed", "goto"
            };
            
            _requiredUsings = new List<string>
            {
                "using System;"
            };
        }
        
        /// <summary>
        /// Провалидировать код на основные ошибки
        /// </summary>
        /// <param name="code">Код для проверки</param>
        /// <returns>Результат валидации</returns>
        public ValidationResult ValidateCode(string code)
        {
            var result = new ValidationResult
            {
                IsValid = true,
                Errors = new List<string>(),
                Warnings = new List<string>()
            };
            
            if (string.IsNullOrWhiteSpace(code))
            {
                result.IsValid = false;
                result.Errors.Add("Код не может быть пустым");
                return result;
            }
            
            // Проверка на запрещенные ключевые слова
            CheckForbiddenKeywords(code, result);
            
            // Проверка синтаксиса скобок
            CheckBracketSyntax(code, result);
            
            // Проверка наличия using директив
            CheckRequiredUsings(code, result);
            
            // Проверка наличия метода Main
            CheckMainMethod(code, result);
            
            return result;
        }
        
        /// <summary>
        /// Проверить наличие запрещенных ключевых слов
        /// </summary>
        private void CheckForbiddenKeywords(string code, ValidationResult result)
        {
            foreach (var keyword in _forbiddenKeywords)
            {
                if (code.Contains(keyword))
                {
                    result.Warnings.Add($"Использование '{keyword}' не рекомендуется для начинающих");
                }
            }
        }
        
        /// <summary>
        /// Проверить синтаксис скобок
        /// </summary>
        private void CheckBracketSyntax(string code, ValidationResult result)
        {
            int curlyBrackets = 0;
            int roundBrackets = 0;
            int squareBrackets = 0;
            
            foreach (char c in code)
            {
                switch (c)
                {
                    case '{':
                        curlyBrackets++;
                        break;
                    case '}':
                        curlyBrackets--;
                        if (curlyBrackets < 0)
                        {
                            result.IsValid = false;
                            result.Errors.Add("Непарная фигурная скобка '}'");
                        }
                        break;
                    case '(':
                        roundBrackets++;
                        break;
                    case ')':
                        roundBrackets--;
                        if (roundBrackets < 0)
                        {
                            result.IsValid = false;
                            result.Errors.Add("Непарная круглая скобка ')'");
                        }
                        break;
                    case '[':
                        squareBrackets++;
                        break;
                    case ']':
                        squareBrackets--;
                        if (squareBrackets < 0)
                        {
                            result.IsValid = false;
                            result.Errors.Add("Непарная квадратная скобка ']'");
                        }
                        break;
                }
            }
            
            if (curlyBrackets != 0)
            {
                result.IsValid = false;
                result.Errors.Add("Непарные фигурные скобки");
            }
            
            if (roundBrackets != 0)
            {
                result.IsValid = false;
                result.Errors.Add("Непарные круглые скобки");
            }
            
            if (squareBrackets != 0)
            {
                result.IsValid = false;
                result.Errors.Add("Непарные квадратные скобки");
            }
        }
        
        /// <summary>
        /// Проверить наличие обязательных using директив
        /// </summary>
        private void CheckRequiredUsings(string code, ValidationResult result)
        {
            foreach (var usingDirective in _requiredUsings)
            {
                if (!code.Contains(usingDirective))
                {
                    result.Warnings.Add($"Рекомендуется добавить '{usingDirective}'");
                }
            }
        }
        
        /// <summary>
        /// Проверить наличие метода Main
        /// </summary>
        private void CheckMainMethod(string code, ValidationResult result)
        {
            var mainMethodPattern = @"(static\s+void\s+Main\s*\()|(static\s+int\s+Main\s*\()";
            if (!Regex.IsMatch(code, mainMethodPattern))
            {
                result.Warnings.Add("Метод Main не обнаружен. Программа может не запуститься.");
            }
        }
    }
    
    /// <summary>
    /// Результат валидации кода
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Прошла ли валидация успешно
        /// </summary>
        public bool IsValid { get; set; }
        
        /// <summary>
        /// Ошибки валидации
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
        
        /// <summary>
        /// Предупреждения
        /// </summary>
        public List<string> Warnings { get; set; } = new List<string>();
    }
}