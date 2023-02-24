# Yet Another Nameless Generator

Yangen - это генератор с гибкой настройкой процесса генерации и поддержкой шаблонов. Yangen может использовать как заготовленные списки имен, так и интегрированные генераторы. Конфигурация Yangen проста для освоения, удобна для написания и легка для чтения и понимания.

## Дизайнер (Designer)

Конфигурация генератора Yangen начинается с дизайнера. Дизайнер состоит из двух компонентов: источника и шаблона. Один дизайнер может иметь множество источников и множество различных шаблонов - это может быть использовано, например, для генерации имен, состоящих из нескольких слов. 

### Простой пример конфигурации

В следующем примере продемонстрирована примитивная конфигурация дизайнера с одним источником и заготовленным списком имен. Мы получаем результаты функцией `Next()`.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddNames("Harry", "Hermione", "Ron", "Hagrid"));

// designer.Next();

// Вывод:
// Hagrid
// Ron
// Harry
```

### Продвинутый пример конфигурации

В следующем примере продемонстрирована продвинутая конфигурация дизайнера, включающая разнообразные элементы: использование источников, шаблонов и генераторов. Но не пугайтесь! Обо всём по порядку.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .Tag("name")
        .AddGenerator<NameGenerator>(g => g
            .WithSyllables(2, 3)
            .WithDefaultSyllableSettings(s => s
                .WithFirstVowelChance(0.1)
                .WithConsonantsChance(0.6))
            .WithLetterSet(l => l
                .WithVowels("aeiouy")
                .WithLeadingConsonants("lstnprmd")
                .WithTailingConsonants("bcdfghklmnprstvhr")
                .WithLeadingConsonantClusters("tr", "br", "th", "fl")
                .WithTailingConsonantClusters("rd", "kr", "sk", "zh")))
        .AddMutation(m => m
            .WithChance(0.5)
            .IfMatch("[^aeiouy]$")
            .RemoveAt(int.MaxValue, -1)
            .AppendWithAny("a", "e", "i", "o", "u", "y"))
        .AddMutation(m => m
            .IfMatch("[s]$")
            .Append("e"))
        .AddMutation(m => m
            .ToUpperFirst()))
    .UsingSource(s => s
        .Tag("type")
        .AddNames("city", "town", "station", "farm", "citadel", "tower"))
    .UsingTemplates(
        "{name}'s {type}",
        "{^type} of {name}");

// Вывод:
// Station of Abir
// Leltogo's town
// Tali's farm
```

## Источники (Source)

Источники являются поставщиками списков имен, которые могут состоять из заготовленных имен и/или использовать генераторы. Большая часть конфигурации завязана именно на источниках. Подробнее об этом в [руководстве об источниках](https://github.com/KsanderVine/Yangen/tree/master/docs/SOURCE.md).

## Шаблоны и теги (Templates and tags)

Шаблоны представляют способ форматирования вывода для приведения его в желаемый вид. В состав шаблонов входят плейсхолдеры, которые, в свою очередь, используют теги источников. Подробнее об этом в [руководстве о шаблонах и тегах](https://github.com/KsanderVine/Yangen/tree/master/docs/TEMPLATES.md).

## Демонстрации

Для демонстрации возможностей Yangen подготовлены несколько конфигураций генераторов, затрагивающих разные элементы и подходы. Если вы сохранили репозиторий локально, то можете запустить проект `Yangen.Demo` из IDE.

## Руководства

Также вы можете ознакомиться с конфигурациями генераторов, описанными в формате руководства. В них поэтапно и детально рассмотрены различные элементы и подходы к созданию генераторов.

+ **[Генератор имен орков](https://github.com/KsanderVine/Yangen/tree/master/docs/demo/ORC_NAMES.md)**

+ **[Генератор имен роботов](https://github.com/KsanderVine/Yangen/tree/master/docs/demo/ROBOT_NAMES.md)**

+ **[Генератор имен в духе Звездных Войн](https://github.com/KsanderVine/Yangen/tree/master/docs/demo/STAR_WARS.md)**

+ **[Генератор фантастических тварей](https://github.com/KsanderVine/Yangen/tree/master/docs/demo/FANTASY_BEASTS.md)**
