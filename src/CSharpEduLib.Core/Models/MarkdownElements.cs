namespace CSharpEduLib.Core.Models
{
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