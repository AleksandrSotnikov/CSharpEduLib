using System;
using System.Collections.Generic;
using CSharpEduLib.Core.Models;

namespace CSharpEduLib.Core.Validators
{
    /// <summary>
    /// Валидатор для проверки заданий
    /// </summary>
    public class ExerciseValidator
    {
        /// <summary>
        /// Провалидировать задание
        /// </summary>
        /// <param name="exercise">Задание</param>
        /// <returns>Результат валидации</returns>
        public ValidationResult ValidateExercise(Exercise exercise)
        {
            var result = new ValidationResult
            {
                IsValid = true,
                Errors = new List<string>(),
                Warnings = new List<string>()
            };
            
            if (exercise == null)
            {
                result.IsValid = false;
                result.Errors.Add("Задание не может быть null");
                return result;
            }
            
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(exercise.Id))
            {
                result.IsValid = false;
                result.Errors.Add("Идентификатор задания обязателен");
            }
            
            if (string.IsNullOrWhiteSpace(exercise.Title))
            {
                result.IsValid = false;
                result.Errors.Add("Название задания обязательно");
            }
            
            if (string.IsNullOrWhiteSpace(exercise.Description))
            {
                result.IsValid = false;
                result.Errors.Add("Описание задания обязательно");
            }
            
            // Проверка сложности
            if (exercise.Difficulty < 1 || exercise.Difficulty > 5)
            {
                result.IsValid = false;
                result.Errors.Add("Сложность должна быть от 1 до 5");
            }
            
            // Проверка максимального балла
            if (exercise.MaxScore <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("Максимальный балл должен быть больше 0");
            }
            
            // Проверка порядкового номера
            if (exercise.Order < 0)
            {
                result.IsValid = false;
                result.Errors.Add("Порядковый номер не может быть отрицательным");
            }
            
            // Проверка подсказок
            if (exercise.Hints != null && exercise.Hints.Count > 5)
            {
                result.Warnings.Add("Большое количество подсказок может упростить задание");
            }
            
            return result;
        }
        
        /// <summary>
        /// Провалидировать код студента
        /// </summary>
        /// <param name="code">Код студента</param>
        /// <returns>Результат валидации</returns>
        public ValidationResult ValidateCode(string code)
        {
            var codeValidator = new CodeValidator();
            return codeValidator.ValidateCode(code);
        }
    }
}