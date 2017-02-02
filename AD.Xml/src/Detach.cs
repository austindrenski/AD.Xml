using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    [PublicAPI]
    public static class DetachExtensions
    {
        public static IEnumerable<XElement> Detach(this IEnumerable<XElement> elements)
        {
            return elements.Select(x => { x.Remove(); return x; });
        }
    }
}
