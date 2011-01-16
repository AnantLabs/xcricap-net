using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
	public class Configuration
	{

		public static NamespaceList StandardNamespaces
		{
			get
			{
				NamespaceList list = new NamespaceList();
				list.Add(@"http://xcri.org/profiles/catalog", "xcri", @"http://www.xcri.org/bindings/xcri_cap_1_1.xsd");
				list.Add(@"http://xcri.org/profiles/catalog/terms", "terms", "http://www.xcri.org/bindings/xcri_cap_terms_1_1.xsd");
				list.Add(@"http://www.w3.org/2001/XMLSchema-instance", "xsi", "");
				list.Add(@"http://www.ukrlp.co.uk", "ukrlp");
				list.Add(@"http://www.w3.org/2003/01/geo/wgs84_pos", "geo");
				return list;
			}
		}

	}
}
