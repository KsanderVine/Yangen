using System.Reflection;

namespace Yangen.Demo
{
    public static class Examples
    {
        private static List<Type> CachedAllTypes { get; set; } = new();
        public static List<Type> AllTypes
        {
            get
            {
                if (!CachedAllTypes.Any())
                {
                    CachedAllTypes = Assembly
                        .GetExecutingAssembly()
                        .GetTypes()
                        .ToList();
                }

                return CachedAllTypes;
            }
        }

        public static IEnumerable<(Type, Func<int, IEnumerable<string>>)> Search ()
        {
            IEnumerable<Type> types = AllTypes.Where(x => x.Name.EndsWith("Example"));
            IEnumerable<Type> forced = types.Where(x => x.ContainsAttribute<IgnoreOthersAttribute>());

            if (forced.Any())
            {
                types = forced;
            }

            foreach(var type in types)
            {
                var methodSearch = type.GetMethod("GetSamples", BindingFlags.Static | BindingFlags.Public);
                if (methodSearch is MethodInfo methodInfo)
                {
                    var methodType = typeof(Func<int, IEnumerable<string>>);
                    var method = (Func<int, IEnumerable<string>>)Delegate.CreateDelegate(methodType, methodInfo);
                    yield return (type, method);
                }
            }
        }

        public static bool ContainsAttribute<T>(this MemberInfo memberInfo) where T : Attribute
        {
            object[] customAttributes = memberInfo.GetCustomAttributes(typeof(T), inherit: true);
            foreach (object attribute in customAttributes)
            {
                if (attribute is T)
                {
                    return true;
                }
            }
            return false;
        }
    }


    [AttributeUsage(AttributeTargets.Class)]
    public class IgnoreOthersAttribute : Attribute
    {
    }
}