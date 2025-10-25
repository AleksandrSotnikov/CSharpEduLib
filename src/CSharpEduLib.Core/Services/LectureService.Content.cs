using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpEduLib.Core.Models;

namespace CSharpEduLib.Core.Services
{
    /// <summary>
    /// Расширение LectureService для загрузки контента лекций и модулей
    /// </summary>
    public partial class LectureService
    {
        private readonly ContentLoader _contentLoader = new ContentLoader();

        /// <summary>
        /// Загрузить лекцию из каталога
        /// </summary>
        public Lecture LoadLectureFromDirectory(string lectureDir, int moduleNumber, int lectureNumber)
        {
            var lecture = new Lecture
            {
                Id = $"module-{moduleNumber}-lecture-{lectureNumber}",
                ModuleNumber = moduleNumber,
                LectureNumber = lectureNumber,
                Title = $"Лекция {moduleNumber}.{lectureNumber}",
                Description = $"Материалы лекции {moduleNumber}.{lectureNumber}",
                TheoryContent = _contentLoader.LoadLectureTheory(lectureDir),
                EstimatedMinutes = 45
            };

            var examplesMd = _contentLoader.LoadLectureExamples(lectureDir);
            if (!string.IsNullOrWhiteSpace(examplesMd))
            {
                // Для простоты сохраняем один пример-агрегатор в Examples
                lecture.Examples.Add(new Models.CodeExample
                {
                    Id = $"{lecture.Id}-examples",
                    Title = "Примеры кода",
                    Description = "См. Markdown в контенте",
                    Code = examplesMd,
                    Order = 1
                });
            }

            lecture.Exercises = _contentLoader.LoadLectureExercises(lectureDir);

            // Добавляем в локальное хранилище сервиса
            if (!_lectures.Any(l => l.Id == lecture.Id))
                _lectures.Add(lecture);

            return lecture;
        }

        /// <summary>
        /// Загрузить модуль целиком по каталогу модуля
        /// </summary>
        public List<Lecture> LoadModuleFromDirectory(string moduleDir, int moduleNumber)
        {
            var lectures = new List<Lecture>();
            if (!Directory.Exists(moduleDir)) return lectures;

            var subDirs = Directory.GetDirectories(moduleDir)
                .Where(d => Path.GetFileName(d).StartsWith("Lecture_"))
                .OrderBy(d => d)
                .ToList();

            int index = 1;
            foreach (var dir in subDirs)
            {
                var lecture = LoadLectureFromDirectory(dir, moduleNumber, index);
                lectures.Add(lecture);
                index++;
            }

            return lectures;
        }
    }
}
