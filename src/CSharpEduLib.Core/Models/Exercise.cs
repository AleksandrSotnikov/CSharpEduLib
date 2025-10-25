using System.Collections.Generic;

namespace CSharpEduLib.Core.Models
{
    /// <summary>
    /// Представляет практическое задание (расширено для совместимости с сервисами)
    /// </summary>
    public class Exercise
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Example { get; set; }
        public int MaxScore { get; set; }
        public int Difficulty { get; set; }
        public int Order { get; set; }
        public List<string> Hints { get; set; } = new List<string>();

        // Новые свойства, ожидаемые сервисами
        public string LectureId { get; set; }
        public int OrderIndex { get; set; }
        public string Type { get; set; }
        public string SolutionTemplate { get; set; }
        public string TestFile { get; set; }
    }
}
