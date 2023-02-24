using Yangen;

namespace Yangen.Tests.Generators
{
    public class NumberGeneratorTests
    {
        [Fact]
        public void Next_ReturnsZero_IfGeneratorNotConfigured()
        {
            var numberGenerator = new NumberGenerator();

            Assert.Equal("0", numberGenerator.Next()?.ToString());
        }

        [Theory]
        [InlineData(500, 550)]
        [InlineData(10, 150)]
        [InlineData(-1000, 1900)]
        [InlineData(-100000, -100)]
        public void Next_ReturnsExpectedValueInRange(int min, int max)
        {
            var numberGenerator = new NumberGenerator().WithRange(min, max);

            Assert.InRange(Convert.ToInt32(numberGenerator.Next()?.ToString()), min, max);
        }

        [Theory]
        [InlineData(500, 150)]
        [InlineData(1000, 150)]
        [InlineData(1000, 100)]
        [InlineData(10000, 100)]
        public void WithRange_ThrowsArgumentOutOfRangeException_IfMaxLessThanMin(int min, int max)
        {
            var numberGenerator = new NumberGenerator();

            Assert.Throws<ArgumentOutOfRangeException>(() => numberGenerator.WithRange(min, max));
        }

        [Theory]
        [InlineData(10, "#######10")]
        [InlineData(0, "########0")]
        [InlineData(9, "########9")]
        [InlineData(555, "######555")]
        [InlineData(-998, "#####-998")]
        public void Next_ReturnsExpected_ForPaddingLeft(int number, string expected)
        {
            var numberGenerator = new NumberGenerator()
                .WithTotalLength(9)
                .WithRange(number, number)
                .WithLeftPadding('#');

            Assert.Equal(expected, numberGenerator.Next()?.ToString());
        }

        [Theory]
        [InlineData(10, "10#######")]
        [InlineData(0, "0########")]
        [InlineData(9, "9########")]
        [InlineData(555, "555######")]
        [InlineData(-998, "-998#####")]
        public void Next_ReturnsExpected_ForPaddingRight(int number, string expected)
        {
            var numberGenerator = new NumberGenerator()
                .WithTotalLength(9)
                .WithRange(number, number)
                .WithRightPadding('#');

            Assert.Equal(expected, numberGenerator.Next()?.ToString());
        }

        [Theory]
        [InlineData(10, "###10####")]
        [InlineData(0, "####0####")]
        [InlineData(9, "####9####")]
        [InlineData(555, "###555###")]
        [InlineData(-998, "##-998###")]
        public void Next_ReturnsExpected_ForPaddingBoth(int number, string expected)
        {
            var numberGenerator = new NumberGenerator()
                .WithTotalLength(9)
                .WithRange(number, number)
                .WithLeftPadding('#')
                .WithRightPadding('#');

            Assert.Equal(expected, numberGenerator.Next()?.ToString());
        }
    }
}