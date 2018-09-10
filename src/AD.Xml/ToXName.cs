using System;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

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
        [CanBeNull]
        public static XName ToXName([NotNull] this string name, [NotNull] XDocument document)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            if (document is null)
                throw new ArgumentNullException(nameof(document));

            return
                document.Root?
                        .Elements()
                        .FirstOrDefault()?
                        .Elements()
                        .Select(x => x.Name.LocalName)
                        .SingleOrDefault(x => string.Equals(x, name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}