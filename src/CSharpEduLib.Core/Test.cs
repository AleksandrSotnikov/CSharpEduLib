using System;
using CSharpEduLib.Core.Interfaces;
using CSharpEduLib.Core.Models;

namespace CSharpEduLib.Core
{
    /// <summary>
    /// Тестовый класс для проверки компиляции
    /// </summary>
    public class Test
    {
        public void TestReferences()
        {
            // Проверяем, что все ссылки работают
            IJsonLoader loader = null;
            IMarkdownParser parser = null;
            IExerciseService exerciseService = null;
            ILectureService lectureService = null;
            
            Header header = new Header();
            CodeBlock codeBlock = new CodeBlock();
            Exercise exercise = new Exercise();
            Lecture lecture = new Lecture();
            TestResult result = new TestResult();
            
            Console.WriteLine("Тест компиляции пройден");
        }
    }
}