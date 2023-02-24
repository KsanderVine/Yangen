using Yangen.Extenstions;

namespace Yangen
{
    public sealed class Source : ISource
    {
        public Tags Tags { get; set; }

        private List<Name> CompiledNames { get; set; }
        private List<ISourceProcessor> Processors { get; set; }

        private bool IsCompilable { get; set; } = true;
        private bool IsCompiled { get; set; }

        public Source()
        {
            Tags = new Tags { "_any_" };

            CompiledNames = new List<Name>();
            Processors = new List<ISourceProcessor>();
        }

        public ISource Tag(params string[] tags)
        {
            if (tags is null)
                throw new ArgumentNullException(nameof(tags));

            foreach (var tag in tags)
            {
                Tags += tag;
            }
            return this;
        }

        public ISource AsCompilable()
        {
            IsCompilable = true;
            return this;
        }

        public ISource AsNotCompilable()
        {
            IsCompilable = false;
            return this;
        }

        public ISource AddProcessor(ISourceProcessor sourceProcessor)
        {
            if (sourceProcessor is null)
                throw new ArgumentNullException(nameof(sourceProcessor));

            Processors.Add(sourceProcessor);
            return this;
        }

        public IEnumerable<ISourceProcessor> GetProcessors()
        {
            foreach (var processor in Processors)
            {
                yield return processor;
            }
        }

        public IEnumerable<Name> GetNames()
        {
            if (IsCompilable)
            {
                if (IsCompiled)
                {
                    return CompiledNames;
                }
            }

            CompiledNames.Clear();

            foreach (var service in Processors)
            {
                CompiledNames = service.ProcessNames(CompiledNames).ToList();
            }

            IsCompiled = true;
            return CompiledNames;
        }

        public Name? GetRandomName()
        {
            return GetNames().GetRandomItem();
        }
    }
}