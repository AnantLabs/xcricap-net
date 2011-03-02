using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP11
{
	/// <summary>
	/// Represents the Course element in the XCRI standard.
    /// http://www.xcri.org/wiki/index.php/Course
	/// </summary>
	public interface ICourse : IElement, XCRICAP11.IGeneric
	{
        /// <summary>
        /// Qualifications that can be achieved from completing the course and its various
        /// pathways.
        /// </summary>
        IList<Interfaces.IQualification> Qualifications { get; }
        /// <summary>
        /// Presentations - implementations of the course to which students can apply and enroll
        /// </summary>
        IList<Interfaces.IPresentation> Presentations { get; }
        // TODO: Credit: http://www.xcri.org/wiki/index.php/Credit
	}
}
