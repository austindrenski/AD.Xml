using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to clone <see cref="XElement"/> and <see cref="XAttribute"/> objects.
    /// </summary>
    [PublicAPI]
    public static class CloneExtensions
    {
        /// <summary>
        /// Returns a deep copy of the source element.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        public static XNode CloneNode([NotNull] this XNode source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            XElement element = source as XElement;

            return
                element is null
                    ? source
                    : new XElement(
                        element.Name,
                        element.Attributes(),
                        element.Nodes().Select(x => x.CloneNode()));
        }

        /// <summary>
        /// Returns a deep copy of the source element.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        public static XElement Clone([NotNull] this XElement source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return
                new XElement(
                    source.Name,
                    source.Attributes(),
                    source.Nodes().Select(x => x.CloneNode()));
        }

        /// <summary>
        /// Returns a deep copy of the source element.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<XElement> Clone([NotNull][ItemNotNull] this IEnumerable<XElement> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.Select(x => x.Clone());
        } 
    }
}