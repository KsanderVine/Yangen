using System.Text.RegularExpressions;

namespace Yangen
{
    public sealed class MatchResult
    {
        public int Index { get; set; }
        public Match Match { get; set; }

        public MatchResult(int index, Match match)
        {
            Index = index;
            Match = match;
        }
    }
}
