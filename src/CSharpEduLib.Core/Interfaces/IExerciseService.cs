using System.Collections.Generic;
using CSharpEduLib.Core.Models;

namespace CSharpEduLib.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для управления упражнениями
    /// </summary>
    public interface IExerciseService
    {
        /// <summary>
        /// Получить упражнение по идентификатору
        /// </summary>
        /// <param name="exerciseId">Идентификатор упражнения</param>
        /// <returns>Упражнение или null, если не найдено</returns>
        Exercise GetExerciseById(string exerciseId);
        
        /// <summary>
        /// Получить все упражнения лекции
        /// </summary>
        /// <param name="lectureId">Идентификатор лекции</param>
        /// <returns>Список упражнений лекции</returns>
        List<Exercise> GetLectureExercises(string lectureId);
        
        /// <summary>
        /// Получить все упражнения модуля
        /// </summary>
        /// <param name="moduleId">Идентификатор модуля</param>
        /// <returns>Список упражнений модуля</returns>
        List<Exercise> GetModuleExercises(string moduleId);
        
        /// <summary>
        /// Выполнить упражнение и получить результат
        /// </summary>
        /// <param name="exercise">Упражнение для выполнения</param>
        /// <param name="studentCode">Код студента</param>
        /// <returns>Результат выполнения</returns>
        TestResult ExecuteExercise(Exercise exercise, string studentCode);
        
        /// <summary>
        /// Проверить решение упражнения
        /// </summary>
        /// <param name="exerciseId">Идентификатор упражнения</param>
        /// <param name="solution">Код решения</param>
        /// <returns>Результат проверки</returns>
        TestResult ValidateSolution(string exerciseId, string solution);
        
        /// <summary>
        /// Перезагрузить упражнения из источника данных
        /// </summary>
        /// <returns>true, если перезагрузка прошла успешно</returns>
        bool ReloadExercises();
    }
}