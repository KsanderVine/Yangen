using System.Text;
using Yangen.Defaults;

namespace Yangen
{
    public sealed class NameGenerator : IGenerator
    {
        private readonly Random _random = new();

        private int MinSyllableCount { get; set; } = 2;
        private int MaxSyllableCount { get; set; } = 3;

        private LetterSet? LetterSet { get; set; }
        private SyllableSettings? SyllableSettings { get; set; }

        private ISyllableGenerator SyllableGenerator { get; set; }

        private bool IsSyllableGeneratorConfigured { get; set; }

        public NameGenerator()
        {
            SyllableGenerator = new SyllableGenerator();
        }

        public NameGenerator WithDefault()
        {
            LetterSet = new DefaultLetterSet();
            SyllableSettings = new DefaultSyllableSettings();
            return this;
        }

        public NameGenerator WithDefaultLetterSet()
        {
            LetterSet = new DefaultLetterSet();
            return this;
        }

        public NameGenerator WithDefaultLetterSet(Func<LetterSet, LetterSet> configure)
        {
            var letterSet = configure(new DefaultLetterSet());

            if (letterSet is null)
                throw new NullReferenceException($"Value of {nameof(letterSet)} can not be null");

            LetterSet = letterSet;
            return this;
        }

        public NameGenerator WithLetterSet(LetterSet letterSet)
        {
            if (letterSet is null)
                throw new ArgumentNullException(nameof(letterSet));

            LetterSet = letterSet;
            return this;
        }

        public NameGenerator WithLetterSet(Func<LetterSet, LetterSet> configure)
        {
            var letterSet = configure(new LetterSet());

            if (letterSet is null)
                throw new NullReferenceException($"Value of {nameof(letterSet)} can not be null");

            LetterSet = configure(new LetterSet());
            return this;
        }

        public NameGenerator WithDefaultSyllableSettings()
        {
            SyllableSettings = new DefaultSyllableSettings();
            return this;
        }

        public NameGenerator WithDefaultSyllableSettings(Func<SyllableSettings, SyllableSettings> configure)
        {
            var settings = configure(new DefaultSyllableSettings());

            if (settings is null)
                throw new NullReferenceException($"Value of {nameof(settings)} can not be null");

            SyllableSettings = settings;
            return this;
        }

        public NameGenerator WithSyllableSettings(SyllableSettings settings)
        {
            if (settings is null)
                throw new ArgumentNullException(nameof(settings));

            SyllableSettings = settings;
            return this;
        }

        public NameGenerator WithSyllableSettings(Func<SyllableSettings, SyllableSettings> configure)
        {
            var settings = configure(new SyllableSettings());

            if (settings is null)
                throw new NullReferenceException($"Value of {nameof(settings)} can not be null");

            SyllableSettings = configure(new SyllableSettings());
            return this;
        }

        public NameGenerator WithSyllables(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), $"Argument {nameof(count)} must be more than zero");

            MinSyllableCount = MaxSyllableCount = count;
            return this;
        }

        public NameGenerator WithSyllables(int min, int max)
        {
            if (max < min)
                throw new ArgumentOutOfRangeException(nameof(max), $"Argument {nameof(max)} must be more than {nameof(min)}");

            if (min <= 0)
                throw new ArgumentOutOfRangeException(nameof(min), $"Argument {nameof(min)} must be more than zero");

            MinSyllableCount = min;
            MaxSyllableCount = max;
            return this;
        }

        public NameGenerator WithSyllables(Range range)
        {
            if (range.End.Value < range.Start.Value)
                throw new ArgumentOutOfRangeException(nameof(range), $"Max value must be more than min value");

            if (range.Start.Value <= 0)
                throw new ArgumentOutOfRangeException(nameof(range), $"Min value of {nameof(range)} must be more than zero");

            MinSyllableCount = range.Start.Value;
            MaxSyllableCount = range.End.Value;
            return this;
        }

        public string? Next()
        {
            return GenerateName();
        }

        private string GenerateName()
        {
            if (SyllableSettings == null)
                throw new NullReferenceException("Settings not provided");

            if (LetterSet == null)
                throw new NullReferenceException("LetterSet not provided");

            var syllableGenerator = ConfigureAndReturnSyllableGenerator();

            StringBuilder nameBuilder = new();

            var syllablesCount = GetRandomSyllablesCount(
                MinSyllableCount, MaxSyllableCount);

            for (int s = 0; s < syllablesCount; s++)
            {
                Syllable syllable = syllableGenerator.GenerateSyllable(s == 0);
                nameBuilder.Append(syllable.ToString());
            }

            return nameBuilder.ToString();

            int GetRandomSyllablesCount(int min, int max) => min == max ? max : _random.Next(min, max + 1);

            ISyllableGenerator ConfigureAndReturnSyllableGenerator()
            {
                if (!IsSyllableGeneratorConfigured)
                {
                    SyllableGenerator = new SyllableGenerator()
                        .WithSyllableSettings(SyllableSettings)
                        .WithLetterSet(LetterSet);
                    IsSyllableGeneratorConfigured = true;
                }
                return SyllableGenerator;
            }
        }
    }
}