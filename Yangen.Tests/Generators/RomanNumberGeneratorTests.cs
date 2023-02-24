using Yangen;

namespace Yangen.Tests.Generators
{
    public class RomanNumberGeneratorTests
    {
        [Fact]
        public void Next_WithNumber_1_Returns_I()
        {
            var romanGenerator = new RomanNumberGenerator().WithNumber(1);

            Assert.Equal("I", romanGenerator.Next());
        }

        [Fact]
        public void Next_WithNumber_5_Returns_V()
        {
            var romanGenerator = new RomanNumberGenerator().WithNumber(5);

            Assert.Equal("V", romanGenerator.Next());
        }

        [Fact]
        public void Next_WithNumber_99_Returns_XCIX()
        {
            var romanGenerator = new RomanNumberGenerator().WithNumber(3999);

            Assert.Equal("MMMCMXCIX", romanGenerator.Next());
        }

        [Fact]
        public void Next_WithNumber_499_Returns_CDXCIX()
        {
            var romanGenerator = new RomanNumberGenerator().WithNumber(3999);

            Assert.Equal("MMMCMXCIX", romanGenerator.Next());
        }

        [Fact]
        public void Next_WithNumber_999_Returns_CMXCIX()
        {
            var romanGenerator = new RomanNumberGenerator().WithNumber(3999);

            Assert.Equal("MMMCMXCIX", romanGenerator.Next());
        }

        [Fact]
        public void Next_WithNumber_1999_Returns_MCMXCIX()
        {
            var romanGenerator = new RomanNumberGenerator().WithNumber(3999);

            Assert.Equal("MMMCMXCIX", romanGenerator.Next());
        }

        [Fact]
        public void Next_WithNumber_2999_Returns_MMCMXCIX()
        {
            var romanGenerator = new RomanNumberGenerator().WithNumber(3999);

            Assert.Equal("MMMCMXCIX", romanGenerator.Next());
        }

        [Fact]
        public void Next_WithNumber_3999_Returns_MMMCMXCIX()
        {
            var romanGenerator = new RomanNumberGenerator().WithNumber(3999);

            Assert.Equal("MMMCMXCIX", romanGenerator.Next());
        }

        [Theory]
        [InlineData(500, 150)]
        [InlineData(1000, 150)]
        [InlineData(1000, 100)]
        [InlineData(10000, 100)]
        public void WithRange_ThrowsArgumentOutOfRangeException_IfMaxLessThanMin(int min, int max)
        {
            var numberGenerator = new RomanNumberGenerator();

            Assert.Throws<ArgumentOutOfRangeException>(() => numberGenerator.WithRange(min, max));
        }

        [Theory]
        [InlineData(-100, 150)]
        [InlineData(-1, 150)]
        [InlineData(0, 150)]
        public void WithRange_ThrowsArgumentOutOfRangeException_IfMinLessThanOne(int min, int max)
        {
            var numberGenerator = new RomanNumberGenerator();

            Assert.Throws<ArgumentOutOfRangeException>(() => numberGenerator.WithRange(min, max));
        }

        [Theory]
        [InlineData(-100, 150)]
        [InlineData(-1, 150)]
        [InlineData(0, 150)]
        public void WithNumber_ThrowsArgumentOutOfRangeException_IfMinLessThanOne(int min, int max)
        {
            var numberGenerator = new RomanNumberGenerator();

            Assert.Throws<ArgumentOutOfRangeException>(() => numberGenerator.WithRange(min, max));
        }
    }
}