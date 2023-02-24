# Фильтр (Filter)

Фильтр представляет собой обработчик списка имен, позволяющий убирать имена, не подходящие под указанные условия (правила). В примере ниже в результате генерации фильтр уберет из итогового списка все имена, содержащие менее четырех символов.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddNames("Harry", "Hermione", "Ron", "Hagrid")
        .AddFilter(f => f
            .WithMinLength(4)));

// Вывод:
// Harry
// Hermione
// Hagrid
```

Обратная ситуация - фильтр убрет все имена, в которых более четырех символов.

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

Один фильтр одновременно может содержать множество правил фильтрации.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddNames("ivan", "artem", "artur")
        .AddFilter(f => f
            .WhenStartsWith("a")
            .WhenEndsWith("r")
            .WhenNotStartsWith("i")
            .WhenNotEndsWith("p")
            .WithLengthRange(1, 10)));

// Вывод:
// artur
```
