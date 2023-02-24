# Генератор фантастических тварей

В этом руководстве мы рассмотрим процесс создания генератора названий для фантастических тварей. Опять же, не будем опираться ни на какую определенную вселенную. Поставим задачу не просто генерировать случайное название из случайных слогов, а замешивать название животного. 

## Список животных

Начнем со списка животных - создадим источник, который будет хранить его. В список можно добавить сколько угодно животных (и не только), но мы ограничимся следующими:

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .Tag("beast")
        .AddNames(
            "fox", "wolf", "bird", "cat", "rabbit",
            "mouse", "pig", "parrot", "hamster", "dog",
            "bull", "chicken", "cow", "sheep", "horse",
            "lynx", "viper", "cobra", "lion", "bear",
            "snake", "owl", "camel", "giraffe", "dragon"));
```

## Источники слогов

Добавим генерацию двух наборов слогов с разными настройками, чтобы в дальнейшем можно было комбинировать их через шаблоны.

+ Первый источник (`name1`) будет хранить слоги, которые всегда будут начинаться с согласной, но никогда не будут ею завершаться. Таким образом, чаще всего это будут слоги из двух букв с очень малым шансом кластеризации.

+ Второй источник (`name2`) будет хранить слоги с алфавитом и настройками по умолчанию, к которым применяется простая мутация. Таким образом, эти слоги всегда будут завершаться гласной.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .Tag("name1")
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefaultLetterSet()
            .WithDefaultSyllableSettings(s => s
                .WithFirstVowelChance(0.0)
                .WithLeadingConsonantsChance(1.0)
                .WithTailingConsonantsChance(0.0)
                .WithConsonantBeClusteredChance(0.05)
                .WithVowelBeClusteredChance(0.05))))
    .UsingSource(s => s
        .Tag("name2")
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefaultSyllableSettings()
            .WithDefaultLetterSet())
        .AddMutation(m => m
            .IfNotMatch("[aeiouy]$")
            .AppendWithAny("a", "o", "e")))
    .UsingSource(..beast..);
```

## Шаблоны

Далее опишем разнообразные шаблоны генерации имен:

```csharp
var designer = new NamelessDesigner()
    .UsingSource(..name1..)
    .UsingSource(..name2..)
    .UsingSource(..beast..)
    .UsingTemplates(
        "{^name2}{beast}",
        "{^beast}{name2}",
        "{^name1:0}-{^name1:0} {^beast}",
        "{^name1}{name2} {^beast}",
        "{^name1}{name2}-{^beast}",
        "{^name1}{name2}{beast}",
        "{^name1}{beast}{name2}",
        "{^name1}{beast}");
```

Наконец, запустим наш генератор и посмотрим на выводимые им результаты:

```csharp
// Вывод:
// Ralion 
// Bocalynx
// Wipo Bird
// Plugaecow
// Hobocat
// Sexu-Cow
// Wolfdai
// Feowl
// Gilion
// Wycat
// Robird 
// Lamaile-Bear 
// Lolynxwape
// Kecat 
// Wucacamel
// Relynx
```

## Полная конфигурация генератора

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .Tag("name1")
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefaultLetterSet()
            .WithDefaultSyllableSettings(s => s
                .WithFirstVowelChance(0.0)
                .WithLeadingConsonantsChance(1.0)
                .WithTailingConsonantsChance(0.0)
                .WithConsonantBeClusteredChance(0.05)
                .WithVowelBeClusteredChance(0.05))))
    .UsingSource(s => s
        .Tag("name2")
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefaultSyllableSettings()
            .WithDefaultLetterSet())
        .AddMutation(m => m
            .IfNotMatch("[aeiouy]$")
            .AppendWithAny("a", "o", "e")))
    .UsingSource(s => s
        .Tag("beast")
        .AddNames(
            "fox", "wolf", "bird", "cat", "rabbit", 
            "mouse", "pig", "parrot", "hamster", "dog", 
            "bull", "chicken", "cow", "sheep", "horse",
            "lynx", "viper", "cobra", "lion", "bear",
            "snake", "owl", "camel", "giraffe", "dragon"))
    .UsingTemplates(
        "{^name2}{beast}",
        "{^beast}{name2}",
        "{^name1:0}-{^name1:0} {^beast}",
        "{^name1}{name2} {^beast}",
        "{^name1}{name2}-{^beast}",
        "{^name1}{name2}{beast}",
        "{^name1}{beast}{name2}",
        "{^name1}{beast}");
```
