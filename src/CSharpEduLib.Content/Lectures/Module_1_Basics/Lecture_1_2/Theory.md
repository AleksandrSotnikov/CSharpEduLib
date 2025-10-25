# Лекция 1.2: Переменные и типы данных в C#

## Введение

**Переменная** — это именованный контейнер для хранения данных в памяти компьютера. Если программирование — это приготовление пищи, то переменные — это наши тарелки, кастрюли и контейнеры, в которые мы помещаем ингредиенты (данные) для дальнейшего использования.

В C# каждая переменная имеет **тип данных**, который определяет:
- Какие значения можно в неё записать
- Сколько памяти она занимает
- Какие операции с ней можно выполнять

## Что такое переменная?

### Объявление переменной

Синтаксис объявления переменной в C#:
```csharp
тип_данных имя_переменной = значение;
```

**Пример:**
```csharp
int age = 25;        // Целое число
string name = "Иван"; // Строка
bool isStudent = true; // Логическое значение
```

### Правила именования переменных

✅ **Правильные имена:**
- `userName`, `firstName`, `totalAmount`
- `count`, `index`, `i`
- `PI`, `MAX_SIZE` (для констант)

❌ **Неправильные имена:**
- `2names` — нельзя начинать с цифры
- `user-name` — нельзя использовать дефис
- `class` — нельзя использовать ключевые слова

### Стили именования в C#

- **camelCase** — для переменных и методов: `firstName`, `calculateAge`
- **PascalCase** — для классов и свойств: `Student`, `FirstName`
- **UPPER_CASE** — для констант: `MAX_USERS`, `DEFAULT_TIMEOUT`

## Примитивные типы данных

### Целые числа

| Тип | Размер | Диапазон | Пример |
|-----|--------|----------|---------|
| `byte` | 1 байт | 0 до 255 | `byte age = 25;` |
| `int` | 4 байта | -2,147,483,648 до 2,147,483,647 | `int count = 1000;` |
| `long` | 8 байт | -9,223,372,036,854,775,808 до 9,223,372,036,854,775,807 | `long distance = 1000000L;` |

**Когда использовать каждый тип:**
- `int` — основной тип для целых чисел (возраст, количество, индексы)
- `long` — для очень больших чисел (расстояния, временные метки)
- `byte` — для небольших значений (цвета RGB, проценты)

### Дробные числа

| Тип | Размер | Точность | Пример |
|-----|--------|----------|---------|
| `float` | 4 байта | ~7 цифр | `float pi = 3.14f;` |
| `double` | 8 байт | ~15-17 цифр | `double precise = 3.141592653589793;` |
| `decimal` | 16 байт | 28-29 цифр | `decimal money = 299.99m;` |

**Когда использовать каждый тип:**
- `double` — основной тип для дробных чисел (вычисления, геометрия)
- `decimal` — для финансовых расчётов (деньги, проценты)
- `float` — когда нужно экономить память (игры, графика)

### Логический тип

```csharp
bool isReady = true;
bool isComplete = false;
bool hasAccess = user.Age >= 18;
```

**Использование:**
- Условия и проверки
- Флаги состояния
- Результаты сравнений

### Символьный тип

```csharp
char grade = 'A';
char symbol = '@';
char digit = '5';
char cyrillic = 'Ё';
```

**Особенности:**
- Хранит один символ Unicode
- Заключается в одинарные кавычки `'`
- Можно преобразовать в число (ASCII/Unicode код)

## Строки (string)

### Основы работы со строками

```csharp
string greeting = "Привет, мир!";
string empty = "";           // Пустая строка
string nullString = null;   // Отсутствие значения
```

### Свойства строк

```csharp
string text = "Программирование";
Console.WriteLine($"Длина: {text.Length}");           // 16
Console.WriteLine($"Пустая?: {string.IsNullOrEmpty(text)}"); // False
Console.WriteLine($"Верхний регистр: {text.ToUpper()}");     // ПРОГРАММИРОВАНИЕ
Console.WriteLine($"Нижний регистр: {text.ToLower()}");      // программирование
```

### Методы строк

```csharp
string sentence = "Изучаем C# программирование";

// Поиск
Console.WriteLine(sentence.Contains("C#"));      // True
Console.WriteLine(sentence.StartsWith("Изучаем")); // True
Console.WriteLine(sentence.EndsWith("ние"));       // True

// Замена и извлечение
Console.WriteLine(sentence.Replace("C#", "C Sharp")); // Изучаем C Sharp программирование
Console.WriteLine(sentence.Substring(0, 7));         // Изучаем
Console.WriteLine(sentence.Substring(8));             // C# программирование
```

### Конкатенация строк

```csharp
string firstName = "Иван";
string lastName = "Петров";

// Способ 1: Оператор +
string fullName1 = firstName + " " + lastName;

// Способ 2: String.Concat
string fullName2 = String.Concat(firstName, " ", lastName);

// Способ 3: Интерполяция (рекомендуется)
string fullName3 = $"{firstName} {lastName}";

// Способ 4: Composite formatting
string fullName4 = String.Format("{0} {1}", firstName, lastName);
```

## Неявная типизация (var)

### Основы var

Ключевое слово `var` позволяет компилятору автоматически определить тип переменной:

```csharp
var age = 25;           // Компилятор понимает: int
var name = "Анна";      // Компилятор понимает: string
var pi = 3.14;          // Компилятор понимает: double
var isReady = true;     // Компилятор понимает: bool
```

### Правила использования var

✅ **Можно использовать:**
```csharp
var number = 42;                    // Тип очевиден
var text = "Hello";                 // Тип очевиден
var result = CalculateSum(a, b);    // Когда тип сложный или длинный
```

❌ **Нельзя использовать:**
```csharp
var x;              // Ошибка: нет инициализации
var y = null;       // Ошибка: тип неопределён
```

### Когда использовать var

**Используйте var когда:**
- Тип переменной очевиден из контекста
- Имя типа очень длинное
- В циклах foreach

**НЕ используйте var когда:**
- Тип не очевиден из контекста
- Хотите явно показать тип для читабельности

## Преобразования типов

### Неявные преобразования

C# автоматически преобразует типы, когда это безопасно:

```csharp
int intValue = 10;
long longValue = intValue;      // int → long (безопасно)
double doubleValue = intValue;  // int → double (безопасно)
```

**Иерархия неявных преобразований:**
```
byte → int → long → float → double
               ↓
             decimal
```

### Явные преобразования (casting)

Для потенциально небезопасных преобразований нужно явное приведение:

```csharp
double doubleValue = 3.99;
int intValue = (int)doubleValue;    // Результат: 3 (дробная часть отбрасывается)

long bigNumber = 1000000000L;
int smallerNumber = (int)bigNumber;  // Может потерять данные при переполнении
```

### Методы Convert

Класс `Convert` предоставляет безопасные методы преобразования:

```csharp
string numberText = "42";
int number = Convert.ToInt32(numberText);       // string → int

double doubleNum = 3.14;
int roundedNum = Convert.ToInt32(doubleNum);    // 3 (с округлением)

bool flag = Convert.ToBoolean("true");          // string → bool
```

### Parse и TryParse

Специальные методы для преобразования строк:

```csharp
// Parse - выбрасывает исключение при ошибке
string text1 = "123";
int number1 = int.Parse(text1);        // OK: 123

string text2 = "abc";
// int number2 = int.Parse(text2);     // Ошибка: FormatException

// TryParse - безопасный способ
string text3 = "456";
if (int.TryParse(text3, out int number3))
{
    Console.WriteLine($"Преобразовано: {number3}");
}
else
{
    Console.WriteLine("Не удалось преобразовать");
}
```

## Константы

### Объявление констант

```csharp
const double PI = 3.14159;
const string COMPANY_NAME = "Microsoft";
const int MAX_USERS = 1000;
```

### Readonly переменные

```csharp
readonly DateTime startTime = DateTime.Now;    // Устанавливается один раз при создании
readonly string connectionString;              // Можно установить в конструкторе
```

### Различия const vs readonly

| const | readonly |
|-------|----------|
| Значение известно на этапе компиляции | Значение может быть установлено во время выполнения |
| Неявно статическая | Может быть статической или экземплярной |
| Только примитивные типы и string | Любые типы |

## Область видимости переменных

### Локальные переменные

```csharp
public void Method()
{
    int localVar = 10;    // Видна только внутри метода
    
    if (localVar > 5)
    {
        string message = "Больше 5";  // Видна только внутри блока if
        Console.WriteLine(message);
    }
    
    // Console.WriteLine(message);   // Ошибка: message не видна здесь
}
```

### Поля класса

```csharp
public class Calculator
{
    private int result = 0;           // Поле класса - видно во всех методах
    private const double PI = 3.14;  // Константа класса
    
    public void Add(int value)
    {
        result += value;              // Можем использовать поле
    }
}
```

## Форматирование вывода

### Стандартное форматирование

```csharp
int number = 1234;
double pi = 3.14159;
decimal money = 1234.56m;
DateTime now = DateTime.Now;

Console.WriteLine($"Целое число: {number:N0}");           // 1,234
Console.WriteLine($"Pi с 2 знаками: {pi:F2}");            // 3.14
Console.WriteLine($"Деньги: {money:C}");                  // ₽1,234.56
Console.WriteLine($"Процент: {0.85:P}");                  // 85.00%
Console.WriteLine($"Дата: {now:dd.MM.yyyy}");             // 25.10.2025
Console.WriteLine($"Время: {now:HH:mm:ss}");              // 22:15:30
```

### Пользовательское форматирование

```csharp
int number = 42;
Console.WriteLine($"Шестнадцатеричное: {number:X}");      // 2A
Console.WriteLine($"С нулями: {number:D5}");              // 00042
Console.WriteLine($"Экспоненциальная запись: {1234.5:E}"); // 1.234500E+003
```

## Работа с null

### Nullable типы

```csharp
int? nullableInt = null;          // int, который может быть null
double? nullableDouble = 3.14;    // double, который может быть null

if (nullableInt.HasValue)
{
    Console.WriteLine($"Значение: {nullableInt.Value}");
}
else
{
    Console.WriteLine("Значение отсутствует");
}

// Краткая запись
Console.WriteLine($"Значение: {nullableInt ?? 0}");  // Если null, то 0
```

### Null-coalescing оператор

```csharp
string name = null;
string displayName = name ?? "Гость";        // Если name == null, то "Гость"

int? count = null;
int actualCount = count ?? 0;                // Если count == null, то 0
```

## Лучшие практики

### Именование

```csharp
// ✅ Хорошо
int studentCount = 25;
string firstName = "Иван";
bool isAuthenticated = true;
const double GOLDEN_RATIO = 1.618;

// ❌ Плохо
int n = 25;           // Неинформативное имя
string s1 = "Иван";   // Сокращение без смысла
bool flag = true;     // Что означает этот флаг?
```

### Инициализация

```csharp
// ✅ Хорошо - инициализируем при объявлении
int counter = 0;
string message = string.Empty;
List<string> names = new List<string>();

// ❌ Плохо - неинициализированные переменные
int counter;
string message;
// Console.WriteLine(counter); // Ошибка компиляции
```

### Выбор типов

```csharp
// ✅ Для денег используем decimal
decimal price = 99.99m;
decimal tax = 0.13m;
decimal total = price * (1 + tax);

// ❌ НЕ используем float/double для денег
float badPrice = 99.99f;      // Может привести к ошибкам округления
```

## Типичные ошибки новичков

### 1. Неправильный выбор типа для денег

```csharp
// ❌ НЕПРАВИЛЬНО:
float money = 10.10f;
float result = money * 3;     // Может дать 30.299999 вместо 30.30

// ✅ ПРАВИЛЬНО:
decimal money = 10.10m;
decimal result = money * 3;   // Даст точно 30.30
```

### 2. Забывание суффиксов для литералов

```csharp
// ❌ НЕПРАВИЛЬНО:
float pi = 3.14;        // Компилятор предупредит о потере точности
long big = 1000000000;  // Может не поместиться в int

// ✅ ПРАВИЛЬНО:
float pi = 3.14f;       // Явно указываем float
long big = 1000000000L; // Явно указываем long
```

### 3. Использование == для сравнения строк с null

```csharp
string text = null;

// ✅ ПРАВИЛЬНО:
if (string.IsNullOrEmpty(text)) { /* ... */ }
if (text == null) { /* ... */ }

// 🤔 Может работать, но лучше избегать:
if (text == "") { /* ... */ }  // NullReferenceException если text == null
```

### 4. Неправильное использование var

```csharp
// ❌ НЕПРАВИЛЬНО:
var result = GetSomething();  // Неясно, что возвращает метод

// ✅ ПРАВИЛЬНО:
Customer customer = GetSomething();  // Ясно видно тип
// или
var customer = GetCustomerById(123); // Тип ясен из названия метода
```

## Полезные горячие клавиши в Visual Studio

- **Ctrl+K, Ctrl+D** — автоформатирование кода
- **Ctrl+.** — быстрые действия (исправления, рефакторинг)
- **F12** — перейти к определению переменной/метода
- **Ctrl+F12** — найти все использования
- **Ctrl+R, Ctrl+R** — переименовать переменную во всём проекте

## Резюме

В этой лекции вы изучили:

- ✅ **Основы переменных**: объявление, инициализация, именование
- ✅ **Примитивные типы**: int, double, bool, char и их особенности
- ✅ **Работу со строками**: свойства, методы, конкатенация
- ✅ **Неявную типизацию**: когда использовать var
- ✅ **Преобразования типов**: неявные, явные, Parse, TryParse, Convert
- ✅ **Константы**: const vs readonly
- ✅ **Область видимости**: локальные переменные и поля
- ✅ **Форматирование вывода**: стандартные и пользовательские форматы
- ✅ **Работу с null**: nullable типы и операторы
- ✅ **Лучшие практики**: именование, инициализация, выбор типов
- ✅ **Типичные ошибки**: и как их избежать

**Следующая лекция:** Операторы и выражения — изучите арифметические, логические операторы и приоритеты выполнения.

---

*Помните: правильный выбор типов данных — это основа надёжных программ. Потратьте время на понимание различий между типами — это сэкономит вам часы отладки в будущем!*