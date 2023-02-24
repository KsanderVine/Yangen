namespace Yangen.Extenstions
{
    internal static class BoolExtensions
    {
        public static void Invert(this ref bool b) => b = !b;
    }
}
