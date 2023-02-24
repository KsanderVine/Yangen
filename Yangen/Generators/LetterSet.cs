namespace Yangen
{
    public class LetterSet
    {
        public HashSet<Letter> LeadingConsonants { get; set; }
        public HashSet<Letter> LeadingConsonantClusters { get; set; }

        public HashSet<Letter> Vowels { get; set; }
        public HashSet<Letter> VowelClusters { get; set; }

        public HashSet<Letter> TailingConsonants { get; set; }
        public HashSet<Letter> TailingConsonantClusters { get; set; }

        public LetterSet()
        {
            LeadingConsonants = new HashSet<Letter>();
            LeadingConsonantClusters = new HashSet<Letter>();

            Vowels = new HashSet<Letter>();
            VowelClusters = new HashSet<Letter>();

            TailingConsonants = new HashSet<Letter>();
            TailingConsonantClusters = new HashSet<Letter>();
        }

        #region Vowels
        public LetterSet WithVowels(string vowels)
        {
            LetterType letterType = LetterType.Vowel;
            AddLettersToHashSet(Vowels, DetermineLetters(vowels, letterType));
            return this;
        }

        public LetterSet WithVowels(IEnumerable<string> vowels)
        {
            LetterType letterType = LetterType.Vowel;
            AddLettersToHashSet(Vowels, DetermineLetters(vowels, letterType));
            return this;
        }

        public LetterSet WithVowels(params string[] vowels)
        {
            return WithVowels(vowels.ToList());
        }
        #endregion

        #region VowelClusters
        public LetterSet WithVowelClusters(IEnumerable<string> vowelClusters)
        {
            LetterType letterType = LetterType.Vowel | LetterType.Cluster;
            AddLettersToHashSet(VowelClusters, DetermineLetters(vowelClusters, letterType));
            return this;
        }

        public LetterSet WithVowelClusters(params string[] vowelClusters)
        {
            return WithVowelClusters(vowelClusters.ToList());
        }
        #endregion

        #region LeadingConsonants
        public LetterSet WithLeadingConsonants(string consonants)
        {
            LetterType letterType = LetterType.Consonant | LetterType.Leading;
            AddLettersToHashSet(LeadingConsonants, DetermineLetters(consonants, letterType));
            return this;
        }

        public LetterSet WithLeadingConsonants(IEnumerable<string> consonants)
        {
            LetterType letterType = LetterType.Consonant | LetterType.Leading;
            AddLettersToHashSet(LeadingConsonants, DetermineLetters(consonants, letterType));
            return this;
        }

        public LetterSet WithLeadingConsonants(params string[] consonants)
        {
            return WithLeadingConsonants(consonants.ToList());
        }
        #endregion

        #region LeadingConsonantClusters
        public LetterSet WithLeadingConsonantClusters(IEnumerable<string> consontantClusters)
        {
            LetterType letterType = LetterType.Consonant | LetterType.Leading | LetterType.Cluster;
            AddLettersToHashSet(LeadingConsonantClusters, DetermineLetters(consontantClusters, letterType));
            return this;
        }

        public LetterSet WithLeadingConsonantClusters(params string[] consontantClusters)
        {
            return WithLeadingConsonantClusters(consontantClusters.ToList());
        }
        #endregion

        #region TailingConsonants
        public LetterSet WithTailingConsonants(string consonants)
        {
            LetterType letterType = LetterType.Consonant | LetterType.Tailing;
            AddLettersToHashSet(TailingConsonants, DetermineLetters(consonants, letterType));
            return this;
        }

        public LetterSet WithTailingConsonants(IEnumerable<string> consonants)
        {
            LetterType letterType = LetterType.Consonant | LetterType.Tailing;
            AddLettersToHashSet(TailingConsonants, DetermineLetters(consonants, letterType));
            return this;
        }

        public LetterSet WithTailingConsonants(params string[] consonants)
        {
            return WithTailingConsonants(consonants.ToList());
        }
        #endregion

        #region TailingConsonantClusters
        public LetterSet WithTailingConsonantClusters(IEnumerable<string> consontantClusters)
        {
            LetterType letterType = LetterType.Consonant | LetterType.Tailing | LetterType.Cluster;
            AddLettersToHashSet(TailingConsonantClusters, DetermineLetters(consontantClusters, letterType));
            return this;
        }

        public LetterSet WithTailingConsonantClusters(params string[] consontantClusters)
        {
            return WithTailingConsonantClusters(consontantClusters.ToList());
        }
        #endregion

        #region WithConsonants
        public LetterSet WithConsonants(string consonants)
        {
            LetterType leadingLetterType = LetterType.Consonant | LetterType.Tailing;
            AddLettersToHashSet(LeadingConsonants, DetermineLetters(consonants, leadingLetterType));

            LetterType tailingLetterType = LetterType.Consonant | LetterType.Tailing;
            AddLettersToHashSet(TailingConsonants, DetermineLetters(consonants, tailingLetterType));
            return this;
        }

        public LetterSet WithConsonants(IEnumerable<string> consonants)
        {
            LetterType leadingLetterType = LetterType.Consonant | LetterType.Tailing;
            AddLettersToHashSet(LeadingConsonants, DetermineLetters(consonants, leadingLetterType));

            LetterType tailingLetterType = LetterType.Consonant | LetterType.Tailing;
            AddLettersToHashSet(TailingConsonants, DetermineLetters(consonants, tailingLetterType));
            return this;
        }

        public LetterSet WithConsonants(params string[] consonants)
        {
            return WithConsonants(consonants.ToList());
        }
        #endregion

        #region ConsonantClusters
        public LetterSet WithConsonantClusters(IEnumerable<string> consontantClusters)
        {
            LetterType letterType = LetterType.Consonant | LetterType.Cluster;
            AddLettersToHashSet(LeadingConsonantClusters, DetermineLetters(consontantClusters, letterType | LetterType.Leading));
            AddLettersToHashSet(TailingConsonantClusters, DetermineLetters(consontantClusters, letterType | LetterType.Tailing));
            return this;
        }

        public LetterSet WithConsonantClusters(params string[] consontantClusters)
        {
            return WithConsonantClusters(consontantClusters.ToList());
        }
        #endregion

        public LetterSet Frequency(int frequency, Func<LetterSet, LetterSet> configure)
        {
            LetterSet letterSet = new();
            letterSet = configure(letterSet);

            AddLettersToHashSet(Vowels,
                UpdateFrequencyAndReturn(frequency, letterSet.Vowels.ToList()));

            AddLettersToHashSet(VowelClusters,
                UpdateFrequencyAndReturn(frequency, letterSet.VowelClusters.ToList()));

            AddLettersToHashSet(LeadingConsonants,
                UpdateFrequencyAndReturn(frequency, letterSet.LeadingConsonants.ToList()));

            AddLettersToHashSet(LeadingConsonantClusters,
                UpdateFrequencyAndReturn(frequency, letterSet.LeadingConsonantClusters.ToList()));

            AddLettersToHashSet(TailingConsonants,
                UpdateFrequencyAndReturn(frequency, letterSet.TailingConsonants.ToList()));

            AddLettersToHashSet(TailingConsonantClusters,
                UpdateFrequencyAndReturn(frequency, letterSet.TailingConsonantClusters.ToList()));

            return this;
        }

        private List<Letter> UpdateFrequencyAndReturn(int frequency, List<Letter> letters)
        {
            if (!letters.Any())
                return letters;

            foreach (var letter in letters)
            {
                letter.Frequency = frequency;
            }

            return letters;
        }

        private void AddLettersToHashSet(HashSet<Letter> hashSet, List<Letter> letters)
        {
            if (letters.Any())
            {
                letters.ForEach(l => hashSet.Add(l));
            }
        }

        private static List<Letter> DetermineLetters(string stringToDetermine, LetterType lettersType)
        {
            return SplitToList(stringToDetermine)
                .Select(v => new Letter(v, lettersType))
                .ToList();
        }

        private static List<Letter> DetermineLetters(IEnumerable<string> letterStrings, LetterType lettersType)
        {
            return letterStrings.Select(v => new Letter(v, lettersType)).ToList();
        }

        private static List<string> SplitToList(string stringToSplit)
        {
            return stringToSplit
                .Select(c => c.ToString())
                .ToList();
        }

        public LetterSet Clone()
        {
            LetterSet clone = new();

            clone.WithLeadingConsonantClusters(GetLettersAsStringList(LeadingConsonantClusters));
            clone.WithTailingConsonantClusters(GetLettersAsStringList(LeadingConsonantClusters));
            clone.WithVowelClusters(GetLettersAsStringList(VowelClusters));

            clone.WithLeadingConsonants(GetLettersAsString(LeadingConsonants));
            clone.WithTailingConsonants(GetLettersAsString(TailingConsonants));
            clone.WithVowels(GetLettersAsString(Vowels));

            return clone;

            string GetLettersAsString(HashSet<Letter> letters)
            {
                return string.Join(null, letters);
            }

            List<string> GetLettersAsStringList(HashSet<Letter> letters)
            {
                return letters.Select(l => l.ToString()).ToList();
            }
        }
    }
}