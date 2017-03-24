using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    public static class RemoveByAllIfEmptyExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static XElement RemoveByAllIfEmpty(this XElement element, XName name)
        {
            element.Descendants(name)
                   .Where(x => !x.HasAttributes)
                   .Where(x => !x.HasElements)
                   .Where(x => x.Value == "")
                   .Remove();
            return element;
        }
    }
}
