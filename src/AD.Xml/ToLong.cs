using System;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to convert text into long values.
    /// </summary>
    [PublicAPI]
    public static class ToLongExtensions
    {
        /// <summary>
        /// Converts the element to a long value or null.
        /// </summary>
        /// <param name="element">The XElement to convert.</param>
        /// <returns>A long value or null.</returns>
        public static long? ToLong([NotNull] this XElement element)
        {
            if (element is null)
                throw new ArgumentNullException(nameof(element));

            return long.TryParse(element.Value.Replace("$", null).Replace(",", null), out long result) ? result : new long?();
        }
    }
}