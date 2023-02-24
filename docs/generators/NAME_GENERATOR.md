# Генератор имен

Данный генератор использует генератор слогов для построения имен. Если вы еще не ознакомились с [Генератором слогов](https://github.com/KsanderVine/Yangen/tree/master/docs/generators/SYLLABLE_GENERATOR.md), то стоит начать с него.

Используем последний пример из руководства к генератору слогов и дополним его специфическим для генератора имен свойством - количеством слогов.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<NameGenerator>(g => g
            .WithSyllables(2,3)
            .WithDefaultSyllableSettings()
            .WithLetterSet(l => l
                .WithVowels("aei")
                .WithConsonants("ln"))));

// Вывод:
// anallil
// nelli
// nana
```

Как видно из примера, генератор составил несколько имен. Схожесть с реальными именами еще предстоит довести до идеала.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .Tag("name")
        .AddGenerator<NameGenerator>(g => g
            .WithSyllables(2)
            .WithLetterSet(l => l
                .WithVowels("ae")
                .WithConsonants("lvndr"))
            .WithDefaultSyllableSettings(c => c
                .WithLeadingConsonantsChance(1)
                .WithTailingConsonantsChance(0.25))));

// Вывод:
// ela
// dalla
// dava
```

Уже лучше. Для получения более качественных результатов необходимо экспериментировать, пробовать добавлять или убирать буквы и буквосочетания, изменять шансы в настройках слога. Для ознакомления с практическим использованием генераторов загляните в раздел демонстраций.
