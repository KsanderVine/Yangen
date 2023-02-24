namespace Yangen
{
    public class SyllableSettings
    {
        public double LeadingConsonantsChance { get; set; }
        public double LeadingConsonantBeClusteredChance { get; set; }
        public bool LeadingConsonantsEnabled { get => LeadingConsonantsChance > 0; }

        public double FirstVowelsChance { get; set; }
        public double VowelsChance { get; set; }
        public double VowelBeClusteredChance { get; set; }
        public bool VowelsEnabled { get => VowelsChance > 0; }

        public double TailingConsonantsChance { get; set; }
        public double TailingConsonantBeClusteredChance { get; set; }
        public bool TailingConsonantsEnabled { get => TailingConsonantsChance > 0; }

        public SyllableSettings WithFirstVowelChance(double firstVowelsChance)
        {
            FirstVowelsChance = firstVowelsChance;
            return this;
        }

        public SyllableSettings WithLeadingConsonantsChance(double leadingConsonantsChance)
        {
            LeadingConsonantsChance = leadingConsonantsChance;
            return this;
        }

        public SyllableSettings WithLeadingConsonantBeClusteredChance(double leadingConsonantClustersChance)
        {
            LeadingConsonantBeClusteredChance = leadingConsonantClustersChance;
            return this;
        }

        public SyllableSettings WithVowelsChance(double vowelsChance)
        {
            VowelsChance = vowelsChance;
            return this;
        }

        public SyllableSettings WithVowelBeClusteredChance(double vowelClustersChance)
        {
            VowelBeClusteredChance = vowelClustersChance;
            return this;
        }

        public SyllableSettings WithTailingConsonantsChance(double tailingConsonantsChance)
        {
            TailingConsonantsChance = tailingConsonantsChance;
            return this;
        }

        public SyllableSettings WithTailingConsonantBeClusteredChance(double tailingConsonantClustersChance)
        {
            TailingConsonantBeClusteredChance = tailingConsonantClustersChance;
            return this;
        }

        public SyllableSettings WithConsonantsChance(double consonantsChance)
        {
            LeadingConsonantsChance = consonantsChance;
            TailingConsonantsChance = consonantsChance;
            return this;
        }

        public SyllableSettings WithConsonantBeClusteredChance(double consonantClustersChance)
        {
            LeadingConsonantBeClusteredChance = consonantClustersChance;
            TailingConsonantBeClusteredChance = consonantClustersChance;
            return this;
        }
    }
}