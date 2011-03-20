using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	/// <summary>
    /// Represents common address elements within the XCRI feed http://www.xcri.org/wiki/index.php/Address.
    /// That is to say that it represents a compound set of the following XCRI elements:
    ///     1. Street
    ///     2. Town
    ///     3. Postcode
    ///     4. Address (lat/long)
	/// </summary>
    public interface ILocation : XCRICAP11.ILocation , XCRICAP12.ILocation
    {
        /// <summary>
        /// The street element of the address
        /// </summary>
        new string Street { get; set; }

        /// <summary>
        /// The town element of the address
        /// </summary>
        new string Town { get; set; }

        /// <summary>
        /// The postcode element of the address
        /// </summary>
        new string Postcode { get; set; }

        /// <summary>
        /// The latitude of the address, or null for unknown
        /// </summary>
        new decimal? Latitude { get; set; }

        /// <summary>
        /// The longitude of the address, or null for unknown
        /// </summary>
        new decimal? Longitude { get; set; }
    }
}
