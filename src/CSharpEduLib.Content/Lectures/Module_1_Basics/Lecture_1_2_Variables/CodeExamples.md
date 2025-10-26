# Примеры кода — Лекция 1.2 (расширенная версия)

Ниже представлены 12 из 25 запланированных примеров с краткими пояснениями.

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
int i = 42; double x = i; int j = (int)x; // сужающее приведение
```

## ex04 — Проверка переполнения
```csharp
checked
{
    int max = int.MaxValue;
    // int overflow = max + 1; // вызовет OverflowException
}
```

## ex05 — unchecked (без выброса исключения)
```csharp
unchecked
{
    int max = int.MaxValue;
    int wrap = max + 1; // переполнение с переходом через границу
}
```

## ex06 — Parse и TryParse
```csharp
int a = int.Parse("123");
bool ok = int.TryParse("123", out int b);
```

## ex07 — Преобразование string → double с культурой
```csharp
var ci = new System.Globalization.CultureInfo("en-US");
double v = double.Parse("3.14", ci);
```

## ex08 — Константы
```csharp
const double Pi = 3.14159; // требуется инициализация во время компиляции
```

## ex09 — Значения по умолчанию
```csharp
int iDefault = default; // 0
bool bDefault = default; // false
```

## ex10 — Тип char
```csharp
char c1 = 'A'; char c2 = (char)65; // 'A'
```

## ex11 — Интерполяция строк
```csharp
int n = 5; string s = $"n = {n}";
```

## ex12 — Преобразования decimal
```csharp
decimal m = 10.5m; double d2 = (double)m; decimal m2 = (decimal)d2;
```
