# Генератор римских чисел

В этом разделе мы подробнее рассмотрим возможности генератора римских чисел. Стоит начать с демонстрации полной конфигурации.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<RomanNumberGenerator>(g => g
            .WithRange(1,50)));

// Вывод:
// VIII
// XLI
// XXVI
```

Как видно из примера, при конфигурации был указан диапазон значений от `1` до `50`. Генератор выбирает случайное число из диапазона и конвертирует его в римскую форму записи. Важно отметить, что числа корректно конвертируются только в диапазоне от `1` до `3999`.

Следующий пример должен продемонстрировать использование данного генератора на практике. Предположим, что мы хотим сделать генератор имен правителей Римской империи:

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .Tag("name")
        .AddNames(
            "Henry", "Conrad", "Lothair", "Frederick", "Richard", 
            "Albert", "Sigismund", "Louis", "Joseph", "Ferdinand"))
    .UsingSource(s => s
        .Tag("number")
        .AddGenerator<RomanNumberGenerator>(g => g
            .WithRange(1, 10)))
    .UsingTemplates("{name} {number}");

// Вывод:
// Sigismund I
// Joseph VII
// Richard I
// Joseph IV
// Ferdinand IX
```

Для ознакомления с практическим использованием генераторов загляните в раздел демонстраций.
