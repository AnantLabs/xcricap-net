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
            : base("provider", Configuration.XCRINamespaceUri)
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

		#endregion

		#region Protected

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

		/*
		/// <summary>
		/// The name of the company or organisation that provides the learning opportunity.
		/// This should be the trading name.
		/// </summary>
		public string Title
		{
			get { return this._Title; }
			set { this._Title = value; }
		}
		*/

        public IEnumerable<Element> Titles
		{
			get
			{
				foreach (Element el in this._ChildElements)
				{
					if (
                        ((el.ElementName ?? String.Empty).Equals("title", StringComparison.CurrentCultureIgnoreCase))
                        )
                        yield return el as Element;
				}
			}
		}

		public IEnumerable<Element> Descriptions
		{
			get
			{
				foreach (Element el in this._ChildElements)
				{
					if ((el.ElementName ?? String.Empty).Equals("description", StringComparison.CurrentCultureIgnoreCase))
						yield return el;
				}
			}
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
		public abstract IEnumerable<Course> Courses { get; }

		public void AddDescription(string description)
		{
			this.AddDescription(new ElementWithStringValue("description", Configuration.XCRINamespaceUri)
			{
				Value = description
			});
		}

		public void AddDescription(Element description)
		{
			this._ChildElements.Add(description);
		}

		public void AddTitle(string title)
		{
            this.AddTitle(new ElementWithStringValue("title", Configuration.XCRINamespaceUri)
			{
				Value = title
			});
		}

		public void AddTitle(Element title)
		{
			this._ChildElements.Add(title);
		}

		#endregion

	}
}
