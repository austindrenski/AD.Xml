using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to convert text into double values.
    /// </summary>
    [PublicAPI]
    public static class ToDoubleExtensions
    {
        /// <summary>
        /// Converts the element to a double value or null.
        /// </summary>
        /// <param name="element">The XElement to convert.</param>
        /// <returns>A double value or null.</returns>
        public static double? ToDouble(this XElement element)
        {
            double result;
            return double.TryParse(element?.Value.Replace("$", null), out result) ? result : new double?();
        }
    }
}
