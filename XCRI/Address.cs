using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI
{
	/// <summary>
	/// Provides a base implementation of Interfaces.IAddress.
	/// Represents common address elements within the XCRI feed.
	/// </summary>
    public class Address : ElementWithStringValue, Interfaces.IAddress
	{

		#region Constructors

		#region Public

		public Address()
			: base("address", Configuration.XCRINamespaceUri)
		{
		}

		#endregion

		#endregion

		#region Properties and Fields

		#region Private

		private string __Street = String.Empty;
		private string __Town = String.Empty;
		private string __Postcode = String.Empty;
		private decimal? __Latitude = null;
		private decimal? __Longitude = null;
		private string __PhoneNumber = String.Empty;
		private string __FaxNumber = String.Empty;
		private string __EmailAddress = String.Empty;

		#endregion

		#region Protected

		protected string _Street
		{
			get { return this.__Street; }
			set
			{
				if (this.__Street == value) { return; }
				this.OnPropertyChanging("Street");
				this.__Street = value;
				this.OnPropertyChanged("Street");
			}
		}

		protected string _Town
		{
			get { return this.__Town; }
			set
			{
				if (this.__Town == value) { return; }
				this.OnPropertyChanging("Town");
				this.__Town = value;
				this.OnPropertyChanged("Town");
			}
		}

		protected string _Postcode
		{
			get { return this.__Postcode; }
			set
			{
				if (this.__Postcode == value) { return; }
				this.OnPropertyChanging("Postcode");
				this.__Postcode = value;
				this.OnPropertyChanged("Postcode");
			}
		}

		protected decimal? _Latitude
		{
			get { return this.__Latitude; }
			set
			{
				if (this.__Latitude == value) { return; }
				this.OnPropertyChanging("Latitude");
				this.__Latitude = value;
				this.OnPropertyChanged("Latitude");
			}
		}

		protected decimal? _Longitude
		{
			get { return this.__Longitude; }
			set
			{
				if (this.__Longitude == value) { return; }
				this.OnPropertyChanging("Longitude");
				this.__Longitude = value;
				this.OnPropertyChanged("Longitude");
			}
		}

		protected string _PhoneNumber
		{
			get { return this.__PhoneNumber; }
			set
			{
				if (this.__PhoneNumber == value) { return; }
				this.OnPropertyChanging("PhoneNumber");
				this.__PhoneNumber = value;
				this.OnPropertyChanged("PhoneNumber");
			}
		}

		protected string _FaxNumber
		{
			get { return this.__FaxNumber; }
			set
			{
				if (this.__FaxNumber == value) { return; }
				this.OnPropertyChanging("FaxNumber");
				this.__FaxNumber = value;
				this.OnPropertyChanged("FaxNumber");
			}
		}

		protected string _EmailAddress
		{
			get { return this.__EmailAddress; }
			set
			{
				if (this.__EmailAddress == value) { return; }
				this.OnPropertyChanging("EmailAddress");
				this.__EmailAddress = value;
				this.OnPropertyChanged("EmailAddress");
			}
		}

		#endregion

		#endregion

		#region IAddress Members

		/// <summary>
		/// The street element of the address
		/// </summary>
		public string Street
		{
			get { return this._Street; }
			set { this._Street = value; }
		}

		/// <summary>
		/// The town element of the address
		/// </summary>
		public string Town
		{
			get { return this._Town; }
			set { this._Town = value; }
		}

		/// <summary>
		/// The postcode element of the address
		/// </summary>
		public string Postcode
		{
			get { return this._Postcode; }
			set { this._Postcode = value; }
		}

		/// <summary>
		/// The latitude of the address, or null for unknown
		/// </summary>
		public decimal? Latitude
		{
			get { return this._Latitude; }
			set { this._Latitude = value; }
		}

		/// <summary>
		/// The longitude of the address, or null for unknown
		/// </summary>
		public decimal? Longitude
		{
			get { return this._Longitude; }
			set { this._Longitude = value; }
		}

		/// <summary>
		/// The phone number element of the address
		/// </summary>
		public string PhoneNumber
		{
			get { return this._PhoneNumber; }
			set { this._PhoneNumber = value; }
		}

		/// <summary>
		/// The fax number element of the address
		/// </summary>
		public string FaxNumber
		{
			get { return this._FaxNumber; }
			set { this._FaxNumber = value; }
		}

		/// <summary>
		/// The email address element of the address
		/// </summary>
		public string EmailAddress
		{
			get { return this._EmailAddress; }
			set { this._EmailAddress = value; }
		}

		/// <summary>
		/// Writes the XML elements associated with the address to the
		/// provided XmlWriter object.
		/// </summary>
		/// <param name="writer">The XmlWriter to output the XML elements to.</param>
		public override void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			if (Profile != XCRIProfiles.XCRI_v1_1)
				throw new ArgumentException("XCRI Profile not supported");
			if (this.Latitude.HasValue)
			{
                ElementWithStringValue latitude = new ElementWithStringValue("address", Configuration.XCRINamespaceUri);
                latitude.XsiType.Value = "lat";
                latitude.XsiType.AttributeValueNamespace = @"http://www.w3.org/2003/01/geo/wgs84_pos";
                latitude.Value = this.Latitude.Value.ToString();
                latitude.GenerateTo(writer, Profile);
			}
			if (this.Longitude.HasValue)
			{
                ElementWithStringValue longitude = new ElementWithStringValue("address", Configuration.XCRINamespaceUri);
                longitude.XsiType.Value = "long";
                longitude.XsiType.AttributeValueNamespace = @"http://www.w3.org/2003/01/geo/wgs84_pos";
                longitude.Value = this.Longitude.Value.ToString();
                longitude.GenerateTo(writer, Profile);
			}
			if (String.IsNullOrEmpty(this.Street) == false)
                writer.WriteElementString("street", Configuration.XCRINamespaceUri, this.Street);
			if (String.IsNullOrEmpty(this.Town) == false)
                writer.WriteElementString("town", Configuration.XCRINamespaceUri, this.Town);
			if (String.IsNullOrEmpty(this.Postcode) == false)
                writer.WriteElementString("postcode", Configuration.XCRINamespaceUri, this.Postcode);
			if (String.IsNullOrEmpty(this.PhoneNumber) == false)
                writer.WriteElementString("phone", Configuration.XCRINamespaceUri, this.PhoneNumber);
			if (String.IsNullOrEmpty(this.FaxNumber) == false)
                writer.WriteElementString("fax", Configuration.XCRINamespaceUri, this.FaxNumber);
			if (String.IsNullOrEmpty(this.EmailAddress) == false)
                writer.WriteElementString("email", Configuration.XCRINamespaceUri, this.EmailAddress);
		}

		#endregion

	}
}
