using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	/// <summary>
	/// Represents common address elements within the XCRI feed.
	/// </summary>
	public interface IAddress : IXmlGenerator
	{

		/// <summary>
		/// The street element of the address
		/// </summary>
		string Street { get; set; }

		/// <summary>
		/// The town element of the address
		/// </summary>
		string Town { get; set; }

		/// <summary>
		/// The postcode element of the address
		/// </summary>
		string Postcode { get; set; }

		/// <summary>
		/// The latitude of the address, or null for unknown
		/// </summary>
		decimal? Latitude { get; set; }

		/// <summary>
		/// The longitude of the address, or null for unknown
		/// </summary>
		decimal? Longitude { get; set; }

		/// <summary>
		/// The phone number element of the address
		/// </summary>
		string PhoneNumber { get; set; }

		/// <summary>
		/// The fax number element of the address
		/// </summary>
		string FaxNumber { get; set; }

		/// <summary>
		/// The email address element of the address
		/// </summary>
		string EmailAddress { get; set; }

	}
}
