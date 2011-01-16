using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
	/// <summary>
	/// Generates an XCRI feed from a list of providers.
	/// </summary>
	public class XCRIGenerator : NotifyBaseClass, Interfaces.IXmlGenerator
	{

		#region Properties

		#region Private

		private List<Interfaces.IProvider> __Providers = new List<Interfaces.IProvider>();

		#endregion

		#region Protected

		protected IEnumerable<Interfaces.IProvider> _Providers
		{
			get { return this.__Providers; }
		}

		#endregion

		#region Public

		public IEnumerable<Interfaces.IProvider> Providers
		{
			get { return this._Providers; }
		}

		#endregion

		#endregion

		#region Methods

		#region Public

		/// <summary>
		/// Adds a provider to the list that go into the XCRI feed.
		/// </summary>
		/// <param name="Provider">The provider to add</param>
		public void AddProvider(Interfaces.IProvider Provider)
		{
			lock (this.__Providers)
			{
				this.OnPropertyChanging("Providers");
				this.__Providers.Add(Provider);
				this.OnPropertyChanged("Providers");
			}
		}

		/// <summary>
		/// Returns whether a provider exists within the list that go into the XCRI feed.
		/// </summary>
		/// <param name="Provider">The provider to check</param>
		/// <returns>Whether it exists or not</returns>
		public bool ContainsProvider(Interfaces.IProvider Provider)
		{
			lock (this.__Providers) { return this.__Providers.Contains(Provider); }
		}

		/// <summary>
		/// Removes a provider from the list that go into the XCRI feed.
		/// </summary>
		/// <param name="Provider">The provider to remove</param>
		public void RemoveProvider(Interfaces.IProvider Provider)
		{
			lock (this.__Providers)
			{
				this.OnPropertyChanging("Providers");
				this.__Providers.Remove(Provider);
				this.OnPropertyChanged("Providers");
			}
		}

		public void GenerateTo
			(
			System.IO.TextWriter textWriter,
			XCRIProfiles Profile
			)
		{
			this.GenerateTo(textWriter, Configuration.StandardNamespaces, Profile);
		}

		/// <summary>
		/// Generates the XCRI feed into the supplied text writer.
		/// </summary>
		/// <param name="textWriter">The text writer to populate</param>
		public void GenerateTo
			(
			System.IO.TextWriter textWriter,
			NamespaceList namespaceData,
			XCRIProfiles Profile
			)
		{
			if(Profile != XCRIProfiles.XCRI_v1_1)
				throw new ArgumentException("XCRI Profile not supported");
			System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.Encoding = Encoding.UTF8;
			xmlWriterSettings.NewLineOnAttributes = true;
			//xmlWriterSettings.OmitXmlDeclaration = true;
			using (System.Xml.XmlWriter xmlWriter = System.Xml.XmlTextWriter.Create(textWriter, xmlWriterSettings))
			{
				this.GenerateTo(xmlWriter, namespaceData, Profile);
			}
		}

		public virtual void GenerateTo(System.Xml.XmlWriter xmlWriter, XCRIProfiles Profile)
		{
			this.GenerateTo(xmlWriter, Configuration.StandardNamespaces, Profile);
		}

		/// <summary>
		/// Generates the XCRI feed into the supplied text writer.
		/// </summary>
		/// <param name="textWriter">The text writer to populate</param>
		public virtual void GenerateTo
			(
			System.Xml.XmlWriter xmlWriter, 
			NamespaceList namespaceData,
			XCRIProfiles Profile
			)
		{
			if (Profile != XCRIProfiles.XCRI_v1_1)
				throw new ArgumentException("XCRI Profile not supported");
			xmlWriter.WriteStartDocument(true);
			xmlWriter.WriteStartElement("catalog", @"http://xcri.org/profiles/catalog");
			/*
			xmlWriter.WriteAttributeString("xmlns", "xhtml", null, @"http://www.w3.org/1999/xhtml");
			xmlWriter.WriteAttributeString("xmlns", "xcri", null, @"http://xcri.org/profiles/catalog");
			xmlWriter.WriteAttributeString("xmlns", "terms", null, @"http://xcri.org/profiles/catalog/terms");
			xmlWriter.WriteAttributeString("xmlns", "xsi", null, @"http://www.w3.org/2001/XMLSchema-instance");
			xmlWriter.WriteAttributeString("xmlns", "ukrlp", null, @"http://www.ukrlp.co.uk");
			xmlWriter.WriteAttributeString("xmlns", "geo", null, @"http://www.w3.org/2003/01/geo/wgs84_pos");
			xmlWriter.WriteAttributeString("xsi", "schemaLocation", null, @"http://xcri.org/profiles/catalog http://www.xcri.org/bindings/xcri_cap_1_1.xsd http://xcri.org/profiles/catalog/terms http://www.xcri.org/bindings/xcri_cap_terms_1_1.xsd");
			*/
			if (namespaceData != null)
			{
				StringBuilder schemaLocation = new StringBuilder();
				foreach (NamespaceData ns in namespaceData)
				{
					if(String.IsNullOrEmpty(ns.NamespaceUri) == true)
						continue;
					if(String.IsNullOrEmpty(ns.Prefix) == false)
						xmlWriter.WriteAttributeString("xmlns", ns.Prefix, null, ns.NamespaceUri);
					if (String.IsNullOrEmpty(ns.XSDLocation) == false)
						schemaLocation.AppendFormat("{0} {1} ", ns.NamespaceUri, ns.XSDLocation);
				}
				xmlWriter.WriteAttributeString("xsi", "schemaLocation", null, schemaLocation.ToString().Trim());
			}
			xmlWriter.WriteAttributeString("generated", DateTime.Now.ToXCRIString());
			foreach (Interfaces.IProvider provider in this.Providers)
			{
				provider.GenerateTo(xmlWriter, Profile);
			}
			xmlWriter.WriteEndElement();
			xmlWriter.Flush();
		}

		#endregion

		#endregion

	}
}
