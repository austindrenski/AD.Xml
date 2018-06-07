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
        /// Filters out child elements that have the specified name.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> to search for children with the given name.</param>
        /// <param name="name">The name of the elements to be removed from the <see cref="XElement"/>.</param>
        /// <returns>
        /// A clone of the element without children of the specified name removed.
        /// </returns>
        [Pure]
        [NotNull]
        public static XElement RemoveBy([NotNull] this XElement element, [CanBeNull] XName name)
        {
            if (element is null)
                throw new ArgumentNullException(nameof(element));

            XElement clone = element.Clone();

            if (name != null)
                clone.Elements(name).Remove();

            return clone;
        }

        /// <summary>
        /// Filters out child elements that satisify the predicate.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> to search for children with the given name.</param>
        /// <param name="predicate">The predicate that is satisfied by the elements to be removed from the <see cref="XElement"/>.</param>
        /// <returns>
        /// A clone of the element without children that satisfy the predicate removed.
        /// </returns>
        [Pure]
        [NotNull]
        public static XElement RemoveBy([NotNull] this XElement element, [CanBeNull] Func<XElement, bool> predicate)
        {
            if (element is null)
                throw new ArgumentNullException(nameof(element));

            XElement clone = element.Clone();

            if (predicate != null)
                clone.Elements().Where(predicate).Remove();

            return clone;
        }

        /// <summary>
        /// Filters out child elements that have the specified name.
        /// </summary>
        /// <param name="elements">The <see cref="IEnumerable{XElement}"/> to search for child elements with the given name.</param>
        /// <param name="name">The name of the child elements to be removed from the <see cref="IEnumerable{XElement}"/>.</param>
        /// <returns>
        /// A collection of elements where children of the speficied name are removed.
        /// </returns>
        [Pure]
        [NotNull]
        [LinqTunnel]
        [ItemNotNull]
        [CollectionAccess(CollectionAccessType.Read)]
        public static IEnumerable<XElement> RemoveBy([NotNull] [ItemCanBeNull] this IEnumerable<XElement> elements, [CanBeNull] XName name)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            foreach (XElement e in elements)
            {
                if (e != null)
                    yield return e.RemoveBy(name);
            }
        }

        /// <summary>
        /// Filters out child elements that satisfy the predicate.
        /// </summary>
        /// <param name="elements">The <see cref="IEnumerable{XElement}"/> to search for child elements with the given name.</param>
        /// <param name="predicate">The predicate that is satisfied by the elements to be removed from each <see cref="XElement"/>.</param>
        /// <returns>
        /// A collection of elements where children of the speficied name are removed.
        /// </returns>
        [Pure]
        [NotNull]
        [LinqTunnel]
        [ItemNotNull]
        [CollectionAccess(CollectionAccessType.Read)]
        public static IEnumerable<XElement> RemoveBy([NotNull] [ItemCanBeNull] this IEnumerable<XElement> elements, [CanBeNull] Func<XElement, bool> predicate)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            foreach (XElement e in elements)
            {
                if (e != null)
                    yield return e.RemoveBy(predicate);
            }
        }
    }
}