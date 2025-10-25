# Лекция 1.1 — Введение в C#

Добро пожаловать в мир программирования на C# (произносится "си-шарп")! В этой лекции вы получите полное представление об этом мощном языке программирования, создадите свою первую программу и изучите основы работы с консольными приложениями.

## История и особенности C#

### Что такое C#?

C# — это современный объектно-ориентированный язык программирования, разработанный компанией Microsoft в 2000 году под руководством Андерса Хейлсберга. Язык был создан как часть платформы .NET Framework и сочетает в себе простоту Visual Basic, мощь C++ и элегантность Java.

### Ключевые особенности C#:

- **Строгая типизация** — каждая переменная имеет определенный тип данных
- **Автоматическое управление памятью** — сборщик мусора освобождает неиспользуемую память
- **Объектно-ориентированность** — поддержка классов, наследования, полиморфизма
- **Безопасность типов** — предотвращение многих ошибок на этапе компиляции
- **Кросс-платформенность** — работает на Windows, Linux, macOS (через .NET Core/.NET 5+)

### .NET Framework и .NET Runtime

.NET Framework — это программная платформа от Microsoft, которая включает:
- **Common Language Runtime (CLR)** — среда выполнения
- **Base Class Library (BCL)** — базовая библиотека классов
- **Различные фреймворки** — ASP.NET, Windows Forms, WPF и др.

Когда вы пишете код на C#, компилятор переводит его в промежуточный язык (IL — Intermediate Language), который затем выполняется виртуальной машиной CLR.

## Структура программы на C#

### Минимальная программа

Любая программа на C# имеет базовую структуру:

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
    }
}
```

Разберем каждую часть:

#### 1. Директива `using`
```csharp
using System;
```
Эта строка подключает пространство имен `System`, которое содержит основные классы .NET, включая `Console` для работы с консолью.

#### 2. Объявление класса
```csharp
class Program
{
    // содержимое класса
}
```
В C# весь код должен находиться внутри классов. `Program` — это имя класса, которое вы можете изменить.

#### 3. Метод Main
```csharp
static void Main()
{
    // точка входа в программу
}
```
- `static` — метод принадлежит классу, а не экземпляру
- `void` — метод ничего не возвращает
- `Main` — специальное имя, указывающее точку входа в программу

### Альтернативные формы метода Main

```csharp
// С параметрами командной строки
static void Main(string[] args)
{
    // args содержит аргументы командной строки
}

// С возвращаемым значением (код завершения)
static int Main()
{
    // выполняем работу
    return 0; // 0 означает успешное завершение
}

// И то, и другое
static int Main(string[] args)
{
    // полная форма
    return 0;
}
```

## Работа с консолью

### Вывод данных

Для вывода информации на консоль используется класс `Console`:

#### Console.WriteLine()
```csharp
Console.WriteLine("Привет, мир!");     // Выводит текст и переходит на новую строку
Console.WriteLine(42);                // Выводит число
Console.WriteLine(3.14159);           // Выводит число с плавающей точкой
Console.WriteLine(true);              // Выводит логическое значение
```

#### Console.Write()
```csharp
Console.Write("Первая часть ");
Console.Write("вторая часть");
// Результат: Первая часть вторая часть (без перехода на новую строку)
```

### Форматирование вывода

#### 1. Конкатенация строк
```csharp
string name = "Александр";
int age = 25;
Console.WriteLine("Меня зовут " + name + ", мне " + age + " лет");
```

#### 2. Форматирование с помощью заполнителей
```csharp
string name = "Александр";
int age = 25;
Console.WriteLine("Меня зовут {0}, мне {1} лет", name, age);
Console.WriteLine("Через год мне будет {1} лет, а зовут меня {0}", name, age + 1);
```

#### 3. Интерполяция строк (C# 6.0+)
```csharp
string name = "Александр";
int age = 25;
Console.WriteLine($"Меня зовут {name}, мне {age} лет");
Console.WriteLine($"Сумма 2 + 3 = {2 + 3}");
```

### Ввод данных

#### Console.ReadLine()
```csharp
Console.WriteLine("Введите ваше имя:");
string name = Console.ReadLine();
Console.WriteLine($"Привет, {name}!");
```

#### Console.ReadKey()
```csharp
Console.WriteLine("Нажмите любую клавишу...");
ConsoleKeyInfo key = Console.ReadKey();
Console.WriteLine($"\nВы нажали: {key.KeyChar}");
```

### Преобразование типов при вводе

Поскольку `Console.ReadLine()` всегда возвращает строку, для работы с числами нужно выполнить преобразование:

#### Метод Parse
```csharp
Console.WriteLine("Введите число:");
string input = Console.ReadLine();
int number = int.Parse(input);
Console.WriteLine($"Квадрат числа: {number * number}");
```

#### Метод TryParse (безопасное преобразование)
```csharp
Console.WriteLine("Введите число:");
string input = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    Console.WriteLine($"Квадрат числа: {number * number}");
}
else
{
    Console.WriteLine("Ошибка: введено не число!");
}
```

## Специальные символы и экранирование

### Escape-последовательности

```csharp
Console.WriteLine("Строка с \"кавычками\"");        // Кавычки
Console.WriteLine("Первая строка\nВторая строка");    // Перевод строки
Console.WriteLine("Колонка1\tКолонка2\tКолонка3");    // Табуляция
Console.WriteLine("Путь: C:\\Users\\Name");           // Обратная косая черта
Console.WriteLine("Звуковой сигнал: \a");             // Звуковой сигнал
```

### Verbatim строки
```csharp
string path1 = "C:\\Users\\Name\\Documents";    // Обычная строка
string path2 = @"C:\Users\Name\Documents";      // Verbatim строка

string multiline = @"Первая строка
Вторая строка
Третья строка";
```

## Комментарии

### Однострочные комментарии
```csharp
// Это однострочный комментарий
Console.WriteLine("Hello"); // Комментарий в конце строки
```

### Многострочные комментарии
```csharp
/* Это многострочный
   комментарий, который может
   занимать несколько строк */
```

### XML-документация
```csharp
/// <summary>
/// Этот метод выводит приветствие
/// </summary>
/// <param name="name">Имя для приветствия</param>
static void SayHello(string name)
{
    Console.WriteLine($"Привет, {name}!");
}
```

## Переменные и типы данных

### Объявление переменных

```csharp
// Явное указание типа
int age = 25;
string name = "Александр";
double salary = 50000.50;
bool isStudent = true;

// Неявное определение типа (var)
var autoAge = 25;        // int
var autoName = "Иван";   // string
var autoSalary = 45000.0; // double
```

### Константы
```csharp
const double PI = 3.14159265359;
const string APP_NAME = "MyApplication";
const int MAX_USERS = 100;
```

### Основные типы данных

#### Целые числа
```csharp
byte b = 255;           // 0 до 255 (8 бит)
short s = 32000;        // -32,768 до 32,767 (16 бит)
int i = 2000000;        // -2,147,483,648 до 2,147,483,647 (32 бита)
long l = 9000000000L;   // очень большие числа (64 бита)
```

#### Числа с плавающей точкой
```csharp
float f = 3.14f;        // ~7 значащих цифр (32 бита)
double d = 3.14159265;  // ~15-17 значащих цифр (64 бита)
decimal m = 3.14159m;   // ~28-29 значащих цифр (128 бит)
```

#### Логический тип и символы
```csharp
bool isTrue = true;
bool isFalse = false;
char letter = 'A';
char unicode = '\u0041'; // Тот же символ 'A' в Unicode
```

## Арифметические операции

### Основные операции
```csharp
int a = 10, b = 3;

Console.WriteLine(a + b);  // Сложение: 13
Console.WriteLine(a - b);  // Вычитание: 7
Console.WriteLine(a * b);  // Умножение: 30
Console.WriteLine(a / b);  // Целочисленное деление: 3
Console.WriteLine(a % b);  // Остаток от деления: 1
```

### Приоритет операций
```csharp
int result1 = 2 + 3 * 4;      // 14 (сначала умножение)
int result2 = (2 + 3) * 4;    // 20 (сначала скобки)

double result3 = 10.0 / 3.0 * 2;   // Слева направо: 6.666...
double result4 = 10.0 / (3.0 * 2); // Сначала скобки: 1.666...
```

### Инкремент и декремент
```csharp
int x = 5;
Console.WriteLine(x++);    // Выведет 5, потом x станет 6
Console.WriteLine(++x);    // x станет 7, потом выведет 7
Console.WriteLine(x--);    // Выведет 7, потом x станет 6
Console.WriteLine(--x);    // x станет 5, потом выведет 5
```

## Практические примеры

### Пример 1: Калькулятор
```csharp
using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("Простой калькулятор");
        Console.WriteLine("==================");
        
        Console.Write("Введите первое число: ");
        double num1 = double.Parse(Console.ReadLine());
        
        Console.Write("Введите второе число: ");
        double num2 = double.Parse(Console.ReadLine());
        
        Console.WriteLine($"\nРезультаты:");
        Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
        Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
        Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
        
        if (num2 != 0)
        {
            Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
        }
        else
        {
            Console.WriteLine("Деление на ноль невозможно!");
        }
    }
}
```

### Пример 2: Персональная информация
```csharp
using System;

class PersonalInfo
{
    static void Main()
    {
        Console.WriteLine("Расскажите о себе:");
        
        Console.Write("Ваше имя: ");
        string firstName = Console.ReadLine();
        
        Console.Write("Ваша фамилия: ");
        string lastName = Console.ReadLine();
        
        Console.Write("Ваш возраст: ");
        int age = int.Parse(Console.ReadLine());
        
        Console.Write("Ваш рост (в см): ");
        double height = double.Parse(Console.ReadLine());
        
        Console.WriteLine("\n" + "=".PadLeft(40, '='));
        Console.WriteLine("ЛИЧНАЯ КАРТОЧКА");
        Console.WriteLine("=".PadLeft(40, '='));
        Console.WriteLine($"ФИО: {lastName} {firstName}");
        Console.WriteLine($"Возраст: {age} лет");
        Console.WriteLine($"Рост: {height} см");
        Console.WriteLine($"Через 10 лет вам будет: {age + 10} лет");
        Console.WriteLine("=".PadLeft(40, '='));
    }
}
```

## Обработка ошибок при вводе

```csharp
using System;

class SafeInput
{
    static void Main()
    {
        Console.Write("Введите ваш возраст: ");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int age))
        {
            if (age >= 0 && age <= 150)
            {
                Console.WriteLine($"Ваш возраст: {age} лет");
                Console.WriteLine($"Через год вам будет: {age + 1} лет");
            }
            else
            {
                Console.WriteLine("Некорректный возраст!");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: введите число!");
        }
    }
}
```

## Полезные советы

### 1. Соглашения по именованию
- **Классы**: `PascalCase` (например: `Program`, `Calculator`)
- **Методы**: `PascalCase` (например: `Main`, `GetUserName`)
- **Переменные**: `camelCase` (например: `userName`, `maxValue`)
- **Константы**: `UPPER_CASE` или `PascalCase` (например: `MAX_SIZE`, `DefaultTimeout`)

### 2. Организация кода
```csharp
using System;  // Подключение пространств имен в начале

class Program  // Один класс на файл (для начинающих)
{
    static void Main()  // Точка входа
    {
        // Основная логика программы
        // Используйте отступы для читаемости
        
        Console.WriteLine("Программа завершена");
        Console.ReadKey(); // Пауза перед закрытием консоли
    }
}
```

### 3. Отладка программ
- Используйте `Console.WriteLine()` для вывода промежуточных результатов
- Проверяйте входные данные на корректность
- Разбивайте сложную логику на простые шаги

## Заключение

В этой лекции мы изучили основы языка C#:
- Структуру программы и роль .NET Framework
- Работу с консольным вводом и выводом
- Основные типы данных и переменные
- Арифметические операции и их приоритет
- Обработку пользовательского ввода
- Форматирование и специальные символы

Теперь вы готовы создавать простые консольные приложения на C#. В следующих лекциях мы углубимся в изучение условных операторов, циклов и более сложных конструкций языка.

## Задания для закрепления

1. **Базовая программа**: Создайте программу, которая выводит ваше имя и фамилию в отдельных строках
2. **Простая арифметика**: Напишите программу, которая вычисляет и выводит сумму чисел 15 и 27
3. **Интерактивная программа**: Создайте программу, которая запрашивает имя пользователя и его возраст, а затем выводит персонализированное приветствие
4. **Калькулятор периметра**: Программа должна запросить длину и ширину прямоугольника, а затем вычислить и вывести его периметр
5. **Конвертер температуры**: Создайте программу для перевода температуры из Цельсия в Фаренгейты (формула: F = C × 9/5 + 32)