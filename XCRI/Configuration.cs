using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
    /// <summary>
    /// Exposed configuration information
    /// </summary>
	public class Configuration
	{

        /// <summary>
        /// Exposes information about common namespaces
        /// </summary>
        public static class Namespaces
        {

            /// <summary>
            /// XML Namespace (for xml:lang)
            /// </summary>
            public static string XmlNamespace
            {
                get { return @"http://www.w3.org/XML/1998/namespace"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the UK Register of Learning Providers
            /// </summary>
            public static string UKRegisterOfLearningProvidersNamespaceUri
            {
                get { return @"http://www.ukrlp.co.uk"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the W3C geopositioning vocabulary
            /// </summary>
            public static string GeolocationNamespaceUri
            {
                get { return @"http://www.w3.org/2003/01/geo/wgs84_pos"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the 1999 XHTML vocabulary
            /// </summary>
            public static string XHTMLNamespaceUri
            {
                get { return @"http://www.w3.org/1999/xhtml"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the XCRICAP 1.1 vocabulary
            /// </summary>
            public static string XCRICAP11NamespaceUri
            {
                get { return @"http://xcri.org/profiles/catalog"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the XCRICAP 1.1 Terms vocabulary
            /// </summary>
            public static string XCRICAP11TermsNamespaceUri
            {
                get { return @"http://xcri.org/profiles/catalog/terms"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the 2001 XML Schema Instance vocabulary
            /// </summary>
            public static string XmlSchemaInstanceNamespaceUri
            {
                get { return @"http://www.w3.org/2001/XMLSchema-instance"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the XCRICAP 1.2 vocabulary
            /// </summary>
            public static string XCRICAP12NamespaceUri
            {
                get { return @"http://xcri.org/profiles/1.2/catalog"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the XCRICAP 1.2 Terms vocabulary
            /// </summary>
            public static string XCRICAP12TermsNamespaceUri
            {
                get { return @"http://xcri.org/profiles/1.2/catalog/terms"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the Metadata for Learning Opportunities vocabulary
            /// </summary>
            public static string MetadataForLearningOpportunitiesNamespaceUri
            {
                get { return @"http://purl.org/net/mlo"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the Dublin Core vocabulary
            /// </summary>
            public static string DublinCoreNamespaceUri
            {
                get { return @"http://purl.org/dc/elements/1.1/"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the Dublin Core Terms vocabulary
            /// </summary>
            public static string DublinCoreTermsNamespaceUri
            {
                get { return @"http://purl.org/dc/terms/"; }
            }

            /// <summary>
            /// The namespace (as a URI) of the CEN Educational Credit Information Model (CWA 16077:2010) vocabulary
            /// </summary>
            public static string CENEducationalCreditInformationModelNamespaceUri
            {
                get { return @"http://purl.org/net/cm"; }
            }

        }

	}
}
