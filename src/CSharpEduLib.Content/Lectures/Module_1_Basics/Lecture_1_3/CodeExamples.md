# Лекция 1.3 — Примеры кода (операторы и выражения)

Ниже представлены более 20 примеров, иллюстрирующих операторы, приоритет, ассоциативность, комбинированные и побитовые операции.

## 1. Унарные + и -

Демонстрация унарных арифметических операторов.

```csharp
using System;

class Program
{
    static void Main()
    {
        int x = 5;
        Console.WriteLine(+x);
        Console.WriteLine(-x);
    }
}
```

**Ожидаемый вывод:**
```
5
-5
```

---

## 2. Префиксный и постфиксный инкремент

Различие между префиксным и постфиксным инкрементом.

```csharp
using System;

class Program
{
    static void Main()
    {
        int a = 5;
        Console.WriteLine(++a);
        Console.WriteLine(a++);
        Console.WriteLine(a);
    }
}
```

**Ожидаемый вывод:**
```
6
6
7
```

---

## 3. Бинарная арифметика

Основные арифметические операции с целыми числами.

```csharp
using System;

class Program
{
    static void Main()
    {
        int a = 10, b = 3;
        Console.WriteLine(a + b);
        Console.WriteLine(a - b);
        Console.WriteLine(a * b);
        Console.WriteLine(a / b);
        Console.WriteLine(a % b);
    }
}
```

**Ожидаемый вывод:**
```
13
7
30
3
1
```

---

## 4. Деление с преобразованием типов

Различие между целочисленным и вещественным делением.

```csharp
using System;

class Program
{
    static void Main()
    {
        int a = 7, b = 3;
        Console.WriteLine((double)a / b);
    }
}
```

**Ожидаемый вывод:**
```
2.3333333333333335
```

---

## 5. Приоритет операций

Демонстрация приоритета умножения над сложением.

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(2 + 3 * 4);
        Console.WriteLine((2 + 3) * 4);
    }
}
```

**Ожидаемый вывод:**
```
14
20
```

---

## 6. Ассоциативность вычитания

Левая ассоциативность арифметических операций.

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(10 - 5 - 2);
    }
}
```

**Ожидаемый вывод:**
```
3
```

---

## 7. Комбинированные операторы

Последовательное применение комбинированных операторов.

```csharp
using System;

class Program
{
    static void Main()
    {
        int x = 10;
        x += 5;
        x *= 2;
        x -= 4;
        Console.WriteLine(x);
    }
}
```

**Ожидаемый вывод:**
```
26
```

---

## 8. Комбинированные с возвратом значения

Комбинированные операторы возвращают новое значение переменной.

```csharp
using System;

class Program
{
    static void Main()
    {
        int a = 5;
        int b = (a += 3);
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}
```

**Ожидаемый вывод:**
```
8
8
```

---

## 9. Сравнение чисел

Основные операторы сравнения.

```csharp
using System;

class Program
{
    static void Main()
    {
        int a = 5, b = 7;
        Console.WriteLine(a < b);
        Console.WriteLine(a == b);
        Console.WriteLine(a != b);
    }
}
```

**Ожидаемый вывод:**
```
True
False
True
```

---

## 10. Логические операции

Основные логические операторы с булевыми значениями.

```csharp
using System;

class Program
{
    static void Main()
    {
        bool p = true, q = false;
        Console.WriteLine(p && q);
        Console.WriteLine(p || q);
        Console.WriteLine(p ^ q);
        Console.WriteLine(!p);
    }
}
```

**Ожидаемый вывод:**
```
False
True
True
False
```

---

## 11. Short-circuit evaluation

Демонстрация короткого замыкания логических операций.

```csharp
using System;

class Program
{
    static void Main()
    {
        int y = 0;
        bool r1 = (y != 0) && (10 / y > 1);
        bool r2 = (y == 0) || (10 / y > 1);
        Console.WriteLine(r1);
        Console.WriteLine(r2);
    }
}
```

**Ожидаемый вывод:**
```
False
True
```

---

## 12. Побитовое И, ИЛИ, XOR

Основные побитовые операции.

```csharp
using System;

class Program
{
    static void Main()
    {
        int a = 0b1010; // 10
        int b = 0b1100; // 12
        Console.WriteLine(a & b);
        Console.WriteLine(a | b);
        Console.WriteLine(a ^ b);
    }
}
```

**Ожидаемый вывод:**
```
8
14
6
```

---

## 13. Побитовая инверсия

Операция инверсии всех бит числа.

```csharp
using System;

class Program
{
    static void Main()
    {
        int a = 10;
        Console.WriteLine(~a);
    }
}
```

**Ожидаемый вывод:**
```
-11
```

---

## 14. Побитовые сдвиги

Сдвиг битов влево и вправо.

```csharp
using System;

class Program
{
    static void Main()
    {
        int a = 10;
        Console.WriteLine(a << 2);
        Console.WriteLine(a >> 1);
    }
}
```

**Ожидаемый вывод:**
```
40
5
```

---

## 15. Проверка четности битом

Использование побитового И для проверки четности.

```csharp
using System;

class Program
{
    static void Main()
    {
        int n = 15;
        Console.WriteLine((n & 1) == 0);
    }
}
```

**Ожидаемый вывод:**
```
False
```

---

## 16. Маски прав доступа

Работа с битовыми флагами для прав доступа.

```csharp
using System;

class Program
{
    static void Main()
    {
        const int READ = 1;
        const int WRITE = 2;
        const int EXEC = 4;
        
        int perms = READ | WRITE;
        Console.WriteLine((perms & READ) != 0);
        Console.WriteLine((perms & EXEC) != 0);
        
        perms |= EXEC;
        Console.WriteLine((perms & EXEC) != 0);
    }
}
```

**Ожидаемый вывод:**
```
True
False
True
```

---

## 17. Тернарный оператор

Простое условное выражение с тернарным оператором.

```csharp
using System;

class Program
{
    static void Main()
    {
        int a = 10, b = 5;
        int max = a > b ? a : b;
        Console.WriteLine(max);
    }
}
```

**Ожидаемый вывод:**
```
10
```

---

## 18. Вложенный тернарный

Система оценок с вложенными тернарными операторами.

```csharp
using System;

class Program
{
    static void Main()
    {
        int score = 85;
        string grade = score >= 90 ? "A" : score >= 80 ? "B" : "C";
        Console.WriteLine(grade);
    }
}
```

**Ожидаемый вывод:**
```
B
```

---

## 19. Операторы typeof и is

Работа с типами данных во время выполнения.

```csharp
using System;

class Program
{
    static void Main()
    {
        object o = "Hello";
        Console.WriteLine(o is string);
        Console.WriteLine(typeof(int).Name);
    }
}
```

**Ожидаемый вывод:**
```
True
Int32
```

---

## 20. Ассоциативность присваивания

Правая ассоциативность операторов присваивания.

```csharp
using System;

class Program
{
    static void Main()
    {
        int x, y, z;
        x = y = z = 3;
        Console.WriteLine(x);
        Console.WriteLine(y);
        Console.WriteLine(z);
    }
}
```

**Ожидаемый вывод:**
```
3
3
3
```

---

## 21. Комбинированные побитовые

Последовательность побитовых операций с присваиванием.

```csharp
using System;

class Program
{
    static void Main()
    {
        int f = 0b1010; // 10
        f &= 0b1100;    // 8
        f |= 0b0011;    // 11
        f ^= 0b1111;    // 4
        Console.WriteLine(f);
    }
}
```

**Ожидаемый вывод:**
```
4
```

---

## 22. Контроль переполнения checked

Обнаружение переполнения арифметических операций.

```csharp
using System;

class Program
{
    static void Main()
    {
        checked
        {
            try
            {
                int m = int.MaxValue;
                m += 1;
                Console.WriteLine(m);
            }
            catch (OverflowException)
            {
                Console.WriteLine("overflow");
            }
        }
    }
}
```

**Ожидаемый вывод:**
```
overflow
```

---

## 23. Приоритет логических операторов

Приоритет && выше чем у ||.

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(true || false && false);
        Console.WriteLine((true || false) && false);
    }
}
```

**Ожидаемый вывод:**
```
True
False
```

---

## 24. Корректное сравнение double

Сравнение чисел с плавающей точкой с учетом погрешности.

```csharp
using System;

class Program
{
    static void Main()
    {
        double d = 0.1 + 0.2;
        Console.WriteLine(Math.Abs(d - 0.3) < 1e-9);
    }
}
```

**Ожидаемый вывод:**
```
True
```

---

## 25. Строковая конкатенация и +=

Комбинированный оператор для строк.

```csharp
using System;

class Program
{
    static void Main()
    {
        string s = "Hello";
        s += ", ";
        s += "World";
        Console.WriteLine(s);
    }
}
```

**Ожидаемый вывод:**
```
Hello, World
```