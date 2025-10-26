# Вопросы и ответы: Условные конструкции

## Основные вопросы

### В: Когда следует использовать if-else, а когда switch?

**О:** 
- **if-else** лучше подходит для сложных логических условий, диапазонов, множественных проверок
- **switch** лучше для сравнения одной переменной с конкретными значениями

**Пример для if-else:**
```csharp
if (score >= 90 && attendance > 0.8) // сложное условие
    grade = "A";
else if (score >= 80 && score < 90) // диапазон
    grade = "B";
```

**Пример для switch:**
```csharp
switch (dayOfWeek) // конкретные значения
{
    case "Monday": workDay = true; break;
    case "Saturday": workDay = false; break;
}
```

### В: Можно ли опускать фигурные скобки в if?

**О:** Да, можно, но только для одной инструкции. Однако рекомендуется всегда использовать скобки для читаемости.

```csharp
// Можно, но не рекомендуется:
if (x > 0)
    Console.WriteLine("Положительное");

// Лучше:
if (x > 0)
{
    Console.WriteLine("Положительное");
}
```

### В: Что происходит, если забыть break в switch?

**О:** В C# компилятор требует обязательного `break`, `return` или `goto` в каждом `case`. Если забыть, программа не скомпилируется.

```csharp
// Ошибка компиляции:
switch (day)
{
    case "Monday":
        Console.WriteLine("Понедельник");
        // Отсутствует break!
    case "Tuesday":
        Console.WriteLine("Вторник");
        break;
}
```

### В: Как работают логические операторы && и ||?

**О:** Они работают по принципу **короткой схемы вычисления** (short-circuit evaluation):

- **&&**: если левая часть `false`, правая не вычисляется
- **||**: если левая часть `true`, правая не вычисляется

```csharp
string text = null;
// Безопасно: text?.Length не вызовет исключение
if (text != null && text.Length > 0)
    Console.WriteLine("Text is not empty");
```

## Продвинутые вопросы

### В: Как работает тройной оператор?

**О:** Тройной оператор `?:` — это сокращенная форма if-else, которая возвращает значение.

```csharp
// Обычный if-else:
string result;
if (score >= 60)
    result = "Сдал";
else
    result = "Не сдал";

// То же самое с тройным оператором:
string result = score >= 60 ? "Сдал" : "Не сдал";
```

### В: Можно ли вложить один тройной оператор в другой?

**О:** Да, можно, но это ухудшает читаемость. Лучше использовать обычные if-else.

```csharp
// Плохо (трудно читать):
string grade = score >= 90 ? "A" : score >= 80 ? "B" : score >= 70 ? "C" : "D";

// Лучше:
string grade;
if (score >= 90) grade = "A";
else if (score >= 80) grade = "B";
else if (score >= 70) grade = "C";
else grade = "D";
```

### В: Что такое pattern matching в switch?

**О:** Pattern matching — это современная возможность C#, позволяющая проверять не только значения, но и типы, условия.

```csharp
// C# 8.0+
object value = 42;
string result = value switch
{
    int i when i > 0 => "Положительное число",
    int i when i < 0 => "Отрицательное число",
    string s when !string.IsNullOrEmpty(s) => "Непустая строка",
    null => "Null значение",
    _ => "Неизвестный тип"
};
```

## Ошибки и подводные камни

### В: Почему мой код не выполняется после if?

**О:** Возможно, вы поставили `;` после if, что создает пустое выражение.

```csharp
// Ошибка: пустое выражение после if
if (x > 0); // Лишняя точка с запятой!
    Console.WriteLine("Положительное"); // Выполняется всегда!

// Правильно:
if (x > 0)
    Console.WriteLine("Положительное");
```

### В: Почему switch не работает с диапазонами?

**О:** Обычный switch работает только с конкретными значениями. Для диапазонов используйте if-else или современные switch expressions.

```csharp
// Не работает:
// switch (age)
// {
//     case >= 18: // Ошибка!
// }

// Правильно:
if (age >= 18 && age < 65)
    category = "Взрослый";
else if (age >= 65)
    category = "Пенсионер";

// Или с современным switch (C# 8.0+):
string category = age switch
{
    >= 18 and < 65 => "Взрослый",
    >= 65 => "Пенсионер",
    _ => "Несовершеннолетний"
};
```

### В: Как избежать глубокой вложенности условий?

**О:** Используйте **early return** (раннее возвращение) и **guard clauses** (защитные условия).

```csharp
// Плохо (глубокая вложенность):
public string ProcessUser(User user)
{
    if (user != null)
    {
        if (!string.IsNullOrEmpty(user.Name))
        {
            if (user.Age >= 18)
            {
                return "Обработан";
            }
            else
            {
                return "Слишком молод";
            }
        }
        else
        {
            return "Пустое имя";
        }
    }
    else
    {
        return "Пользователь null";
    }
}

// Лучше (early return):
public string ProcessUser(User user)
{
    if (user == null)
        return "Пользователь null";
        
    if (string.IsNullOrEmpty(user.Name))
        return "Пустое имя";
        
    if (user.Age < 18)
        return "Слишком молод";
        
    return "Обработан";
}
```

## Лучшие практики

### В: Какие существуют общие рекомендации по стилю кода?

**О:**
1. Всегда используйте фигурные скобки
2. Избегайте глубокой вложенности
3. Предпочитайте switch для сравнения конкретных значений
4. Всегда включайте `default` случай в switch
5. Используйте понятные имена для логических переменных

```csharp
// Плохо:
if (u.a > 18 && u.s == 1 && u.v)
    DoSomething();

// Лучше:
bool isAdult = user.Age > 18;
bool isActive = user.Status == UserStatus.Active;
bool isVerified = user.IsVerified;

if (isAdult && isActive && isVerified)
    ProcessUser(user);
```

### В: Когда стоит выносить сложную логику в отдельные методы?

**О:** Когда условие становится слишком сложным для понимания, лучше вынести его в отдельный метод с говорящим именем.

```csharp
// Плохо (сложно понять):
if (user.Age >= 18 && user.HasActiveSubscription && 
    user.AccountType != AccountType.Suspended && 
    user.LastLoginDate > DateTime.Now.AddDays(-30))
{
    GrantAccess();
}

// Лучше:
if (CanUserAccessPremiumFeatures(user))
{
    GrantAccess();
}

private bool CanUserAccessPremiumFeatures(User user)
{
    return user.Age >= 18 && 
           user.HasActiveSubscription && 
           user.AccountType != AccountType.Suspended && 
           user.LastLoginDate > DateTime.Now.AddDays(-30);
}
```

## Практические примеры

### В: Как правильно проверять строки на пустоту?

**О:** Используйте `string.IsNullOrEmpty()` или `string.IsNullOrWhiteSpace()`.

```csharp
// Плохо (может вызвать NullReferenceException):
if (text.Length == 0)
    Console.WriteLine("Пустая строка");

// Лучше:
if (string.IsNullOrEmpty(text))
    Console.WriteLine("Пустая строка");

// Еще лучше (учитывает пробелы):
if (string.IsNullOrWhiteSpace(text))
    Console.WriteLine("Пустая строка");
```

### В: Как правильно сравнивать строки?

**О:** Для сравнения без учета регистра используйте `StringComparison`.

```csharp
// Плохо (чувствительно к регистру):
if (userInput == "YES")
    DoSomething();

// Лучше:
if (userInput.Equals("YES", StringComparison.OrdinalIgnoreCase))
    DoSomething();

// Или:
if (string.Equals(userInput, "YES", StringComparison.OrdinalIgnoreCase))
    DoSomething();
```

Эти вопросы и ответы помогут вам лучше понять работу с условными конструкциями в C# и избежать распространенных ошибок.