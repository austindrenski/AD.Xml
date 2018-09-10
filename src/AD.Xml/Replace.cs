using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to replace nodes in an XML tree.
    /// </summary>
    [PublicAPI]
    public static class ReplaceExtensions
    {
        /// <summary>
        /// Replaces descendants with a name equal to <paramref name="oldName"/> with the element created from <paramref name="name"/> and <paramref name="content"/>.
        /// This method works on the existing <see cref="XElement"/> and returns a reference to it for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for descendants whose names are equal to <paramref name="oldName"/>.</param>
        /// <param name="oldName">The element name for which to search.</param>
        /// <param name="name">The name of the replacement node.</param>
        /// <param name="content">The content of the replacement node.</param>
        /// <returns>
        /// A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="element"/></exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="oldName"/></exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="name"/></exception>
        [NotNull]
        public static XElement Replace(
            [NotNull] this XElement element,
            [NotNull] XName oldName,
            [NotNull] XName name,
            [CanBeNull] object content)
        {
            if (element is null)
                throw new ArgumentNullException(nameof(element));

            if (oldName is null)
                throw new ArgumentNullException(nameof(oldName));

            if (name is null)
                throw new ArgumentNullException(nameof(name));

            IEnumerable<XElement> nodesToRemove =
                element.Descendants(oldName)
                       .ToArray();

            IEnumerable<XElement> parents =
                nodesToRemove.Select(x => x.Parent)
                             .ToArray();

            nodesToRemove.Remove();
            foreach (XElement item in parents)
            {
                item.Add(new XElement(name, content));
            }

            return element;
        }
    }
}