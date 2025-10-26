# Вопросы и ответы: Переменные и типы данных

## Основные вопросы

### В: В чём разница между значимыми и ссылочными типами?

**О:** Основные различия:

**Значимые типы (Value Types):**
- Хранятся в стеке или встроено в объект
- Копируются по значению
- Не могут быть null (кроме nullable типов)
- Примеры: int, double, bool, char, struct, enum

**Ссылочные типы (Reference Types):**
- Объект хранится в куче, переменная хранит ссылку
- Копируются по ссылке
- Могут быть null
- Примеры: string, object, массивы, классы

```csharp
// Значимый тип - копирование по значению
int a = 5;
int b = a;
a = 10;
Console.WriteLine($"a = {a}, b = {b}"); // a = 10, b = 5

// Ссылочный тип - копирование по ссылке
int[] arr1 = {1, 2, 3};
int[] arr2 = arr1;
arr1[0] = 10;
Console.WriteLine($"arr1[0] = {arr1[0]}, arr2[0] = {arr2[0]}"); // 10, 10
```

### В: Когда следует использовать float, double или decimal?

**О:** Выбор зависит от требований к точности:

**float:**
- Малый размер (4 байта)
- Ограниченная точность (6-9 цифр)
- Используйте для 3D графики, игр (когда нужна скорость)

**double:**
- Средний размер (8 байт)
- Высокая точность (15-17 цифр)
- Используйте для общих научных расчётов, математики

**decimal:**
- Большой размер (16 байт)
- Максимальная точность (28-29 цифр)
- Обязателен для финансовых расчётов

```csharp
// Проблема с double в финансах:
double money = 0.1 + 0.2;
Console.WriteLine(money); // 0.30000000000000004

// Правильно для финансов:
decimal moneyDecimal = 0.1M + 0.2M;
Console.WriteLine(moneyDecimal); // 0.3
```

### В: Когда использовать var, а когда явно указывать тип?

**О:** Рекомендации по использованию `var`:

**Используйте var, когда:**
- Тип очевиден из правой части
- При работе с анонимными типами
- При сложных обобщённых типах

**Не используйте var, когда:**
- Тип не очевиден
- В API сигнатурах (параметры, возвращаемые значения)
- Когда тип важен для понимания кода

```csharp
// Хорошо:
var dictionary = new Dictionary<string, List<int>>();
var customer = new Customer("Иван");

// Плохо (не очевидно):
var data = GetData(); // Какой тип возвращает GetData()?

// Лучше:
Customer data = GetData();
```

### В: Почему string является ссылочным типом, но ведёт себя как значимый?

**О:** string в C# имеет особую семантику:

**Похож на значимый:**
- Неизменяемый (immutable)
- Оператор `==` сравнивает значения, а не ссылки

**Остаётся ссылочным:**
- Может быть null
- Хранится в куче
- Передаётся по ссылке

```csharp
string str1 = "Hello";
string str2 = "Hello";
Console.WriteLine(str1 == str2); // true (сравнение значений)

// Но string может быть null:
string nullStr = null;
// Console.WriteLine(nullStr.Length); // NullReferenceException!
```

### В: Как правильно работать с nullable типами?

**О:** Nullable типы позволяют значимым типам хранить null:

```csharp
int? nullableInt = null;

// Проверка на null:
if (nullableInt.HasValue)
{
    Console.WriteLine($"Значение: {nullableInt.Value}");
}
else
{
    Console.WriteLine("Значение отсутствует");
}

// Оператор объединения с null (??):
int actualValue = nullableInt ?? 0; // Если null, то 0

// GetValueOrDefault():
int defaultValue = nullableInt.GetValueOrDefault(); // 0
int customDefault = nullableInt.GetValueOrDefault(42); // 42
```

## Продвинутые вопросы

### В: Как работают преобразования между числовыми типами?

**О:** Преобразования бывают неявные (безопасные) и явные (с возможной потерей данных):

**Неявные (расширяющие):**
```csharp
int intValue = 100;
long longValue = intValue;     // ОК: int помещается в long
double doubleValue = intValue; // ОК: int помещается в double
```

**Явные (сужающие):**
```csharp
double doubleValue = 123.45;
int intValue = (int)doubleValue; // 123 - дробная часть отсекается

long longValue = long.MaxValue;
int intValue2 = (int)longValue;  // Может вызвать overflow!
```

### В: Какая разница между Parse и TryParse?

**О:** Основная разница в обработке ошибок:

**Parse методы:**
- Бросают исключения при ошибке
- Используйте, когда уверены в формате данных

**TryParse методы:**
- Возвращают bool (успех/неудача)
- Результат через out параметр
- Безопасны для пользовательского ввода

```csharp
// Parse - может бросить FormatException:
try
{
    int number = int.Parse("абв"); // FormatException!
}
catch (FormatException)
{
    Console.WriteLine("Ошибка преобразования");
}

// TryParse - безопасно:
if (int.TryParse("абв", out int number))
{
    Console.WriteLine($"Результат: {number}");
}
else
{
    Console.WriteLine("Ошибка преобразования");
}
```

### В: Как работает переполнение чисел?

**О:** Переполнение происходит, когда результат операции не помещается в тип:

**unchecked контекст (по умолчанию):**
```csharp
int maxInt = int.MaxValue; // 2,147,483,647
int overflow = maxInt + 1; // -2,147,483,648 (зацикливание)
Console.WriteLine(overflow);
```

**checked контекст:**
```csharp
checked
{
    int maxInt = int.MaxValue;
    int overflow = maxInt + 1; // OverflowException!
}

// Или для одного выражения:
int result = checked(int.MaxValue + 1);
```

## Ошибки и подводные камни

### В: Почему мой код не компилируется с ошибкой "Use of unassigned local variable"?

**О:** В C# локальные переменные должны быть инициализированы перед использованием:

```csharp
// Ошибка:
int x;
Console.WriteLine(x); // Error: Use of unassigned local variable 'x'

// Правильно:
int x = 0; // Или любое другое значение
Console.WriteLine(x);

// Или с default:
int x = default; // 0
Console.WriteLine(x);
```

### В: Почему 0.1 + 0.2 не равно 0.3 в double?

**О:** Это особенность представления чисел с плавающей точкой IEEE 754:

```csharp
double result = 0.1 + 0.2;
Console.WriteLine(result); // 0.30000000000000004
Console.WriteLine(result == 0.3); // False!

// Правильное сравнение:
double epsilon = 1e-10;
bool isEqual = Math.Abs(result - 0.3) < epsilon;
Console.WriteLine(isEqual); // True

// Или используйте decimal:
decimal decimalResult = 0.1M + 0.2M;
Console.WriteLine(decimalResult); // 0.3
Console.WriteLine(decimalResult == 0.3M); // True
```

### В: Как правильно сравнивать строки?

**О:** В C# есть несколько способов сравнения строк:

```csharp
string str1 = "Hello";
string str2 = "hello";
string str3 = "Hello";

// Оператор == (чувствителен к регистру):
Console.WriteLine(str1 == str2); // False
Console.WriteLine(str1 == str3); // True

// Сравнение без учёта регистра:
bool isEqual = string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
Console.WriteLine(isEqual); // True

// Метод Equals:
bool isEqual2 = str1.Equals(str2, StringComparison.OrdinalIgnoreCase);
Console.WriteLine(isEqual2); // True
```

## Практические примеры

### В: Как безопасно преобразовать пользовательский ввод?

**О:** Всегда используйте TryParse для пользовательского ввода:

```csharp
Console.Write("Введите число: ");
string input = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    Console.WriteLine($"Вы ввели число: {number}");
    Console.WriteLine($"Квадрат: {number * number}");
}
else
{
    Console.WriteLine("Ошибка: Некорректный формат числа");
}
```

### В: Как правильно форматировать числа и даты?

**О:** Используйте специализированные спецификаторы формата:

```csharp
double price = 1234.56;
double percentage = 0.85;
int count = 1000000;

// Монетарный формат:
string priceFormatted = price.ToString("C"); // ₽1,234.56
string priceInterpolated = $"{price:C}";     // ₽1,234.56

// Проценты:
string percentFormatted = percentage.ToString("P"); // 85.00%
string percentInterpolated = $"{percentage:P1}";   // 85.0%

// Нумерация с разделителями:
string countFormatted = count.ToString("N0"); // 1,000,000
string countInterpolated = $"{count:N0}";     // 1,000,000

// Фиксированное количество знаков:
string fixedFormat = price.ToString("F2"); // 1234.56
string sciFormat = count.ToString("E2");   // 1.00E+006
```

### В: Как правильно обработать CultureInfo при парсинге?

**О:** Разные культуры используют разные форматы чисел:

```csharp
using System.Globalization;

// Русская культура (запятая как десятичный разделитель):
CultureInfo ruCulture = new CultureInfo("ru-RU");
if (double.TryParse("3,14", NumberStyles.Float, ruCulture, out double value))
{
    Console.WriteLine($"Результат: {value}"); // 3.14
}

// Английская культура (точка):
CultureInfo usCulture = new CultureInfo("en-US");
if (double.TryParse("3.14", NumberStyles.Float, usCulture, out double value2))
{
    Console.WriteLine($"Результат: {value2}"); // 3.14
}

// Инвариантная культура (безопасно):
if (double.TryParse("3.14", NumberStyles.Float, CultureInfo.InvariantCulture, out double value3))
{
    Console.WriteLine($"Результат: {value3}");
}
```

## Лучшие практики

### В: Какие существуют рекомендации по выбору типов?

**О:**

1. **Целые числа:** Используйте `int` по умолчанию, `long` для больших чисел
2. **Дробные числа:** `double` для общих случаев, `decimal` для финансов
3. **Текст:** `string` для текста, `char` для одиночных символов
4. **Логика:** `bool` для да/нет значений

### В: Когда стоит использовать checked/unchecked?

**О:**

**Используйте checked:**
- В критичных вычислениях
- При работе с пользовательским вводом
- Когда нужно узнать о переполнении

**Используйте unchecked:**
- В производительных вычислениях
- Когда переполнение ожидаемо (например, в hash-функциях)
- При работе с циклическими счётчиками

```csharp
// Пример checked для критичных вычислений:
try
{
    checked
    {
        int userInput = int.Parse(Console.ReadLine());
        int result = userInput * 1000; // Может overflow
        Console.WriteLine($"Результат: {result}");
    }
}
catch (OverflowException)
{
    Console.WriteLine("Ошибка: Переполнение при вычислении");
}
```

### В: Как создавать собственные константы?

**О:** Константы лучше организовывать в отдельных классах:

```csharp
// Плохо (константы разбросаны по коду):
const int MaxUsers = 100;
const int MaxFiles = 1000;
const double TaxRate = 0.2;

// Лучше (сгруппировано):
public static class AppConstants
{
    public const int MaxUsers = 100;
    public const int MaxFiles = 1000;
    public const double TaxRate = 0.2;
    
    public static class DatabaseLimits
    {
        public const int MaxConnections = 50;
        public const int CommandTimeout = 30;
    }
}

// Использование:
if (userCount > AppConstants.MaxUsers)
    throw new InvalidOperationException("Слишком много пользователей");
```

### В: Как лучше всего обрабатывать ошибки преобразования?

**О:** Лучшие практики для обработки ошибок:

```csharp
// Плохо (может упасть):
int number = int.Parse(userInput);

// Лучше:
public static bool TryConvertToInt(string input, out int result)
{
    result = 0;
    
    // Проверка на null/empty
    if (string.IsNullOrWhiteSpace(input))
        return false;
        
    // Попытка преобразования
    if (int.TryParse(input.Trim(), out result))
        return true;
        
    return false;
}

// Использование:
if (TryConvertToInt(userInput, out int number))
{
    Console.WriteLine($"Число: {number}");
}
else
{
    Console.WriteLine("Ошибка: Некорректное число");
}
```

Эти вопросы и ответы помогут вам лучше понять особенности работы с переменными и типами данных в C# и избежать распространённых ошибок.