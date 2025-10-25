namespace CSharpEduLib.Core.Utils
{
    /// <summary>
    /// Интерфейс для парсинга Markdown файлов
    /// </summary>
    public interface IMarkdownParser
    {
        /// <summary>
        /// Парсить Markdown файл
        /// </summary>
        string ParseFile(string filePath);
        
        /// <summary>
        /// Парсить Markdown строку
        /// </summary>
        string ParseString(string markdown);
        
        /// <summary>
        /// Преобразовать Markdown в HTML
        /// </summary>
        string ConvertToHtml(string markdown);
        
        /// <summary>
        /// Извлечь заголовки из Markdown
        /// </summary>
        string[] ExtractHeaders(string markdown);
        
        /// <summary>
        /// Извлечь блоки кода из Markdown
        /// </summary>
        string[] ExtractCodeBlocks(string markdown);
    }
}