using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEduLib.Core.Models
{
    /// <summary>
    /// Представляет практическое задание
    /// </summary>
    public class Exercise
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Название задания
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Описание задания
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Требования к решению
        /// </summary>
        public string Requirements { get; set; }
        
        /// <summary>
        /// Пример использования
        /// </summary>
        public string Example { get; set; }
        
        /// <summary>
        /// Максимальное количество баллов за задание
        /// </summary>
        public int MaxScore { get; set; }
        
        /// <summary>
        /// Сложность задания (1-5)
        /// </summary>
        public int Difficulty { get; set; }
        
        /// <summary>
        /// Порядковый номер в лекции
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// Подсказки для решения
        /// </summary>
        public List<string> Hints { get; set; } = new List<string>();
    }
}