# Лекция 1.1 — Примеры кода

Ниже приведены примеры, используемые в лекции 1.1. Каждый пример сопровождается кратким описанием и ожидаемым выводом.

## 1. Минимальная программа Hello, World!

Самая простая программа на C#, которая выводит классическое приветствие.

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

**Ожидаемый вывод:**
```
Hello, World!
```

---

## 2. Вывод имени и фамилии в разные строки

Программа демонстрирует вывод нескольких строк текста.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine("Иванов"); 
        Console.WriteLine("Иван"); 
    } 
}
```

**Ожидаемый вывод:**
```
Иванов
Иван
```

---

## 3. Арифметические вычисления

Программа выполняет сложение двух чисел и выводит результат.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine(2 + 3); 
    } 
}
```

**Ожидаемый вывод:**
```
5
```

---

## 4. Конкатенация строк

Пример соединения двух строк с помощью оператора `+`.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine("Hello, " + "C#"); 
    } 
}
```

**Ожидаемый вывод:**
```
Hello, C#
```

---

## 5. Экранирование кавычек

Пример вывода текста, содержащего кавычки.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine("\"Строка в кавычках\""); 
    } 
}
```

**Ожидаемый вывод:**
```
"Строка в кавычках"
```

---

## 6. Перевод строки

Использование специального символа `\n` для перехода на новую строку.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine("Первая строка\nВторая строка"); 
    } 
}
```

**Ожидаемый вывод:**
```
Первая строка
Вторая строка
```

---

## 7. Табуляция

Пример использования символа табуляции `\t` для создания ровных колонок.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine("Колонка1\tКолонка2"); 
    } 
}
```

**Ожидаемый вывод:**
```
Колонка1	Колонка2
```

---

## 8. Форматирование с заполнителями

Пример использования заполнителей `{0}` для вставки значений в строку.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine("Ответ: {0}", 42); 
    } 
}
```

**Ожидаемый вывод:**
```
Ответ: 42
```

---

## 9. Интерполяция строк

Пример современного способа форматирования строк с помощью символа `$`.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        int x = 5; 
        Console.WriteLine($"x = {x}"); 
    } 
}
```

**Ожидаемый вывод:**
```
x = 5
```

---

## 10. Комментарии в коде

Пример использования однострочных и многострочных комментариев.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        // Это однострочный комментарий
        Console.WriteLine("Test");
        
        /* А это многострочный
           комментарий */
    } 
}
```

**Ожидаемый вывод:**
```
Test
```

---

## 11. Ввод данных с клавиатуры

Программа запрашивает у пользователя имя и выводит персонализированное приветствие.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine("Введите ваше имя:");
        string name = Console.ReadLine();
        Console.WriteLine($"Hi, {name}!"); 
    } 
}
```

**Ожидаемый вывод (при вводе "Алекс"):**
```
Введите ваше имя:
Алекс
Hi, Алекс!
```

---

## 12. Приведение строки к числу

Пример преобразования введенной строки в число и вычисления квадрата.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine("Введите число:");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        Console.WriteLine($"Квадрат числа: {number * number}"); 
    } 
}
```

**Ожидаемый вывод (при вводе "7"):**
```
Введите число:
7
Квадрат числа: 49
```

---

## 13. Безопасное преобразование с TryParse

Пример безопасного преобразования строки в число с обработкой ошибок.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
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
    } 
}
```

**Ожидаемый вывод (при вводе "5"):**
```
Введите число:
5
Квадрат числа: 25
```

**Ожидаемый вывод (при вводе "abc"):**
```
Введите число:
abc
Ошибка: введено не число!
```

---

## 14. Объявление нескольких переменных одновременно

Пример объявления нескольких переменных одного типа в одной строке.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        int a = 2, b = 3;
        Console.WriteLine(a + b); 
    } 
}
```

**Ожидаемый вывод:**
```
5
```

---

## 15. Использование констант

Пример определения и использования константы.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        const double PI = 3.14159;
        Console.WriteLine($"Окружность с радиусом 1: {2 * PI}"); 
    } 
}
```

**Ожидаемый вывод:**
```
Окружность с радиусом 1: 6.28318
```

---

## 16. Обзор основных типов данных

Программа демонстрирует работу с различными типами данных.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        int integerNumber = 1;
        double doubleNumber = 2.5;
        bool booleanValue = true;
        string textString = "Hello";
        
        Console.WriteLine($"{integerNumber} {doubleNumber} {booleanValue} {textString}"); 
    } 
}
```

**Ожидаемый вывод:**
```
1 2.5 True Hello
```

---

## 17. Сложное арифметическое выражение

Пример вычисления сложного арифметического выражения.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine((10 - 3) * 2); 
    } 
}
```

**Ожидаемый вывод:**
```
14
```

---

## 18. Операция остатка от деления

Пример использования оператора `%` для получения остатка от деления.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine(10 % 3); 
    } 
}
```

**Ожидаемый вывод:**
```
1
```

---

## 19. Приоритет операций

Пример демонстрации приоритета арифметических операций.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine(2 + 3 * 4); 
    } 
}
```

**Ожидаемый вывод:**
```
14
```

*Пояснение: сначала выполняется умножение (3 * 4 = 12), а затем сложение (2 + 12 = 14)*

---

## 20. Изменение приоритета с помощью скобок

Пример использования скобок для изменения порядка вычислений.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.WriteLine((2 + 3) * 4); 
    } 
}
```

**Ожидаемый вывод:**
```
20
```

*Пояснение: скобки принуждают сначала выполнить сложение (2 + 3 = 5), а затем умножение (5 * 4 = 20)*

---

## 21. Практический пример: Калькулятор периметра прямоугольника

Программа для вычисления периметра прямоугольника по введенным длине и ширине.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.Write("Введите длину прямоугольника: ");
        double length = double.Parse(Console.ReadLine());
        
        Console.Write("Введите ширину прямоугольника: ");
        double width = double.Parse(Console.ReadLine());
        
        double perimeter = 2 * (length + width);
        
        Console.WriteLine($"Периметр прямоугольника: {perimeter}"); 
    } 
}
```

**Ожидаемый вывод (при вводе длины "5" и ширины "3"):**
```
Введите длину прямоугольника: 5
Введите ширину прямоугольника: 3
Периметр прямоугольника: 16
```

---

## 22. Практический пример: Конвертер температуры

Программа для перевода температуры из градусов Цельсия в Фаренгейты.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        Console.Write("Введите температуру в градусах Цельсия: ");
        double celsius = double.Parse(Console.ReadLine());
        
        double fahrenheit = celsius * 9 / 5 + 32;
        
        Console.WriteLine($"{celsius}°C = {fahrenheit}°F"); 
    } 
}
```

**Ожидаемый вывод (при вводе "25"):**
```
Введите температуру в градусах Цельсия: 25
25°C = 77°F
```

---

## 23. Операции инкремента и декремента

Пример использования операторов увеличения и уменьшения на единицу.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        int number = 5;
        
        Console.WriteLine($"Начальное значение: {number}");
        Console.WriteLine($"Постфиксный инкремент: {number++}");
        Console.WriteLine($"После инкремента: {number}");
        Console.WriteLine($"Префиксный инкремент: {++number}");
        Console.WriteLine($"Декремент: {--number}");
    } 
}
```

**Ожидаемый вывод:**
```
Начальное значение: 5
Постфиксный инкремент: 5
После инкремента: 6
Префиксный инкремент: 7
Декремент: 6
```

---

## 24. Математические функции

Пример использования библиотеки Math для математических вычислений.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        double number = 16.7;
        
        Console.WriteLine($"Квадратный корень из 16: {Math.Sqrt(16)}");
        Console.WriteLine($"Округление {number}: {Math.Round(number)}");
        Console.WriteLine($"Максимум из 5 и 8: {Math.Max(5, 8)}");
        Console.WriteLine($"2 в степени 3: {Math.Pow(2, 3)}"); 
    } 
}
```

**Ожидаемый вывод:**
```
Квадратный корень из 16: 4
Округление 16.7: 17
Максимум из 5 и 8: 8
2 в степени 3: 8
```

---

## 25. Практический пример: Полноценная программа опроса

Комплексная программа, объединяющая все изученные концепции.

```csharp
using System;

class Program 
{ 
    static void Main()
    { 
        // Приветствие
        Console.WriteLine("=".PadLeft(50, '='));
        Console.WriteLine("		ЛИЧНАЯ ИНФОРМАЦИЯ");
        Console.WriteLine("=".PadLeft(50, '='));
        
        // Сбор информации
        Console.Write("Ваше имя: ");
        string name = Console.ReadLine();
        
        Console.Write("Ваш возраст: ");
        int age = int.Parse(Console.ReadLine());
        
        Console.Write("Ваш рост (в сантиметрах): ");
        double height = double.Parse(Console.ReadLine());
        
        // Вычисления
        int yearOfBirth = DateTime.Now.Year - age;
        double heightInMeters = height / 100;
        
        // Вывод результатов
        Console.WriteLine("\n" + "-".PadLeft(50, '-'));
        Console.WriteLine("РЕЗУЛЬТАТЫ ОПРОСА");
        Console.WriteLine("-".PadLeft(50, '-'));
        Console.WriteLine($"Привет, {name}!");
        Console.WriteLine($"Возраст: {age} лет");
        Console.WriteLine($"Рост: {height} см ({heightInMeters:F2} м)");
        Console.WriteLine($"Год рождения: {yearOfBirth} г.");
        Console.WriteLine($"Через 10 лет вам будет: {age + 10} лет");
        Console.WriteLine("-".PadLeft(50, '-'));
        
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    } 
}
```

**Ожидаемый вывод (при вводе имени "Александр", возраста "25" и роста "175"):**
```
==================================================
		ЛИЧНАЯ ИНФОРМАЦИЯ
==================================================
Ваше имя: Александр
Ваш возраст: 25
Ваш рост (в сантиметрах): 175

--------------------------------------------------
РЕЗУЛЬТАТЫ ОПРОСА
--------------------------------------------------
Привет, Александр!
Возраст: 25 лет
Рост: 175 см (1.75 м)
Год рождения: 2000 г.
Через 10 лет вам будет: 35 лет
--------------------------------------------------

Нажмите любую клавишу для выхода...
```

---

*Примечание: Каждый пример может быть сохранен как отдельная программа в файле .cs и скомпилирован для выполнения.*