using Yangen.Extenstions;

namespace Yangen
{
    public sealed class NumberGenerator : IGenerator
    {
        private readonly Random _random = new();

        private int MinNumberValue { get; set; } = 0;
        private int MaxNumberValue { get; set; } = 0;

        private PaddingType Padding { get; set; } = PaddingType.None;

        private char LeftPadChar { get; set; }
        private char RightPadChar { get; set; }

        private int TotalNumberLength { get; set; }

        public NumberGenerator WithRange(int min, int max)
        {
            if (max < min)
                throw new ArgumentOutOfRangeException(nameof(max), $"Max value must be more than min value");

            MinNumberValue = min;
            MaxNumberValue = max;
            return this;
        }

        public NumberGenerator WithLeftPadding(char paddingChar = '0')
        {
            Padding |= PaddingType.Left;
            LeftPadChar = paddingChar;
            return this;
        }

        public NumberGenerator WithRightPadding(char paddingChar = '0')
        {
            Padding |= PaddingType.Right;
            RightPadChar = paddingChar;
            return this;
        }

        public NumberGenerator WithTotalLength(int length)
        {
            TotalNumberLength = length;
            return this;
        }

        public string? Next()
        {
            return GenerateNumber();
        }

        private string GenerateNumber()
        {
            string number = _random.Next(MinNumberValue, MaxNumberValue).ToString();

            if (number.Length < TotalNumberLength)
            {
                int paddingLength = TotalNumberLength - number.Length;

                int paddingLeftLength = Floor(paddingLength * LengthFactor(Padding, true));
                int paddingRightLendth = Ceiling(paddingLength * LengthFactor(Padding, false));

                number = $"{LeftPadChar.Repeat(paddingLeftLength)}{number}";
                number = $"{number}{RightPadChar.Repeat(paddingRightLendth)}";
            }

            return number;

            int Floor(double value) => Convert.ToInt32(Math.Floor(value));
            int Ceiling(double value) => Convert.ToInt32(Math.Ceiling(value));

            double LengthFactor(PaddingType padding, bool isLeftSide) => padding switch
            {
                PaddingType.None => 0.0,
                PaddingType.Both => 0.5,
                PaddingType.Left => isLeftSide == true ? 1.0 : 0.0,
                PaddingType.Right => isLeftSide == true ? 0.0 : 1.0,
                _ => 1.0,
            };
        }
    }
}