using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI.Interfaces.XCRICAP11
{
	/// <summary>
	/// Represents the Provider element in the XCRI standard.
	/// </summary>
    public interface IProvider : IElement, XCRICAP11.IOrganisation
	{
		/// <summary>
		/// The UK Provider Reference Number for the course provider,
		/// or null if not available.
		/// </summary>
		long? ReferenceNumber { get; set; }
		/// <summary>
		/// Retrieves the courses from the course provider's database.
		/// </summary>
        IList<Interfaces.ICourse> Courses { get; }
	}
}
