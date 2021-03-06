﻿using System;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to evaluate a predicate against an <see cref="XElement"/>.
    /// </summary>
    [PublicAPI]
    public static class IsFalseExtensions
    {
        /// <summary>
        /// Evaluates the predicate against the <see cref="XElement"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> against which the predicate is evaluated.</param>
        /// <param name="predicate">The condition with which to test the <see cref="XElement"/>.</param>
        /// <returns>True if the <see cref="XElement"/> fails to satisfy the predicate.</returns>
        [Pure]
        public static bool IsFalse([NotNull] this XElement element, [NotNull] Func<XElement, bool> predicate)
        {
            return !predicate(element);
        }
    }
}
