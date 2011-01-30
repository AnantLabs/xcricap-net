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

		#region Constructors

		#region Public

		public Course()
			: base("course", Configuration.XCRICAP11NamespaceUri)
		{
		}

		#endregion

		#endregion

		#region Properties and Fields

		#region Private

        private List<Interfaces.ITitle> __Titles = new List<Interfaces.ITitle>();
		private Uri __Uri = null;
        private Image __Image = null;
        private Dictionary<XCRI.Interfaces.DescriptionTypes, DescriptionData> __Descriptions = new Dictionary<XCRI.Interfaces.DescriptionTypes, DescriptionData>();
        private List<Interfaces.ISubject> __Subjects = new List<Interfaces.ISubject>();
        private List<Interfaces.IQualification> __Qualifications = new List<Interfaces.IQualification>();
        private List<Interfaces.IPresentation> __Presentations = new List<Interfaces.IPresentation>();

		#endregion

		#region Protected

        protected IList<Interfaces.ITitle> _Titles
		{
			get { return this.__Titles; }
		}

        protected IList<Interfaces.ISubject> _Subjects
        {
            get { return this.__Subjects; }
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

		public Dictionary<XCRI.Interfaces.DescriptionTypes, DescriptionData> Descriptions
		{
			get { return this.__Descriptions; }
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
	public struct DescriptionData
	{
		public bool IsXHtmlEncoded;
		public string Data;
		public DescriptionData(string Data)
		{
			this.IsXHtmlEncoded = false;
			this.Data = Data;
		}
		public static implicit operator DescriptionData(string Data)
		{
			return new DescriptionData(Data);
		}
	}
}
