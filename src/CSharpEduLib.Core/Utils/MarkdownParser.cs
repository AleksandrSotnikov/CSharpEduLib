using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using CSharpEduLib.Core.Interfaces;

namespace CSharpEduLib.Core.Utils
{
    /// <summary>
    /// Минимальный Markdown парсер без внешних движков. Сохраняет исходный контент.
    /// </summary>
    public class MarkdownParser : IMarkdownParser
    {
        public string ParseFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Путь к файлу не может быть пустым", nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Markdown файл не найден: '{Path.GetFullPath(filePath)}'");
            return File.ReadAllText(filePath, new UTF8Encoding(false));
        }

        public string ParseString(string markdown)
        {
            return markdown ?? string.Empty;
        }

        public List<Header> ExtractHeaders(string markdown)
        {
            var headers = new List<Header>();
            if (string.IsNullOrWhiteSpace(markdown))
                return headers;

            foreach (var line in markdown.Split('\n'))
            {
                var m = Regex.Match(line, @"^(#{1,3})\s+(.*)$");
                if (m.Success)
                {
                    headers.Add(new Header
                    {
                        Level = m.Groups[1].Value.Length,
                        Text = m.Groups[2].Value.TrimEnd('\r')
                    });
                }
            }
            return headers;
        }

        public List<CodeBlock> ExtractCodeBlocks(string markdown)
        {
            var result = new List<CodeBlock>();
            if (string.IsNullOrWhiteSpace(markdown))
                return result;

            var rx = new Regex(@"```(\w*)\n([\s\S]*?)```", RegexOptions.Multiline);
            foreach (Match m in rx.Matches(markdown))
            {
                result.Add(new CodeBlock
                {
                    Language = m.Groups[1].Value.Trim(),
                    Code = m.Groups[2].Value.Replace("\r\n", "\n").Trim('\n','\r')
                });
            }
            return result;
        }

        public string ConvertToHtml(string markdown)
        {
            if (string.IsNullOrWhiteSpace(markdown))
                return string.Empty;

            var sb = new StringBuilder();
            var lines = markdown.Replace("\r\n", "\n").Split('\n');
            bool inCode = false;
            string codeLang = string.Empty;
            var codeBuf = new StringBuilder();

            foreach (var raw in lines)
            {
                var line = raw;
                if (!inCode)
                {
                    var m = Regex.Match(line, @"^(#{1,3})\s+(.*)$");
                    if (m.Success)
                    {
                        int lvl = m.Groups[1].Value.Length;
                        sb.AppendLine($"<h{lvl}>{EscapeHtml(m.Groups[2].Value)}</h{lvl}>");
                        continue;
                    }
                    var codeStart = Regex.Match(line, @"^```(\w*)\s*$");
                    if (codeStart.Success)
                    {
                        inCode = true;
                        codeLang = codeStart.Groups[1].Value;
                        codeBuf.Clear();
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        sb.AppendLine($"<p>{EscapeHtml(line)}</p>");
                    }
                }
                else
                {
                    if (Regex.IsMatch(line, @"^```\s*$"))
                    {
                        inCode = false;
                        sb.AppendLine($"<pre><code class=\"language-{EscapeHtml(codeLang)}\">{EscapeHtml(codeBuf.ToString())}</code></pre>");
                        codeLang = string.Empty;
                        codeBuf.Clear();
                    }
                    else
                    {
                        codeBuf.AppendLine(line);
                    }
                }
            }

            if (inCode)
            {
                sb.AppendLine($"<pre><code class=\"language-{EscapeHtml(codeLang)}\">{EscapeHtml(codeBuf.ToString())}</code></pre>");
            }

            return sb.ToString();
        }

        private static string EscapeHtml(string s)
        {
            return s
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&#39;");
        }
    }
}