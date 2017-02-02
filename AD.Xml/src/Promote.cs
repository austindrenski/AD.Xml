using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    [PublicAPI]
    public static class PromoteExtensions
    {
        public static void Promote(this IEnumerable<XElement> elements)
        {
            XElement[] elementArray = elements as XElement[] ?? elements.ToArray();
            foreach (XElement item in elementArray)
            {
                if (item.HasElements)
                {
                    item.AddAfterSelf(item.Elements());
                }
                else
                {
                    item.AddAfterSelf(item.Value);
                }
                if (!item.HasAttributes)
                {
                    continue;
                }
                foreach (XAttribute attribute in item.Attributes())
                {
                    item.Parent?.SetAttributeValue(attribute.Name, attribute.Value);
                }
            }
            elementArray.Remove();
        }
    }
}
