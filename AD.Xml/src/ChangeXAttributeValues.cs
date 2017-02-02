using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    [PublicAPI]
    public static class ChangeXAttributeValuesExtensions
    {
        public static XElement ChangeXAttributeValues(this XElement element, XName name, string value)
        {
            foreach (XAttribute attribute in element.Descendants().Attributes(name))
            {
                attribute.SetValue(value);
            }
            return element;
        }

        [Pure]
        public static IEnumerable<XElement> ChangeXAttributeValues(this IEnumerable<XElement> element, XName name, string value)
        {
            return element.Select(x => x.ChangeXAttributeValues(name, value));
        }

        public static XElement ChangeXAttributeValues(this XElement element, XName name, string oldValue, string newValue)
        {
            foreach (XAttribute attribute in element.Descendants().Attributes(name).Where(x => x.Value == oldValue))
            {
                attribute.SetValue(newValue);
            }
            return element;
        }

        [Pure]
        public static IEnumerable<XElement> ChangeXAttributeValues(this IEnumerable<XElement> element, XName name, string oldValue, string newValue)
        {
            return element.Select(x => x.ChangeXAttributeValues(name, oldValue, newValue));
        }

        public static XElement ChangeXAttributeValues(this XElement element, XName descendantName, XName attributeName, string oldValue, string newValue)
        {
            foreach (XAttribute attribute in element.Descendants(descendantName).Attributes(attributeName).Where(x => x.Value == oldValue))
            {
                attribute.SetValue(newValue);
            }
            return element;
        }

        [Pure]
        public static IEnumerable<XElement> ChangeXAttributeValues(this IEnumerable<XElement> element, XName descendantName, XName attributeName, string oldValue, string newValue)
        {
            return element.Select(x => x.ChangeXAttributeValues(descendantName, attributeName, oldValue, newValue));
        }
    }
}
