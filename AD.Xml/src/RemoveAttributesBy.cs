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
        [NotNull]
        public static XElement RemoveAttributesBy([NotNull] this XElement element, [NotNull] XName name)
        {
            element.DescendantsAndSelf().Attributes(name).Remove();
            return element;
        }

        /// <summary>
        /// Removes attributes with the specified name from each node in the enumerable and all of their descendants.
        /// </summary>
        /// <param name="elements">The source nodes.</param>
        /// <param name="name">The name of the attributes to remove.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="System.ArgumentException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> RemoveAttributesBy([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name)
        {
            return elements.Select(x => x.RemoveAttributesBy(name));
        }

        /// <summary>
        /// Removes attributes with the specified name from each node in the enumerable and all of their descendants.
        /// </summary>
        /// <param name="elements">The source nodes.</param>
        /// <param name="name">The name of the attributes to remove.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="System.AggregateException"/>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.OperationCanceledException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> RemoveAttributesBy([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName name)
        {
            return elements.Select(x => x.RemoveAttributesBy(name));
        }
    }
}
