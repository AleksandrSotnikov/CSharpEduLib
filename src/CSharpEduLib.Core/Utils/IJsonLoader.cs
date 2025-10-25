using System.Collections.Generic;

namespace CSharpEduLib.Core.Utils
{
    /// <summary>
    /// Интерфейс для загрузки JSON файлов
    /// </summary>
    public interface IJsonLoader
    {
        /// <summary>
        /// Загрузить объект из JSON файла
        /// </summary>
        T LoadFromFile<T>(string filePath) where T : class;
        
        /// <summary>
        /// Загрузить объект из JSON строки
        /// </summary>
        T LoadFromString<T>(string jsonString) where T : class;
        
        /// <summary>
        /// Сохранить объект в JSON файл
        /// </summary>
        bool SaveToFile<T>(T obj, string filePath) where T : class;
        
        /// <summary>
        /// Преобразовать объект в JSON строку
        /// </summary>
        string ConvertToString<T>(T obj) where T : class;
        
        /// <summary>
        /// Проверить, является ли строка валидным JSON
        /// </summary>
        bool IsValidJson(string jsonString);
    }
}