using System;
using System.Diagnostics;
using System.Text;

namespace CSharpEduLib.Tests.Helpers
{
    public static class Runner
    {
        public static string Normalize(string s)
        {
            if (s == null) return string.Empty;
            s = s.Replace("\r\n", "\n").Replace("\r", "\n");
            var lines = s.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].TrimEnd();
            }
            var normalized = string.Join("\n", lines).Trim();
            return normalized;
        }
    }
}
