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
				list.Add(Configuration.XCRINamespaceUri, String.Empty, @"http://www.xcri.org/bindings/xcri_cap_1_1.xsd");
				list.Add(Configuration.XCRITermsNamespaceUri, "terms", "http://www.xcri.org/bindings/xcri_cap_terms_1_1.xsd");
				list.Add(Configuration.XMLSchemaInstanceNamespaceUri, "xsi", "");
				list.Add(@"http://www.ukrlp.co.uk", "ukrlp", "http://www.craighawker.co.uk/xcri/validation/xsds/ukprn.xsd");
                list.Add(@"http://www.w3.org/2003/01/geo/wgs84_pos", "geo", "http://www.craighawker.co.uk/xcri/validation/xsds/geo.xsd");
				return list;
			}
		}

        public static string XCRINamespaceUri
        {
            get { return @"http://xcri.org/profiles/catalog"; }
        }

        public static string XCRITermsNamespaceUri
        {
            get { return @"http://xcri.org/profiles/catalog/terms"; }
        }

        public static string XMLSchemaInstanceNamespaceUri
        {
            get { return @"http://www.w3.org/2001/XMLSchema-instance"; }
        }

	}
}
