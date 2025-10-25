using System;

namespace CSharpEduLib.Core.Interfaces
{
    /// <summary>
    /// Интерфейс компиляции и выполнения кода (каркас для Roslyn)
    /// </summary>
    public interface ICompilationService
    {
        /// <summary>
        /// Компилирует исходный C# код в сборку (в памяти или на диске)
        /// </summary>
        /// <param name="sourceCode">Исходный код</param>
        /// <returns>Условный объект сборки (implementation-specific)</returns>
        object Compile(string sourceCode);

        /// <summary>
        /// Выполняет указанный метод из скомпилированной сборки
        /// </summary>
        /// <param name="compiledAssembly">Скомпилированная сборка</param>
        /// <param name="typeName">Полное имя типа</param>
        /// <param name="methodName">Имя метода</param>
        /// <param name="parameters">Параметры</param>
        /// <returns>Производит вывод в Console.Out и/или возвращает результат выполнения</returns>
        object Execute(object compiledAssembly, string typeName, string methodName, object[] parameters = null);

        /// <summary>
        /// Компилирует и выполняет метод за одну операцию
        /// </summary>
        /// <param name="sourceCode">Исходный код</param>
        /// <param name="typeName">Тип</param>
        /// <param name="methodName">Метод</param>
        /// <param name="parameters">Параметры</param>
        /// <returns>Результат выполнения</returns>
        object CompileAndExecute(string sourceCode, string typeName, string methodName, object[] parameters = null);
    }
}
