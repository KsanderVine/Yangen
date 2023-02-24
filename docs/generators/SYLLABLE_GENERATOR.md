# Генератор слогов

В этом разделе мы подробнее рассмотрим возможности генератора слогов. Для начала стоит определиться с термином `слог`.

## Что такое слог?

Согласно тексту Википедии, это сочетание звуков в слове, произносимое одним толчком выдыхаемого воздуха. В практическом смысле это конструкция, состоящая из трех элементов: `начала`, `центра` и `окончания`. В терминах данного генератора это, соответственно, `leading consonant`, `vowel` и `tailing consonant`. На практике в центре не обязательно должна быть гласная, а в качестве ведущей буквы не всегда выступает согласная - такая терминология была выбрана ради простоты понимания. При конфигурации генератора вы можете указать абсолютно любые символы. Также стоит отметить, что в качестве этих элементов может выступать и группа букв - так называемые кластеры. Сам генератор состоит из двух обязательных частей, которые необходимо сконфигурировать: `алфавита` (Letters set) и `настроек слога` (Syllable settings).

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithSyllableSettings(..)
            .WithLetterSet(..)));
```

## Алфавит (Letters set)

Представляет собой хранилище всех возможных вариантов букв и буквосочетаний, используемых при генерации слога. Полный список элементов слога имеет следующий вид:

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithSyllableSettings(..)
            .WithLetterSet(l => l
                .WithLeadingConsonants("bcdfghklmnprstvxhrw")
                .WithLeadingConsonantClusters("sh", "pl", "sp", "tr")
                .WithVowels("aeiouy")
                .WithVowelClusters("ai", "ay", "ia", "ea")
                .WithTailingConsonants("bcdfghklmnprstvxhrw")
                .WithTailingConsonantClusters("rk", "sc", "st", "nk"))));
```

Также можно воспользоваться алфавитом по умолчанию, который уже включает в себя все английские гласные, согласные буквы и часто используемые буквосочетания.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithSyllableSettings(..)
            .WithDefaultLetterSet()));
```

В случае необходимости можно переопределить только какую-то его часть.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithSyllableSettings(..)
            .WithDefaultLetterSet(l => l
                .WithVowels("a")
                .WithVowelClusters("ai"))));
```

## Настройки слога (Syllable settings)

В настройках слога содержится шанс на размещение того или иного элемента слога. Полный список настроек слога имеет следующий вид:

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithSyllableSettings(d => d
                .WithFirstVowelChance(1.0)
                .WithLeadingConsonantsChance(1.0)
                .WithLeadingConsonantBeClusteredChance(1.0)
                .WithVowelsChance(1.0)
                .WithVowelBeClusteredChance(1.0)
                .WithTailingConsonantsChance(1.0)
                .WithTailingConsonantBeClusteredChance(1.0))
            .WithLetterSet(..)));
```

Также можно воспользоваться настройками по умолчанию, которые содержат откалиброванные значения вероятностей для букв и буквосочетаний.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefaultSyllableSettings()
            .WithLetterSet(..)));
```

В случае необходимости можно переопределить только какую-то их часть.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefaultSyllableSettings(d => d
                .WithVowelBeClusteredChance(1.0)
                .WithTailingConsonantsChance(1.0)
                .WithTailingConsonantBeClusteredChance(1.0))
            .WithLetterSet(..)));
```

## Полный вид конфигурации

Ради устрашения стоит продемонстрировать полный вид всей конфигурации генератора слогов без использования значений по умолчанию.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithSyllableSettings(d => d
                .WithFirstVowelChance(1.0)
                .WithLeadingConsonantsChance(1.0)
                .WithLeadingConsonantBeClusteredChance(1.0)
                .WithVowelsChance(1.0)
                .WithVowelBeClusteredChance(1.0)
                .WithTailingConsonantsChance(1.0)
                .WithTailingConsonantBeClusteredChance(1.0))
            .WithLetterSet(l => l
                .WithLeadingConsonants("bcdfghklmnprstvxhrw")
                .WithLeadingConsonantClusters("sh", "pl", "sp", "tr")
                .WithVowels("aeiouy")
                .WithVowelClusters("ai", "ay", "ia", "ea")
                .WithTailingConsonants("bcdfghklmnprstvxhrw")
                .WithTailingConsonantClusters("rk", "sc", "st", "nk"))));
```

Однако такой вид конфигурация принимает только при необходимости тонко настроить абсолютно каждый параметр. Для ознакомления с практическим использованием генератора загляните в раздел демонстраций.

## Конфигурация по умолчанию

Если вас не интересует тонкая настройка генератора и необходимо просто получить хоть какой-то слог, можно воспользоваться настройками по умолчанию. Два следующих способа идентичны, второй является сокращенной версией первого.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefaultSyllableSettings()
            .WithDefaultLetterSet()));
```

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithDefault()));
```

## Пример конфигурации

Следующий пример должен продемонстрировать использование данного генератора на практике.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddGenerator<SyllableGenerator>(g => g
            .WithLetterSet(l => l
                .WithVowels("oaei")
                .WithConsonants("brcps"))
            .WithDefaultSyllableSettings(c => c
                .WithFirstVowelChance(0)
                .WithConsonantsChance(1)
                .WithConsonantBeClusteredChance(0))));

// Вывод:
// rob
// seb
// pap
```

Как можно заметить, в примере в качестве алфавита не используются значения по умолчанию, при этом определены далеко не все возможные элементы (буквы и кластеры). В процессе генератор использует только те элементы, которые были определены в конфигурации. Если не будет определено ничего - генератор вернет пустую строку.  В данном случае генератор получил алфавит с набором гласных - `oaei` и набором универсальных согласных, которые могут быть размещены и в начале, и в окончании слога - `brcps`.

В качестве настроек слога мы используем значения по умолчанию, но переопределяем некоторые из них. Таким образом явно указано, что слог не будет начинаться с гласной. При этом всегда будут присутствовать начало и окончание, но они никогда не будут представлены в виде буквосочетаний (кластеров), хотя эта настройка и не нужна, так как алфавиту не было передано ни одно буквосочетание.

В результате генератор вернул следующие слоги: `rob`, `seb` и `pap`. Но как это использовать? Для ознакомления с практическим использованием генератора загляните в раздел демонстраций.
