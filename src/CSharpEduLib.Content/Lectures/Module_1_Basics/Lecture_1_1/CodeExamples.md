# Лекция 1.1 — Примеры кода

Ниже приведены примеры, используемые в лекции 1.1. Каждый пример сопровождается кратким описанием и ожидаемым выводом.

## 1. Hello, World!
```csharp
using System;
class Program { static void Main(){ Console.WriteLine("Hello, World!"); } }
```
Ожидаемый вывод:
```
Hello, World!
```

## 2. Две строки
```csharp
using System;
class Program { static void Main(){ Console.WriteLine("Ivanov"); Console.WriteLine("Ivan"); } }
```
Ожидаемый вывод:
```
Ivanov
Ivan
```

## 3. Сумма чисел
```csharp
using System;
class Program { static void Main(){ Console.WriteLine(2+3); } }
```
Ожидаемый вывод:
```
5
```

## 4. Конкатенация строк
```csharp
using System;
class Program { static void Main(){ Console.WriteLine("Hello, " + "C#"); } }
```
Ожидаемый вывод:
```
Hello, C#
```

## 5. Экранирование кавычек
```csharp
using System;
class Program { static void Main(){ Console.WriteLine("\"Строка в кавычках\""); } }
```
Ожидаемый вывод:
```
"Строка в кавычках"
```

## 6. Перевод строки
```csharp
using System;
class Program { static void Main(){ Console.WriteLine("Первая строка\nВторая строка"); } }
```
Ожидаемый вывод:
```
Первая строка
Вторая строка
```

## 7. Табуляция
```csharp
using System;
class Program { static void Main(){ Console.WriteLine("Колонка1\tКолонка2"); } }
```
Ожидаемый вывод:
```
Колонка1	Колонка2
```

## 8. Форматированная строка
```csharp
using System;
class Program { static void Main(){ Console.WriteLine("Ответ: {0}", 42); } }
```
Ожидаемый вывод:
```
Ответ: 42
```

## 9. Интерполяция строк
```csharp
using System;
class Program { static void Main(){ int x=5; Console.WriteLine($"x={x}"); } }
```
Ожидаемый вывод:
```
x=5
```

## 10. Комментарии
```csharp
using System;
class Program { static void Main(){ // комментарий
 Console.WriteLine("Test"); /* многострочный 
 комментарий */ } }
```
Ожидаемый вывод:
```
Test
```

## 11. Ввод с клавиатуры
```csharp
using System;
class Program { static void Main(){ var name=Console.ReadLine(); Console.WriteLine("Hi, "+name+"!"); } }
```
(Ожидание ввода)

## 12. Приведение к числу
```csharp
using System;
class Program { static void Main(){ var s=Console.ReadLine(); int n=int.Parse(s); Console.WriteLine(n*n); } }
```
(Ожидание ввода)

## 13. TryParse
```csharp
using System;
class Program { static void Main(){ var s=Console.ReadLine(); if(int.TryParse(s, out var n)) Console.WriteLine(n*n); else Console.WriteLine("error"); } }
```

## 14. Несколько переменных
```csharp
using System;
class Program { static void Main(){ int a=2,b=3; Console.WriteLine(a+b); } }
```

## 15. Константы
```csharp
using System;
class Program { static void Main(){ const double PI=3.14159; Console.WriteLine(2*PI); } }
```

## 16. Типы данных — обзор
```csharp
using System;
class Program { static void Main(){ int i=1; double d=2.5; bool f=true; string s="str"; Console.WriteLine(i+" "+d+" "+f+" "+s); } }
```

## 17. Арифметика
```csharp
using System;
class Program { static void Main(){ Console.WriteLine((10-3)*2); } }
```

## 18. Остаток от деления
```csharp
using System;
class Program { static void Main(){ Console.WriteLine(10%3); } }
```

## 19. Приоритет операций
```csharp
using System;
class Program { static void Main(){ Console.WriteLine(2+3*4); } }
```

## 20. Скобки меняют приоритет
```csharp
using System;
class Program { static void Main(){ Console.WriteLine((2+3)*4); } }
```
