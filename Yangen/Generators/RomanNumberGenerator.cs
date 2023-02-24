using System.Text;

namespace Yangen
{
    public sealed class RomanNumberGenerator : IGenerator
    {
        public enum RomanNumber : int
        {
            I = 1,
            IV = 4,
            V = 5,
            IX = 9,
            X = 10,
            XL = 40,
            L = 50,
            XC = 90,
            C = 100,
            CD = 400,
            D = 500,
            CM = 900,
            M = 1000
        }

        private readonly Random _random = new();

        private int MinNumberValue { get; set; } = 1;
        private int MaxNumberValue { get; set; } = 10;

        public RomanNumberGenerator WithRange(int min, int max)
        {
            if (max < min)
                throw new ArgumentOutOfRangeException(nameof(max), $"Max value must be more than min value");

            if (min < 1)
                throw new ArgumentOutOfRangeException(nameof(min), $"Min value must be more than zero");

            MinNumberValue = min;
            MaxNumberValue = max;
            return this;
        }

        public RomanNumberGenerator WithNumber(int number)
        {
            if (number < 1)
                throw new ArgumentOutOfRangeException(nameof(number), $"Min value must be more than zero");

            MinNumberValue = number;
            MaxNumberValue = number;
            return this;
        }

        public string? Next()
        {
            return GenerateNumber();
        }

        private string GenerateNumber()
        {
            var roman = new StringBuilder();
            int number = _random.Next(MinNumberValue, MaxNumberValue);

            List<RomanNumber> romanNumbers = Enum.GetValues<RomanNumber>()
                .Reverse()
                .ToList();

            foreach (var romanNumber in romanNumbers)
            {
                int value = (int)romanNumber;

                while (number >= value)
                {
                    roman.Append(romanNumber.ToString());
                    number -= value;
                }
            }

            return roman.ToString();
        }
    }
}