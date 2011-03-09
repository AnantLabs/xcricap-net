using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;
using XCRI.Interfaces;

namespace XCRI
{
	/// <summary>
	/// Provides a base implementation of Interfaces.IProvider.
	/// Represents the provider element in the XCRI standard.
	/// </summary>
	public class Provider : Element, Interfaces.IProvider
	{

		#region Properties and Fields

		#region Private

		private Uri __Url = null;
		private long? __ReferenceNumber = null;
		private Interfaces.ILocation __Address = null;
        private IImage __Image = null;
        private List<Interfaces.ITitle> __Titles = new List<Interfaces.ITitle>();
        private List<Interfaces.ICourse> __Courses = new List<Interfaces.ICourse>();
        private List<Interfaces.IDescription> __Descriptions = new List<Interfaces.IDescription>();
        private List<Interfaces.ISubject> __Subjects = new List<Interfaces.ISubject>();
        private ResourceStatus __ResourceStatus = XCRI.ResourceStatus.Unknown;
        private string __PhoneNumber = String.Empty;
        private string __FaxNumber = String.Empty;
        private string __EmailAddress = String.Empty;
        private List<Interfaces.IIdentifier> __Identifiers = new List<Interfaces.IIdentifier>();

		#endregion

        #region Protected

        protected IList<Interfaces.IIdentifier> _Identifiers
        {
            get { return this.__Identifiers; }
        }

        protected ResourceStatus _ResourceStatus
        {
            get { return this.__ResourceStatus; }
            set
            {
                if (this.__ResourceStatus == value) { return; }
                this.OnPropertyChanging("ResourceStatus");
                this.__ResourceStatus = value;
                this.OnPropertyChanged("ResourceStatus");
            }
        }

        protected List<Interfaces.ITitle> _Titles
        {
            get { return this.__Titles; }
        }

        protected List<Interfaces.ICourse> _Courses
        {
            get { return this.__Courses; }
        }

        protected List<Interfaces.ISubject> _Subjects
        {
            get { return this.__Subjects; }
        }

        protected List<Interfaces.IDescription> _Descriptions
        {
            get { return this.__Descriptions; }
        }

		protected Uri _Url
		{
			get { return this.__Url; }
			set
			{
				if (this.__Url == value) { return; }
                this.OnPropertyChanging("Url");
				this.__Url = value;
                this.OnPropertyChanged("Url");
			}
		}

		protected long? _ReferenceNumber
		{
			get { return this.__ReferenceNumber; }
			set
			{
				if (this.__ReferenceNumber == value) { return; }
				this.OnPropertyChanging("ReferenceNumber");
				this.__ReferenceNumber = value;
				this.OnPropertyChanged("ReferenceNumber");
			}
		}

		protected Interfaces.ILocation _Address
		{
			get { return this.__Address; }
			set
			{
				if (this.__Address == value) { return; }
				this.OnPropertyChanging("Address");
				this.__Address = value;
				this.OnPropertyChanged("Address");
			}
		}

        protected IImage _Image
        {
            get { return this.__Image; }
            set
            {
                if (this.__Image == value) { return; }
                this.OnPropertyChanging("Image");
                this.__Image = value;
                this.OnPropertyChanged("Image");
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

        #region IProvider Members

        public IList<Interfaces.IIdentifier> Identifiers
        {
            get { return this._Identifiers; }
        }

        public ResourceStatus ResourceStatus
        {
            get { return this._ResourceStatus; }
            set { this._ResourceStatus = value; }
        }

		/// <summary>
		/// The public web address for the course provider
		/// </summary>
		public Uri Url
		{
			get { return this._Url; }
			set { this._Url = value; }
		}

		/// <summary>
		/// The UK Provider Reference Number for the course provider,
		/// or null if not available.
		/// </summary>
		public long? ReferenceNumber
		{
			get { return this._ReferenceNumber; }
			set { this._ReferenceNumber = value; }
		}

        public IList<Interfaces.ITitle> Titles
		{
            get { return this._Titles; }
		}

        public IList<Interfaces.ISubject> Subjects
        {
            get { return this._Subjects; }
        }

        public IList<Interfaces.IDescription> Descriptions
        {
            get { return this._Descriptions; }
        }

		/// <summary>
		/// The main address of the course provider
		/// </summary>
		public XCRI.Interfaces.ILocation Address
		{
			get { return this._Address; }
            set { this._Address = value; }
		}

		/// <summary>
		/// An image element enabling images to be displayed by an aggregator.
		/// </summary>
        public IImage Image
		{
			get { return this._Image; }
			set { this._Image = value; }
		}

		/// <summary>
		/// Retrieves the courses from the course provider's database.
		/// </summary>
        public IList<Interfaces.ICourse> Courses
        {
            get { return this._Courses; }
        }

        public string PhoneNumber
        {
            get { return this._PhoneNumber; }
            set { this._PhoneNumber = value; }
        }

        public string FaxNumber
        {
            get { return this._FaxNumber; }
            set { this._FaxNumber = value; }
        }

        public string EmailAddress
        {
            get { return this._EmailAddress; }
            set { this._EmailAddress = value; }
        }

        #endregion

    }
}
