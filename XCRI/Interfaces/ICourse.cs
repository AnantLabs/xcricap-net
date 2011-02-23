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
	public interface ICourse : IElement, IElementWithIdentifiers
	{

		/// <summary>
		/// The titles of the course.
        /// Multiple titles can be used - for example to provide multi-language titles
        /// for a specific course.
		/// </summary>
		IList<ITitle> Titles { get; }
        /// <summary>
        /// Tags describing the resource
        /// </summary>
        IList<ISubject> Subjects { get; }
        /// <summary>
        /// A URL for further information
        /// </summary>
		Uri Uri { get; set; }
        /// <summary>
        /// An image that represents the resource
        /// </summary>
        Image Image { get; set; }
        /// <summary>
        /// Descriptions for the resource
        /// </summary>
		IList<IDescription> Descriptions { get; }
        /// <summary>
        /// Qualifications that can be achieved from completing the course and its various
        /// pathways.
        /// </summary>
		IList<IQualification> Qualifications { get; }
        /// <summary>
        /// Presentations - implementations of the course to which students can apply and enroll
        /// </summary>
		IList<IPresentation> Presentations { get; }
        // TODO: Credit: http://www.xcri.org/wiki/index.php/Credit
        /// <summary>
        /// When used with the delta update pattern (http://www.xcri.org/wiki/index.php/Delta_update_pattern)
        /// indicates the status of this resource.
        /// </summary>
        ResourceStatus ResourceStatus { get; set; }
	}
}
