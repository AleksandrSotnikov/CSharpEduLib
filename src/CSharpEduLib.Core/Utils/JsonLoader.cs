using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CSharpEduLib.Core.Utils
{
    /// <summary>
    /// Утилита для загрузки JSON файлов
    /// </summary>
    public class JsonLoader
    {
        /// <summary>
        /// Загрузить объект из JSON файла
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Объект с данными из JSON</returns>
        public T LoadFromFile<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Файл {filePath} не найден");
                }
                
                string jsonContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonContent);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при загрузке JSON из {filePath}: {ex.Message}", ex);
            }
        }
        
        /// <summary>
        /// Загрузить объект из JSON строки
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="jsonString">JSON строка</param>
        /// <returns>Объект с данными из JSON</returns>
        public T LoadFromString<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при парсинге JSON: {ex.Message}", ex);
            }
        }
        
        /// <summary>
        /// Сохранить объект в JSON файл
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="obj">Объект для сохранения</param>
        /// <param name="filePath">Путь к файлу</param>
        public void SaveToFile<T>(T obj, string filePath)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(obj, Formatting.Indented);
                
                // Создаем директорию, если она не существует
                string directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                
                File.WriteAllText(filePath, jsonContent);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при сохранении JSON в {filePath}: {ex.Message}", ex);
            }
        }
        
        /// <summary>
        /// Преобразовать объект в JSON строку
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="obj">Объект для преобразования</param>
        /// <returns>JSON строка</returns>
        public string ConvertToString<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при преобразовании объекта в JSON: {ex.Message}", ex);
            }
        }
        
        /// <summary>
        /// Загрузить все JSON файлы из директории
        /// </summary>
        /// <typeparam name="T">Тип объектов</typeparam>
        /// <param name="directoryPath">Путь к директории</param>
        /// <returns>Список объектов</returns>
        public List<T> LoadAllFromDirectory<T>(string directoryPath)
        {
            var results = new List<T>();
            
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    return results;
                }
                
                string[] jsonFiles = Directory.GetFiles(directoryPath, "*.json", SearchOption.AllDirectories);
                
                foreach (string file in jsonFiles)
                {
                    try
                    {
                        T obj = LoadFromFile<T>(file);
                        results.Add(obj);
                    }
                    catch (Exception ex)
                    {
                        // Логируем ошибку и продолжаем
                        Console.WriteLine($"Ошибка при загрузке {file}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при обработке директории {directoryPath}: {ex.Message}", ex);
            }
            
            return results;
        }
        
        /// <summary>
        /// Проверить, является ли строка валидным JSON
        /// </summary>
        /// <param name="jsonString">Строка для проверки</param>
        /// <returns>True, если строка является валидным JSON</returns>
        public bool IsValidJson(string jsonString)
        {
            try
            {
                JsonConvert.DeserializeObject(jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}