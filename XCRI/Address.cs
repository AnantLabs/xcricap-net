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
    public class Address : ElementWithChildElements, Interfaces.IAddress
	{

		#region Constructors

		#region Public

		public Address()
			: base("address", Configuration.XCRICAP11NamespaceUri)
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

		#endregion

	}
}
