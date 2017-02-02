using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    [PublicAPI]
    public static class PreviousExtensions
    {
        /// <summary>
        /// Returns the previous sibling node as an <see cref="XElement"/> or null.
        /// </summary>
        /// <param name="element">The source element.</param>
        /// <returns>The previous sibling <see cref="XElement"/>.</returns>
        [CanBeNull]
        public static XElement Previous(this XElement element)
        {
            return element.PreviousNode as XElement;
        }
    }
}
