using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	/// <summary>
	/// Represents the Presentation element within the XCRI standard.
	/// </summary>
	public interface IPresentation : IElement, IElementWithIdentifiers
	{

		IList<ITitle> Titles { get; }
		IList<IDescription> Descriptions { get; }
        IList<ISubject> Subjects { get; }
		Uri Uri { get; set; }
		Image Image { get; set; }
		DateTime? Start { get; set; }
		DateTime? End { get; set; }
		string Duration { get; set; }
		IStudyMode StudyMode { get; set; }
		IAttendanceMode AttendanceMode { get; set; }
		IAttendancePattern AttendancePattern { get; set; }
		IList<string> LanguageOfInstruction { get; }
		IList<string> LanguageOfAssessment { get; }
		string PlacesAvailable { get; set; }
		string Cost { get; set; }
		IList<IVenue> Venues { get; }
		string EnquireTo { get; set; }
		string ApplyTo { get; set; }
        /// <summary>
        /// When used with the delta update pattern (http://www.xcri.org/wiki/index.php/Delta_update_pattern)
        /// indicates the status of this resource.
        /// </summary>
        ResourceStatus ResourceStatus { get; set; }
        // TODO: EntryProfile
        // TODO: EntryRequirements
        // TODO: ApplyFrom
        // TODO: ApplyUntil
	}
}
