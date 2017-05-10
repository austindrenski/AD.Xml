using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml.Standard
{
    /// <summary>
    /// Extension methods to set attribute values in <see cref="XElement"/> colelctions.
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
        public static IEnumerable<XElement> SetAttributeValues([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name, [CanBeNull] object value)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return elements.Clone()
                           .Select(x =>
                           {
                               x.SetAttributeValue(name, value);
                               return x;
                           });
        }
    }
}