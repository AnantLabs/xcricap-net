using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Vocabularies.XCRICAP11.Terms
{
	public static class ExtensionMethods
	{

		public static string ToXCRIString(this StudyModeTypes input)
		{
			switch (input)
			{ 
				case StudyModeTypes.FullTime:
					return "Full Time";
				case StudyModeTypes.PartTime:
					return "Part Time";
				default:
					return input.ToString();
			}
		}

        public static string ToXCRIString(this AttendanceModeTypes input)
		{
			switch (input)
			{
				case AttendanceModeTypes.DistanceWithAttendance:
					return "Distance with attendance";
				case AttendanceModeTypes.DistanceWithoutAttendance:
					return "Distance without attendance";
				case AttendanceModeTypes.WorkBased:
					return "Work-based";
				default:
					return input.ToString();
			}
		}

        public static string ToXCRIString(this AttendancePatternTypes input)
		{
			switch (input)
			{
				case AttendancePatternTypes.DayOrBlockRelease:
					return "Day/Block release";
				case AttendancePatternTypes.StandardDays:
					return "Standard days";
				default:
					return input.ToString();
			}
		}

	}
}
