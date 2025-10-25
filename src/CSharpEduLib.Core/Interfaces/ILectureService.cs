using System.Collections.Generic;
using CSharpEduLib.Core.Models;

namespace CSharpEduLib.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для управления лекциями
    /// </summary>
    public interface ILectureService
    {
        /// <summary>
        /// Получить лекцию по идентификатору
        /// </summary>
        /// <param name="lectureId">Идентификатор лекции</param>
        /// <returns>Лекция или null, если не найдена</returns>
        Lecture GetLectureById(string lectureId);
        
        /// <summary>
        /// Получить все лекции модуля
        /// </summary>
        /// <param name="moduleId">Идентификатор модуля</param>
        /// <returns>Список лекций модуля</returns>
        List<Lecture> GetModuleLectures(string moduleId);
        
        /// <summary>
        /// Получить все доступные лекции
        /// </summary>
        /// <returns>Полный список лекций</returns>
        List<Lecture> GetAllLectures();
        
        /// <summary>
        /// Перезагрузить лекции из источника данных
        /// </summary>
        /// <returns>true, если перезагрузка прошла успешно</returns>
        bool ReloadLectures();
        
        /// <summary>
        /// Получить количество доступных лекций
        /// </summary>
        /// <returns>Общее количество лекций</returns>
        int GetLectureCount();
    }
}