using Yangen.Defaults;

namespace Yangen
{
    public sealed class SyllableGenerator : ISyllableGenerator
    {
        private static Random Random { get; set; } = new Random();

        private LetterSet? LetterSet { get; set; }
        private SyllableSettings? SyllableSettings { get; set; }

        public SyllableGenerator WithDefault()
        {
            LetterSet = new DefaultLetterSet();
            SyllableSettings = new DefaultSyllableSettings();
            return this;
        }

        public SyllableGenerator WithDefaultLetterSet()
        {
            LetterSet = new DefaultLetterSet();
            return this;
        }

        public SyllableGenerator WithDefaultLetterSet(Func<LetterSet, LetterSet> configure)
        {
            var letterSet = configure(new DefaultLetterSet());

            if (letterSet is null)
                throw new NullReferenceException($"Value of {nameof(letterSet)} can not be null");

            LetterSet = letterSet;
            return this;
        }

        public SyllableGenerator WithLetterSet(LetterSet letterSet)
        {
            if (letterSet is null)
                throw new ArgumentNullException(nameof(letterSet));

            LetterSet = letterSet;
            return this;
        }

        public SyllableGenerator WithLetterSet(Func<LetterSet, LetterSet> configure)
        {
            var letterSet = configure(new LetterSet());

            if (letterSet is null)
                throw new NullReferenceException($"Value of {nameof(letterSet)} can not be null");

            LetterSet = configure(new LetterSet());
            return this;
        }

        public SyllableGenerator WithDefaultSyllableSettings()
        {
            SyllableSettings = new DefaultSyllableSettings();
            return this;
        }

        public SyllableGenerator WithDefaultSyllableSettings(Func<SyllableSettings, SyllableSettings> configure)
        {
            var settings = configure(new DefaultSyllableSettings());

            if (settings is null)
                throw new NullReferenceException($"Value of {nameof(settings)} can not be null");

            SyllableSettings = settings;
            return this;
        }

        public SyllableGenerator WithSyllableSettings(SyllableSettings settings)
        {
            if (settings is null)
                throw new ArgumentNullException(nameof(settings));

            SyllableSettings = settings;
            return this;
        }

        public SyllableGenerator WithSyllableSettings(Func<SyllableSettings, SyllableSettings> configure)
        {
            var settings = configure(new SyllableSettings());

            if (settings is null)
                throw new NullReferenceException($"Value of {nameof(settings)} can not be null");

            SyllableSettings = configure(new SyllableSettings());
            return this;
        }

        public string? Next()
        {
            return GenerateSyllable(false).ToString();
        }

        public Syllable GenerateSyllable(bool isFirstSyllable)
        {
            if (SyllableSettings == null)
                throw new NullReferenceException("Settings not provided");

            if (LetterSet == null)
                throw new NullReferenceException("LetterSet not provided");

            var syllable = new Syllable();
            bool isFirstVowel = false;

            if (isFirstSyllable)
            {
                if (SyllableSettings.VowelsEnabled && ChanceFor(SyllableSettings.FirstVowelsChance))
                {
                    syllable.Vowel = GetRandomLetterByFrequency(LetterSet.Vowels);
                    isFirstVowel = true;
                }
            }

            if (isFirstVowel == false)
            {
                if (SyllableSettings.LeadingConsonantsEnabled && ChanceFor(SyllableSettings.LeadingConsonantsChance))
                {
                    if (Any(LetterSet.LeadingConsonantClusters) && ChanceFor(SyllableSettings.LeadingConsonantBeClusteredChance))
                    {
                        syllable.LeadingConsonant = GetRandomLetterByFrequency(LetterSet.LeadingConsonantClusters);
                    }
                    else
                    {
                        syllable.LeadingConsonant = GetRandomLetterByFrequency(LetterSet.LeadingConsonants);
                    }
                }
            }

            if (isFirstVowel == false)
            {
                if (SyllableSettings.VowelsEnabled && ChanceFor(SyllableSettings.VowelsChance))
                {
                    if (Any(LetterSet.VowelClusters) && ChanceFor(SyllableSettings.VowelBeClusteredChance))
                    {
                        syllable.Vowel = GetRandomLetterByFrequency(LetterSet.VowelClusters);
                    }
                    else
                    {
                        syllable.Vowel = GetRandomLetterByFrequency(LetterSet.Vowels);
                    }
                }
            }

            if (SyllableSettings.TailingConsonantsEnabled && ChanceFor(SyllableSettings.TailingConsonantsChance))
            {
                if (Any(LetterSet.TailingConsonantClusters) && ChanceFor(SyllableSettings.TailingConsonantBeClusteredChance))
                {
                    syllable.TailingConsonant = GetRandomLetterByFrequency(LetterSet.TailingConsonantClusters);
                }
                else
                {
                    syllable.TailingConsonant = GetRandomLetterByFrequency(LetterSet.TailingConsonants);
                }
            }
            return syllable;

            static bool ChanceFor(double chance) => Random.NextDouble() <= chance;
            static bool Any(HashSet<Letter> letters) => letters.Any(l => l.Frequency > 0);
        }

        private static Letter? GetRandomLetterByFrequency(HashSet<Letter> letterSet)
        {
            var letters = letterSet.Where(l => l.Frequency > 0).ToList();

            if (!letters.Any())
                return null;

            int totalFrequency = letters.Sum(l => l.Frequency);
            int targetFrequency = Random.Next(totalFrequency + 1);
            int counter = 0;

            foreach (var letter in letters)
            {
                counter += letter.Frequency;

                if (counter >= targetFrequency)
                {
                    return letter;
                }
            }

            throw new IndexOutOfRangeException(nameof(letters));
        }
    }
}