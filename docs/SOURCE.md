# Источники (Source)

Источник является поставщиком списка имен, который может состоять из заготовленных имен и/или использовать генераторы. Для того, чтобы дизайнер мог возвращать результаты, необходимо сконфигурировать хотя бы один источник. Каждый источник состоит из обработчиков, организованных в конвейер обработки списка имен, он выполняется последовательно.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddNames("Harry", "Hermione", "Ron", "Hagrid"))
    .UsingSource(s => s
        .AddNames("Potter", "Granger", "Weasley", "Rubeus"));

// Вывод:
// Hagrid
// Granger
// Weasley
```

## Конвейер обработчиков

Каждый источник состоит из обработчиков, организованных в конвейер обработки имен. Обработчик преставляет собой один этап обработки списка имен, на котором происходит добавление новых или изменение уже находящихся в обработке имен. Допустим, у нас есть следующий конвейер:

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddNames(..)
        .AddGenerator(..)
        .AddMutation(..)
        .AddFilter(..)
        .AddMutation(..)
        .AddFilter(..));
```

Вот что будет происходить поэтапно:

+ `AddNames`  - добавит заготовленные имена в обработку.

+ `AddGenerator` - добавит сгенерированные имена в обработку.

+ `AddMutation` - проведет изменения над именами в обработке.

+ `AddFilter` - отфильтрует имена, находящиеся в обработке.

+ `AddMutation` - еще одна порция изменений над именами.

+ `AddFilter` - контрольная фильтрация имен в обработке.

В конечном итоге источник получит и будет хранить список имен, образованный этим конвейером.

### Перечисление имен

Пример ниже демонстрирует добавление перечисления в конвейер обработки списка имен. Перечисление - это простейший обработчик списка имен, который добавляет в обработку заготовленный список.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddNames("Harry", "Hermione", "Ron", "Hagrid"));

// Вывод:
// Hermione
// Hagrid
// Harry
```

## Мутация

Мутация представляет собой обработчик списка имен, позволяющий изменять уже содержащиеся в обрабатываемом списке имена. В следующем примере в результате обработки мутация модифицирует первую букву каждого имени в заглавную. Подробнее об этом в [руководстве о мутациях](https://github.com/KsanderVine/Yangen/tree/master/docs/MUTATION.md).

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddNames("harry", "hermione", "ron", "hagrid")
        .AddMutation(m => m
            .ToUpperFirst()));

// Вывод:
// Hermione
// Hagrid
// Harry
```

## Фильтр

Фильтр представляет обработчик списка имен, позволяющий убирать имена, не подходящие под указанные условия (правила). В следующем примере в результате обработки фильтр уберет из итогового списка все имена, содержащие более четырех символов. Подробнее об этом в [руководстве о фильтрах](https://github.com/KsanderVine/Yangen/tree/master/docs/FILTER.md).

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddNames("Harry", "Hermione", "Ron", "Hagrid")
        .AddFilter(f => f
            .WithMaxLength(4)));

// Вывод:
// Ron
// Ron
// Ron
```

## Генератор

Генератор представляет собой обработчик списка имен, который, используя конфигурацию определенного генератора, добавляет в обработку имена. Существует несколько предзаготовленных генераторов, их конфигурация описана в следующих руководствах:

+ **[Генератор чисел](https://github.com/KsanderVine/Yangen/tree/master/docs/generators/NUMBER_GENERATOR.md)**

+ **[Генератор римских чисел](https://github.com/KsanderVine/Yangen/tree/master/docs/generators/ROMAN_NUMBER_GENERATOR.md)**

+ **[Генератор слогов](https://github.com/KsanderVine/Yangen/tree/master/docs/generators/SYLLABLE_GENERATOR.md)**

+ **[Генератор имен](https://github.com/KsanderVine/Yangen/tree/master/docs/generators/NAME_GENERATOR.md)**

## Анализатор

Анализатор представляет особый обработчик списка имен, который никак не влияет на сам процесс генерации, но позволяет собрать некоторую специфическую информацию в формате отчета. Подробнее об этом в [руководстве об анализаторах](https://github.com/KsanderVine/Yangen/tree/master/docs/ANALYSER.md).
