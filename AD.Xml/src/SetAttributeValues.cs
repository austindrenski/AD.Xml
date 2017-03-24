using System.Collections.Generic;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    public static class SetAttributeValuesExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetAttributeValues(this IEnumerable<XElement> elements, XName name, object value)
        {
            foreach (XElement element in elements)
            {
                element.SetAttributeValue(name, value);
            }
        }
    }
}
