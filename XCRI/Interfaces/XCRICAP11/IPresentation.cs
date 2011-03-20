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
		Interfaces.IDate Start { get; set; }
        Interfaces.IDate End { get; set; }
        TimeSpan? Duration { get; set; }
        Interfaces.IStudyMode StudyMode { get; set; }
        Interfaces.IAttendanceMode AttendanceMode { get; set; }
        Interfaces.IAttendancePattern AttendancePattern { get; set; }
		IList<string> LanguagesOfInstruction { get; }
		IList<string> LanguagesOfAssessment { get; }
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
