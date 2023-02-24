# Генератор имен орков

В этом руководстве мы рассмотрим процесс создания генератора имен орков. Каких именно орков - неважно. Пусть это будут типичные орки в представлении каждого. Злые, грубые и топорные, совсем как их имена - резкие рычащие звуки. Не будем усложнять генератор фамилиями и сосредоточимся на именах.

## Алфавит

Имена орков должны звучать грозно. В них должно быть достаточно резких звучаний, неудобных согласных буквосочетаний. Добавим некоторый набор букв и посмотрим, что из этого выйдет.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<NameGenerator>(g => g
            .WithLetterSet(l => l
                .WithVowels("aiuoe")
                .WithConsonants("nzlgrm")
                .WithConsonantClusters("sh", "hr", "ks", "kr", "nt", "nd", "rt", "rd", "rr"))
            .WithDefaultSyllableSettings()
            .WithSyllables(2)));

// Вывод:
// ulu
// nogim
// ezird
// nesha
// mala
```

Неплохо, однако недостаточно устрашающе. Нужно больше рычания богу рычания!

## Настройки слога

Попробуем изменить настройки слога, чтобы сделать генерацию более похожей на желаемый результат.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<NameGenerator>(g => g
            .WithLetterSet(l => l
                .WithVowels("aiuoe")
                .WithConsonants("nzlgrm")
                .WithConsonantClusters("sh", "hr", "ks", "kr", "nt", "nd", "rt", "rd", "rr"))
            .WithSyllables(2)
            .WithDefaultSyllableSettings(c => c
                .WithVowelsChance(0.95)
                .WithConsonantsChance(0.95)
                .WithLeadingConsonantBeClusteredChance(0.1)
                .WithTailingConsonantBeClusteredChance(0.5))));

// Вывод:         
// mashrond
// rtamgo
// nonnart
// lartgog
// murrnard
```

Звучит хорошо, однако все еще недостаточно грозно.

## Добавление окончаний

Ничто так не повышает грозность, как правильное окончание имени. Воспользуемся мутацией, чтобы добавить именам наших орков чуть больше "оркости".

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<NameGenerator>(g => g
            .WithLetterSet(l => l
                .WithVowels("aiuoe")
                .WithConsonants("nzlgrm")
                .WithConsonantClusters("sh", "hr", "ks", "kr", "nt", "nd", "rt", "rd", "rr"))
            .WithSyllables(2)
            .WithDefaultSyllableSettings(c => c
                .WithVowelsChance(0.95)
                .WithConsonantsChance(0.95)
                .WithLeadingConsonantBeClusteredChance(0.1)
                .WithTailingConsonantBeClusteredChance(0.5)))
        .AddMutation(m => m
            .IfMatch("[aeiouy]$")
            .AppendWithAny("grym", "grim", "drim", "dur", "zog", "urk"))
        .AddMutation(m => m
            .ToUpperFirst()));

// Вывод:
// Luntlokr
// Magraz
// Rrunnard
// Ishgaz
// Gantrtakr
// Lakrush
// Nongesh
```

Мне кажется, звучит отлично. Можно продолжить доводить конфигурацию до совершенства, но для данного руководства этого вполне достаточно.
