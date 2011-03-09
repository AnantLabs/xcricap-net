using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{
    public interface ILocation : IElement
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
        string PhoneNumber { get; set; }
        string FaxNumber { get; set; }
        string EmailAddress { get; set; }
        Uri Url { get; set; }

    }
}
