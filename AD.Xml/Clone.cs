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
        public static XElement Clone([NotNull] this XElement source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return
                new XElement(
                    source.Name,
                    source.Attributes().Select(x => x.Clone()),
                    source.Elements().Select(x => x.Clone()));
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

        /// <summary>
        /// Returns a deep copy of the source attribute.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        public static XAttribute Clone([NotNull] this XAttribute source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return
                new XAttribute(
                    source.Name,
                    source.Value);
        }

        /// <summary>
        /// Returns a deep copy of the source attritube.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<XAttribute> Clone([NotNull][ItemNotNull] this IEnumerable<XAttribute> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.Select(x => x.Clone());
        }
    }
}