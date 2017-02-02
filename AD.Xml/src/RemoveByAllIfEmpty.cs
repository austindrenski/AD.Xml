using System.Linq;
using System.Xml.Linq;

namespace AD.Xml
{
    public static class RemoveByAllIfEmptyExtensions
    {
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
