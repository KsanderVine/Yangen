namespace Yangen.Defaults
{
    public class DefaultSyllableSettings : SyllableSettings
    {
        private static readonly double _defaultFirstVowelChance = 0.15;
        private static readonly double _defaultLeadingConsonantsChance = 0.8;
        private static readonly double _defaultLeadingConsonantBeClusteredChance = 0.05;
        private static readonly double _defaultVowelsChance = 1.0;
        private static readonly double _defaultVowelBeClusteredChance = 0.45;
        private static readonly double _defaultTailingConsonantsChance = 0.35;
        private static readonly double _defaultTailingConsonantBeClusteredChance = 0.05;

        public DefaultSyllableSettings()
        {
            WithFirstVowelChance(_defaultFirstVowelChance);
            WithLeadingConsonantsChance(_defaultLeadingConsonantsChance);
            WithLeadingConsonantBeClusteredChance(_defaultLeadingConsonantBeClusteredChance);
            WithVowelsChance(_defaultVowelsChance);
            WithVowelBeClusteredChance(_defaultVowelBeClusteredChance);
            WithTailingConsonantsChance(_defaultTailingConsonantsChance);
            WithTailingConsonantBeClusteredChance(_defaultTailingConsonantBeClusteredChance);
        }
    }
}