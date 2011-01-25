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
    public interface IProvider : IXmlElement, IElementWithIdentifiers
	{

		/// <summary>
		/// The public web address for the course provider
		/// </summary>
		Uri WebAddress { get; set; }

		/// <summary>
		/// The UK Provider Reference Number for the course provider,
		/// or null if not available.
		/// </summary>
		long? ReferenceNumber { get; set; }

		/*
		/// <summary>
		/// The name of the company or organisation that provides the learning opportunity.
		/// This should be the trading name.
		/// </summary>
		string Title { get; set; }
		*/

		IEnumerable<Element> Titles { get; }

        IEnumerable<Element> Descriptions { get; }

		/// <summary>
		/// The main address of the course provider
		/// </summary>
		IAddress Address { get; set; }

		/// <summary>
		/// An image element enabling images to be displayed by an aggregator.
		/// </summary>
		Image Image { get; set; }

		/// <summary>
		/// Retrieves the courses from the course provider's database.
		/// </summary>
		IEnumerable<Course> Courses { get; }
		
	}
}
