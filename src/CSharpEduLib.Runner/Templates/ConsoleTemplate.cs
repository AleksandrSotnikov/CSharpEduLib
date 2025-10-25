using System;
using System.IO;

namespace CSharpEduLib.Runner.Templates
{
    public static class ConsoleTemplate
    {
        // Подставляет userCode внутрь минимального консольного проекта
        public static string Wrap(string userCode)
        {
            return "using System;\n" +
                   "class Program { static void Main(){\n" +
                   userCode + "\n" +
                   "} }\n";
        }
    }
}
