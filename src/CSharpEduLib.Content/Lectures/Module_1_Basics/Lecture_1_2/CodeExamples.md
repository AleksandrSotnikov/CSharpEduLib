# Лекция 1.2 — Примеры кода (20)

1) int
```csharp
int n = 5; Console.WriteLine(n);
```
2) double
```csharp
double x = 2.5; Console.WriteLine(x);
```
3) bool
```csharp
bool ok = true; Console.WriteLine(ok);
```
4) char
```csharp
char c = 'A'; Console.WriteLine(c);
```
5) string
```csharp
string s = "Hello"; Console.WriteLine(s);
```
6) var (неявная типизация)
```csharp
var y = 10; Console.WriteLine(y.GetType().Name);
```
7) Явное приведение
```csharp
double d = 9.99; int i = (int)d; Console.WriteLine(i);
```
8) Parse
```csharp
int a = int.Parse("42"); Console.WriteLine(a);
```
9) TryParse
```csharp
if (int.TryParse("x", out var v)) Console.WriteLine(v); else Console.WriteLine("error");
```
10) Convert
```csharp
Console.WriteLine(Convert.ToInt32(3.7));
```
11) Форматирование
```csharp
int k=7; Console.WriteLine($"k={{k}}");
```
12) Интерполяция с выражением
```csharp
int u=3; Console.WriteLine($"u^2={u*u}");
```
13) Десятичные
```csharp
decimal m=10.5m; Console.WriteLine(m);
```
14) Символы и коды
```csharp
char ch='b'; Console.WriteLine((int)ch);
```
15) Экранирование
```csharp
Console.WriteLine("\"quote\"");
```
16) Конкатенация
```csharp
Console.WriteLine("Hello"+" "+"World");
```
17) Арифметика типов
```csharp
int p=2; double q=3; Console.WriteLine(p+q);
```
18) Приведение вверх
```csharp
int t=1; double r=t; Console.WriteLine(r);
```
19) Приведение вниз (осторожно)
```csharp
object obj = 5; int z=(int)obj; Console.WriteLine(z);
```
20) Ошибка приведения
```csharp
object o = "str"; // int z=(int)o; // ошибка
Console.WriteLine("ok");
```
