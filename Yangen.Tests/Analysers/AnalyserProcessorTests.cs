using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yangen;

namespace Yangen.Tests.Analysers
{
    public class AnalyserProcessorTests
    {
        [Fact]
        public void UsingAnalyser_ArgumentNullException_IfAnalyserIsNull()
        {
            var processor = new AnalyserProcessor();

            Assert.Throws<ArgumentNullException>(() => processor.UsingAnalyser(null!));
        }

        [Fact]
        public void WithAnalyserTag_ExpectedAnalyserTag()
        {
            var analyserTag = "AnalyserTag";
            var processor = new AnalyserProcessor();
            processor.WithAnalyserTag(analyserTag);

            Assert.Equal(analyserTag, processor.AnalyserTag);
        }

        [Fact]
        public void ProcessNames_ReturnsExpectedResult()
        {
            var names = new List<Name>() { "SomenameA", "SomenameB", "SomenameC" };
            var processor = new AnalyserProcessor();

            Assert.Collection(processor.ProcessNames(names),
                x => x.Equals(names[0]),
                x => x.Equals(names[1]),
                x => x.Equals(names[2]));
        }
    }

    public class LettersUsageAnalyserTests
    {
        [Fact]
        public void GetReport_ExpectingNotNullReport()
        {
            var names = new List<Name>() { "SA", "SB", "SC" };
            var analyser = new LettersUsageAnalyser();
            var report = analyser.GetReport(names);

            Assert.NotNull(report);
        }

        [Fact]
        public void GetReport_ExpectingNotEmptyRows()
        {
            var names = new List<Name>() { "SA", "SB", "SC" };
            var analyser = new LettersUsageAnalyser();
            var report = analyser.GetReport(names);

            Assert.NotEmpty(report!.GetRows());
        }

        [Fact]
        public void GetReport_ExpectingRows()
        {
            var expected = new Dictionary<string, string>()
            {
                { "S", "3" },
                { "B", "1" },
                { "C", "1" },
                { "A", "1" }
            };
            var names = new List<Name>() { "SA", "SB", "SC" };
            var analyser = new LettersUsageAnalyser();
            var report = analyser.GetReport(names);

            var rows = report!.GetRows();
            Assert.Equal(4, rows.Count());

            foreach (var expectedLetter in expected.Keys)
            {
                string expectedCount = expected[expectedLetter];

                var row = rows.First(x => x.GetValues()[0].Equals(expectedLetter));
                Assert.Equal(expectedCount, row.GetValues()[1]);
            }
        }
    }

    public class UniqueNamesAnalyserTests
    {
        [Fact]
        public void GetReport_ExpectingNotNullReport()
        {
            var names = new List<Name>() { "SA", "SB", "SC" };
            var analyser = new UniqueNamesAnalyser();
            var report = analyser.GetReport(names);

            Assert.NotNull(report);
        }

        [Fact]
        public void GetReport_ExpectingNotEmptyRows()
        {
            var names = new List<Name>() { "SA", "SB", "SC" };
            var analyser = new UniqueNamesAnalyser();
            var report = analyser.GetReport(names);

            Assert.NotEmpty(report!.GetRows());
        }

        [Fact]
        public void GetReport_ExpectingRows()
        {
            var names = new List<Name>() { "Some", "Some", "Name" };
            var analyser = new UniqueNamesAnalyser();
            var report = analyser.GetReport(names);

            var rows = report!.GetRows();
            Assert.Single(rows);

            var row = rows.First();
            var rowValues = row.GetValues();

            Assert.Equal("2", rowValues[0]);
            Assert.Equal("1", rowValues[1]);
        }
    }
}
