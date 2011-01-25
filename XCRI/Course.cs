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
	public abstract class Course : ElementWithIdentifiers, Interfaces.ICourse
	{

		#region Constructors

		#region Public

		public Course()
			: base("course", Configuration.XCRINamespaceUri)
		{
		}

		#endregion

		#endregion

		#region Properties and Fields

		#region Private

		private string __Title = String.Empty;
		private Uri __Uri = null;
		private Dictionary<XCRI.Interfaces.DescriptionTypes, DescriptionData> __Descriptions = new Dictionary<XCRI.Interfaces.DescriptionTypes, DescriptionData>();
		private List<string> __Subjects = new List<string>();
		private Interfaces.IQualification __Qualification = null;

		#endregion

		#region Protected

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

		protected Interfaces.IQualification _Qualification
		{
			get { return this.__Qualification; }
			set
			{
				if (this.__Qualification == value) { return; }
				this.OnPropertyChanging("Qualification");
				this.__Qualification = value;
				this.OnPropertyChanged("Qualification");
			}
		}

		#endregion

		#endregion

		#region ICourse Members

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

		public Dictionary<XCRI.Interfaces.DescriptionTypes, DescriptionData> Descriptions
		{
			get { return this.__Descriptions; }
		}

		public ICollection<String> Subjects
		{
			get { return this.__Subjects; }
		}

		public XCRI.Interfaces.IQualification Qualification
		{
			get { return this._Qualification; }
			set { this._Qualification = value; }
		}

		public abstract IEnumerable<XCRI.Interfaces.IPresentation> Presentations { get; }

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
