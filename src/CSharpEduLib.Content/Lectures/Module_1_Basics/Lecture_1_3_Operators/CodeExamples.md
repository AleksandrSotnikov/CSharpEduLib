# Примеры кода: Операторы и выражения

Ниже представлены 30 тщательно подобранных примеров, покрывающих арифметические операторы, сравнения, логические операторы, составные присваивания, приоритет и сочетания операторов.

## 1. Арифметика: базовые операции
```csharp
int a = 7, b = 3;
Console.WriteLine(a + b); // 10
Console.WriteLine(a - b); // 4
Console.WriteLine(a * b); // 21
Console.WriteLine(a / b); // 2 (целочисленное деление)
Console.WriteLine(a % b); // 1
```

## 2. Деление double
```csharp
double x = 7, y = 3;
Console.WriteLine(x / y); // 2.333333...
```

## 3. Инкремент/декремент (префикс/постфикс)
```csharp
int n = 5;
Console.WriteLine(++n); // 6 (префикс)
Console.WriteLine(n++); // 6 (постфикс), n станет 7
Console.WriteLine(n);   // 7
```

## 4. Операторы сравнения
```csharp
int c = 10, d = 20;
Console.WriteLine(c == d); // False
Console.WriteLine(c != d); // True
Console.WriteLine(c < d);  // True
Console.WriteLine(c >= d); // False
```

## 5. Логические операторы (short-circuit)
```csharp
bool p = true, q = false;
Console.WriteLine(p && q); // False
Console.WriteLine(p || q); // True
Console.WriteLine(!p);     // False
```

## 6. Составные присваивания
```csharp
int e = 10;
e += 5;  // 15
e -= 3;  // 12
e *= 2;  // 24
e /= 4;  // 6
e %= 5;  // 1
```

## 7. Приоритет операторов
```csharp
int result = 2 + 3 * 4;      // 14
int result2 = (2 + 3) * 4;   // 20
```

## 8. Комбинированные выражения
```csharp
int i = 2, j = 3, k = 4;
int r = i++ + ++j * k--; // разберите по шагам
```

## 9. Тернарный оператор
```csharp
int age = 18;
string access = age >= 18 ? "allowed" : "denied";
```

## 10. Сравнение double с эпсилон
```csharp
double v = 0.1 + 0.2;
bool eq = Math.Abs(v - 0.3) < 1e-10; // true
```

## 11. Побитовые операторы (для int)
```csharp
int m = 0b_0101;   // 5
int n2 = 0b_0011;  // 3
Console.WriteLine(m & n2); // 1
Console.WriteLine(m | n2); // 7
Console.WriteLine(m ^ n2); // 6
Console.WriteLine(~m);     // -6
Console.WriteLine(m << 1); // 10
Console.WriteLine(m >> 1); // 2
```

## 12. Логические vs побитовые
```csharp
bool a1 = false, b1 = true;
Console.WriteLine(a1 & b1);  // False (без short-circuit)
Console.WriteLine(a1 && b1); // False (short-circuit)
```

## 13. Приведение типов в выражениях
```csharp
int ii = 5; double dd = 2;
double rr = ii / dd; // 2.5, т.к. выражение в double
```

## 14. Переполнение и checked
```csharp
checked
{
    int x2 = int.MaxValue;
    // int y2 = x2 + 1; // OverflowException
}
```

## 15. Null-coalescing и условный доступ
```csharp
string? s = null;
string name = s ?? "guest";
int? len = s?.Length; // null
```

## 16. Сопоставление с образцом в выражениях
```csharp
object obj = 42;
string type = obj switch
{
    int n when n > 0 => "+int",
    int n when n < 0 => "-int",
    string str => "string",
    _ => "other"
};
```

## 17. Логические выражения с приоритетами
```csharp
bool res = true || false && false; // true (&& выше ||)
```

## 18. Комплексные присваивания
```csharp
int x3 = 1;
x3 += (x3 *= 2); // x3 = 1 + (1*2) = 3
```

## 19. Тернарный оператор с вложенностью
```csharp
int score = 85;
string grade = score >= 90 ? "A" : score >= 80 ? "B" : score >= 70 ? "C" : "D";
```

## 20. Округление и математика
```csharp
double v2 = 2.675;
Console.WriteLine(Math.Round(v2, 2));
```

## 21. Равенство ссылок vs значений (string)
```csharp
string a2 = "abc";
string b2 = string.Join("", new[]{"a","b","c"});
Console.WriteLine(a2 == b2);        // True (значение)
Console.WriteLine(object.ReferenceEquals(a2, b2)); // может быть False
```

## 22. Присваивание и выражение
```csharp
int t; Console.WriteLine(t = 5); // 5
```

## 23. Выражения с побочными эффектами
```csharp
int z = 0;
if (z++ == 0 && ++z == 2) { /* ... */}
```

## 24. Приоритет с унарными операторами
```csharp
int u = 1;
int r2 = -u++ + ++u; // разберите пошагово
```

## 25. Деление по модулю для отрицательных
```csharp
Console.WriteLine(-7 % 3); // -1 в C#
```

## 26. Смешение типов в выражениях
```csharp
int i3 = 5; decimal m3 = 2m;
decimal r3 = i3 / m3; // decimal
```

## 27. Присваивание с null-coalescing
```csharp
string? s2 = null;
s2 ??= "default"; // s2 = "default"
```

## 28. Комбинированные логические проверки
```csharp
int x4 = 5, y4 = 10, z4 = 15;
bool ok = (x4 < y4) && (y4 < z4) || (z4 == 0);
```

## 29. Тернарный + null-coalescing
```csharp
string? input = null;
string res2 = (input?.Length ?? 0) > 0 ? input : "empty";
```

## 30. Итоговое комплексное выражение
```csharp
int a5 = 2, b5 = 3, c5 = 4;
int r5 = (a5++ * --b5) + (c5 >> 1) - (a5 & b5);
```
