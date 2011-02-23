using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
    public class NamespaceList : IEnumerable<NamespaceData>
    {

        #region Properties and Fields

        #region Private

        private Dictionary<string, NamespaceData> __NamespaceData = new Dictionary<string, NamespaceData>();

        #endregion

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// Removes all namespaces from the list
        /// </summary>
        public void Clear()
        {
            this.__NamespaceData.Clear();
        }

        /// <summary>
        /// Removes a namespace from the list
        /// </summary>
        /// <param name="NamespaceUri">The namespace to remove (case sensitive)</param>
        public void Remove(string NamespaceUri)
        {
            if (this.__NamespaceData.ContainsKey(NamespaceUri) == false)
                return;
            this.__NamespaceData.Remove(NamespaceUri);
        }

        /// <summary>
        /// Adds a namespace to the list
        /// </summary>
        /// <param name="NamespaceUri">The namespace to add</param>
        /// <param name="Prefix">The prefix to assign the namespace</param>
        /// <param name="XSDLocation">The location - as a full URI - of the XSD file for this namespace</param>
        public void Add(string NamespaceUri, string Prefix, string XSDLocation)
        {
            this.__NamespaceData.Add(NamespaceUri, new NamespaceData()
            {
                NamespaceUri = NamespaceUri,
                Prefix = Prefix,
                XSDLocation = XSDLocation
            });
        }

        /// <summary>
        /// Returns whether the list contains this namespace
        /// </summary>
        /// <param name="NamespaceUri">The namespace to look up (case sensitive)</param>
        /// <returns></returns>
        public bool Contains(string NamespaceUri)
        {
            return this.__NamespaceData.ContainsKey(NamespaceUri);
        }

        #endregion

        #region Public static

        public static NamespaceList GetNamespaces()
        {
            return GetNamespaces(Namespaces.All);
        }

        public static NamespaceList GetNamespaces(Namespaces namespacesToInclude)
        {
            NamespaceList list = new NamespaceList();
            if((namespacesToInclude & Namespaces.XCRICAP11) > 0)
                list.Add(Configuration.Namespaces.XCRICAP11NamespaceUri, String.Empty, @"http://www.xcri.org/bindings/xcri_cap_1_1.xsd");
            if ((namespacesToInclude & Namespaces.XCRICAP11Terms) > 0)
                list.Add(Configuration.Namespaces.XCRICAP11TermsNamespaceUri, "terms", "http://www.xcri.org/bindings/xcri_cap_terms_1_1.xsd");
            if ((namespacesToInclude & Namespaces.XmlSchemaInstance) > 0)
                list.Add(Configuration.Namespaces.XmlSchemaInstanceNamespaceUri, "xsi", "");
            if ((namespacesToInclude & Namespaces.UKRegisterOfLearningProviders) > 0)
                list.Add(Configuration.Namespaces.UKRegisterOfLearningProvidersNamespaceUri, "ukrlp", "http://www.craighawker.co.uk/xcri/validation/xsds/ukprn.xsd");
            if ((namespacesToInclude & Namespaces.Geolocation) > 0)
                list.Add(Configuration.Namespaces.GeolocationNamespaceUri, "geo", "http://www.craighawker.co.uk/xcri/validation/xsds/geo.xsd");
            return list;
        }

        #endregion

        #endregion

        #region Enums

        #region Public

        public enum Namespaces
        {
            None = 0,
            XmlSchemaInstance = 1,
            XCRICAP11 = 2,
            XCRICAP11Terms = 4,
            XCRICAP11_All = XCRICAP11 | XCRICAP11Terms,
            UKRegisterOfLearningProviders = 8,
            Geolocation = 16,
            LatestXCRIStandard = XCRICAP12_All,
            XCRICAP12 = 32,
            XCRICAP12Terms = 64,
            MetadataForLearningOpportunities = 128,
            DublinCore = 256,
            DublinCoreTerms = 512,
            CENEducationalCreditInformationModel = 1024,
            XCRICAP12_All = XCRICAP12 | XCRICAP12Terms | MetadataForLearningOpportunities | DublinCore | DublinCoreTerms,
            All = XmlSchemaInstance | XCRICAP11_All | UKRegisterOfLearningProviders | LatestXCRIStandard
        }

        #endregion

        #endregion

		#region IEnumerable<NamespaceData> Members

		public IEnumerator<NamespaceData> GetEnumerator()
		{
			return this.__NamespaceData.Values.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.__NamespaceData.Values.GetEnumerator();
		}

		#endregion

	}
    public struct NamespaceData
    {
        public string NamespaceUri;
        public string XSDLocation;
        public string Prefix;
    }
}
