using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace CSharpEduLib.Core.Utils
{
    /// <summary>
    /// Парсер для обработки Markdown файлов
    /// </summary>
    public class MarkdownParser
    {
        /// <summary>
        /// Парсить Markdown текст в HTML
        /// </summary>
        /// <param name="markdown">Markdown текст</param>
        /// <returns>HTML текст</returns>
        public string ParseToHtml(string markdown)
        {
            if (string.IsNullOrWhiteSpace(markdown))
                return string.Empty;
            
            string html = markdown;
            
            // Обработка заголовков
            html = ProcessHeaders(html);
            
            // Обработка блоков кода
            html = ProcessCodeBlocks(html);
            
            // Обработка жирного текста
            html = ProcessBold(html);
            
            // Обработка курсива
            html = ProcessItalic(html);
            
            // Обработка ссылок
            html = ProcessLinks(html);
            
            // Обработка списков
            html = ProcessLists(html);
            
            // Обработка параграфов
            html = ProcessParagraphs(html);
            
            return html;
        }
        
        /// <summary>
        /// Извлечь блоки кода из Markdown
        /// </summary>
        /// <param name="markdown">Markdown текст</param>
        /// <returns>Список блоков кода</returns>
        public List<CodeBlock> ExtractCodeBlocks(string markdown)
        {
            var codeBlocks = new List<CodeBlock>();
            
            if (string.IsNullOrWhiteSpace(markdown))
                return codeBlocks;
            
            // Поиск блоков кода ```
            var pattern = @"```(\w*)\n([\s\S]*?)```";
            var matches = Regex.Matches(markdown, pattern);
            
            foreach (Match match in matches)
            {
                codeBlocks.Add(new CodeBlock
                {
                    Language = match.Groups[1].Value,
                    Code = match.Groups[2].Value.Trim()
                });
            }
            
            return codeBlocks;
        }
        
        /// <summary>
        /// Извлечь заголовки из Markdown
        /// </summary>
        /// <param name="markdown">Markdown текст</param>
        /// <returns>Список заголовков</returns>
        public List<Header> ExtractHeaders(string markdown)
        {
            var headers = new List<Header>();
            
            if (string.IsNullOrWhiteSpace(markdown))
                return headers;
            
            var lines = markdown.Split('\n');
            
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                if (trimmedLine.StartsWith("#"))
                {
                    int level = 0;
                    while (level < trimmedLine.Length && trimmedLine[level] == '#')
                    {
                        level++;
                    }
                    
                    if (level <= 6 && level < trimmedLine.Length && trimmedLine[level] == ' ')
                    {
                        headers.Add(new Header
                        {
                            Level = level,
                            Text = trimmedLine.Substring(level + 1).Trim()
                        });
                    }
                }
            }
            
            return headers;
        }
        
        private string ProcessHeaders(string text)
        {
            // Обработка заголовков от H6 до H1
            for (int i = 6; i >= 1; i--)
            {
                string pattern = $@"^#{{{i}}} (.+)$";
                string replacement = $"<h{i}>$1</h{i}>";
                text = Regex.Replace(text, pattern, replacement, RegexOptions.Multiline);
            }
            
            return text;
        }
        
        private string ProcessCodeBlocks(string text)
        {
            // Обработка блоков кода
            text = Regex.Replace(text, @"```(\w*)\n([\s\S]*?)```", "<pre><code class=\"language-$1\">$2</code></pre>");
            
            // Обработка inline кода
            text = Regex.Replace(text, @"`([^`]+)`", "<code>$1</code>");
            
            return text;
        }
        
        private string ProcessBold(string text)
        {
            text = Regex.Replace(text, @"\*\*([^\*]+)\*\*", "<strong>$1</strong>");
            text = Regex.Replace(text, @"__([^_]+)__", "<strong>$1</strong>");
            return text;
        }
        
        private string ProcessItalic(string text)
        {
            text = Regex.Replace(text, @"\*([^\*]+)\*", "<em>$1</em>");
            text = Regex.Replace(text, @"_([^_]+)_", "<em>$1</em>");
            return text;
        }
        
        private string ProcessLinks(string text)
        {
            text = Regex.Replace(text, @"\[([^\]]+)\]\(([^\)]+)\)", "<a href=\"$2\">$1</a>");
            return text;
        }
        
        private string ProcessLists(string text)
        {
            // Простая обработка списков
            text = Regex.Replace(text, @"^\* (.+)$", "<li>$1</li>", RegexOptions.Multiline);
            text = Regex.Replace(text, @"^- (.+)$", "<li>$1</li>", RegexOptions.Multiline);
            
            // Оборачиваем группы li в ul
            text = Regex.Replace(text, @"(<li>.+</li>\s*)+", "<ul>$&</ul>", RegexOptions.Multiline | RegexOptions.Singleline);
            
            return text;
        }
        
        private string ProcessParagraphs(string text)
        {
            // Простая обработка параграфов
            var lines = text.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            var processedLines = new List<string>();
            
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                if (!string.IsNullOrEmpty(trimmedLine) && 
                    !trimmedLine.StartsWith("<h") && 
                    !trimmedLine.StartsWith("<pre") &&
                    !trimmedLine.StartsWith("<ul") &&
                    !trimmedLine.StartsWith("<li"))
                {
                    processedLines.Add($"<p>{trimmedLine}</p>");
                }
                else
                {
                    processedLines.Add(trimmedLine);
                }
            }
            
            return string.Join("\n\n", processedLines);
        }
    }
    
    /// <summary>
    /// Представляет блок кода
    /// </summary>
    public class CodeBlock
    {
        public string Language { get; set; }
        public string Code { get; set; }
    }
    
    /// <summary>
    /// Представляет заголовок
    /// </summary>
    public class Header
    {
        public int Level { get; set; }
        public string Text { get; set; }
    }
}