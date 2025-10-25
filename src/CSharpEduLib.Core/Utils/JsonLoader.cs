using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using CSharpEduLib.Core.Interfaces;

namespace CSharpEduLib.Core.Utils
{
    /// <summary>
    /// Утилита для работы с JSON файлами с поддержкой UTF-8 без BOM
    /// </summary>
    public class JsonLoader : IJsonLoader
    {
        private static readonly UTF8Encoding UTF8WithoutBOM = new UTF8Encoding(false);
        
        private static readonly JsonSerializerSettings DefaultSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Include,
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
        };

        public T LoadFromFile<T>(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Путь к файлу не может быть пустым", nameof(filePath));
            
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Файл '{Path.GetFullPath(filePath)}' не найден");
                }
                
                string jsonContent = File.ReadAllText(filePath, UTF8WithoutBOM);
                
                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    throw new InvalidOperationException($"Файл '{filePath}' пуст или содержит только пробелы");
                }
                
                return JsonConvert.DeserializeObject<T>(jsonContent, DefaultSettings);
            }
            catch (JsonReaderException ex)
            {
                throw new InvalidOperationException(
                    $"Ошибка парсинга JSON в файле '{filePath}' на строке {ex.LineNumber}, позиции {ex.LinePosition}: {ex.Message}", 
                    ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException(
                    $"Ошибка парсинга JSON в файле '{filePath}': {ex.Message}",
                    ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Ошибка при загрузке JSON из '{filePath}': {ex.Message}", 
                    ex);
            }
        }
        
        public T LoadFromString<T>(string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
                throw new ArgumentException("JSON строка не может быть пустой", nameof(jsonString));
            
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString, DefaultSettings);
            }
            catch (JsonReaderException ex)
            {
                throw new InvalidOperationException(
                    $"Ошибка парсинга JSON: строка {ex.LineNumber}, позиция {ex.LinePosition}: {ex.Message}", 
                    ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException(
                    $"Ошибка парсинга JSON: {ex.Message}", 
                    ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при парсинге JSON: {ex.Message}", ex);
            }
        }
        
        public void SaveToFile<T>(T obj, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Путь к файлу не может быть пустым", nameof(filePath));
            
            try
            {
                string jsonContent = JsonConvert.SerializeObject(obj, DefaultSettings);
                
                string directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                
                File.WriteAllText(filePath, jsonContent, UTF8WithoutBOM);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException(
                    $"Ошибка сериализации объекта в JSON: {ex.Message}", 
                    ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new InvalidOperationException(
                    $"Нет доступа для записи в '{filePath}': {ex.Message}", 
                    ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new InvalidOperationException(
                    $"Директория для '{filePath}' не найдена: {ex.Message}", 
                    ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Ошибка при сохранении JSON в '{filePath}': {ex.Message}", 
                    ex);
            }
        }
        
        public string ConvertToString<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, DefaultSettings);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException(
                    $"Ошибка сериализации объекта в JSON: {ex.Message}", 
                    ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Ошибка при преобразовании объекта в JSON: {ex.Message}", 
                    ex);
            }
        }
        
        public bool IsValidJson(string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
                return false;
                
            try
            {
                JsonConvert.DeserializeObject(jsonString, DefaultSettings);
                return true;
            }
            catch (JsonException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }
        
        public bool IsValidJsonFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return false;
                
            try
            {
                string content = File.ReadAllText(filePath, UTF8WithoutBOM);
                return IsValidJson(content);
            }
            catch
            {
                return false;
            }
        }
        
        public List<T> LoadAllFromDirectory<T>(string directoryPath, bool recursive = true)
        {
            var results = new List<T>();
            
            if (string.IsNullOrWhiteSpace(directoryPath))
                return results;
            
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    return results;
                }
                
                SearchOption searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                string[] jsonFiles = Directory.GetFiles(directoryPath, "*.json", searchOption);
                
                foreach (string file in jsonFiles)
                {
                    try
                    {
                        T obj = LoadFromFile<T>(file);
                        if (obj != null)
                        {
                            results.Add(obj);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Ошибка JsonLoader] Не удалось загрузить {file}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Ошибка при обработке директории '{directoryPath}': {ex.Message}", 
                    ex);
            }
            
            return results;
        }
    }
}
