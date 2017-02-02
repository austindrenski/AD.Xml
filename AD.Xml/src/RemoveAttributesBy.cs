using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    [PublicAPI]
    public static class RemoveAttributesByExtensions
    {
        public static XElement RemoveAttributesBy(this XElement element, XName name)
        {
            element.DescendantsAndSelf().Attributes(name).Remove();
            return element;
        }

        public static IEnumerable<XElement> RemoveAttributesBy(this IEnumerable<XElement> elements, XName name)
        {
            return elements.Select(x => x.RemoveAttributesBy(name));
        }

        public static ParallelQuery<XElement> RemoveAttributesBy(this ParallelQuery<XElement> elements, XName name)
        {
            return elements.Select(x => x.RemoveAttributesBy(name));
        }
    }
}
