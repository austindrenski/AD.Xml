using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml.Standard
{
    /// <summary>
    /// Promotes elements to the level of their parent.
    /// </summary>
    [PublicAPI]
    public static class PromoteExtensions
    {
        /// <summary>
        /// Promotes the elements of the enumerable.
        /// </summary>
        /// <param name="elements">The source enumerable.</param>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.InvalidOperationException"/>
        public static void Promote([NotNull][ItemNotNull] this IEnumerable<XElement> elements)
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
