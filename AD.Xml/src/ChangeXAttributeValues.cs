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
        /// <param name="elements">The root elements from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="value">The value to which the attributes are set.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXAttributeValues([NotNull][ItemNotNull]  this IEnumerable<XElement> elements, [NotNull] XName name, string value)
        {
            return elements.Select(x => x.ChangeXAttributeValues(name, value));
        }

        /// <summary>
        /// Sets the value of attributes with the specified name on all descendant nodes of each item in the enumerable.
        /// </summary>
        /// <param name="elements">The root elements from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="value">The value to which the attributes are set.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXAttributeValues([NotNull][ItemNotNull]  this ParallelQuery<XElement> elements, [NotNull] XName name, string value)
        {
            return elements.Select(x => x.ChangeXAttributeValues(name, value));
        }

        /// <summary>
        /// Sets the value of attributes with the specified name and value on all descendant nodes.
        /// </summary>
        /// <param name="element">The root element from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="oldValue">The value of the attribute to affect.</param>
        /// <param name="newValue">The value to which the attributes are set.</param>
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
        /// Sets the value of attributes with the specified name and value on all descendant nodes of each item in the enumerable.
        /// </summary>
        /// <param name="elements">The root elements from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="oldValue">The value of the attribute to affect.</param>
        /// <param name="newValue">The value to which the attributes are set.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name, string oldValue, string newValue)
        {
            return elements.Select(x => x.ChangeXAttributeValues(name, oldValue, newValue));
        }

        /// <summary>
        /// Sets the value of attributes with the specified name and value on all descendant nodes of each item in the enumerable.
        /// </summary>
        /// <param name="elements">The root elements from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="oldValue">The value of the attribute to affect.</param>
        /// <param name="newValue">The value to which the attributes are set.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName name, string oldValue, string newValue)
        {
            return elements.Select(x => x.ChangeXAttributeValues(name, oldValue, newValue));
        }

        /// <summary>
        /// Sets the value of attributes with the specified name and value on all descendant nodes with the specified name of each item in the enumerable.
        /// </summary>
        /// <param name="element">The root element from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="descendantName">The name of the descendant nodes whose attributes are to be affected.</param>
        /// <param name="attributeName">The name of the attribute to affect.</param>
        /// <param name="oldValue">The value of the attribute to affect.</param>
        /// <param name="newValue">The value to which the attributes are set.</param>
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
        /// Sets the value of attributes with the specified name and value on all descendant nodes with the specified name of each item in the enumerable.
        /// </summary>
        /// <param name="elements">The root elements from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="descendantName">The name of the descendant nodes whose attributes are to be affected.</param>
        /// <param name="attributeName">The name of the attribute to affect.</param>
        /// <param name="oldValue">The value of the attribute to affect.</param>
        /// <param name="newValue">The value to which the attributes are set.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName descendantName, [NotNull] XName attributeName, string oldValue, string newValue)
        {
            return elements.Select(x => x.ChangeXAttributeValues(descendantName, attributeName, oldValue, newValue));
        }

        /// <summary>
        /// Sets the value of attributes with the specified name and value on all descendant nodes with the specified name of each item in the enumerable.
        /// </summary>
        /// <param name="elements">The root elements from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="descendantName">The name of the descendant nodes whose attributes are to be affected.</param>
        /// <param name="attributeName">The name of the attribute to affect.</param>
        /// <param name="oldValue">The value of the attribute to affect.</param>
        /// <param name="newValue">The value to which the attributes are set.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName descendantName, [NotNull] XName attributeName, string oldValue, string newValue)
        {
            return elements.Select(x => x.ChangeXAttributeValues(descendantName, attributeName, oldValue, newValue));
        }
    }
}
