using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	public interface IXmlGenerator
	{
		/// <summary>
		/// Writes the XML elements associated with the object to the
		/// provided XmlWriter object.
		/// </summary>
		/// <param name="writer">The XmlWriter to output the XML elements to.</param>
		void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile);
	}
}
