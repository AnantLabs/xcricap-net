using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	/// <summary>
	/// Represents the Qualification element in the XCRI standard
	/// </summary>
	public interface IQualification : IXmlGenerator //, IObjectWithIdentifiers
	{

		string Title { get; set; }
		Uri Uri { get; set; }
		string Level { get; set; }
		string Type { get; set; }
		string AwardedBy { get; set; }

	}
}
