using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Removes attributes from elements by name.
    /// </summary>
    [PublicAPI]
    public static class RemoveAttributesByExtensions
    {
        /// <summary>
        /// Removes attributes with the specified name from this node and all descendants.
        /// </summary>
        /// <param name="element">The source node.</param>
        /// <param name="name">The name of the attributes to remove.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [Pure]
        [NotNull]
        public static XElement RemoveAttributesBy([NotNull] this XElement element, [NotNull] XName name)
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

            clone.DescendantsAndSelf()
                 .Attributes(name)
                 .Remove();

            return clone;
        }

        /// <summary>
        /// Removes attributes with the specified name from each node in the enumerable and all of their descendants.
        /// </summary>
        /// <param name="elements">The source nodes.</param>
        /// <param name="name">The name of the attributes to remove.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentException"/>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<XElement> RemoveAttributesBy([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return elements.Select(x => x.RemoveAttributesBy(name));
        }

        /// <summary>
        /// Removes attributes with the specified name from each node in the enumerable and all of their descendants.
        /// </summary>
        /// <param name="elements">The source nodes.</param>
        /// <param name="name">The name of the attributes to remove.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="OperationCanceledException"/>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static ParallelQuery<XElement> RemoveAttributesBy([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName name)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return elements.Select(x => x.RemoveAttributesBy(name));
        }
    }
}