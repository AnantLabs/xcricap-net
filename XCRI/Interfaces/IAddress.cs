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
    public interface IAddress : XCRICAP11.IAddress 
    {
    }
}
