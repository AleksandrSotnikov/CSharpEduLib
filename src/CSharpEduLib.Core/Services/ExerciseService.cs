using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpEduLib.Core.Interfaces;
using CSharpEduLib.Core.Models;
using CSharpEduLib.Core.Utils;

namespace CSharpEduLib.Core.Services
{
    /// <summary>
    /// Сервис для управления упражнениями с поддержкой связи с лекциями
    /// </summary>
    public class ExerciseService : IExerciseService
    {
        private readonly string _contentPath;
        private readonly IJsonLoader _jsonLoader;
        private List<Exercise> _exercises;
        private readonly object _lockObject = new object();
        
        public ExerciseService(string contentPath, IJsonLoader jsonLoader)
        {
            _contentPath = contentPath ?? throw new ArgumentNullException(nameof(contentPath));
            _jsonLoader = jsonLoader ?? throw new ArgumentNullException(nameof(jsonLoader));
            _exercises = new List<Exercise>();
            
            LoadExercises();
        }
        
        /// <summary>
        /// Получить упражнение по идентификатору
        /// </summary>
        public Exercise GetExerciseById(string exerciseId)
        {
            if (string.IsNullOrWhiteSpace(exerciseId))
                throw new ArgumentException("Идентификатор упражнения не может быть пустым", nameof(exerciseId));
            
            lock (_lockObject)
            {
                return _exercises.FirstOrDefault(e => e.Id.Equals(exerciseId, StringComparison.OrdinalIgnoreCase));
            }
        }
        
        /// <summary>
        /// Получить все упражнения для конкретной лекции
        /// </summary>
        public List<Exercise> GetLectureExercises(string lectureId)
        {
            if (string.IsNullOrWhiteSpace(lectureId))
                throw new ArgumentException("Идентификатор лекции не может быть пустым", nameof(lectureId));
            
            lock (_lockObject)
            {
                return _exercises.Where(e => e.LectureId.Equals(lectureId, StringComparison.OrdinalIgnoreCase))
                              .OrderBy(e => e.OrderIndex)
                              .ToList();
            }
        }
        
        /// <summary>
        /// Получить все упражнения для конкретного модуля
        /// </summary>
        public List<Exercise> GetModuleExercises(string moduleId)
        {
            if (string.IsNullOrWhiteSpace(moduleId))
                throw new ArgumentException("Идентификатор модуля не может быть пустым", nameof(moduleId));
            
            lock (_lockObject)
            {
                return _exercises.Where(e => e.LectureId.StartsWith($"{moduleId}_", StringComparison.OrdinalIgnoreCase))
                              .OrderBy(e => e.LectureId)
                              .ThenBy(e => e.OrderIndex)
                              .ToList();
            }
        }
        
        /// <summary>
        /// Выполнить упражнение и получить результат
        /// </summary>
        public TestResult ExecuteExercise(Exercise exercise, string studentCode)
        {
            if (exercise == null)
                throw new ArgumentNullException(nameof(exercise));
            if (string.IsNullOrWhiteSpace(studentCode))
                throw new ArgumentException("Код студента не может быть пустым", nameof(studentCode));
            
            // Заглушка для выполнения упражнения
            return new TestResult
            {
                IsSuccess = true,
                Message = "Упражнение выполнено успешно",
                Details = $"Код для упражнения '{exercise.Title}' принят",
                ExecutionTime = TimeSpan.FromSeconds(1)
            };
        }
        
        /// <summary>
        /// Проверить решение упражнения
        /// </summary>
        public TestResult ValidateSolution(string exerciseId, string solution)
        {
            if (string.IsNullOrWhiteSpace(exerciseId))
                throw new ArgumentException("Идентификатор упражнения не может быть пустым", nameof(exerciseId));
            if (string.IsNullOrWhiteSpace(solution))
                throw new ArgumentException("Решение не может быть пустым", nameof(solution));
            
            var exercise = GetExerciseById(exerciseId);
            if (exercise == null)
            {
                return new TestResult
                {
                    IsSuccess = false,
                    Message = $"Упражнение с ID '{exerciseId}' не найдено",
                    Details = "Проверьте правильность идентификатора упражнения"
                };
            }
            
            return ExecuteExercise(exercise, solution);
        }
        
        /// <summary>
        /// Получить все упражнения
        /// </summary>
        public List<Exercise> GetAllExercises()
        {
            lock (_lockObject)
            {
                return _exercises.OrderBy(e => e.LectureId)
                              .ThenBy(e => e.OrderIndex)
                              .ToList();
            }
        }
        
        /// <summary>
        /// Перезагрузить все упражнения
        /// </summary>
        public bool ReloadExercises()
        {
            try
            {
                LoadExercises();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ExerciseService] Ошибка при перезагрузке упражнений: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Получить количество упражнений
        /// </summary>
        public int GetExerciseCount()
        {
            lock (_lockObject)
            {
                return _exercises.Count;
            }
        }
        
        private void LoadExercises()
        {
            var newExercises = new List<Exercise>();
            
            if (!Directory.Exists(_contentPath))
            {
                Directory.CreateDirectory(_contentPath);
                return;
            }
            
            // Проходим по всем модулям
            var moduleDirectories = Directory.GetDirectories(_contentPath, "Module_*", SearchOption.TopDirectoryOnly);
            
            foreach (var moduleDir in moduleDirectories)
            {
                var moduleId = Path.GetFileName(moduleDir);
                var lectureDirectories = Directory.GetDirectories(moduleDir, "Lecture_*", SearchOption.TopDirectoryOnly);
                
                foreach (var lectureDir in lectureDirectories)
                {
                    var lectureName = Path.GetFileName(lectureDir);
                    var lectureId = $"{moduleId}_{lectureName}";
                    var exercisesDir = Path.Combine(lectureDir, "Exercises");
                    
                    if (Directory.Exists(exercisesDir))
                    {
                        try
                        {
                            var exercisesForLecture = LoadExercisesFromDirectory(exercisesDir, lectureId);
                            newExercises.AddRange(exercisesForLecture);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[ExerciseService] Ошибка при загрузке упражнений для лекции '{lectureId}': {ex.Message}");
                        }
                    }
                }
            }
            
            lock (_lockObject)
            {
                _exercises = newExercises;
            }
        }
        
        private List<Exercise> LoadExercisesFromDirectory(string exercisesDirectory, string lectureId)
        {
            var exercises = new List<Exercise>();
            
            // Получаем все папки Exercise_*
            var exerciseDirectories = Directory.GetDirectories(exercisesDirectory, "Exercise_*", SearchOption.TopDirectoryOnly);
            
            foreach (var exerciseDir in exerciseDirectories)
            {
                try
                {
                    var exercise = LoadSingleExercise(exerciseDir, lectureId);
                    if (exercise != null)
                    {
                        exercises.Add(exercise);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ExerciseService] Ошибка при загрузке упражнения '{exerciseDir}': {ex.Message}");
                }
            }
            
            return exercises;
        }
        
        private Exercise LoadSingleExercise(string exerciseDirectory, string lectureId)
        {
            var exerciseName = Path.GetFileName(exerciseDirectory);
            var studentSolutionFile = Path.Combine(exerciseDirectory, "StudentSolution.cs");
            
            if (!File.Exists(studentSolutionFile))
            {
                Console.WriteLine($"[ExerciseService] Не найден StudentSolution.cs в '{exerciseDirectory}'");
                return null;
            }
            
            // Извлекаем номер из имени (Exercise_1_HelloWorld -> 1)
            var orderIndex = ExtractOrderFromExerciseName(exerciseName);
            var exerciseId = $"{lectureId}_{exerciseName}";
            
            // Пытаемся извлечь метаданные из комментариев StudentSolution.cs
            var (title, description) = ExtractMetadataFromFile(studentSolutionFile);
            
            var exercise = new Exercise
            {
                Id = exerciseId,
                LectureId = lectureId,
                Title = title ?? exerciseName.Replace("_", " "),
                Description = description ?? $"Упражнение {exerciseName}",
                OrderIndex = orderIndex,
                Type = "CodeExercise", // По умолчанию все упражнения - кодовые
                Difficulty = "Beginner", // По умолчанию все упражнения уровня Beginner
                SolutionTemplate = File.ReadAllText(studentSolutionFile),
                TestFile = Path.Combine(exerciseDirectory, $"Exercise{orderIndex}Tests.cs")
            };
            
            return exercise;
        }
        
        private int ExtractOrderFromExerciseName(string exerciseName)
        {
            try
            {
                // Exercise_1_HelloWorld -> 1
                var parts = exerciseName.Split('_');
                if (parts.Length >= 2 && int.TryParse(parts[1], out int order))
                {
                    return order;
                }
            }
            catch
            {
                // Игнорируем ошибки
            }
            
            return 0;
        }
        
        private (string title, string description) ExtractMetadataFromFile(string filePath)
        {
            try
            {
                var content = File.ReadAllText(filePath);
                string title = null;
                string description = null;
                
                // Простой парсинг XML-комментариев
                var lines = content.Split('\n');
                bool inSummary = false;
                var summaryLines = new List<string>();
                
                foreach (var line in lines)
                {
                    var trimmed = line.Trim();
                    if (trimmed.StartsWith("/// <summary>"))
                    {
                        inSummary = true;
                        continue;
                    }
                    if (trimmed.StartsWith("/// </summary>"))
                    {
                        inSummary = false;
                        break;
                    }
                    if (inSummary && trimmed.StartsWith("/// "))
                    {
                        var commentText = trimmed.Substring(4).Trim();
                        if (!string.IsNullOrWhiteSpace(commentText))
                        {
                            summaryLines.Add(commentText);
                        }
                    }
                }
                
                if (summaryLines.Count > 0)
                {
                    // Первая строка - заголовок, остальные - описание
                    title = summaryLines[0];
                    if (summaryLines.Count > 1)
                    {
                        description = string.Join(" ", summaryLines.Skip(1));
                    }
                }
                
                return (title, description);
            }
            catch
            {
                return (null, null);
            }
        }
    }
}