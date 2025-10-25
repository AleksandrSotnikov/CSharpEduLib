using System;
using System.Collections.Generic;
using System.Linq;
using CSharpEduLib.Core.Models;
using CSharpEduLib.Core.Utils;

namespace CSharpEduLib.Core.Services
{
    /// <summary>
    /// Сервис для работы с лекциями
    /// </summary>
    public class LectureService
    {
        private readonly List<Lecture> _lectures;
        private readonly JsonLoader _jsonLoader;
        
        public LectureService()
        {
            _lectures = new List<Lecture>();
            _jsonLoader = new JsonLoader();
        }
        
        /// <summary>
        /// Загрузить все лекции
        /// </summary>
        public void LoadAllLectures()
        {
            // TODO: Реализация загрузки лекций из файлов
        }
        
        /// <summary>
        /// Получить лекцию по ID
        /// </summary>
        /// <param name="id">Идентификатор лекции</param>
        /// <returns>Лекция или null</returns>
        public Lecture GetLectureById(string id)
        {
            return _lectures.FirstOrDefault(l => l.Id == id);
        }
        
        /// <summary>
        /// Получить все лекции модуля
        /// </summary>
        /// <param name="moduleNumber">Номер модуля</param>
        /// <returns>Список лекций</returns>
        public List<Lecture> GetLecturesByModule(int moduleNumber)
        {
            return _lectures.Where(l => l.ModuleNumber == moduleNumber)
                           .OrderBy(l => l.LectureNumber)
                           .ToList();
        }
        
        /// <summary>
        /// Получить следующую лекцию
        /// </summary>
        /// <param name="currentLectureId">Идентификатор текущей лекции</param>
        /// <returns>Следующая лекция или null</returns>
        public Lecture GetNextLecture(string currentLectureId)
        {
            var current = GetLectureById(currentLectureId);
            if (current == null) return null;
            
            return _lectures.FirstOrDefault(l => 
                l.ModuleNumber == current.ModuleNumber && 
                l.LectureNumber == current.LectureNumber + 1) ??
                _lectures.FirstOrDefault(l => 
                    l.ModuleNumber == current.ModuleNumber + 1 && 
                    l.LectureNumber == 1);
        }
        
        /// <summary>
        /// Получить предыдущую лекцию
        /// </summary>
        /// <param name="currentLectureId">Идентификатор текущей лекции</param>
        /// <returns>Предыдущая лекция или null</returns>
        public Lecture GetPreviousLecture(string currentLectureId)
        {
            var current = GetLectureById(currentLectureId);
            if (current == null) return null;
            
            return _lectures.FirstOrDefault(l => 
                l.ModuleNumber == current.ModuleNumber && 
                l.LectureNumber == current.LectureNumber - 1);
        }
        
        /// <summary>
        /// Получить все лекции
        /// </summary>
        /// <returns>Список всех лекций</returns>
        public List<Lecture> GetAllLectures()
        {
            return _lectures.OrderBy(l => l.ModuleNumber)
                           .ThenBy(l => l.LectureNumber)
                           .ToList();
        }
        
        /// <summary>
        /// Получить общее количество лекций
        /// </summary>
        /// <returns>Количество лекций</returns>
        public int GetTotalLectureCount()
        {
            return _lectures.Count;
        }
        
        /// <summary>
        /// Получить количество модулей
        /// </summary>
        /// <returns>Количество модулей</returns>
        public int GetTotalModuleCount()
        {
            return _lectures.GroupBy(l => l.ModuleNumber).Count();
        }
    }
}