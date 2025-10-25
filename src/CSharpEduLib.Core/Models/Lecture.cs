using System.Collections.Generic;

namespace CSharpEduLib.Core.Models
{
    /// <summary>
    /// Представляет лекцию по определенной теме (расширено для совместимости с сервисами)
    /// </summary>
    public class Lecture
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ModuleNumber { get; set; }
        public int LectureNumber { get; set; }
        public string TheoryContent { get; set; }
        public List<CodeExample> Examples { get; set; } = new List<CodeExample>();
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
        public int EstimatedMinutes { get; set; }

        // Новые свойства, ожидаемые сервисами
        public string ModuleId { get; set; }
        public string Content { get; set; }
        public int OrderIndex { get; set; }
    }
}
