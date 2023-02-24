using Yangen.Extenstions;

namespace Yangen
{
    public sealed class NamelessDesigner : IGeneratorDesigner<NamelessDesigner>
    {
        private class SourceSink
        {
            public string Tag { get; set; } = string.Empty;
            private List<ISource> Sources { get; set; } = new List<ISource>();

            public SourceSink(string tag)
            {
                Tag = tag;
            }

            public SourceSink Add(ISource source)
            {
                Sources.Add(source);
                return this;
            }

            public int Count() => Sources.Count;

            public Name GetRandomName()
            {
                int index = Random.Shared.Next(Sources.Count);
                Name? name = Sources[index].GetRandomName();
                return name is null ? string.Empty : name;
            }
        }

        private List<ISource> Sources { get; set; }
        private List<Template> Templates { get; set; }

        private bool IsCompiled { get; set; }
        private List<SourceSink> SourceSinks { get; set; }

        public NamelessDesigner()
        {
            Sources = new List<ISource>();
            Templates = new List<Template>();
            SourceSinks = new List<SourceSink>();
        }

        public NamelessDesigner UsingSource(ISource source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            Sources.Add(source);

            return this;
        }

        public NamelessDesigner UsingSource(Func<ISource, ISource> configure)
        {
            ISource? source = configure(new Source());

            if (source is null)
                throw new NullReferenceException($"Configured source can not be null");

            Sources.Add(source);
            return this;
        }

        public NamelessDesigner UsingTemplates(params Template[] templates)
        {
            Templates.AddRange(templates);
            return this;
        }

        public IEnumerable<ISource> GetSources() => Sources.ToList();

        public string NextWithTag(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                throw new ArgumentException($"Value of {nameof(tag)} can not be null, empty or write space");

            if (!IsCompiled)
            {
                CompileSourceSinks();
                IsCompiled = true;
            }

            return GetRandomNameByTag(tag).ToString();
        }

        public string NextWithTemplate(Template template)
        {
            if (template is null)
                throw new ArgumentNullException(nameof(template));

            if (!IsCompiled)
            {
                CompileSourceSinks();
                IsCompiled = true;
            }

            var tags = template.GetTags();

            var names = GetRandomNamesByTags(tags)
                .Select(n => n.ToString())
                .ToArray();

            return template.Map(names);
        }

        public string Next()
        {
            if (!Sources.Any())
                throw new NullReferenceException("No source provided");

            if (!IsCompiled)
            {
                CompileSourceSinks();
                IsCompiled = true;
            }

            if (Templates.GetRandomItem() is Template template)
            {
                return NextWithTemplate(template);
            }

            return NextWithTag("_any_");
        }

        private IEnumerable<Name> GetRandomNamesByTags(IEnumerable<string> tags)
        {
            var names = new List<Name>();

            foreach (var tag in tags)
            {
                var name = GetRandomNameByTag(tag);
                names.Add(name);
            }

            return names;
        }

        private Name GetRandomNameByTag(string tag)
        {
            if (SourceSinks.Find(x => x.Tag == tag) is SourceSink sourcesSink)
            {
                return sourcesSink.GetRandomName();
            }

            throw new NullReferenceException($"Could not find any source with tag \"{tag}\"");
        }

        private void CompileSourceSinks()
        {
            SourceSinks = new List<SourceSink>();
            foreach (var source in Sources)
            {
                foreach (var tag in source.Tags)
                {
                    if (SourceSinks.Find(x => x.Tag == tag) is SourceSink sourceSink)
                    {
                        sourceSink.Add(source);
                    }
                    else
                    {
                        var newSourceSink = new SourceSink(tag);
                        SourceSinks.Add(newSourceSink);
                        newSourceSink.Add(source);
                    }
                }
            }
        }
    }
}