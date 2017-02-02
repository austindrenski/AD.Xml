using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to change the value of an <see cref="XAttribute"/> on each descendant element.
    /// </summary>
    [PublicAPI]
    public static class ChangeXAttributeValuesExtensions
    {
        /// <summary>
        /// Sets the value of attributes with the specified name on all descendant nodes.
        /// </summary>
        /// <param name="element">The root element from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="value">The value to which the attributes are set.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [NotNull]
        public static XElement ChangeXAttributeValues([NotNull] this XElement element, [NotNull] XName name, string value)
        {
            foreach (XAttribute attribute in element.Descendants().Attributes(name))
            {
                attribute.SetValue(value);
            }
            return element;
        }

        /// <summary>
        /// Sets the value of attributes with the specified name on all descendant nodes of each item in the enumerable.
        /// </summary>
        /// <param name="element">The root element from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="value">The value to which the attributes are set.</param>
        /// <returns>The modified <see cref="IEnumerable{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXAttributeValues([NotNull][ItemNotNull]  this IEnumerable<XElement> element, [NotNull] XName name, string value)
        {
            return element.Select(x => x.ChangeXAttributeValues(name, value));
        }

        /// <summary>
        /// Sets the value of attributes with the specified name on all descendant nodes of each item in the enumerable.
        /// </summary>
        /// <param name="element">The root element from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="value">The value to which the attributes are set.</param>
        /// <returns>The modified <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXAttributeValues([NotNull][ItemNotNull]  this ParallelQuery<XElement> element, [NotNull] XName name, string value)
        {
            return element.Select(x => x.ChangeXAttributeValues(name, value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [NotNull]
        public static XElement ChangeXAttributeValues([NotNull] this XElement element, [NotNull] XName name, string oldValue, string newValue)
        {
            foreach (XAttribute attribute in element.Descendants().Attributes(name).Where(x => x.Value == oldValue))
            {
                attribute.SetValue(newValue);
            }
            return element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns>The modified <see cref="IEnumerable{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this IEnumerable<XElement> element, [NotNull] XName name, string oldValue, string newValue)
        {
            return element.Select(x => x.ChangeXAttributeValues(name, oldValue, newValue));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns>The modified <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this ParallelQuery<XElement> element, [NotNull] XName name, string oldValue, string newValue)
        {
            return element.Select(x => x.ChangeXAttributeValues(name, oldValue, newValue));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="descendantName"></param>
        /// <param name="attributeName"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [NotNull]
        public static XElement ChangeXAttributeValues([NotNull] this XElement element, [NotNull] XName descendantName, [NotNull]  XName attributeName, string oldValue, string newValue)
        {
            foreach (XAttribute attribute in element.Descendants(descendantName).Attributes(attributeName).Where(x => x.Value == oldValue))
            {
                attribute.SetValue(newValue);
            }
            return element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="descendantName"></param>
        /// <param name="attributeName"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns>The modified <see cref="IEnumerable{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this IEnumerable<XElement> element, [NotNull] XName descendantName, [NotNull] XName attributeName, string oldValue, string newValue)
        {
            return element.Select(x => x.ChangeXAttributeValues(descendantName, attributeName, oldValue, newValue));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="descendantName"></param>
        /// <param name="attributeName"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns>The modified <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this ParallelQuery<XElement> element, [NotNull] XName descendantName, [NotNull] XName attributeName, string oldValue, string newValue)
        {
            return element.Select(x => x.ChangeXAttributeValues(descendantName, attributeName, oldValue, newValue));
        }
    }
}
