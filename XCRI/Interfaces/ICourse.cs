using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	/// <summary>
	/// Represents the Course element in the XCRI standard.
    /// http://www.xcri.org/wiki/index.php/Course
	/// </summary>
    public interface ICourse : XCRICAP11.ICourse, XCRICAP12.ICourse
    {
        new IList<Interfaces.IQualification> Qualifications { get; }
        new IList<Interfaces.IPresentation> Presentations { get; }
        new IList<Interfaces.IDescription> Descriptions { get; }
        new IList<Interfaces.IIdentifier> Identifiers { get; }
        new Interfaces.IImage Image { get; set; }
        new IList<Interfaces.ISubject> Subjects { get; }
        new IList<Interfaces.ITitle> Titles { get; }
        new Uri Url { get; set; }
    }
}
