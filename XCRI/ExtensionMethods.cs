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

		public static string ToXCRIString(this Interfaces.StudyModes input)
		{
			switch (input)
			{ 
				case XCRI.Interfaces.StudyModes.FullTime:
					return "Full Time";
				case XCRI.Interfaces.StudyModes.PartTime:
					return "Part Time";
				default:
					return input.ToString();
			}
		}

		public static string ToXCRIString(this Interfaces.AttendanceModes input)
		{
			switch (input)
			{
				case XCRI.Interfaces.AttendanceModes.DistanceWithAttendance:
					return "Distance with attendance";
				case XCRI.Interfaces.AttendanceModes.DistanceWithoutAttendance:
					return "Distance without attendance";
				case XCRI.Interfaces.AttendanceModes.WorkBased:
					return "Work-based";
				default:
					return input.ToString();
			}
		}

		public static string ToXCRIString(this Interfaces.AttendancePatterns input)
		{
			switch (input)
			{
				case XCRI.Interfaces.AttendancePatterns.DayOrBlockRelease:
					return "Day/Block release";
				case XCRI.Interfaces.AttendancePatterns.StandardDays:
					return "Standard days";
				default:
					return input.ToString();
			}
		}

	}
}
