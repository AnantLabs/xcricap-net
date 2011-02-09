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
	public class Course : ElementWithIdentifiers, Interfaces.ICourse
	{

		#region Properties and Fields

		#region Private

        private List<Interfaces.ITitle> __Titles = new List<Interfaces.ITitle>();
		private Uri __Uri = null;
        private Image __Image = null;
        private List<XCRI.Interfaces.IDescription> __Descriptions = new List<Interfaces.IDescription>();
        private List<Interfaces.ISubject> __Subjects = new List<Interfaces.ISubject>();
        private List<Interfaces.IQualification> __Qualifications = new List<Interfaces.IQualification>();
        private List<Interfaces.IPresentation> __Presentations = new List<Interfaces.IPresentation>();
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

        public ResourceStatus ResourceStatus
        {
            get { return this._ResourceStatus; }
            set { this._ResourceStatus = value; }
        }

        public IList<Interfaces.ITitle> Titles
        {
            get { return this._Titles; }
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
