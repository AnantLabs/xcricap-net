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
		/// </summary>
		/// <param name="input">The datetime to convert</param>
		/// <returns>The formatted string</returns>
		public static string ToXCRIString(this DateTime input)
		{
			return input.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss+00:00");
		}

	}
}
