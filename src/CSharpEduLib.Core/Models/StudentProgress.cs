using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEduLib.Core.Models
{
    /// <summary>
    /// Представляет прогресс студента
    /// </summary>
    public class StudentProgress
    {
        /// <summary>
        /// Идентификатор студента
        /// </summary>
        public string StudentId { get; set; }
        
        /// <summary>
        /// Количество завершенных модулей
        /// </summary>
        public int CompletedModules { get; set; }
        
        /// <summary>
        /// Общее количество модулей
        /// </summary>
        public int TotalModules { get; set; }
        
        /// <summary>
        /// Количество завершенных лекций
        /// </summary>
        public int CompletedLectures { get; set; }
        
        /// <summary>
        /// Общее количество лекций
        /// </summary>
        public int TotalLectures { get; set; }
        
        /// <summary>
        /// Общий набранный балл
        /// </summary>
        public int TotalScore { get; set; }
        
        /// <summary>
        /// Максимально возможный балл
        /// </summary>
        public int MaxPossibleScore { get; set; }
        
        /// <summary>
        /// Процент завершения
        /// </summary>
        public double CompletionPercentage
        {
            get
            {
                return TotalLectures > 0 ? (double)CompletedLectures / TotalLectures * 100 : 0;
            }
        }
        
        /// <summary>
        /// Прогресс по каждому модулю
        /// </summary>
        public Dictionary<int, ModuleProgress> ModuleProgress { get; set; } = new Dictionary<int, ModuleProgress>();
        
        /// <summary>
        /// Получить рекомендации по изучению
        /// </summary>
        /// <returns>Список рекомендаций</returns>
        public List<Recommendation> GetRecommendations()
        {
            // TODO: Реализация логики рекомендаций
            return new List<Recommendation>();
        }
        
        /// <summary>
        /// Получить слабые области
        /// </summary>
        /// <returns>Список слабых областей</returns>
        public List<WeakArea> GetWeakAreas()
        {
            // TODO: Реализация логики определения слабых областей
            return new List<WeakArea>();
        }
    }
    
    /// <summary>
    /// Прогресс по отдельному модулю
    /// </summary>
    public class ModuleProgress
    {
        public int ModuleNumber { get; set; }
        public string ModuleName { get; set; }
        public int CompletedLectures { get; set; }
        public int TotalLectures { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public bool IsCompleted { get; set; }
    }
    
    /// <summary>
    /// Рекомендация по обучению
    /// </summary>
    public class Recommendation
    {
        public string LectureId { get; set; }
        public string LectureTitle { get; set; }
        public string Reason { get; set; }
        public int Priority { get; set; }
    }
    
    /// <summary>
    /// Слабая область в знаниях
    /// </summary>
    public class WeakArea
    {
        public string Topic { get; set; }
        public double Percentage { get; set; }
        public string Recommendation { get; set; }
    }
}