using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI
{
	/// <summary>
	/// Provides a base implementation of Interfaces.ICourse.
	/// Represents the Course element in the XCRI standard.
	/// </summary>
	public class Course : Element, Interfaces.ICourse
	{

		#region Properties and Fields

		#region Private

        private List<Interfaces.ITitle> __Titles = new List<Interfaces.ITitle>();
		private Uri __Url = null;
        private Interfaces.IImage __Image = null;
        private List<XCRI.Interfaces.IDescription> __Descriptions = new List<Interfaces.IDescription>();
        private List<Interfaces.ISubject> __Subjects = new List<Interfaces.ISubject>();
        private List<Interfaces.IQualification> __Qualifications = new List<Interfaces.IQualification>();
        private List<Interfaces.IPresentation> __Presentations = new List<Interfaces.IPresentation>();
        private ResourceStatus __ResourceStatus = XCRI.ResourceStatus.Unknown;

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

        protected IList<Interfaces.ITitle> _Titles
		{
			get { return this.__Titles; }
		}

        protected IList<Interfaces.ISubject> _Subjects
        {
            get { return this.__Subjects; }
        }

        protected IList<Interfaces.IDescription> _Descriptions
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

        protected Interfaces.IImage _Image
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

		protected IList<Interfaces.IQualification> _Qualifications
		{
			get { return this.__Qualifications; }
		}

        protected IList<Interfaces.IPresentation> _Presentations
        {
            get { return this.__Presentations; }
        }

		#endregion

		#endregion

        #region ICourse Members

        public IList<Interfaces.IIdentifier> Identifiers
        {
            get { return this._Identifiers; }
        }

        public ResourceStatus ResourceStatus
        {
            get { return this._ResourceStatus; }
            set { this._ResourceStatus = value; }
        }

        public IList<Interfaces.ITitle> Titles
        {
            get { return this._Titles; }
        }

		public Uri Url
		{
			get { return this._Url; }
			set { this._Url = value; }
		}

        public Interfaces.IImage Image
        {
            get { return this._Image; }
            set { this._Image = value; }
        }

		public IList<Interfaces.IDescription> Descriptions
		{
			get { return this._Descriptions; }
		}

		public IList<Interfaces.ISubject> Subjects
		{
			get { return this._Subjects; }
		}

		public IList<XCRI.Interfaces.IQualification> Qualifications
		{
			get { return this._Qualifications; }
		}

        public IList<XCRI.Interfaces.IPresentation> Presentations
        {
            get { return this._Presentations; }
        }

		#endregion

	}
}
