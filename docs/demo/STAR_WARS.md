# Генератор имен в духе Звездных Войн

В этом руководстве мы рассмотрим процесс создания генератора имен в духе Звездных Войн. Условимся, что это должны быть имена с фамилиями. Во вселенной Звездных Войн довольно много различных конструкций имен и фамилий для разных рас - мы не будем создавать их все, но постараемся максимально приблизиться к их звучанию.

## Имена

Имена во вселенной Звездных Войн могут быть очень короткими, состоящими из двух-трех букв (например: По, Оби, Зен). Поэтому вместо использования генератора имен мы используем генератор слогов, а в дальнейшем прибегнем к небольшой хитрости.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(x => x
        .Tag("name")
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefaultLetterSet()
            .WithDefaultSyllableSettings(s => s
                .WithLeadingConsonantsChance(1.0)
                .WithLeadingConsonantBeClusteredChance(0.01)
                .WithVowelsChance(0.5)
                .WithVowelBeClusteredChance(0.2)
                .WithTailingConsonantsChance(0.0)))
        .AddFilter(f => f
            .WithMinLength(2)
            .WhenNotMatchPattern("[bcdfghklmnprstvxhrw]{2}")));
```

Как можно заметить, использованы алфавит и настройки по умолчанию с некоторыми корректировками шансов, чтобы генерируемый результат звучал максимально похоже на желаемый. На этом этапе мы получаем следующие имена:

```csharp
// Вывод:
// nie
// fey
// ku
// ce
```

## Фамилии

Ненадолго оставим генерацию имен и займемся генерацией фамилий. С фамилиями во вселенной Звездных Войн дела обстоят свободнее. Их звучание многообразно и не поддается какому-то явному шаблону. Следующая конфигурация, как мне кажется, отлично справляется со своей задачей.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(..name..)
    .UsingSource(s => s
        .Tag("surname")
        .AddGenerator<NameGenerator>(g => g
            .WithSyllables(2, 3)
            .WithDefaultLetterSet()
            .WithDefaultSyllableSettings(c => c
                .WithFirstVowelChance(0.4)
                .WithLeadingConsonantsChance(1.0)
                .WithVowelBeClusteredChance(0.05)
                .WithTailingConsonantsChance(0.1)))
        .AddMutationSwitch(
            m1 => m1
                .IfMatch("[aeiouy]$")
                .AppendWithAny("ga", "da", "na", "ni", "bi"),
            m2 => m2
                .AppendWithAny("in", "er", "od", "on"))
        .AddFilter(f => f
            .WhenNotMatchPattern(@"(.)\1")));
```

> `AddMutationSwitch` принимает в себя множество блоков с мутациями и работает как конструкция If в C#. Генератор последовательно подставляет каждое обрабатываемое имя под условия каждого блока мутаций, выбирая первый подходящий, и применяет мутации только из этого блока. В данном случае, если у обрабатываемого имени окончанием является гласная, то применяется первый блок мутаций, а если нет, то второй.

На этом этапе мы получаем следующие фамилии.

```csharp
// Вывод:
// huclanin
// cobaroga
// cunabi
// ifeni
```

## Шаблоны

Настало время перейти к самой интересной части генератора. У нас есть два источника, но вместо того, чтобы просто соединять их один к одному, мы воспользуемся шаблонами, чтобы точнее настроить вывод. Время экспериментов!

```csharp
var designer = new NamelessDesigner()
    .UsingSource(..name..)
    .UsingSource(..surname..)
    .UsingTemplates(
        "{^name} {^surname}",
        "{^name} {^name} {^surname}",
        "{^name}{name} {^surname}",
        "{^name}{name} {^name}{name} {^surname}",
        "{^name}{name} {^name} {^surname}",
        "{^name} {^name}{name} {^surname}",
        "{^name}-{name} {^surname}",
        "{^name}-{^name} {^surname}",
        "{^name:0}-{^name:0} {^surname}",
        "{^name:0} {^surname}{name:0}",
        "{^name:0}{name:0} {^surname}");
```

> Хитрость заключается в том, что, разместив плейсхолдер имени два раза подряд, мы, по сути, создаем имя из двух слогов.

Немного знаний об устройстве плейсхолдеров в Yangen ([Руководство о шаблонах и тегах](https://github.com/KsanderVine/Yangen/tree/master/docs/TEMPLATES.md)), и мы получаем следующие имена в результате генерации:

```csharp
// Вывод:
// Kuku Asibabi
// Rere Dapiga
// Dai-bo Fibaliker
// Ti Lascudati
// Vi-fy Pakabruni
// Lou-Lou Nodiga
// Mi-My Pohabi
// Bebai Radu Somabi
// Ba-Ba Abiker
```

## Полная конфигурация генератора

```csharp
var designer = new NamelessDesigner()
    .UsingSource(x => x
        .Tag("name")
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefaultLetterSet()
            .WithDefaultSyllableSettings(s => s
                .WithLeadingConsonantsChance(1.0)
                .WithLeadingConsonantBeClusteredChance(0.01)
                .WithVowelsChance(0.5)
                .WithVowelBeClusteredChance(0.2)
                .WithTailingConsonantsChance(0.0)))
        .AddFilter(f => f
            .WithMinLength(2)
            .DoNotAllowPatterns("[bcdfghklmnprstvxhrw]{2}")))
    .UsingSource(s => s
        .Tag("surname")
        .AddGenerator<NameGenerator>(g => g
            .WithSyllables(2, 3)
            .WithDefaultLetterSet()
            .WithDefaultSyllableSettings(c => c
                .WithFirstVowelChance(0.4)
                .WithLeadingConsonantsChance(1.0)
                .WithVowelBeClusteredChance(0.05)
                .WithTailingConsonantsChance(0.1)))
        .AddMutationSwitch(
            m1 => m1
                .IfMatch("[aeiouy]$")
                .AppendWithAny("ga", "da", "na", "ni", "bi"),
            m2 => m2
                .AppendWithAny("in", "er", "od", "on"))
        .AddFilter(f => f
            .WhenNotMatchPattern(@"(.)\1")))
    .UsingTemplates(
        "{^name} {^surname}",
        "{^name} {^name} {^surname}",
        "{^name}{name} {^surname}",
        "{^name}{name} {^name}{name} {^surname}",
        "{^name}{name} {^name} {^surname}",
        "{^name} {^name}{name} {^surname}",
        "{^name}-{name} {^surname}",
        "{^name}-{^name} {^surname}",
        "{^name:0}-{^name:0} {^surname}",
        "{^name:0} {^surname}{name:0}",
        "{^name:0}{name:0} {^surname}");
```
