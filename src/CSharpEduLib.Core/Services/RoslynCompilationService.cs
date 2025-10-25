using System;
using CSharpEduLib.Core.Interfaces;

namespace CSharpEduLib.Core.Services
{
    /// <summary>
    /// Заглушка для RoslynCompilationService. Реализация будет добавлена на следующем этапе.
    /// </summary>
    public class RoslynCompilationService : ICompilationService
    {
        public object Compile(string sourceCode)
        {
            if (string.IsNullOrWhiteSpace(sourceCode))
                throw new ArgumentException("Исходный код не может быть пустым", nameof(sourceCode));
            throw new NotImplementedException("RoslynCompilationService.Compile будет реализован на следующем этапе");
        }

        public object Execute(object compiledAssembly, string typeName, string methodName, object[] parameters = null)
        {
            if (compiledAssembly == null)
                throw new ArgumentNullException(nameof(compiledAssembly));
            if (string.IsNullOrWhiteSpace(typeName))
                throw new ArgumentException("typeName не может быть пустым", nameof(typeName));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentException("methodName не может быть пустым", nameof(methodName));
            throw new NotImplementedException("RoslynCompilationService.Execute будет реализован на следующем этапе");
        }

        public object CompileAndExecute(string sourceCode, string typeName, string methodName, object[] parameters = null)
        {
            if (string.IsNullOrWhiteSpace(sourceCode))
                throw new ArgumentException("Исходный код не может быть пустым", nameof(sourceCode));
            if (string.IsNullOrWhiteSpace(typeName))
                throw new ArgumentException("typeName не может быть пустым", nameof(typeName));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentException("methodName не может быть пустым", nameof(methodName));
            throw new NotImplementedException("RoslynCompilationService.CompileAndExecute будет реализован на следующем этапе");
        }
    }
}
