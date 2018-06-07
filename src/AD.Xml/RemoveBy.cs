using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to remove XML elements.
    /// </summary>
    [PublicAPI]
    public static class RemoveByExtensions
    {
        /// <summary>
        /// Removes elements from the <see cref="XElement"/> that have the given name.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> to search for children with the given name.</param>
        /// <param name="name">The name of the elements to be removed from the <see cref="XElement"/>.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [Pure]
        [NotNull]
        public static XElement RemoveBy([NotNull] this XElement element, [NotNull] XName name)
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

            clone.Elements(name).Remove();

            return clone;
        }

        /// <summary>
        /// Removes elements from the <see cref="XElement"/> that satisify the predicate.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> to search for children with the given name.</param>
        /// <param name="predicate">The predicate that is satisfied by the elements to be removed from the <see cref="XElement"/>.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [Pure]
        [NotNull]
        public static XElement RemoveBy([NotNull] this XElement element, [NotNull] Func<XElement, bool> predicate)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            XElement clone = element.Clone();

            clone.Elements().Where(predicate).Remove();

            return clone;
        }

        /// <summary>
        /// Removes elements from the <see cref="IEnumerable{XElement}"/> that have the given name.
        /// </summary>
        /// <param name="elements">The <see cref="IEnumerable{XElement}"/> to search for child elements with the given name.</param>
        /// <param name="name">The name of the child elements to be removed from the <see cref="IEnumerable{XElement}"/>.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<XElement> RemoveBy([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return elements.Select(x => x.RemoveBy(name));
        }

        /// <summary>
        /// Removes elements from the <see cref="IEnumerable{XElement}"/> that satisfy the predicate.
        /// </summary>
        /// <param name="elements">The <see cref="IEnumerable{XElement}"/> to search for child elements with the given name.</param>
        /// <param name="predicate">The predicate that is satisfied by the elements to be removed from each <see cref="XElement"/>.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<XElement> RemoveBy([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] Func<XElement, bool> predicate)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return elements.Select(x => x.RemoveBy(predicate));
        }

        /// <summary>
        /// Removes elements from the <see cref="ParallelQuery{XElement}"/> that have the given name.
        /// </summary>
        /// <param name="elements">The <see cref="ParallelQuery{XElement}"/> to search for child elements with the given name.</param>
        /// <param name="name">The name of the child elements to be removed from the <see cref="ParallelQuery{XElement}"/>.</param>
        /// <returns>A reference to the existing <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static ParallelQuery<XElement> RemoveBy([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName name)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return elements.Select(x => x.RemoveBy(name));
        }

        /// <summary>
        /// Removes elements from the <see cref="ParallelQuery{XElement}"/> that satisfy the predicate.
        /// </summary>
        /// <param name="elements">The <see cref="ParallelQuery{XElement}"/> to search for child elements with the given name.</param>
        /// <param name="predicate">The predicate that is satisfied by the elements to be removed from each <see cref="XElement"/>.</param>
        /// <returns>A reference to the existing <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static ParallelQuery<XElement> RemoveBy([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] Func<XElement, bool> predicate)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return elements.Select(x => x.RemoveBy(predicate));
        }
    }
}