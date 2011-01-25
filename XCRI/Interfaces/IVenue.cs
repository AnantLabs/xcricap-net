using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	public interface IVenue : IAddress, IXmlElement //, IObjectWithIdentifiers
	{

		string Title { get; set; }
		Uri Uri { get; set; }
		Image Image { get; set; }


	}
}
