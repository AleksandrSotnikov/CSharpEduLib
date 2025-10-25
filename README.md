# CSharpEduLib - Библиотека для изучения C#

**Комплексная библиотека для обучения программированию на C# с нулевого уровня**

![.NET Framework](https://img.shields.io/badge/.NET-Framework%204.8-512BD4)
![C#](https://img.shields.io/badge/C%23-7.3%2B-239120)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91)
![MIT License](https://img.shields.io/badge/license-MIT-green)

## 📖 Описание проекта

CSharpEduLib - это комплексная библиотека для обучения программированию на C# с самых основ. Включает подробные лекции, сотни примеров кода и автоматизированные unit-тесты для проверки решений практических заданий.

### ✨ Особенности

- **📚 30+ лекций** с подробными объяснениями
- **💻 700+ примеров кода** на все темы
- **🎯 300+ практических заданий** с автопроверкой
- **✅ 600+ unit-тестов** для валидации решений
- **🏗️ 25 практических проектов** для закрепления навыков
- **📊 Система отслеживания прогресса**
- **🔧 Полная интеграция с Visual Studio 2022**

## 🎯 Для кого этот проект

- 👶 Новички, начинающие программировать с нуля
- 👨‍🏫 Преподаватели программирования
- 🎓 Студенты, изучающие C# как первый язык
- 📚 Самообучающиеся разработчики
- 🚀 Люди, делающие карьерный переход в IT

## 📋 Содержание курса

### Модуль 1: Основы и синтаксис (40+ часов)
- Введение в программирование и C#
- Переменные и типы данных
- Операторы и выражения
- Условные операторы (if-else, switch)
- Циклы (for, while, do-while, foreach)
- Введение в массивы и коллекции

### Модуль 2: Функции и методы (30+ часов)
- Методы. Основы
- Работа с параметрами (ref, out, params)
- Локальные функции и лямбда-выражения
- Рекурсия

### Модуль 3: ООП (50+ часов)
- Классы и объекты
- Инкапсуляция и свойства
- Наследование
- Полиморфизм
- Интерфейсы

### Модуль 4: Работа с данными (40+ часов)
- Строки и обработка текста
- Коллекции (List, Dictionary, Set)
- LINQ (Language Integrated Query)
- Обработка исключений

### Модуль 5: Продвинутые концепции (40+ часов)
- Обобщения (Generics)
- Делегаты и события
- Асинхронное программирование (async/await)
- Работа с файлами и потоками

### Модуль 6: Практические проекты (60+ часов)
- 25 практических проектов различной сложности
- От простого калькулятора до системы управления данными

## 🛠️ Технические требования

- **IDE:** Visual Studio 2022 (Community/Professional/Enterprise)
- **Framework:** .NET Framework 4.8
- **Язык:** C# 7.3+
- **Тестирование:** NUnit 3.x
- **ОС:** Windows 10/11

## 🚀 Быстрый старт

### 1. Установка

```bash
git clone https://github.com/AleksandrSotnikov/CSharpEduLib.git
cd CSharpEduLib
```

### 2. Открытие в Visual Studio 2022

1. Откройте `CSharpEduLib.sln`
2. Восстановите NuGet пакеты
3. Соберите решение (Ctrl+Shift+B)

### 3. Ваша первая лекция

```csharp
using CSharpEduLib.Core;

// Инициализация библиотеки
var eduLib = EduLibrary.Initialize();

// Получение первой лекции
var lecture = eduLib.GetLectureById("module-1-lecture-1");

Console.WriteLine($"Тема: {lecture.Title}");
Console.WriteLine($"Описание: {lecture.Description}");

// Просмотр примеров
foreach (var example in lecture.Examples.Take(3))
{
    Console.WriteLine($"\\n=== {example.Title} ===");
    Console.WriteLine(example.Code);
}
```

### 4. Выполнение задания

```csharp
// Получение задания
var exercise = eduLib.GetExerciseById("module-1-lecture-1-exercise-1");

Console.WriteLine($"Задание: {exercise.Title}");
Console.WriteLine($"Описание: {exercise.Description}");

// Выполнение и проверка
var result = exercise.Execute();

if (result.Success)
{
    Console.WriteLine("✓ Задание выполнено успешно!");
    Console.WriteLine($"Баллы: {result.Score}/{result.MaxScore}");
}
```

## 📂 Структура проекта

```
CSharpEduLib/
├── src/
│   ├── CSharpEduLib.Core/          # Основная библиотека
│   ├── CSharpEduLib.Content/       # Контент лекций
│   └── CSharpEduLib.Samples/       # Примеры использования
├── tests/
│   ├── CSharpEduLib.Core.Tests/    # Тесты основной библиотеки
│   └── CSharpEduLib.Exercises.Tests/ # Тесты заданий
├── docs/                           # Документация
└── .github/                        # CI/CD конфигурации
```

## 📚 Документация

- [Руководство по установке](docs/tutorials/01_Installation.md)
- [Создание первой программы](docs/tutorials/02_FirstProgram.md)
- [Работа с лекциями](docs/tutorials/03_UsingLectures.md)
- [Выполнение заданий](docs/tutorials/04_RunningExercises.md)
- [API документация](docs/API_DOCUMENTATION.md)

## 🤝 Участие в проекте

Мы приветствуем вклад в развитие проекта! Ознакомьтесь с [руководством для контрибьюторов](CONTRIBUTING.md).

### Как помочь:
- 🐛 Сообщить об ошибке
- 💡 Предложить улучшение
- 📝 Улучшить документацию
- ✨ Добавить новые примеры или задания

## 📊 Статистика проекта

- **Модулей:** 6
- **Лекций:** 30+
- **Примеров кода:** 700+
- **Практических заданий:** 300+
- **Unit-тестов:** 600+
- **Часов обучения:** 200+

## 📝 Лицензия

Проект распространяется под [MIT License](LICENSE).

## 🙋‍♂️ Поддержка

- **Issues:** GitHub Issues
- **Discussions:** GitHub Discussions

## 🌟 Поддержите проект

Если проект оказался полезным, поставьте ⭐ и поделитесь с друзьями!

---

**Изучайте C# легко и эффективно с CSharpEduLib!** 🚀