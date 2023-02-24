namespace Yangen
{
    [Flags]
    public enum LetterType
    {
        None = 0,
        Vowel = 1,
        Consonant = 2,
        Leading = 4,
        Tailing = 8,
        Cluster = 16
    }
}