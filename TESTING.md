# CSharpEduLib — запуск и тестирование

Этот раздел описывает, как запускать тесты упражнений локально и в CI.

## Требования
- Visual Studio 2022
- .NET Framework 4.8
- NuGet (для восстановления пакетов)

## Локальный запуск в Visual Studio
1. Откройте решение `CSharpEduLib.sln` в Visual Studio 2022.
2. Постройте solution (Debug или Release).
3. Откройте Test Explorer (Test -> Test Explorer).
4. Запустите тесты проекта `CSharpEduLib.Tests`.

## Локальный запуск через консоль
```bat
nuget restore CSharpEduLib.sln
msbuild CSharpEduLib.sln /t:Rebuild /p:Configuration=Release
nuget install NUnit.ConsoleRunner -Version 3.16.3 -OutputDirectory tools
tools\NUnit.ConsoleRunner.3.16.3\tools\nunit3-console.exe tests\CSharpEduLib.Tests\bin\Release\CSharpEduLib.Tests.dll --result TestResult.xml;format=nunit2
```

## CI (GitHub Actions)
- Workflow запускается для ветки `feature/enhanced-utilities-and-exercises` и для PR в `main`.
- Выполняется восстановление пакетов, сборка и запуск NUnit-тестов.
- Результаты тестов доступны как артефакт `nunit-test-results` (файл `TestResult.xml`).

## Замечания по упражнениям
- В каждом упражнении метод `StudentSolution.Run()` изначально содержит `NotImplementedException`. Это нормально — тесты упадут до реализации студентом.
- Для динамических примеров (DateTime/Random) применяются паттерн-проверки форматов и диапазонов.

## Следующие шаги
- Интеграция Roslyn (ICompilationService, RoslynCompilationService) для компиляции и запуска кода студентов.
- Расширение контента: Лекция 1.2 с упражнениями и тестами.
