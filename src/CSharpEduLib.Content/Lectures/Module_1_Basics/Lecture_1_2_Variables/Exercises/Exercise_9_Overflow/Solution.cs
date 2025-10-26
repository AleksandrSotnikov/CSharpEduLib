// Exercise 9 — Overflow
// Цель: показать поведение переполнения в unchecked
namespace CSharpEduLib.Content.Module1.Lecture12.Exercises
{
    public static class Exercise_9_Overflow
    {
        public static int Run()
        {
            unchecked { int max = int.MaxValue; return max + 1; }
        }
    }
}
