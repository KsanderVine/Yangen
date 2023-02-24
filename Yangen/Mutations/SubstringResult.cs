namespace Yangen
{
    public sealed class SubstringResult
    {
        public int Index { get; set; }
        public int Position { get; set; }

        public SubstringResult(int index, int position)
        {
            Index = index;
            Position = position;
        }
    }
}
