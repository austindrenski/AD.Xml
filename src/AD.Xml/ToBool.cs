﻿using System;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to convert text into boolean values.
    /// </summary>
    [PublicAPI]
    public static class ToBoolExtensions
    {
        /// <summary>
        /// Converts the element to true, false, or null.
        /// </summary>
        /// <param name="element">The XElement to convert.</param>
        /// <returns>True, false, or null.</returns>
        public static bool? ToBool([NotNull] this XElement element)
        {
            if (element is null)
                throw new ArgumentNullException(nameof(element));

            if (bool.TryParse(element.Value, out bool result))
                return result;

            switch (element.Value)
            {
                case "0": return false;
                case "1": return true;
                default: return null;
            }
        }
    }
}