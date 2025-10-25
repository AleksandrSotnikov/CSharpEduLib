using System.Collections.Generic;

namespace CSharpEduLib.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с Markdown файлами
    /// </summary>
    public interface IMarkdownParser
    {
        /// <summary>
        /// Парсить Markdown файл
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Содержимое файла</returns>
        string ParseFile(string filePath);
        
        /// <summary>
        /// Парсить Markdown строку
        /// </summary>
        /// <param name="markdown">Markdown текст</param>
        /// <returns>Обработанный текст</returns>
        string ParseString(string markdown);
        
        /// <summary>
        /// Извлечь заголовки из Markdown
        /// </summary>
        /// <param name="markdown">Markdown текст</param>
        /// <returns>Список заголовков</returns>
        List<Header> ExtractHeaders(string markdown);
        
        /// <summary>
        /// Извлечь блоки кода из Markdown
        /// </summary>
        /// <param name="markdown">Markdown текст</param>
        /// <returns>Список блоков кода</returns>
        List<CodeBlock> ExtractCodeBlocks(string markdown);
        
        /// <summary>
        /// Преобразовать Markdown в HTML
        /// </summary>
        /// <param name="markdown">Markdown текст</param>
        /// <returns>HTML текст</returns>
        string ConvertToHtml(string markdown);
    }
    
    /// <summary>
    /// Заголовок Markdown
    /// </summary>
    public class Header
    {
        public int Level { get; set; }
        public string Text { get; set; }
    }
    
    /// <summary>
    /// Блок кода Markdown
    /// </summary>
    public class CodeBlock
    {
        public string Language { get; set; }
        public string Code { get; set; }
    }
}