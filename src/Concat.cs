using System.Collections.Generic;
using JetBrains.Annotations;

namespace AD.Xml
{
    [PublicAPI]
    public static class ConcatExtensions
    {
        public static string Concat(this IEnumerable<string> strings, string join = null)
        {
            return string.Join(join, strings);
        }
    }
}
