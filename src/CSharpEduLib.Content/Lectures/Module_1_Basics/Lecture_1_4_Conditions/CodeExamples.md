# Примеры кода: Условные конструкции

## 1. Простой if

```csharp
int age = 18;
if (age >= 18)
{
    Console.WriteLine("Вы совершеннолетний!");
}
// Вывод: Вы совершеннолетний!
```

## 2. Простой if-else

```csharp
int number = 7;
if (number % 2 == 0)
{
    Console.WriteLine("Число четное");
}
else
{
    Console.WriteLine("Число нечетное");
}
// Вывод: Число нечетное
```

## 3. if-else if-else

```csharp
int score = 85;
if (score >= 90)
{
    Console.WriteLine("Оценка: 5");
}
else if (score >= 80)
{
    Console.WriteLine("Оценка: 4");
}
else if (score >= 70)
{
    Console.WriteLine("Оценка: 3");
}
else if (score >= 60)
{
    Console.WriteLine("Оценка: 2");
}
else
{
    Console.WriteLine("Оценка: 1");
}
// Вывод: Оценка: 4
```

## 4. Сложные логические условия

```csharp
int temperature = 25;
bool isRaining = false;

if (temperature > 20 && !isRaining)
{
    Console.WriteLine("Отличный день для прогулки!");
}
else if (temperature > 20 && isRaining)
{
    Console.WriteLine("Тепло, но дождь");
}
else
{
    Console.WriteLine("Не очень подходящая погода");
}
// Вывод: Отличный день для прогулки!
```

## 5. Тернарный оператор (простой пример)

```csharp
int x = 10;
string result = x > 5 ? "Больше 5" : "Меньше или равно 5";
Console.WriteLine(result);
// Вывод: Больше 5
```

## 6. Тернарный оператор (вложенный)

```csharp
int score = 75;
string grade = score >= 90 ? "A" : score >= 80 ? "B" : score >= 70 ? "C" : "D";
Console.WriteLine($"Оценка: {grade}");
// Вывод: Оценка: C
```

## 7. Классический switch

```csharp
string dayOfWeek = "Monday";
switch (dayOfWeek)
{
    case "Monday":
        Console.WriteLine("Понедельник - начало недели");
        break;
    case "Friday":
        Console.WriteLine("Пятница - конец рабочей недели");
        break;
    case "Saturday":
    case "Sunday":
        Console.WriteLine("Выходные!");
        break;
    default:
        Console.WriteLine("Обычный день");
        break;
}
// Вывод: Понедельник - начало недели
```

## 8. Switch с числами

```csharp
int month = 12;
switch (month)
{
    case 12:
    case 1:
    case 2:
        Console.WriteLine("Зима");
        break;
    case 3:
    case 4:
    case 5:
        Console.WriteLine("Весна");
        break;
    case 6:
    case 7:
    case 8:
        Console.WriteLine("Лето");
        break;
    case 9:
    case 10:
    case 11:
        Console.WriteLine("Осень");
        break;
    default:
        Console.WriteLine("Некорректный месяц");
        break;
}
// Вывод: Зима
```

## 9. Switch expression (C# 8.0+)

```csharp
int dayNumber = 1;
string dayName = dayNumber switch
{
    1 => "Понедельник",
    2 => "Вторник",
    3 => "Среда",
    4 => "Четверг",
    5 => "Пятница",
    6 => "Суббота",
    7 => "Воскресенье",
    _ => "Неизвестный день"
};
Console.WriteLine(dayName);
// Вывод: Понедельник
```

## 10. Проверка строки на null или пустоту

```csharp
string userName = "";
if (string.IsNullOrEmpty(userName))
{
    Console.WriteLine("Пользователь не указал имя");
}
else
{
    Console.WriteLine($"Привет, {userName}!");
}
// Вывод: Пользователь не указал имя
```

## 11. Проверка диапазона

```csharp
int value = 50;
if (value >= 1 && value <= 100)
{
    Console.WriteLine("Значение в допустимом диапазоне");
}
else
{
    Console.WriteLine("Значение вне диапазона");
}
// Вывод: Значение в допустимом диапазоне
```

## 12. Логика булевых переменных

```csharp
bool hasPermission = true;
bool isLoggedIn = false;

if (hasPermission && isLoggedIn)
{
    Console.WriteLine("Доступ разрешен");
}
else if (!isLoggedIn)
{
    Console.WriteLine("Необходимо войти в систему");
}
else if (!hasPermission)
{
    Console.WriteLine("Нет прав доступа");
}
// Вывод: Необходимо войти в систему
```

## 13. Калькулятор на switch

```csharp
double num1 = 10;
double num2 = 3;
char operation = '/';
double result = 0;
bool validOperation = true;

switch (operation)
{
    case '+':
        result = num1 + num2;
        break;
    case '-':
        result = num1 - num2;
        break;
    case '*':
        result = num1 * num2;
        break;
    case '/':
        if (num2 != 0)
            result = num1 / num2;
        else
        {
            Console.WriteLine("Ошибка: деление на ноль!");
            validOperation = false;
        }
        break;
    default:
        Console.WriteLine("Неизвестная операция!");
        validOperation = false;
        break;
}

if (validOperation)
    Console.WriteLine($"Результат: {result:F2}");
// Вывод: Результат: 3.33
```

## 14. Проверка возрастных категорий

```csharp
int age = 16;
string category;

if (age < 13)
    category = "Ребенок";
else if (age < 20)
    category = "Подросток";
else if (age < 60)
    category = "Взрослый";
else
    category = "Пенсионер";

Console.WriteLine($"Возрастная категория: {category}");
// Вывод: Возрастная категория: Подросток
```

## 15. Проверка множественных условий

```csharp
int hour = 14;
string greeting;

if (hour >= 5 && hour < 12)
    greeting = "Доброе утро!";
else if (hour >= 12 && hour < 17)
    greeting = "Добрый день!";
else if (hour >= 17 && hour < 22)
    greeting = "Добрый вечер!";
else
    greeting = "Доброй ночи!";

Console.WriteLine(greeting);
// Вывод: Добрый день!
```

## 16. Проверка символа

```csharp
char symbol = 'A';

if (char.IsLetter(symbol))
{
    if (char.IsUpper(symbol))
        Console.WriteLine("Символ - заглавная буква");
    else
        Console.WriteLine("Символ - строчная буква");
}
else if (char.IsDigit(symbol))
{
    Console.WriteLine("Символ - цифра");
}
else
{
    Console.WriteLine("Символ - специальный знак");
}
// Вывод: Символ - заглавная буква
```

## 17. Оптимизация с early return

```csharp
int CheckNumber(int number)
{
    if (number < 0)
        return -1; // отрицательное
    
    if (number == 0)
        return 0; // ноль
    
    return 1; // положительное
}

int result = CheckNumber(-5);
Console.WriteLine($"Результат: {result}");
// Вывод: Результат: -1
```

## 18. Switch с enum

```csharp
enum Status
{
    Active,
    Inactive,
    Pending,
    Suspended
}

Status userStatus = Status.Pending;

string message = userStatus switch
{
    Status.Active => "Пользователь активен",
    Status.Inactive => "Пользователь неактивен",
    Status.Pending => "Пользователь ожидает подтверждения",
    Status.Suspended => "Пользователь заблокирован",
    _ => "Неизвестный статус"
};

Console.WriteLine(message);
// Вывод: Пользователь ожидает подтверждения
```

## 19. Проверка пароля

```csharp
string password = "MyPass123";
bool isValid = true;

if (password.Length < 8)
{
    Console.WriteLine("Пароль слишком короткий");
    isValid = false;
}

if (!password.Any(char.IsDigit))
{
    Console.WriteLine("Пароль должен содержать цифры");
    isValid = false;
}

if (!password.Any(char.IsUpper))
{
    Console.WriteLine("Пароль должен содержать заглавные буквы");
    isValid = false;
}

if (isValid)
    Console.WriteLine("Пароль корректный!");
// Вывод: Пароль корректный!
```

## 20. Сортировка трех чисел

```csharp
int a = 5, b = 2, c = 8;
int first, second, third;

if (a >= b && a >= c)
{
    first = a;
    if (b >= c)
    {
        second = b;
        third = c;
    }
    else
    {
        second = c;
        third = b;
    }
}
else if (b >= a && b >= c)
{
    first = b;
    if (a >= c)
    {
        second = a;
        third = c;
    }
    else
    {
        second = c;
        third = a;
    }
}
else
{
    first = c;
    if (a >= b)
    {
        second = a;
        third = b;
    }
    else
    {
        second = b;
        third = a;
    }
}

Console.WriteLine($"По убыванию: {first}, {second}, {third}");
// Вывод: По убыванию: 8, 5, 2
```

## 21. Проверка года на високосность

```csharp
int year = 2024;
bool isLeapYear;

if (year % 400 == 0)
    isLeapYear = true;
else if (year % 100 == 0)
    isLeapYear = false;
else if (year % 4 == 0)
    isLeapYear = true;
else
    isLeapYear = false;

Console.WriteLine(isLeapYear ? $"{year} - високосный год" : $"{year} - обычный год");
// Вывод: 2024 - високосный год
```

## 22. Определение квадранта координат

```csharp
int x = 3, y = -2;
string quadrant;

if (x > 0 && y > 0)
    quadrant = "I квадрант";
else if (x < 0 && y > 0)
    quadrant = "II квадрант";
else if (x < 0 && y < 0)
    quadrant = "III квадрант";
else if (x > 0 && y < 0)
    quadrant = "IV квадрант";
else if (x == 0 && y != 0)
    quadrant = "На оси Y";
else if (x != 0 && y == 0)
    quadrant = "На оси X";
else
    quadrant = "В начале координат";

Console.WriteLine($"Точка ({x}, {y}) находится в: {quadrant}");
// Вывод: Точка (3, -2) находится в: IV квадрант
```

## 23. Проверка треугольника

```csharp
int side1 = 3, side2 = 4, side3 = 5;

if (side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1)
{
    if (side1 == side2 && side2 == side3)
        Console.WriteLine("Равносторонний треугольник");
    else if (side1 == side2 || side2 == side3 || side1 == side3)
        Console.WriteLine("Равнобедренный треугольник");
    else
        Console.WriteLine("Обычный треугольник");
        
    // Проверка на прямоугольность
    if (side1*side1 + side2*side2 == side3*side3 || 
        side1*side1 + side3*side3 == side2*side2 || 
        side2*side2 + side3*side3 == side1*side1)
        Console.WriteLine("Прямоугольный!");
}
else
{
    Console.WriteLine("Треугольник не существует");
}
// Вывод: Обычный треугольник
//         Прямоугольный!
```

## 24. Многоуровневое меню

```csharp
int mainChoice = 2;
int subChoice = 1;

switch (mainChoice)
{
    case 1:
        Console.WriteLine("Выбран раздел: Настройки");
        break;
    case 2:
        Console.WriteLine("Выбран раздел: Графика");
        switch (subChoice)
        {
            case 1:
                Console.WriteLine(" - Разрешение экрана");
                break;
            case 2:
                Console.WriteLine(" - Качество текстур");
                break;
            case 3:
                Console.WriteLine(" - Яркость");
                break;
            default:
                Console.WriteLine(" - Неизвестная опция");
                break;
        }
        break;
    case 3:
        Console.WriteLine("Выбран раздел: Звук");
        break;
    default:
        Console.WriteLine("Неизвестный раздел");
        break;
}
// Вывод: Выбран раздел: Графика
//         - Разрешение экрана
```

## 25. Комбинированный пример с валидацией ввода

```csharp
string input = "25";
bool isValidInput = true;
int number = 0;
string result = "";

// Проверка на пустоту
if (string.IsNullOrWhiteSpace(input))
{
    result = "Ошибка: Пустое значение";
    isValidInput = false;
}
// Проверка на число
else if (!int.TryParse(input, out number))
{
    result = "Ошибка: Не является числом";
    isValidInput = false;
}
// Проверка диапазона
else if (number < 0 || number > 100)
{
    result = "Ошибка: Число вне диапазона 0-100";
    isValidInput = false;
}

if (isValidInput)
{
    // Определяем категорию числа
    string category = number switch
    {
        0 => "Ноль",
        >= 1 and <= 10 => "Малое число",
        >= 11 and <= 50 => "Среднее число",
        >= 51 and <= 100 => "Большое число",
        _ => "Неопределенное"
    };
    
    string parity = (number % 2 == 0) ? "Четное" : "Нечетное";
    
    result = $"Число: {number} - {category}, {parity}";
}

Console.WriteLine(result);
// Вывод: Число: 25 - Среднее число, Нечетное
```

## Заключение

Эти примеры показывают различные способы использования условных конструкций в C#. От простых проверок до сложных многоуровневых условий — все эти техники помогут вам создавать более умные и гибкие программы.