namespace Yangen
{
    public sealed class FilterProcessor : IFilterProcessor
    {
        private List<IFilterRule> FilterRules { get; set; }

        public FilterProcessor()
        {
            FilterRules = new List<IFilterRule>();
        }

        public IFilterProcessor AddFilterRule(IFilterRule filterRule)
        {
            if (filterRule is null)
                throw new ArgumentNullException(nameof(filterRule));

            FilterRules.Add(filterRule);
            return this;
        }

        public IEnumerable<Name> ProcessNames(IEnumerable<Name> names)
        {
            if (!FilterRules.Any())
                return names;

            List<Name> namesList = names.ToList();
            (int validCount, FilterFlag[] flags) = GetFilterFlagsForNames(namesList, FilterRules);

            if (validCount == 0)
                return new List<Name>();

            return flags
                .Where(x => x.IsValid == true)
                .Select(x => namesList[x.NameIndex]);
        }

        private static (int, FilterFlag[]) GetFilterFlagsForNames(List<Name> names, List<IFilterRule> filterRules)
        {
            int validCount = 0;
            FilterFlag[] flags = new FilterFlag[names.Count];

            int flagIndex = 0;
            foreach (var name in names)
            {
                flags[flagIndex].NameIndex = flagIndex;
                if (IsValidName(name))
                {
                    flags[flagIndex].IsValid = true;
                    validCount++;
                }
                flagIndex++;
            }

            return (validCount, flags);

            bool IsValidName(Name name)
            {
                foreach (var filterRule in filterRules)
                {
                    if (!filterRule.IsValidName(name))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private struct FilterFlag
        {
            public int NameIndex { get; set; }
            public bool IsValid { get; set; }
        }
    }
}