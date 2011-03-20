using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	/// <summary>
	/// Represents the Presentation element within the XCRI standard.
	/// </summary>
    public interface IPresentation : XCRICAP11.IPresentation, XCRICAP12.IPresentation
    {
        new Interfaces.IDate Start { get; set; }
        new Interfaces.IDate End { get; set; }
        new TimeSpan? Duration { get; set; }
        new string ApplyTo { get; set; }
        new Interfaces.IStudyMode StudyMode { get; set; }
        new Interfaces.IAttendanceMode AttendanceMode { get; set; }
        new Interfaces.IAttendancePattern AttendancePattern { get; set; }
        new IList<string> LanguagesOfInstruction { get; }
        new IList<string> LanguagesOfAssessment { get; }
        new string PlacesAvailable { get; set; }
        new string Cost { get; set; }
        new IList<Interfaces.IVenue> Venues { get; }
    }
}
