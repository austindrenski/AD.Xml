using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to set attribute values in <see cref="XElement"/> collections.
    /// </summary>
    [PublicAPI]
    public static class SetAttributeValuesExtensions
    {
        /// <summary>
        /// Returns an <see cref="XElement"/> collection where the attributes of the specified name are set to the sepcified value.
        /// </summary>
        /// <param name="elements">The source collection.</param>
        /// <param name="name">The namespace-qualified name of the attribute.</param>
        /// <param name="value">The value to which the attributes will be set.</param>
        [Pure]
        [NotNull]
        [ItemNotNull]
        [CollectionAccess(CollectionAccessType.Read)]
        public static IEnumerable<XElement> SetAttributeValues([NotNull] [ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name, [CanBeNull] object value)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            foreach (XElement e in elements)
            {
                yield return e.SetAttributeValues(name, value);
            }
        }

        /// <summary>
        /// Returns an <see cref="XElement"/> collection where the attributes of the specified name are set to the sepcified value.
        /// </summary>
        /// <param name="element">The source element.</param>
        /// <param name="name">The namespace-qualified name of the attribute.</param>
        /// <param name="value">The value to which the attributes will be set.</param>
        [Pure]
        [NotNull]
        public static XElement SetAttributeValues([NotNull] this XElement element, [NotNull] XName name, [CanBeNull] object value)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            XElement e = element.Clone();

            if (e.Attribute(name) != null)
                e.SetAttributeValue(name, value);

            return
                new XElement(
                    e.Name,
                    e.Attributes(),
                    e.Elements().Select(x => x.SetAttributeValues(name, value)));
        }
    }
}