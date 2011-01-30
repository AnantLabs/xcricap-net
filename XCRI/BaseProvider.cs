using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI
{
	/// <summary>
	/// Provides a base implementation of Interfaces.IProvider.
	/// Represents the provider element in the XCRI standard.
	/// </summary>
	public abstract class BaseProvider : ElementWithIdentifiers, Interfaces.IProvider
	{

		#region Constructors

		#region Public

		public BaseProvider()
            : base("provider", Configuration.XCRICAP11NamespaceUri)
		{
		}

		#endregion

		#endregion

		#region Properties and Fields

		#region Private

		private Uri __WebAddress = null;
		private long? __ReferenceNumber = null;
		//private string __Title = String.Empty;
		private Interfaces.IAddress __Address = null;
		private Image __Image = null;
        private List<Interfaces.ITitle> __Titles = new List<Interfaces.ITitle>();
        private List<Interfaces.IDescription> __Descriptions = new List<Interfaces.IDescription>();

		#endregion

		#region Protected

        protected List<Interfaces.ITitle> _Titles
        {
            get { return this.__Titles; }
        }

        protected List<Interfaces.IDescription> _Descriptions
        {
            get { return this.__Descriptions; }
        }

		protected Uri _WebAddress
		{
			get { return this.__WebAddress; }
			set
			{
				if (this.__WebAddress == value) { return; }
				this.OnPropertyChanging("WebAddress");
				this.__WebAddress = value;
				this.OnPropertyChanged("WebAddress");
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

		/*
		protected string _Title
		{
			get { return this.__Title; }
			set
			{
				if (this.__Title == value) { return; }
				this.OnPropertyChanging("Title");
				this.__Title = value;
				this.OnPropertyChanged("Title");
			}
		}
		*/

		protected Interfaces.IAddress _Address
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

		protected Image _Image
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

		#endregion

		#endregion

		#region IProvider Members

		/// <summary>
		/// The public web address for the course provider
		/// </summary>
		public Uri WebAddress
		{
			get { return this._WebAddress; }
			set { this._WebAddress = value; }
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

        public IList<Interfaces.IDescription> Descriptions
		{
            get { return this._Descriptions; }
		}

		/// <summary>
		/// The main address of the course provider
		/// </summary>
		public XCRI.Interfaces.IAddress Address
		{
			get { return this._Address; }
			set { this._Address = value; }
		}

		/// <summary>
		/// An image element enabling images to be displayed by an aggregator.
		/// </summary>
		public Image Image
		{
			get { return this._Image; }
			set { this._Image = value; }
		}

		/// <summary>
		/// Retrieves the courses from the course provider's database.
		/// </summary>
		public abstract IEnumerable<Interfaces.ICourse> Courses { get; }

		public void AddDescription(string description)
		{
			this.Descriptions.Add(new Description()
			{
				Value = description
			});
		}

        public void AddTitle(string title)
        {
            this.Titles.Add(new Title()
            {
                Value = title
            });
        }

		#endregion

	}
}
