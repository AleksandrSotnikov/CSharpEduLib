using System;
using NUnit.Framework;

namespace CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_3_Operators.Exercises.Exercise_8_ShortCircuit
{
    /// <summary>
    /// Упражнение 8: Короткое замыкание логических операторов
    /// 
    /// Задача:
    /// Напишите программу, которая демонстрирует принцип короткого замыкания 
    /// в логических операторах (&& и ||).
    /// </summary>
    public class StudentSolution
    {
        public static int CallCountA = 0;
        public static int CallCountB = 0;
        
        public static void ResetCounters()
        {
            CallCountA = 0;
            CallCountB = 0;
        }
        
        public static bool MethodA()
        {
            throw new NotImplementedException("Упражнение еще не выполнено.");
        }
        
        public static bool MethodB()
        {
            throw new NotImplementedException("Упражнение еще не выполнено.");
        }
    }
}