using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP11
{
	/// <summary>
	/// Represents the Presentation element within the XCRI standard.
	/// </summary>
	public interface IPresentation : IElement, XCRICAP11.IGeneric
	{
		DateTime? Start { get; set; }
		DateTime? End { get; set; }
		string Duration { get; set; }
        Interfaces.IStudyMode StudyMode { get; set; }
        Interfaces.IAttendanceMode AttendanceMode { get; set; }
        Interfaces.IAttendancePattern AttendancePattern { get; set; }
		IList<string> LanguageOfInstruction { get; }
		IList<string> LanguageOfAssessment { get; }
		string PlacesAvailable { get; set; }
		string Cost { get; set; }
        IList<Interfaces.IVenue> Venues { get; }
		string EnquireTo { get; set; }
		string ApplyTo { get; set; }
        // TODO: EntryProfile
        // TODO: EntryRequirements
        // TODO: ApplyFrom
        // TODO: ApplyUntil
	}
}
