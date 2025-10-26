// Exercise 2 — TypeConversions
// Цель: выполнить неявные и явные преобразования типов и вернуть результат через кортеж
using System;

namespace CSharpEduLib.Content.Module1.Lecture12.Exercises
{
    public static class Exercise_2_TypeConversions
    {
        public static (double implicitDouble, int explicitInt) Run()
        {
            int i = 42; // неявно к double
            double x = i;
            int j = (int)Math.Truncate(x + 0.7); // пример явного приведения
            return (x, j);
        }
    }
}
