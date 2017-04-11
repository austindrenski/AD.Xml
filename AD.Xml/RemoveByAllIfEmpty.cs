using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to remove empty descendant elements.
    /// </summary>
    [PublicAPI]
    public static class RemoveByAllIfEmptyExtensions
    {
        /// <summary>
        /// Removes descendants with the given name where the value is null or empty.
        /// </summary>
        /// <param name="element">The source element.</param>
        /// <param name="name">The namespace-qualified name of the descendants to remove.</param>
        /// <param name="removeElements">True to remove only if there are no child elements.</param>
        /// <param name="removeAttributes">True to remove only if there are no attributes.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [Pure]
        [NotNull]
        public static XElement RemoveByAllIfEmpty([NotNull] this XElement element, [NotNull] XName name, bool removeElements = true, bool removeAttributes = true)
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

            clone.Descendants(name)
                 .Where(x => removeAttributes && !x.HasAttributes)
                 .Where(x => removeElements && !x.HasElements)
                 .Where(x => string.IsNullOrEmpty(x.Value))
                 .Remove();

            return clone;
        }

        /// <summary>
        /// Removes descendants with the given name where the value is null or empty from each item in the collection.
        /// </summary>
        /// <param name="elements">The source collection.</param>
        /// <param name="name">The namespace-qualified name of the descendants to remove.</param>
        /// <param name="removeElements">True to remove only if there are no child elements.</param>
        /// <param name="removeAttributes">True to remove only if there are no attributes.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<XElement> RemoveByAllIfEmpty([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name, bool removeElements = true, bool removeAttributes = true)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return elements.Select(x => x.RemoveByAllIfEmpty(name, removeElements, removeAttributes));
        }


        /// <summary>
        /// Removes descendants with the given name where the value is null or empty from each item in the collection.
        /// </summary>
        /// <param name="elements">The source collection.</param>
        /// <param name="name">The namespace-qualified name of the descendants to remove.</param>
        /// <param name="removeElements">True to remove only if there are no child elements.</param>
        /// <param name="removeAttributes">True to remove only if there are no attributes.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static ParallelQuery<XElement> RemoveByAllIfEmpty([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName name, bool removeElements = true, bool removeAttributes = true)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return elements.Select(x => x.RemoveByAllIfEmpty(name, removeElements, removeAttributes));
        }
    }
}