namespace Yangen
{
    public class NamesEnumProcessor : ISourceProcessor
    {
        private readonly List<string> _names;

        public NamesEnumProcessor(IEnumerable<string> names)
        {
            _names = names.ToList();
        }

        public NamesEnumProcessor(params string[] names)
        {
            _names = new List<string>(names);
        }

        public IEnumerable<Name> ProcessNames(IEnumerable<Name> names)
        {
            var namesList = new List<Name>(names);
            namesList.AddRange(_names.Select(n => new Name(n)));
            return namesList;
        }
    }
}
