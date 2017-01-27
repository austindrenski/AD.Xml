using System;
using System.Linq;
using System.Xml.Linq;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to find a string name in an existing XDocument.
    /// </summary>
    public static class ToXNameExtensions 
    {
        /// <summary>
        /// Finds the XName representation of the string in the XDocument.
        /// </summary>
        /// <param name="name">The string to find as an XName.</param>
        /// <param name="document">The XDocument to search.</param>
        /// <returns>The XName representation of the string name.</returns>
        public static XName ToXName(this string name, XDocument document)
        {
            return document.Root?
                           .Elements()
                           .FirstOrDefault()?
                           .Elements()
                           .Select(x => x.Name.LocalName)
                           .SingleOrDefault(x => string.Equals(x, name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
