using System.Collections.Generic;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    [PublicAPI]
    public static class SetAttributeValuesExtensions
    {
        public static void SetAttributeValues(this IEnumerable<XElement> elements, XName name, object value)
        {
            foreach (XElement element in elements)
            {
                element.SetAttributeValue(name, value);
            }
        }
    }
}
