# Символьные типы данных  
Символьные типы данных в C#  

### 1. Тип char — один символ (16-битный Unicode)

```csharp
char a = 'A';        // обычная буква
char b = 'Я';        // русская буква
char digit = '5';    // цифра как символ (не число!)
char smile = '😊';   // даже эмодзи можно!
char pi    = '\u03C0'; // π через Unicode-код
char newline = '\n';   // перевод строки
char tab     = '\t';   // табуляция
char quote   = '\'';   // одинарная кавычка
char backslash = '\\'; // обратный слэш
```

**Важно:** `char` всегда в одинарных кавычках и хранит ровно один символ.

#### Все основные статические методы char (с примерами)

```csharp
char c = 'Ж';

char.IsLetter(c)          // true  → это буква?
char.IsDigit('8')         // true
char.IsLetterOrDigit('@') // false
char.IsWhiteSpace(' ')    // true
char.IsWhiteSpace('\t')   // true
char.IsWhiteSpace('\n')   // true
char.IsUpper('А')         // true  → заглавная?
char.IsLower('б')         // true  → строчная?
char.IsPunctuation('!')   // true
char.IsSymbol('+')        // true
char.IsControl('\n')      // true → управляющий символ

char.ToUpper('я')         // возвращает 'Я'
char.ToLower('Ш')         // возвращает 'ш'
char.GetNumericValue('7') // возвращает 7.0 как double
char.GetUnicodeCategory('Ж') // возвращает UnicodeCategory
```

### 2. Тип string — неизменяемая строка

```csharp
string s1 = "Классическая строка";
string s2 = @"Verbatim-строка
может быть многострочной
C:\Users\Документы\file.txt";   // \n и \t НЕ обрабатываются!

string name = "Марина";
int age = 27;
decimal salary = 85_000.50m;

string s3 = $"Имя: {name}, возраст: {age}, зарплата: {salary:C}";
// → Имя: Марина, возраст: 27, зарплата: 85 000,50 ₽
```

#### Все важнейшие свойства и методы string 

| Метод / свойство               | Что делает                                                                 | Пример кода                                                                      | Результат                          |
|--------------------------------|-----------------------------------------------------------------------------|----------------------------------------------------------------------------------|------------------------------------|
| `.Length`                      | Количество символов                                                         | `"Привет".Length`                                                                | `7`                                |
| `s[i]`                         | Получить символ по индексу (только чтение!)                                 | `"Hello"[1]`                                                                     | `'e'`                              |
| `.ToUpper()`                   | Все буквы заглавные                                                         | `"москва".ToUpper()`                                                             | `"МОСКВА"`                         |
| `.ToLower()`                   | Все буквы строчные                                                          | `"САНКТ-ПЕТЕРБУРГ".ToLower()`                                                    | `"санкт-петербург"`                |
| `.Trim()`                      | Убрать все пробельные символы с краёв                                       | `"   текст   ".Trim()`                                                           | `"текст"`                          |
| `.TrimStart()`, `.TrimEnd()`   | Убрать только слева / справа                                                | `"---hello---".Trim('-')`                                                        | `"hello"`                          |
| `.PadLeft(10)`, `.PadRight(10)`| Добавить пробелы/символы слева или справа до нужной длины                  | `"5".PadLeft(4, '0')`                                                            | `"0005"`                           |
| `.Contains("abc")`             | Содержит ли подстроку                                                       | `"Я люблю C#".Contains("люблю")`                                                 | `true`                             |
| `.StartsWith("http")`          | Начинается ли с...                                                          | `"https://site.ru".StartsWith("http")`                                           | `true`                             |
| `.EndsWith(".exe")`            | Заканчивается ли на...                                                      | `"virus.exe".EndsWith(".exe")`                                                   | `true`                             |
| `.IndexOf('x')`                | Первое вхождение символа (-1 если нет)                                      | `"banana".IndexOf('a')`                                                          | `1`                                |
| `.LastIndexOf('a')`            | Последнее вхождение                                                         | `"banana".LastIndexOf('a')`                                                      | `5`                                |
| `.Replace("old","new")`        | Заменить все вхождения                                                      | `"я люблю котов".Replace("котов", "собак")`                                      | `"я люблю собак"`                  |
| `.Remove(3)`                   | Удалить от позиции 3 до конца                                               | `"0123456789".Remove(5)`                                                         | `"01234"`                          |
| `.Remove(2, 4)`                | Удалить 4 символа начиная с позиции 2                                       | `"0123456789".Remove(2,4)`                                                       | `"016789"`                         |
| `.Substring(2, 5)`             | Вырезать подстроку (с индекса 2, длиной 5)                                  | `"0123456789".Substring(2,5)`                                                    | `"23456"`                          |
| `.Substring(7)`                | От позиции 7 до конца                                                       | `"Hello world".Substring(6)`                                                     | `"world"`                          |
| `.Split(' ')`                  | Разбить по разделителю → массив string[]                                    | `"один два три".Split(' ')`                                                      | `{ "один", "два", "три" }`         |
| `.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)` | Разбить по нескольким вариантам перевода строки | —                                                                      | —                                  |
| `string.Join(", ", массив)`    | Склеить массив в одну строку                                                | `string.Join(" → ", new[] {"A","B","C"})`                                        | `"A → B → C"`                      |
| `.ToCharArray()`               | Строка → массив символов                                                    | `"C#".ToCharArray()`                                                             | `{ 'C', '#' }`                     |
| `.Equals("abc")` или `==`      | Сравнение строк                                                             | `"abc" == "abc"`                                                                 | `true`                             |

#### Статические методы string 

```csharp
string.IsNullOrEmpty(null)                 // true
string.IsNullOrEmpty("")                   // true
string.IsNullOrEmpty("   ")                // false

string.IsNullOrWhiteSpace(null)            // true
string.IsNullOrWhiteSpace("")              // true
string.IsNullOrWhiteSpace("   \t   ")      // true  ← ЭТО САМЫЙ ВАЖНЫЙ МЕТОД!
```

### 3. Массивы символов (char[]) и массивы строк (string[])

#### char[] — единственный способ менять отдельные символы

```csharp
// Создание
char[] letters = { 'П', 'р', 'и', 'в', 'е', 'т' };
char[] word = "racecar".ToCharArray();

// Меняем символы — в string так нельзя!
word[0] = 'g';
word[4] = 'd';
string newWord = new string(word);   // "gacedcr"

// Полезные операции с массивом
Array.Reverse(word);                 // перевернуть
string palindrom = new string(word);

Array.Sort(word);                    // отсортировать символы
string sorted = new string(word);
```

#### string[] — массив строк

```csharp
string[] names = { "Анна", "Борис", "Вера" };
string[] words = "я,люблю,программировать".Split(',');

foreach (string w in words)
    Console.WriteLine(w.Trim());     // уберёт лишние пробелы

string csv = string.Join("; ", names);  // "Анна; Борис; Вера"
```

### 4. Ввод с консоли — все рабочие способы (подробно)

#### 4.1 Ввод строки (самый частый)

```csharp
Console.Write("Введите ФИО: ");
string fio = Console.ReadLine()!.Trim();   // ! — говорим компилятору, что не будет null
Console.WriteLine($"Здравствуйте, {fio}!");
```

#### 4.2 Ввод ровно одного символа (без Enter)

```csharp
Console.Write("Выберите действие (y/n): ");
char answer = Console.ReadKey().KeyChar;
Console.WriteLine();                       // переходим на новую строку
Console.WriteLine($"Вы выбрали: {answer}");
```

#### 4.3 Надёжный ввод одного символа с проверкой

```csharp
char letter;
do
{
    Console.Write("Введите одну букву: ");
    string input = Console.ReadLine()!.Trim();
    
    if (input.Length == 1 && char.IsLetter(input[0]))
    {
        letter = input[0];
        break;
    }
    Console.WriteLine("Ошибка! Нужно ввести ровно одну букву.");
} while (true);

Console.WriteLine($"Вы ввели букву: {letter}");
```

#### 4.4 Ожидание любой клавиши (как в играх, меню)

```csharp
Console.WriteLine("Нажмите любую клавишу для продолжения...");
Console.ReadKey(true);     // true = не показывать символ на экране
```

#### 4.5 Цикл с мгновенной реакцией на клавиши

```csharp
Console.WriteLine("Управление: стрелки + Space. Q — выход");
while (true)
{
    if (Console.KeyAvailable)                 // есть ли нажатая клавиша?
    {
        ConsoleKeyInfo key = Console.ReadKey(true);  // true = не выводить
        char ch = key.KeyChar;
        
        if (key.Key == ConsoleKey.Q) break;
        if (key.Key == ConsoleKey.UpArrow)    Console.WriteLine("Вверх");
        if (key.Key == ConsoleKey.DownArrow)  Console.WriteLine("Вниз");
        if (key.Key == ConsoleKey.Spacebar)  Console.WriteLine("Прыжок!");
        if (char.IsLetterOrDigit(ch))         Console.WriteLine($"Символ: {ch}");
    }
}
```

### Итоговая шпаргалка 

| Что нужно сделать                         | Как написать в C# (2025)                                      |
|-------------------------------------------|---------------------------------------------------------------|
| Один символ                               | `char c = 'A';`                                               |
| Строка с переменными                      | `$"Цена: {price:0.00} ₽"`                                     |
| Многострочный текст                       | `@"первая строка\nвторая строка"`                             |
| Поменять буквы в слове                    | `char[] a = s.ToCharArray(); a[0]='X'; s = new string(a);`    |
| Ввод строки                               | `string s = Console.ReadLine()!.Trim();`                      |
| Ввод одного символа сразу                 | `char c = Console.ReadKey().KeyChar;`                         |
| Безопасная проверка пустой строки         | `if (string.IsNullOrWhiteSpace(input))`                       |
| Разбить по запятой                        | `string[] parts = text.Split(',');`                           |
| Склеить массив строк                      | ``` string result = string.Join("  ", array ) ```                  |
| Убрать пробелы                            | `s = s.Trim();`                                               |
| Привести к верхнему регистру              | `s = s.ToUpper();`                                            |
| Заменить подстроку                        | `s = s.Replace("старое", "новое");`                           |
| Проверить начало/конец строки             | `s.StartsWith("http")`, `s.EndsWith(".pdf")`                  |

