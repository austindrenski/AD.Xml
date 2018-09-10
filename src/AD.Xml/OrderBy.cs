using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
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
        /// <returns>
        /// A sorted XDocument.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="document"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="sortOrder"/></exception>
        [Pure]
        [NotNull]
        public static XDocument OrderBy([NotNull] this XDocument document, [NotNull] IDictionary<XName, SortOrderType> sortOrder)
        {
            if (document is null)
                throw new ArgumentNullException(nameof(document));

            if (sortOrder is null)
                throw new ArgumentNullException(nameof(sortOrder));

            if (!sortOrder.Any())
                return document;

            IOrderedEnumerable<XElement> orderedDocument;

            switch (sortOrder.First().Value)
            {
                case SortOrderType.Ascending:
                    orderedDocument =
                        document.Root?
                                .Elements()
                                .OrderBy(x => x.Element(sortOrder.First().Key)?.Value);
                    break;

                case SortOrderType.Descending:
                    orderedDocument =
                        document.Root?
                                .Elements()
                                .OrderByDescending(x => x.Element(sortOrder.First().Key)?.Value);
                    break;

                default:
                    throw new NotSupportedException();
            }

            foreach (KeyValuePair<XName, SortOrderType> kvp in sortOrder.Skip(1))
            {
                switch (kvp.Value)
                {
                    case SortOrderType.Ascending:
                        orderedDocument = orderedDocument?.ThenBy(x => x.Element(kvp.Key)?.Value);
                        continue;

                    case SortOrderType.Descending:
                        orderedDocument = orderedDocument?.ThenByDescending(x => x.Element(kvp.Key)?.Value);
                        continue;

                    default:
                        throw new NotSupportedException();
                }
            }

            if (orderedDocument == null)
                throw new ArgumentException();

            return orderedDocument.ToXDocument();
        }

        /// <summary>
        /// Orders the elements of the root of the XDocument by the given names and sort types.
        /// </summary>
        /// <param name="document">The XDocument to sort.</param>
        /// <param name="sortStrings">An enumerable collection of names and sort directions. E.g. "name|asc".</param>
        /// <returns>
        /// A sorted XDocument.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="document"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="sortStrings"/></exception>
        [Pure]
        [NotNull]
        public static XDocument OrderBy([NotNull] this XDocument document, [NotNull] IEnumerable<string> sortStrings)
        {
            if (document is null)
                throw new ArgumentNullException(nameof(document));

            if (sortStrings is null)
                throw new ArgumentNullException(nameof(sortStrings));

            IEnumerable<string> sortStringArrays =
                sortStrings as string[] ?? sortStrings.ToArray();

            if (!sortStringArrays.Any())
                return document;

            return document.OrderBy(
                sortStringArrays.SkipWhile(string.IsNullOrEmpty)
                                .Select(x => x.Contains('|') ? x : $"{x}|asc")
                                .Select(x => x.Split('|'))
                                .ToDictionary(x => x[0].ToXName(document),
                                     x => x[1].ToLower().StartsWith("asc")
                                              ? SortOrderType.Ascending
                                              : SortOrderType.Descending));
        }
    }

    /// <summary>
    /// Enum describing the direction of a sort.
    /// </summary>
    public enum SortOrderType
    {
        /// <summary>
        /// Sorted in ascending order.
        /// </summary>
        Ascending,

        /// <summary>
        /// Sorted in descending order.
        /// </summary>
        Descending
    }
}