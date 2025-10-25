using System;
using System.Collections.Generic;
using System.Linq;
using CSharpEduLib.Core.Models;
using CSharpEduLib.Core.Utils;

namespace CSharpEduLib.Core.Services
{
    /// <summary>
    /// Сервис для отслеживания прогресса студента
    /// </summary>
    public class ProgressTracker
    {
        private readonly Dictionary<string, StudentProgress> _studentProgress;
        private readonly JsonLoader _jsonLoader;
        
        public ProgressTracker()
        {
            _studentProgress = new Dictionary<string, StudentProgress>();
            _jsonLoader = new JsonLoader();
        }
        
        /// <summary>
        /// Получить прогресс студента
        /// </summary>
        /// <param name="studentId">Идентификатор студента</param>
        /// <returns>Прогресс студента</returns>
        public StudentProgress GetProgress(string studentId)
        {
            if (!_studentProgress.ContainsKey(studentId))
            {
                _studentProgress[studentId] = new StudentProgress
                {
                    StudentId = studentId,
                    CompletedModules = 0,
                    TotalModules = 6, // По ТЗ
                    CompletedLectures = 0,
                    TotalLectures = 30, // По ТЗ
                    TotalScore = 0,
                    MaxPossibleScore = 0
                };
            }
            
            return _studentProgress[studentId];
        }
        
        /// <summary>
        /// Отметить завершение лекции
        /// </summary>
        /// <param name="studentId">Идентификатор студента</param>
        /// <param name="lecture">Лекция</param>
        public void MarkLectureCompleted(string studentId, Lecture lecture)
        {
            var progress = GetProgress(studentId);
            progress.CompletedLectures++;
            
            // Обновляем прогресс модуля
            if (!progress.ModuleProgress.ContainsKey(lecture.ModuleNumber))
            {
                progress.ModuleProgress[lecture.ModuleNumber] = new ModuleProgress
                {
                    ModuleNumber = lecture.ModuleNumber,
                    ModuleName = $"Модуль {lecture.ModuleNumber}",
                    CompletedLectures = 0,
                    TotalLectures = GetLectureCountForModule(lecture.ModuleNumber),
                    Score = 0,
                    MaxScore = 0
                };
            }
            
            progress.ModuleProgress[lecture.ModuleNumber].CompletedLectures++;
        }
        
        /// <summary>
        /// Обновить скор за выполненное задание
        /// </summary>
        /// <param name="studentId">Идентификатор студента</param>
        /// <param name="moduleNumber">Номер модуля</param>
        /// <param name="score">Полученные баллы</param>
        public void UpdateScore(string studentId, int moduleNumber, int score)
        {
            var progress = GetProgress(studentId);
            progress.TotalScore += score;
            
            if (progress.ModuleProgress.ContainsKey(moduleNumber))
            {
                progress.ModuleProgress[moduleNumber].Score += score;
            }
        }
        
        /// <summary>
        /// Проверить, завершен ли модуль
        /// </summary>
        /// <param name="studentId">Идентификатор студента</param>
        /// <param name="moduleNumber">Номер модуля</param>
        /// <returns>True, если модуль завершен</returns>
        public bool IsModuleCompleted(string studentId, int moduleNumber)
        {
            var progress = GetProgress(studentId);
            return progress.ModuleProgress.ContainsKey(moduleNumber) &&
                   progress.ModuleProgress[moduleNumber].IsCompleted;
        }
        
        /// <summary>
        /// Получить статистику по всем студентам
        /// </summary>
        /// <returns>Общая статистика</returns>
        public Dictionary<string, object> GetOverallStatistics()
        {
            var stats = new Dictionary<string, object>
            {
                ["TotalStudents"] = _studentProgress.Count,
                ["AverageCompletionRate"] = _studentProgress.Values.Average(p => p.CompletionPercentage),
                ["TotalExercisesCompleted"] = _studentProgress.Values.Sum(p => p.CompletedLectures),
                ["AverageScore"] = _studentProgress.Values.Average(p => p.TotalScore)
            };
            
            return stats;
        }
        
        /// <summary>
        /// Сохранить прогресс в файл
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public void SaveProgress(string filePath)
        {
            // TODO: Реализация сохранения в JSON
        }
        
        /// <summary>
        /// Загрузить прогресс из файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public void LoadProgress(string filePath)
        {
            // TODO: Реализация загрузки из JSON
        }
        
        /// <summary>
        /// Получить количество лекций в модуле
        /// </summary>
        /// <param name="moduleNumber">Номер модуля</param>
        /// <returns>Количество лекций</returns>
        private int GetLectureCountForModule(int moduleNumber)
        {
            // TODO: Получать реальное количество из конфигурации
            return 5; // Пока что по умолчанию
        }
    }
}