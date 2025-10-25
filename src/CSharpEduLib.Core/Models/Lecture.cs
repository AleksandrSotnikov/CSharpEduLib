using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEduLib.Core.Models
{
    /// <summary>
    /// Представляет лекцию по определенной теме
    /// </summary>
    public class Lecture
    {
        /// <summary>
        /// Уникальный идентификатор лекции
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Название лекции
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Описание лекции
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Номер модуля
        /// </summary>
        public int ModuleNumber { get; set; }
        
        /// <summary>
        /// Номер лекции в модуле
        /// </summary>
        public int LectureNumber { get; set; }
        
        /// <summary>
        /// Теоретический материал в формате Markdown
        /// </summary>
        public string TheoryContent { get; set; }
        
        /// <summary>
        /// Примеры кода к лекции
        /// </summary>
        public List<CodeExample> Examples { get; set; } = new List<CodeExample>();
        
        /// <summary>
        /// Практические задания
        /// </summary>
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
        
        /// <summary>
        /// Оценочное время изучения в минутах
        /// </summary>
        public int EstimatedMinutes { get; set; }
    }
}