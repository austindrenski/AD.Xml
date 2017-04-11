using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Detaches each item in the enumerable from its parent node.
    /// </summary>
    [PublicAPI]
    public static class DetachExtensions
    {
        /// <summary>
        /// Detaches each item in the enumerable from its parent node.
        /// </summary>
        /// <param name="elements">The elements to detach from their parent nodes.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.InvalidOperationException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> Detach([NotNull][ItemNotNull] this IEnumerable<XElement> elements)
        {
            return elements.Select(x =>
            {
                if (x.Parent != null)
                {
                    x.Remove();
                }
                return x;
            });
        }

        /// <summary>
        /// Detaches each item in the enumerable from its parent node.
        /// </summary>
        /// <param name="elements">The elements to detach from their parent nodes.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="System.AggregateException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.InvalidOperationException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> Detach([NotNull][ItemNotNull] this ParallelQuery<XElement> elements)
        {
            return elements.Select(x =>
            {
                if (x.Parent != null)
                {
                    x.Remove();
                }
                return x;
            });
        }
    }
}
