using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.ExtensionMethods
{
    public static class DurationExtensionMethods
    {
        /// <summary>
        /// Converts a standard .NET TimeSpan string into that required by the XCRI standard.
        /// </summary>
        /// <param name="input">The TimeSpan to convert</param>
        /// <returns>The formatted string</returns>
        public static string ToISO8601(this TimeSpan input)
        {
            return String.Format
                (
                "P{0}D",
                input.Days
                );
        }
    }
}
