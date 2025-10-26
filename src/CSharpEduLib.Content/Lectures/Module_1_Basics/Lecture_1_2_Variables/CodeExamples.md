# Примеры кода — Лекция 1.2 (25/25)

Ниже представлены 25 примеров с краткими пояснениями и ожидаемым результатом (где уместно).

## ex01 — Объявление переменных
```csharp
int a = 10; double d = 3.14; string s = "text"; bool ok = true; char ch = 'A';
```

## ex02 — Min/Max для типов
```csharp
int min = int.MinValue; int max = int.MaxValue; long lmin = long.MinValue; long lmax = long.MaxValue;
```

## ex03 — Неявные/явные приведения
```csharp
int i = 42; double x = i; int j = (int)x; // 42
```

## ex04 — checked переполнение
```csharp
checked { int max = int.MaxValue; /* int overflow = max + 1; */ }
```

## ex05 — unchecked переполнение
```csharp
unchecked { int max = int.MaxValue; int wrap = max + 1; }
```

## ex06 — Parse/TryParse
```csharp
int a = int.Parse("123"); bool ok = int.TryParse("123", out int b);
```

## ex07 — Культура для double
```csharp
var ci = new System.Globalization.CultureInfo("en-US"); double v = double.Parse("3.14", ci);
```

## ex08 — Константы
```csharp
const double Pi = 3.14159;
```

## ex09 — Значения по умолчанию
```csharp
int iDefault = default; bool bDefault = default;
```

## ex10 — Тип char
```csharp
char c1 = 'A'; char c2 = (char)65; // 'A'
```

## ex11 — Интерполяция строк
```csharp
int n = 5; string s = $"n = {n}"; // n = 5
```

## ex12 — decimal конверсии
```csharp
decimal m = 10.5m; double d2 = (double)m; decimal m2 = (decimal)d2;
```

## ex13 — Конвертация через Convert
```csharp
int i = Convert.ToInt32(3.9); // 4 (banker's rounding may apply)
```

## ex14 — TryParse с культурой
```csharp
var ci = new System.Globalization.CultureInfo("ru-RU");
bool ok = double.TryParse("3,14", NumberStyles.Float, ci, out double val);
```

## ex15 — Boxing/Unboxing
```csharp
int x = 10; object bx = x; int y = (int)bx; // unbox
```

## ex16 — var и явные типы
```csharp
var sum = 1 + 2; int s = sum; // var выведет int
```

## ex17 — default(T)
```csharp
DateTime dt = default; // 01.01.0001 00:00:00
```

## ex18 — checked для умножения
```csharp
checked { int big = 50_000; int p = big * big; }
```

## ex19 — Parse для bool/char
```csharp
bool b = bool.Parse("True"); char c = char.Parse("A");
```

## ex20 — TryParse для Enum
```csharp
enum Color { Red, Green, Blue }
bool ok = Enum.TryParse("Green", out Color c);
```

## ex21 — Строковое форматирование чисел
```csharp
double v = 1234.56; string s1 = v.ToString("F2"); // 1234.56
```

## ex22 — Инкремент/декремент типов
```csharp
int a1 = 1; a1++; --a1; // снова 1
```

## ex23 — Bounds для массивов типов
```csharp
int[] arr = new int[3]; int len = arr.Length; // 3
```

## ex24 — Nullable типы
```csharp
int? ni = null; bool has = ni.HasValue; // false
```

## ex25 — Исчерпывающее приведение через Convert
```csharp
string s = "255"; byte b = Convert.ToByte(s); // 255
```
