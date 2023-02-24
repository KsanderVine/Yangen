namespace Yangen.Defaults
{
    public class DefaultLetterSet : LetterSet
    {
        private static readonly string _defaultVowels = "aeiouy";
        private static readonly string _defaultLeadingConsonants = "bcdfghklmnprstvxhrw";
        private static readonly string _defaultTailingConsonants = "bcdfghklmnprstvxhrw";

        private static readonly string[] _defaultVowelClusters =
        {"ai", "ay", "ia", "ea", "ey", "ie", "ae", "oi", "au", "ou"};

        private static readonly string[] _defaultLeadingConsonantClusters =
        {"sh", "pl", "sp", "tr", "gl", "bl", "cl", "sc", "pr", "dr", "ch", "sl", "cr", "fl", "th", "br", "st"};

        private static readonly string[] _defaultTailingConsonantSequences =
        { "rk", "sc", "st", "nk", "xt", "ck", "ng"};

        public DefaultLetterSet()
        {
            WithVowels(_defaultVowels);
            WithLeadingConsonants(_defaultLeadingConsonants);
            WithTailingConsonants(_defaultTailingConsonants);

            WithVowelClusters(_defaultVowelClusters);
            WithLeadingConsonantClusters(_defaultLeadingConsonantClusters);
            WithTailingConsonantClusters(_defaultTailingConsonantSequences);
        }
    }
}