using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    [PublicAPI]
    public static class NextExtensions
    {
        /// <summary>
        /// Returns the next sibling node as an <see cref="XElement"/> or null.
        /// </summary>
        /// <param name="element">The source element.</param>
        /// <returns>The next sibling <see cref="XElement"/>.</returns>
        [CanBeNull]
        public static XElement Next(this XElement element)
        {
            return element.NextNode as XElement;
        }

        /// <summary>
        /// Returns the next node (in document order) of the given name as an <see cref="XElement"/> or null.
        /// </summary>
        /// <param name="element">The source element.</param>
        /// <param name="name">The name of the next element to find.</param>
        /// <returns>The next sibling <see cref="XElement"/>.</returns>
        [CanBeNull]
        public static XElement Next(this XElement element, XName name)
        {
            XElement host = element;
            while (host.Parent != null)
            {
                host = host.Parent;
            }
            bool check = false;
            foreach (XElement item in host.DescendantsAndSelf().InDocumentOrder())
            {
                if (item == element)
                {
                    check = true;
                }
                if (!check)
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
