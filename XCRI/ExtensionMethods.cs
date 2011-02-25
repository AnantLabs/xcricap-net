using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
	public static class ExtensionMethods
	{
        /// <summary>
		/// Converts a standard .NET datetime string into that required by the XCRI standard.
        /// If the date has no time component, omits time component.
		/// </summary>
		/// <param name="input">The datetime to convert</param>
		/// <returns>The formatted string</returns>
        public static string ToXCRIString(this DateTime input)
        {
            if (input.TimeOfDay == TimeSpan.Zero)
                return input.ToXCRIString(false);
            else
                return input.ToXCRIString(true);
        }
		/// <summary>
		/// Converts a standard .NET datetime string into that required by the XCRI standard.
		/// </summary>
		/// <param name="input">The datetime to convert</param>
        /// <param name="outputTime">Whether to include the date</param>
		/// <returns>The formatted string</returns>
		public static string ToXCRIString(this DateTime input, bool outputTime)
		{
            if(outputTime)
                    return input.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss+00:00");
            else
                return input.ToUniversalTime().ToString("yyyy-MM-dd");
		}

	}
}
