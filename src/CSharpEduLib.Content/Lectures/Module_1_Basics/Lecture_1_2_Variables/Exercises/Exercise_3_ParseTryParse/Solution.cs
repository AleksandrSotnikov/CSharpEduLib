// Exercise 3 — ParseTryParse
// Цель: распарсить строки в числа с TryParse и вернуть сумму
using System;

namespace CSharpEduLib.Content.Module1.Lecture12.Exercises
{
    public static class Exercise_3_ParseTryParse
    {
        public static int Run(string a, string b)
        {
            int x = 0, y = 0;
            int.TryParse(a, out x);
            int.TryParse(b, out y);
            return x + y;
        }
    }
}
