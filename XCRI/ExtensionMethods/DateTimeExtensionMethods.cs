using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.ExtensionMethods
{
	public static class DateTimeExtensionMethods
	{
        /// <summary>
		/// Converts a standard .NET datetime string into that required by the XCRI standard.
        /// If the date has no time component, omits time component.
		/// </summary>
		/// <param name="input">The datetime to convert</param>
		/// <returns>The formatted string</returns>
        public static string ToISO8601(this DateTimeOffset input)
        {
            if (input.TimeOfDay == TimeSpan.Zero)
                return input.ToISO8601(false);
            else
                return input.ToISO8601(true);
        }
		/// <summary>
		/// Converts a standard .NET datetime string into that required by the XCRI standard.
		/// </summary>
		/// <param name="input">The datetime to convert</param>
        /// <param name="outputTime">Whether to include the time</param>
		/// <returns>The formatted string</returns>
		public static string ToISO8601(this DateTimeOffset input, bool outputTime)
		{
            if(outputTime)
                    return input.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            else
                return input.ToUniversalTime().ToString("yyyy-MM-dd");
		}

	}
}
