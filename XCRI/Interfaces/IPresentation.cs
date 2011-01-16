using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	/// <summary>
	/// Represents the Presentation element within the XCRI standard.
	/// </summary>
	public interface IPresentation : IXmlGenerator //, IObjectWithIdentifiers
	{

		string Title { get; set; }
		Dictionary<DescriptionTypes, string> Descriptions { get; }
		Uri Uri { get; set; }
		Image Image { get; set; }
		DateTime? Start { get; set; }
		DateTime? End { get; set; }
		string Duration { get; set; }
		StudyModes StudyMode { get; set; }
		AttendanceModes AttendanceMode { get; set; }
		AttendancePatterns AttendancePattern { get; set; }
		List<Languages> LanguageOfInstruction { get; }
		List<Languages> LanguageOfAssessment { get; }
		string PlacesAvailable { get; set; }
		string Cost { get; set; }
		List<IVenue> Venues { get; }
		string EnquireTo { get; set; }
		string ApplyTo { get; set; }
		
	}
	/// <summary>
	/// Represents the suggested terms for the study modes
	/// property as defined within http://www.xcri.org/wiki/index.php/XCRI_Terms_1.1
	/// </summary>
	public enum StudyModes
	{
		Unknown,
		FullTime,
		PartTime,
		Sandwich
	}
	/// <summary>
	/// Represents the suggested terms for the attendance modes
	/// property as defined within http://www.xcri.org/wiki/index.php/XCRI_Terms_1.1
	/// </summary>
	public enum AttendanceModes
	{
		Unknown,
		Campus,
		DistanceWithAttendance,
		DistanceWithoutAttendance,
		WorkBased,
		Mixed
	}
	/// <summary>
	/// Represents the suggested terms for the attendance patterns
	/// property as defined within http://www.xcri.org/wiki/index.php/XCRI_Terms_1.1
	/// </summary>
	public enum AttendancePatterns
	{
		Unknown,
		Daytime,
		Evening,
		Twilight,
		DayOrBlockRelease,
		Weekend,
		Short,
		Customised,
		StandardDays
	}
	/// <summary>
	/// Represents the languages defined within the ISO standard.
	/// Currently not completely implemented.
	/// </summary>
	public enum Languages
	{
		English
	}
}
