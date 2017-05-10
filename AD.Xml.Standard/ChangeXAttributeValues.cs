using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml.Standard
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
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        public static XElement ChangeXAttributeValues([NotNull] this XElement element, [NotNull] XName name, [CanBeNull] string value)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            XElement clone = element.Clone();
            
            foreach (XAttribute attribute in clone.Descendants().Attributes(name))
            {
                attribute.SetValue(value ?? string.Empty);
            }

            return clone;
        }

        /// <summary>
        /// Sets the value of attributes with the specified name on all descendant nodes of each item in the enumerable.
        /// </summary>
        /// <param name="elements">The root elements from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="value">The value to which the attributes are set.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name, [CanBeNull] string value)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return elements.Select(x => x.ChangeXAttributeValues(name, value));
        }

        /// <summary>
        /// Sets the value of attributes with the specified name on all descendant nodes of each item in the enumerable.
        /// </summary>
        /// <param name="elements">The root elements from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="value">The value to which the attributes are set.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static ParallelQuery<XElement> ChangeXAttributeValues([NotNull][ItemNotNull]  this ParallelQuery<XElement> elements, [NotNull] XName name, [CanBeNull] string value)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

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
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        public static XElement ChangeXAttributeValues([NotNull] this XElement element, [NotNull] XName name, [CanBeNull] string oldValue, [CanBeNull] string newValue)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            XElement clone = element.Clone();
            
            foreach (XAttribute attribute in clone.Descendants().Attributes(name).Where(x => x.Value == oldValue))
            {
                attribute.SetValue(newValue ?? string.Empty);
            }

            return clone;
        }

        /// <summary>
        /// Sets the value of attributes with the specified name and value on all descendant nodes of each item in the enumerable.
        /// </summary>
        /// <param name="elements">The root elements from which descendants are found. This element is not searched for attributes.</param>
        /// <param name="name">The name of the attribute to affect.</param>
        /// <param name="oldValue">The value of the attribute to affect.</param>
        /// <param name="newValue">The value to which the attributes are set.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name, [CanBeNull] string oldValue, [CanBeNull] string newValue)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

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
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static ParallelQuery<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName name, [CanBeNull] string oldValue, [CanBeNull] string newValue)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

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
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        [NotNull]
        public static XElement ChangeXAttributeValues([NotNull] this XElement element, [NotNull] XName descendantName, [NotNull] XName attributeName, [CanBeNull] string oldValue, [CanBeNull] string newValue)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            if (descendantName is null)
            {
                throw new ArgumentNullException(nameof(descendantName));
            }
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            XElement clone = element.Clone();

            foreach (XAttribute attribute in clone.Descendants(descendantName).Attributes(attributeName).Where(x => x.Value == oldValue))
            {
                attribute.SetValue(newValue ?? string.Empty);
            }

            return clone;
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
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName descendantName, [NotNull] XName attributeName, [CanBeNull] string oldValue, [CanBeNull] string newValue)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (descendantName is null)
            {
                throw new ArgumentNullException(nameof(descendantName));
            }
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

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
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static ParallelQuery<XElement> ChangeXAttributeValues([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName descendantName, [NotNull] XName attributeName, [CanBeNull] string oldValue, [CanBeNull] string newValue)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (descendantName is null)
            {
                throw new ArgumentNullException(nameof(descendantName));
            }
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return elements.Select(x => x.ChangeXAttributeValues(descendantName, attributeName, oldValue, newValue));
        }
    }
}