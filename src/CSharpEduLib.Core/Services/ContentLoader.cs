using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpEduLib.Core.Models;
using CSharpEduLib.Core.Utils;

namespace CSharpEduLib.Core.Services
{
    public class ContentLoader
    {
        private readonly JsonLoader _json;
        public ContentLoader()
        {
            _json = new JsonLoader();
        }

        /// <summary>
        /// Загрузить упражнения лекции из JSON файлов в каталоге лекции
        /// </summary>
        public List<Exercise> LoadLectureExercises(string lectureDir)
        {
            var result = new List<Exercise>();
            if (!Directory.Exists(lectureDir)) return result;

            // Основной файл
            var main = Path.Combine(lectureDir, "Exercises.json");
            if (File.Exists(main))
            {
                var items = _json.LoadFromFile<List<Exercise>>(main) ?? new List<Exercise>();
                result.AddRange(items);
            }

            // Дополнительные файлы *.more.json
            foreach (var file in Directory.GetFiles(lectureDir, "*.more.json", SearchOption.TopDirectoryOnly))
            {
                var items = _json.LoadFromFile<List<Exercise>>(file) ?? new List<Exercise>();
                result.AddRange(items);
            }

            // Упорядочиваем и удаляем дубликаты по Id
            result = result
                .GroupBy(e => e.Id)
                .Select(g => g.First())
                .OrderBy(e => e.Order)
                .ToList();

            return result;
        }

        /// <summary>
        /// Загрузить теорию лекции (Markdown)
        /// </summary>
        public string LoadLectureTheory(string lectureDir)
        {
            var theory = Path.Combine(lectureDir, "Theory.md");
            return File.Exists(theory) ? File.ReadAllText(theory) : string.Empty;
        }

        /// <summary>
        /// Загрузить примеры к лекции (Markdown)
        /// </summary>
        public string LoadLectureExamples(string lectureDir)
        {
            var examples = Path.Combine(lectureDir, "CodeExamples.md");
            return File.Exists(examples) ? File.ReadAllText(examples) : string.Empty;
        }
    }
}
