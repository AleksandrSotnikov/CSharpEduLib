// Exercise 8 — Defaults
// Цель: вернуть значения по умолчанию для int и bool
namespace CSharpEduLib.Content.Module1.Lecture12.Exercises
{
    public static class Exercise_8_Defaults
    {
        public static (int, bool) Run()
        {
            int i = default; bool b = default;
            return (i, b);
        }
    }
}
