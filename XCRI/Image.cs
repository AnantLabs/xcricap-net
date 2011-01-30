using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI
{
    public class Image : Element, Interfaces.IXmlElement, Interfaces.IImage
	{

		#region Constructors

		#region Public

		public Image()
            : base("image", Configuration.XCRICAP11NamespaceUri)
		{
		}

		#endregion

		#endregion

		#region Properties and Fields

		#region Private

		private Uri __Source = null;
		private string __Title = String.Empty;
        private string __Alt = String.Empty;

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

        protected string _Alt
        {
            get { return this.__Alt; }
            set
            {
                if (this.__Alt == value) { return; }
                this.OnPropertyChanging("Alt");
                this.__Alt = value;
                this.OnPropertyChanged("Alt");
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

        public string Alt
        {
            get { return this._Alt; }
            set { this._Alt = value; }
        }

		#endregion

		#endregion

	}
}
