using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Enum describing the direction of a sort.
    /// </summary>
    public enum SortOrderType
    {
        Ascending,
        Descending,
        DoNotUse
    }

    /// <summary>
    /// Extension methods to sort the elements of the root element in an XDocument.
    /// </summary>
    [PublicAPI]
    public static class OrderByExtensions
    {
        /// <summary>
        /// Orders the elements of the root of the XDocument by the given names and sort types.
        /// </summary>
        /// <param name="document">The XDocument to sort.</param>
        /// <param name="sortOrder">An IDictionary of XNames and SortOrderTypes.</param>
        /// <returns>A sorted XDocument.</returns>
        public static XDocument OrderBy(this XDocument document, IDictionary<XName, SortOrderType> sortOrder)
        {
            IOrderedEnumerable<XElement> orderedDocument;
            switch (sortOrder.First().Value)
            {
                case SortOrderType.Ascending:
                {
                    orderedDocument = document.Elements()
                                              .Elements()
                                              .OrderBy(x => x.Element(sortOrder.First().Key)?.Value);
                    break;
                }
                case SortOrderType.Descending:
                {
                    orderedDocument = document.Elements()
                                              .Elements()
                                              .OrderByDescending(x => x.Element(sortOrder.First().Key)?.Value);
                    break;
                }
                default:
                {
                    throw new NotImplementedException();
                }
            }       
            foreach (KeyValuePair<XName, SortOrderType> kvp in sortOrder.Skip(1))
            {
                switch (kvp.Value)
                {
                    case SortOrderType.Ascending:
                    {
                        orderedDocument = orderedDocument.ThenBy(x => x.Element(kvp.Key)?.Value);
                        break;
                    }
                    case SortOrderType.Descending:
                    {
                        orderedDocument = orderedDocument.ThenByDescending(x => x.Element(kvp.Key)?.Value);
                        break;
                    }
                    default:
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            return orderedDocument.ToXDocument();
        }

        /// <summary>
        /// Orders the elements of the root of the XDocument by the given names and sort types.
        /// </summary>
        /// <param name="document">The XDocument to sort.</param>
        /// <param name="sortStrings">An enumerable collection of names and sort directions. E.g. "name|asc".</param>
        /// <returns>A sorted XDocument.</returns>
        public static XDocument OrderBy(this XDocument document, IEnumerable<string> sortStrings)
        {
            if (sortStrings == null)
            {
                return document;
            }
            IEnumerable<string> sortStringArrays = sortStrings as string[] ?? sortStrings.ToArray();
            if (!sortStringArrays.Any())
            {
                return document;
            }
            return document.OrderBy(
                                    sortStringArrays.SkipWhile(string.IsNullOrEmpty)
                                                    .Select(x => x.Contains('|') ? x : $"{x}|asc")
                                                    .Select(x => x.Split('|'))
                                                    .ToDictionary(x => x[0].ToXName(document), 
                                                                  x => x[1].ToLower().StartsWith("asc") ? SortOrderType.Ascending 
                                                                                                        : SortOrderType.Descending));
        }
    }
}
