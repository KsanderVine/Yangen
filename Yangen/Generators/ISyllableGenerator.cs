namespace Yangen
{
    public interface ISyllableGenerator : IGenerator
    {
        Syllable GenerateSyllable(bool isFirstSyllable);
    }
}