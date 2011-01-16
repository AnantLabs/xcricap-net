using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
			: base("course", @"http://xcri.org/profiles/catalog")
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

		public List<String> Subjects
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

		#region IXmlGenerator Members

		public override void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			if (Profile != XCRIProfiles.XCRI_v1_1)
				throw new ArgumentException("XCRI Profile not supported");
			base.WriteStartElement(writer, Profile);
			foreach (Identifier identifier in this.Identifiers)
			{
				if (identifier != null)
					identifier.GenerateTo(writer, Profile);
			}
			if (String.IsNullOrEmpty(this.Title) == false)
				writer.WriteElementString("title", this.Title);
			foreach (string subject in this.Subjects)
			{
				if (String.IsNullOrEmpty(subject))
					continue;
				writer.WriteElementString("subject", subject);
			}
			foreach (XCRI.Interfaces.DescriptionTypes type in this.Descriptions.Keys)
			{
				writer.WriteStartElement("description");
				writer.WriteAttributeString
					(
					writer.LookupPrefix(@"http://www.w3.org/2001/XMLSchema-instance"),
					"type",
					null,
					String.Format("{0}:{1}", writer.LookupPrefix(@"http://xcri.org/profiles/catalog/terms"), type.ToString())
					);
				if (this.Descriptions[type].IsHtmlEncoded == false)
				{
					writer.WriteValue(this.Descriptions[type].Data);
				}
				else
				{
					writer.WriteRaw(this.Descriptions[type].Data);
				}
				writer.WriteEndElement();
			}
			writer.WriteElementString("url", this.Uri.ToString());
			if (this.Qualification != null)
				Qualification.GenerateTo(writer, Profile);
			foreach (Interfaces.IPresentation presentation in this.Presentations)
			{
				presentation.GenerateTo(writer, Profile);
			}
			writer.WriteEndElement();
		}

		#endregion

	}
	public struct DescriptionData
	{
		public bool IsHtmlEncoded;
		public string Data;
		public DescriptionData(string Data)
		{
			this.IsHtmlEncoded = false;
			this.Data = Data;
		}
		public static implicit operator DescriptionData(string Data)
		{
			return new DescriptionData(Data);
		}
	}
}
