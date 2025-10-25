using System;
using System.Collections.Generic;
using System.Linq;
using CSharpEduLib.Core.Models;
using CSharpEduLib.Core.Validators;

namespace CSharpEduLib.Core.Services
{
    /// <summary>
    /// Сервис для работы с практическими заданиями
    /// </summary>
    public class ExerciseService
    {
        private readonly ExerciseValidator _validator;
        private readonly TestExecutor _testExecutor;
        
        public ExerciseService()
        {
            _validator = new ExerciseValidator();
            _testExecutor = new TestExecutor();
        }
        
        /// <summary>
        /// Получить все задания лекции
        /// </summary>
        /// <param name="lecture">Лекция</param>
        /// <returns>Список заданий</returns>
        public List<Exercise> GetExercisesForLecture(Lecture lecture)
        {
            return lecture.Exercises.OrderBy(e => e.Order).ToList();
        }
        
        /// <summary>
        /// Получить задание по ID
        /// </summary>
        /// <param name="exerciseId">Идентификатор задания</param>
        /// <param name="lectures">Список всех лекций</param>
        /// <returns>Задание или null</returns>
        public Exercise GetExerciseById(string exerciseId, List<Lecture> lectures)
        {
            return lectures.SelectMany(l => l.Exercises)
                          .FirstOrDefault(e => e.Id == exerciseId);
        }
        
        /// <summary>
        /// Выполнить задание с проверкой
        /// </summary>
        /// <param name="exercise">Задание</param>
        /// <param name="studentCode">Код студента</param>
        /// <returns>Результат выполнения</returns>
        public TestResult ExecuteExercise(Exercise exercise, string studentCode)
        {
            try
            {
                // Проверяем синтаксис
                var validationResult = _validator.ValidateCode(studentCode);
                if (!validationResult.IsValid)
                {
                    return new TestResult
                    {
                        Success = false,
                        Score = 0,
                        MaxScore = exercise.MaxScore,
                        PassedTests = 0,
                        TotalTests = 1,
                        Errors = validationResult.Errors
                    };
                }
                
                // Выполняем тесты
                return _testExecutor.ExecuteTests(exercise.Id, studentCode);
            }
            catch (Exception ex)
            {
                return new TestResult
                {
                    Success = false,
                    Score = 0,
                    MaxScore = exercise.MaxScore,
                    PassedTests = 0,
                    TotalTests = 1,
                    Errors = new List<string> { ex.Message }
                };
            }
        }
        
        /// <summary>
        /// Получить задания по сложности
        /// </summary>
        /// <param name="lectures">Список лекций</param>
        /// <param name="difficulty">Уровень сложности</param>
        /// <returns>Список заданий</returns>
        public List<Exercise> GetExercisesByDifficulty(List<Lecture> lectures, int difficulty)
        {
            return lectures.SelectMany(l => l.Exercises)
                          .Where(e => e.Difficulty == difficulty)
                          .ToList();
        }
        
        /// <summary>
        /// Получить общее количество заданий
        /// </summary>
        /// <param name="lectures">Список лекций</param>
        /// <returns>Общее количество заданий</returns>
        public int GetTotalExerciseCount(List<Lecture> lectures)
        {
            return lectures.Sum(l => l.Exercises.Count);
        }
        
        /// <summary>
        /// Получить максимально возможный балл
        /// </summary>
        /// <param name="lectures">Список лекций</param>
        /// <returns>Максимальный балл</returns>
        public int GetMaxPossibleScore(List<Lecture> lectures)
        {
            return lectures.Sum(l => l.Exercises.Sum(e => e.MaxScore));
        }
    }
}