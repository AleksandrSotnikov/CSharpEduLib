using System.Collections.Generic;

namespace CSharpEduLib.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с JSON файлами
    /// </summary>
    public interface IJsonLoader
    {
        /// <summary>
        /// Загрузить объект из JSON файла
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Объект с данными из JSON</returns>
        T LoadFromFile<T>(string filePath);
        
        /// <summary>
        /// Загрузить объект из JSON строки
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="jsonString">JSON строка</param>
        /// <returns>Объект с данными из JSON</returns>
        T LoadFromString<T>(string jsonString);
        
        /// <summary>
        /// Сохранить объект в JSON файл
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="obj">Объект для сохранения</param>
        /// <param name="filePath">Путь к файлу</param>
        void SaveToFile<T>(T obj, string filePath);
        
        /// <summary>
        /// Преобразовать объект в JSON строку
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="obj">Объект для преобразования</param>
        /// <returns>JSON строка</returns>
        string ConvertToString<T>(T obj);
        
        /// <summary>
        /// Проверить, является ли строка валидным JSON
        /// </summary>
        /// <param name="jsonString">Строка для проверки</param>
        /// <returns>True, если строка является валидным JSON</returns>
        bool IsValidJson(string jsonString);
        
        /// <summary>
        /// Проверить, является ли файл валидным JSON
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>True, если файл содержит валидный JSON</returns>
        bool IsValidJsonFile(string filePath);
        
        /// <summary>
        /// Загрузить все JSON файлы из директории
        /// </summary>
        /// <typeparam name="T">Тип объектов</typeparam>
        /// <param name="directoryPath">Путь к директории</param>
        /// <param name="recursive">Рекурсивный поиск</param>
        /// <returns>Список объектов</returns>
        List<T> LoadAllFromDirectory<T>(string directoryPath, bool recursive = true);
    }
}