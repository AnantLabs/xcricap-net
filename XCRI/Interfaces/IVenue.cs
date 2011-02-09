using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	public interface IVenue : IAddress, IElement, IElementWithIdentifiers
	{

		string Title { get; set; }
		Uri Uri { get; set; }
		Image Image { get; set; }
        /// <summary>
        /// When used with the delta update pattern (http://www.xcri.org/wiki/index.php/Delta_update_pattern)
        /// indicates the status of this resource.
        /// </summary>
        ResourceStatus ResourceStatus { get; set; }

	}
}
