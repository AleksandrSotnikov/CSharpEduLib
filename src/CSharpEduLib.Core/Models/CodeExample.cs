using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEduLib.Core.Models
{
    /// <summary>
    /// Представляет пример кода к лекции
    /// </summary>
    public class CodeExample
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Название примера
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Описание примера
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Код примера
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// Ожидаемый результат выполнения
        /// </summary>
        public string ExpectedOutput { get; set; }
        
        /// <summary>
        /// Порядковый номер в лекции
        /// </summary>
        public int Order { get; set; }
    }
}