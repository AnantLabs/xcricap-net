using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{
    public interface IPresentation : ICommonAndCommonDescriptiveElements
    {

        Interfaces.IDate Start { get; set; }
        Interfaces.IDate End { get; set; }
        TimeSpan? Duration { get; set; }
        string ApplyTo { get; set; }
        IList<Interfaces.IEngagement> Engagements { get; }
        Interfaces.IStudyMode StudyMode { get; set; }
        Interfaces.IAttendanceMode AttendanceMode { get; set; }
        Interfaces.IAttendancePattern AttendancePattern { get; set; }
        IList<string> LanguagesOfInstruction { get;  }
        IList<string> LanguagesOfAssessment { get;  }
        string PlacesAvailable { get; set; }
        string Cost { get; set; }
        string AgeRange { get; set; }
        IList<Interfaces.IVenue> Venues { get; }

    }
}
