using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to navigate between ordered nodes.
    /// </summary>
    [PublicAPI]
    public static class PreviousExtensions
    {
        /// <summary>
        /// Returns the previous sibling node as an <see cref="XElement"/> or null.
        /// </summary>
        /// <param name="element">The source element.</param>
        /// <returns>The previous sibling <see cref="XElement"/>.</returns>
        [CanBeNull]
        [Pure]
        public static XElement Previous([NotNull] this XElement element)
        {
            return element.PreviousNode as XElement;
        }

        /// <summary>
        /// Returns the next node (in document order) of the given name as an <see cref="XElement"/> or null.
        /// </summary>
        /// <param name="element">The source element.</param>
        /// <param name="name">The name of the next element to find.</param>
        /// <returns>The next sibling <see cref="XElement"/>.</returns>
        [CanBeNull]
        [Pure]
        public static XElement Previous([NotNull] this XElement element, [NotNull] XName name)
        {
            XElement host = element;
            while (host.Parent != null)
            {
                host = host.Parent;
            }
            bool check = false;
            foreach (XElement item in host.DescendantsAndSelf().InDocumentOrder())
            {
                if (item.Next() == element)
                {
                    check = true;
                }
                if (check)
                {
                    continue;
                }
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
