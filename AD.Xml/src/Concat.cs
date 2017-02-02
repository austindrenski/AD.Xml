using System.Collections.Generic;
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
        /// <param name="join">The string that joins the items in the enumerable.</param>
        /// <returns>The string formed by concatenating the strings of the enumerable.</returns>
        /// <exception cref="System.ArgumentNullException"/>
        [CanBeNull]
        [Pure]
        public static string Concat([NotNull] this IEnumerable<string> strings, string join = null)
        {
            return string.Join(join, strings);
        }
    }
}
