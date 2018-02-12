using System;
using System.Xml.Linq;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to cast an XElement as a DateTime or null.
    /// </summary>
    public static class ToDateTimeExtensions
    {
        /// <summary>
        /// Casts an XElement as a DateTime or null.
        /// </summary>
        /// <param name="element">The XElement to cast.</param>
        /// <returns>The DateTime representation of the value of the XElement, or null.</returns>
        public static DateTime? ToDateTime(this XElement element)
        {
            DateTime result;
            return DateTime.TryParse(element.Value, out result) ? result : new DateTime?();
        }
    }
}
