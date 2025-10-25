using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpEduLib.Core.Interfaces;
using CSharpEduLib.Core.Models;
using CSharpEduLib.Core.Utils;
using Newtonsoft.Json;

namespace CSharpEduLib.Core.Services
{
    /// <summary>
    /// Сервис для управления лекциями
    /// </summary>
    public class LectureService : ILectureService
    {
        private readonly string _contentPath;
        private readonly IJsonLoader _jsonLoader;
        private readonly IMarkdownParser _markdownParser;
        private List<Lecture> _lectures;
        private readonly object _lockObject = new object();
        
        public LectureService(string contentPath, IJsonLoader jsonLoader, IMarkdownParser markdownParser)
        {
            _contentPath = contentPath ?? throw new ArgumentNullException(nameof(contentPath));
            _jsonLoader = jsonLoader ?? throw new ArgumentNullException(nameof(jsonLoader));
            _markdownParser = markdownParser ?? throw new ArgumentNullException(nameof(markdownParser));
            _lectures = new List<Lecture>();
            
            LoadLectures();
        }
        
        public Lecture GetLectureById(string lectureId)
        {
            if (string.IsNullOrWhiteSpace(lectureId))
                throw new ArgumentException("Идентификатор лекции не может быть пустым", nameof(lectureId));
            
            lock (_lockObject)
            {
                return _lectures.FirstOrDefault(l => l.Id.Equals(lectureId, StringComparison.OrdinalIgnoreCase));
            }
        }
        
        public List<Lecture> GetModuleLectures(string moduleId)
        {
            if (string.IsNullOrWhiteSpace(moduleId))
                throw new ArgumentException("Идентификатор модуля не может быть пустым", nameof(moduleId));
            
            lock (_lockObject)
            {
                return _lectures.Where(l => l.ModuleId.Equals(moduleId, StringComparison.OrdinalIgnoreCase))
                             .OrderBy(l => l.OrderIndex)
                             .ToList();
            }
        }
        
        public List<Lecture> GetAllLectures()
        {
            lock (_lockObject)
            {
                return _lectures.OrderBy(l => l.ModuleId)
                              .ThenBy(l => l.OrderIndex)
                              .ToList();
            }
        }
        
        public bool ReloadLectures()
        {
            try
            {
                LoadLectures();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при перезагрузке лекций: {ex.Message}");
                return false;
            }
        }
        
        public int GetLectureCount()
        {
            lock (_lockObject)
            {
                return _lectures.Count;
            }
        }
        
        private void LoadLectures()
        {
            var newLectures = new List<Lecture>();
            
            if (!Directory.Exists(_contentPath))
            {
                Directory.CreateDirectory(_contentPath);
                return;
            }
            
            var moduleDirectories = Directory.GetDirectories(_contentPath, "Module_*", SearchOption.TopDirectoryOnly);
            
            foreach (var moduleDir in moduleDirectories)
            {
                var moduleId = Path.GetFileName(moduleDir);
                var lectureDirectories = Directory.GetDirectories(moduleDir, "Lecture_*", SearchOption.TopDirectoryOnly);
                
                foreach (var lectureDir in lectureDirectories)
                {
                    try
                    {
                        var lecture = LoadSingleLecture(lectureDir, moduleId);
                        if (lecture != null)
                        {
                            newLectures.Add(lecture);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при загрузке лекции {lectureDir}: {ex.Message}");
                    }
                }
            }
            
            lock (_lockObject)
            {
                _lectures = newLectures;
            }
        }
        
        private Lecture LoadSingleLecture(string lectureDirectory, string moduleId)
        {
            var lectureName = Path.GetFileName(lectureDirectory);
            var theoryFile = Path.Combine(lectureDirectory, "Theory.md");
            var examplesFile = Path.Combine(lectureDirectory, "Examples.json");
            
            if (!File.Exists(theoryFile))
            {
                Console.WriteLine($"Не найден файл теории: {theoryFile}");
                return null;
            }
            
            var lecture = new Lecture
            {
                Id = $"{moduleId}_{lectureName}",
                ModuleId = moduleId,
                Title = ExtractTitleFromMarkdown(theoryFile),
                Description = "",
                Content = _markdownParser.ParseFile(theoryFile),
                Examples = new List<CodeExample>(),
                OrderIndex = ExtractOrderFromLectureName(lectureName)
            };
            
            if (File.Exists(examplesFile))
            {
                try
                {
                    var examplesJson = File.ReadAllText(examplesFile);
                    var examples = JsonConvert.DeserializeObject<List<CodeExample>>(examplesJson);
                    lecture.Examples = examples ?? new List<CodeExample>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при загрузке примеров: {ex.Message}");
                }
            }
            
            return lecture;
        }
        
        private string ExtractTitleFromMarkdown(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                var titleLine = lines.FirstOrDefault(l => l.StartsWith("# "));
                return titleLine?.Substring(2).Trim() ?? "Неизвестная лекция";
            }
            catch
            {
                return "Неизвестная лекция";
            }
        }
        
        private int ExtractOrderFromLectureName(string lectureName)
        {
            try
            {
                var parts = lectureName.Split('_');
                if (parts.Length >= 3 && int.TryParse(parts[1], out int moduleOrder) && int.TryParse(parts[2], out int lectureOrder))
                {
                    return moduleOrder * 100 + lectureOrder;
                }
            }
            catch
            {
                // Игнорируем ошибки
            }
            
            return 0;
        }
    }
}