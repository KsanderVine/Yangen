# Мутация (Mutation)

Мутация представляет собой обработчик списка имен, позволяющий изменять уже содержащиеся в обрабатываемом списке имена. В следующем примере в результате генерации мутация модифицирует первую букву каждого имени в заглавную.

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

Обработчик мутации состоит из действий и условий. Изменим пример, добавив в мутацию еще одно действие, которое присоединит к каждому имени окончание `son`.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddNames("harry", "hermione", "ron", "hagrid")
        .AddMutation(m => m
            .Append("son")
            .ToUpperFirst()));

// Вывод:
// Harryson
// Hagridson
// Ronson
```

Во время обработки условия мутации индивидуально для каждого имени определяют, подходит оно для модификации или нет. Изменим мутацию таким образом, чтобы первая буква всегда становилась заглавной, а также добавим условие, которое присоединит окончание `son` только к именам короче четырех символов.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => 
        .AddNames("harry", "hermione", "ron", "hagrid")")
        .AddMutation(m => m
            .IfLengthLess(4)
            .Append("son"))
        .AddMutation(m => m
            .ToUpperFirst()));

// Вывод:
// Harry
// Hagrid
// Ronson
```

Как видно из примера, единственное имя, на которое подействовала мутация с добавлением окончания, это `ron`. Источнику было возвращено имя `ronson`, на которое подействовала и вторая мутация, в конечном итоге превратив имя в `Ronson`.
