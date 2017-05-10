using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml.Standard
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
        public static long? ToLong(this XElement element)
        {
            long result;
            return long.TryParse(element?.Value.Replace("$", null).Replace(",", null), out result) ? result : new long?();
        }
    }
}
