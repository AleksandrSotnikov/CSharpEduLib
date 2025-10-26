// Exercise 1 — DeclaringVariables
// Цель: объявить переменные всех базовых типов и вернуть конкатенированную строку со значениями
using System;

namespace CSharpEduLib.Content.Module1.Lecture12.Exercises
{
    public static class Exercise_1_DeclaringVariables
    {
        public static string Run()
        {
            int a = 10; double d = 3.14; string s = "text"; bool ok = true; char ch = 'A';
            return $"{a}|{d}|{s}|{ok}|{ch}";
        }
    }
}
