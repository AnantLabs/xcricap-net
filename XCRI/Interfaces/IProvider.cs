using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI.Interfaces
{
	/// <summary>
	/// Represents the Provider element in the XCRI standard.
	/// </summary>
	public interface IProvider : IElement, IElementWithIdentifiers
	{

		/// <summary>
		/// The public web address for the course provider
		/// </summary>
		Uri Url { get; set; }

		/// <summary>
		/// The UK Provider Reference Number for the course provider,
		/// or null if not available.
		/// </summary>
		long? ReferenceNumber { get; set; }

		IList<ITitle> Titles { get; }

        
		IList<IDescription> Descriptions { get; }

        IList<ISubject> Subjects { get; }

		/// <summary>
		/// The main address of the course provider
		/// </summary>
        IAddress Address { get; set; }

		/// <summary>
		/// An image element enabling images to be displayed by an aggregator.
		/// </summary>
		IImage Image { get; set; }

		/// <summary>
		/// Retrieves the courses from the course provider's database.
		/// </summary>
		IList<ICourse> Courses { get; }

        /// <summary>
        /// When used with the delta update pattern (http://www.xcri.org/wiki/index.php/Delta_update_pattern)
        /// indicates the status of this resource.
        /// </summary>
        ResourceStatus ResourceStatus { get; set; }
	}
}
