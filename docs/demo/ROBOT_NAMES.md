# Генератор имен роботов

В этом руководстве мы рассмотрим процесс создания генератора имен роботов. Мы не будем опираться на какую-то конкретную вселенную, а используем своё воображение, чтобы представить, какими они могли бы быть. Как серийные номера? Может, они используют цифры как буквы? Или же их имена - это просто набор символов? Поэтому в данном руководстве мы начнем с шаблонов.

## Шаблоны

Представим пять шаблонов имен роботов:

+ БуквыЦифры - например, BOB03

+ Буквы/Цифры-Цифры - например, GIG/09-11

+ ДлинноеЧисло:Буквы - например, 49398:MIG

+ БуквыЦифры Mark РимскиеЦифры - например, GAD01 Mark X

+ БуквыЦифры-Цифры-ДлинноеЧисло-Буквы - например, LAT03-08-13330-ALT

Перенесем эти шаблоны в код генератора имен. Таким образом получим для себя список тегов источников, которые необходимо указать в конфигурации:

```csharp
var designer = new NamelessDesigner()
    .UsingTemplates(
        "{code}{number}",
        "{code}/{number}-{number}",
        "{long_number}:{code}",
        "{code}{number} Mark {roman_number}",
        "{code}{number}-{number}-{long_number}-{code}");
```

## Источники

Создадим по одному источнику для каждого использованного тега и сконфигурируем их так, чтобы они генерировали необходимые списки имен:

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .Tag("code")
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefaultLetterSet()
            .WithDefaultSyllableSettings(c => c
                .WithFirstVowelChance(0)
                .WithConsonantsChance(1)
                .WithConsonantBeClusteredChance(0)))
        .AddFilter(f => f
            .WithLengthRange(3, 3))
        .AddMutation(m => m
            .ToUpper()))
    .UsingSource(s => s
        .Tag("number")
        .AddGenerator<NumberGenerator>(g => g
            .WithRange(1, 10)
            .WithTotalLength(2)
            .WithLeftPadding()))
    .UsingSource(s => s
        .Tag("roman_number")
        .AddGenerator<RomanNumberGenerator>(g => g
            .WithRange(1, 10)))
    .UsingSource(s => s
        .Tag("long_number")
        .AddGenerator<NumberGenerator>(g => g
            .WithRange(1, 999)
            .WithTotalLength(5)
            .WithLeftPadding()
            .WithRightPadding()))
    .UsingTemplates(
        "{code}{number}",
        "{code}/{number}-{number}",
        "{long_number}:{code}",
        "{code}{number} Mark {roman_number}",
        "{code}{number}-{number}-{long_number}-{code}");
```

В результате генерации получаются следующие имена:

```csharp
// Вывод:
// FAV07
// POB/09-07
// XOM05-09-01210-BUH
// MEF08
// NUB08-06-01500-LID
// GUF04 Mark IX
```
