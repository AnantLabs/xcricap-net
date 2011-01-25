using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI
{
	public class Image : ElementWithStringValue, Interfaces.IXmlElement
	{

		#region Constructors

		#region Public

		public Image()
            : base("image", Configuration.XCRINamespaceUri)
		{
		}

		#endregion

		#endregion

		#region Properties and Fields

		#region Private

		private Uri __Source = null;
		private string __Title = String.Empty;

		#endregion

		#region Protected

		protected Uri _Source
		{
			get { return this.__Source; }
			set
			{
				if (this.__Source == value) { return; }
				this.OnPropertyChanging("Source");
				this.__Source = value;
				this.OnPropertyChanged("Source");
			}
		}

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

		#endregion

		#region Public

		public Uri Source
		{
			get { return this._Source; }
			set { this._Source = value; }
		}
		public string Title
		{
			get { return this._Title; }
			set { this._Title = value; }
		}

		#endregion

		#endregion

	}
}
