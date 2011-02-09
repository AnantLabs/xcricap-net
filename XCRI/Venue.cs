using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI
{
	public class Venue : Address, Interfaces.IVenue
	{

		#region Properties and Fields

		#region Private

		private string __Title = String.Empty;
		private Uri __Uri = null;
        private Image __Image = null;
        private List<Interfaces.IIdentifier> __Identifiers = new List<Interfaces.IIdentifier>();
        private ResourceStatus __ResourceStatus = XCRI.ResourceStatus.Unknown;

		#endregion

        #region Protected

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

		protected Uri _Uri
		{
			get { return this.__Uri; }
			set
			{
				if (this.__Uri == value) { return; }
				this.OnPropertyChanging("Uri");
				this.__Uri = value;
				this.OnPropertyChanged("Uri");
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

        protected IList<Interfaces.IIdentifier> _Identifiers
        {
            get { return this.__Identifiers; }
        }

		#endregion

        #region Public

        public IList<Interfaces.IIdentifier> Identifiers
        {
            get { return this._Identifiers; }
        }

		#endregion

		#endregion

        #region IVenue Members

        public ResourceStatus ResourceStatus
        {
            get { return this._ResourceStatus; }
            set { this._ResourceStatus = value; }
        }

		public string Title
		{
			get { return this._Title; }
			set { this._Title = value; }
		}

		public Uri Uri
		{
			get { return this._Uri; }
			set { this._Uri = value; }
		}

		public Image Image
		{
			get { return this._Image; }
			set { this._Image = value; }
		}

		#endregion

	}
}
