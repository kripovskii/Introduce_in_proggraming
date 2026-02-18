# Рекурсия в C# — от простого к профессиональному уровню

### Что такое рекурсия?

Рекурсия — это когда метод вызывает сам себя для решения более мелкой версии той же задачи.

В C# рекурсия выглядит так:

```csharp
void Countdown(int n)
{
    if (n == 0) 
    {
        Console.WriteLine("Пуск!");
        return;
    }

    Console.WriteLine(n);
    Countdown(n - 1);  // метод вызывает сам себя
}
```

### Три золотых правила рекурсии

1. У рекурсии должен быть базовый случай (условие остановки)
2. Рекурсивный вызов должен приближать к базовому случаю
3. Доверяй рекурсии (не пытайся мысленно развернуть весь стек)

Если нарушить хотя бы одно — будет StackOverflowException.

### Классические примеры

#### 1. Факториал

```csharp
static long Factorial(int n)
{
    // Базовый случай
    if (n <= 1) return  // можно писать n == 0 || n == 1
        return 1;

    // Рекурсивный случай
    return n * Factorial(n - 1);
}
```

Вызов: `Factorial(5)` → 120

#### 2. Числа Фибоначчи (наивная рекурсия — очень медленно!)

```csharp
static long Fib(int n)
{
    if (n <= 1) return n;
    return Fib(n - 1) + Fib(n - 2);
}
```

Проблема: Fib(40) будет считаться минуты! Дерево вызовов экспоненциальное.

#### 3. Обход папок (реальный пример из жизни)

```csharp
static void PrintAllFiles(string path, int level = 0)
{
    try
    {
        foreach (string file in Directory.GetFiles(path))
        {
            Console.WriteLine(new string(' ', level * 2) + "Файл: " + Path.GetFileName(file));
        }

        foreach (string dir in Directory.GetDirectories(path))
        {
            Console.WriteLine(new string(' ', level * 2) + "Папка: " + Path.GetFileName(dir));
            Countdown(dir, level + 1);  // рекурсия!
        }
    }
    catch (UnauthorizedAccessException) { /* нет доступа — пропускаем */ }
}
```

### Рекурсия с возвращаемым значением

#### Сумма элементов массива

```csharp
static int Sum(int[] arr, int index = 0)
{
    if (index >= arr.Length) return 0;
    return arr[index] + Sum(arr, index + 1);
}
```

### Хвостовая рекурсия (Tail Recursion)

Если рекурсивный вызов — последнее, что делает метод, это хвостовая рекурсия.

```csharp
static void CountdownTail(int n, int accumulator = 0)
{
    if (n == 0)
    {
        Console.WriteLine("Пуск!");
        return;
    }

    Console.WriteLine(n);
    CountdownTail(n - 1); // последний вызов — хвостовой
}
```

Важно: .NET (CLR) не делает оптимизацию хвостовой рекурсии (в отличие от F# или Scala), поэтому стек всё равно растёт.

### Косвенная рекурсия

```csharp
static void A(int n) { if (n > 0) { Console.WriteLine("A"); B(n - 1); } }
static void B(int n) { if (n > 0) { Console.WriteLine("B"); A(n - 1); } }
```

### Когда рекурсия — плохая идея?

- Очень глубокая рекурсия (> 10 000–50 000 вызовов) → StackOverflowException
- Задачу можно решить простым циклом
- Нужна максимальная производительность (например, Fib > 40)

### Как избежать StackOverflow при глубокой рекурсии?

Варианты:

1. Переписать итеративно (цикл)
2. Использовать собственный стек (ручная симуляция рекурсии)
3. Увеличить размер стека (не рекомендуется в продакшене):

```csharp
var thread = new Thread(SomeDeepRecursiveMethod, 1024 * 1024 * 10); // 10 МБ стека
thread.Start();
```

### Продвинутые примеры

#### 1. Быстрый Фибоначчи через хвостовую рекурсию с аккумуляторами

```csharp
static long FibTail(int n, long a = 0, long b = 1)
{
    if (n == 0) return a;
    if (n == 1) return b;
    return FibTail(n - 1, b, a + b);
}

// Теперь FibTail(1000) — мгновенно и без переполнения стека (до ~1 млн легко)
```

#### 2. Рекурсивный парсер простого математического выражения

```csharp
static double Parse(string s, ref int pos)
{
    double result = 0;
    while (pos < s.Length)
    {
        char c = s[pos];
        if (char.IsDigit(c))
        {
            int num = 0;
            while (pos < s.Length && char.IsDigit(s[pos]))
                num = num * 10 + (s[pos++] - '0');
            result += num;
        }
        else if (c == '+') { pos++; result += Parse(s, ref pos); }
        else if (c == '(') { pos++; result += Parse(s, ref pos); }
        else if (c == ')') { pos++; return result; }
        else pos++;
    }
    return result;
}
```

### Лучшие практики рекурсии в C#

1

1. Всегда пиши базовый случай первым
2. Убедись, что аргументы приближаются к базовому случаю
3. Для больших данных предпочитай итеративные решения или ручной стек
4. Используй хвостовую рекурсию + аккумуляторы для линейных задач
5. Делай рекурсивные методы private или internal, если они не часть публичного API

### Итог: Когда использовать рекурсию в C#?

Используй рекурсию, когда:

- Задача естественно делится на похожие подзадачи (деревья, графы, backtracking)
- Код становится значительно проще и читабельнее
- Глубина рекурсии гарантированно небольшая (< 1000–5000)

Не используй, когда:

- Глубина неизвестна или очень большая
- Критична производительность
- Есть простое итеративное решение

Рекурсия — это не магия, это просто ещё один инструмент. Используй его с умом!
