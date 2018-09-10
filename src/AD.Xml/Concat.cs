using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Concatenates items of enumerable collections.
    /// </summary>
    [PublicAPI]
    public static class ConcatExtensions
    {
        /// <summary>
        /// Concatenates the strings of the enumerable optionally inserting a string separator.
        /// </summary>
        /// <param name="strings">The source enumerable.</param>
        /// <param name="delimiter">The string that joins the items in the enumerable.</param>
        /// <returns>
        /// The string formed by concatenating the strings of the enumerable.
        /// </returns>
        [Pure]
        [NotNull]
        public static string Concat([NotNull] this IEnumerable<string> strings, [CanBeNull] string delimiter = null)
        {
            if (strings is null)
                throw new ArgumentNullException(nameof(strings));

            return strings.Aggregate(
                new StringBuilder(),
                (current, next) =>
                {
                    if (current.Length != 0 && delimiter != null)
                        current.Append(delimiter);

                    return current.Append(next);
                },
                result => result.ToString());
        }
    }
}