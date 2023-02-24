# Анализатор (Analyser)

Анализатор представляет особый обработчик списка имен, который никак не влияет на сам процесс генерации, но позволяет собрать некоторую специфическую информацию в формате отчета.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AddNames("Harry", "Hermione", "Ron", "Hagrid")
        .AnalyseLettersUsage("LettersUsage")
        .AnalyseUniqueNames("UniqueNames"));

designer.Next();
var formatter = new ConsoleTableReportFormatter();
```

Следующий анализатор создает таблицу частотой использований каждой буквы исходя из списка имен.

```csharp
var lettersUsageReport = designer.GetAnalyserReport("LettersUsage");
Console.WriteLine(formatter.FormatReport(lettersUsageReport!));

// Отчет использования букв:
-------------------------
| Letter || Usage count |
-------------------------
| H      || 3           |
| a      || 2           |
| r      || 4           |
| y      || 1           |
| e      || 2           |
| m      || 1           |
| i      || 2           |
| o      || 2           |
| n      || 2           |
| R      || 1           |
| g      || 1           |
| d      || 1           |
-------------------------
```

Следующий анализатор проверяет список имен на наличие повторений и возвращает единственную строку.

```csharp
var uniqueNamesReport = designer.GetAnalyserReport("UniqueNames");
Console.WriteLine(formatter.FormatReport(uniqueNamesReport!));

// Отчет уникальности имен:
---------------------
| Unique || Repeats |
---------------------
| 4      || 0       |
---------------------
```

Анализатор формирует отчет после первого запроса к дизайнеру. Дизайнер возвращает сформированный отчет по тегу анализатора, указанному при его конфигурации. Важно отметить, что анализатор создает отчет на имена, находящиеся в обработке до анализатора, то есть все результаты действий обработчиков, стоящих после анализатора, не попадут в итоговый отчет. Таким образом, необходимо разместить анализатор после всех прочих обработчиков, чтобы он корректно обработал имена. Следующий пример демонстрирует важность указания правильного порядка обработчиков.

```csharp
var designer = new NamelessDesigner()
    .UsingSource(s => s
        .AnalyseUniqueNames("UniqueNames")
        .AddNames("Harry", "Hermione", "Ron", "Hagrid"));

designer.Next();
var formatter = new ConsoleTableReportFormatter();

var uniqueNamesReport = designer.GetAnalyserReport("UniqueNames");
Console.WriteLine(formatter.FormatReport(uniqueNamesReport!));

// Отчет уникальности имен:
---------------------
| Unique || Repeats |
---------------------
| 0      || 0       |
---------------------
```

Анализаторы, как следует из их названия, необходимы для анализа имен. В процессе конфигурации дизайнера под определенную задачу некоторые процессы остаются за кадром, и итоговые списки имен в источниках скрыты. В этом случае и нужны анализаторы - для получения информации, которую можно использовать для внесения изменений в конфигурацию и улучшения процесса генерации.
