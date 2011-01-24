using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI
{
	public class Presentation : ElementWithIdentifiers, Interfaces.IPresentation
	{

		#region Constructors

		#region Public

		public Presentation()
			: base("presentation", Configuration.XCRINamespaceUri)
		{
		}

		#endregion

		#endregion

		#region Properties and Fields

		#region Private

		private string __Title = String.Empty;
		private Dictionary<XCRI.Interfaces.DescriptionTypes, string> __Descriptions = new Dictionary<XCRI.Interfaces.DescriptionTypes, string>();
		private Uri __Uri = null;
		private Image __Image = null;
		private DateTime? __Start = null;
		private DateTime? __End = null;
		private string __Duration = String.Empty;
		private XCRI.Interfaces.StudyModes __StudyMode = XCRI.Interfaces.StudyModes.Unknown;
		private XCRI.Interfaces.AttendanceModes __AttendanceMode = XCRI.Interfaces.AttendanceModes.Unknown;
		private XCRI.Interfaces.AttendancePatterns __AttendancePattern = XCRI.Interfaces.AttendancePatterns.Unknown;
		private List<XCRI.Interfaces.Languages> __LanguageOfInstruction = new List<XCRI.Interfaces.Languages>();
		private List<XCRI.Interfaces.Languages> __LanguageOfAssessment = new List<XCRI.Interfaces.Languages>();
		private string __PlacesAvailable = String.Empty;
		private string __Cost = String.Empty;
		private List<XCRI.Interfaces.IVenue> __Venues = new List<XCRI.Interfaces.IVenue>();
		private string __EnquireTo = String.Empty;
		private string __ApplyTo = String.Empty;

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

		protected Dictionary<XCRI.Interfaces.DescriptionTypes, string> _Descriptions
		{
			get { return this.__Descriptions; }
			set
			{
				if (this.__Descriptions == value) { return; }
				this.OnPropertyChanging("Descriptions");
				this.__Descriptions = value;
				this.OnPropertyChanged("Descriptions");
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

		protected DateTime? _Start
		{
			get { return this.__Start; }
			set
			{
				if (this.__Start == value) { return; }
				this.OnPropertyChanging("Start");
				this.__Start = value;
				this.OnPropertyChanged("Start");
			}
		}

		protected DateTime? _End
		{
			get { return this.__End; }
			set
			{
				if (this.__End == value) { return; }
				this.OnPropertyChanging("End");
				this.__End = value;
				this.OnPropertyChanged("End");
			}
		}

		protected string _Duration
		{
			get { return this.__Duration; }
			set
			{
				if (this.__Duration == value) { return; }
				this.OnPropertyChanging("Duration");
				this.__Duration = value;
				this.OnPropertyChanged("Duration");
			}
		}

		protected XCRI.Interfaces.StudyModes _StudyMode
		{
			get { return this.__StudyMode; }
			set
			{
				if (this.__StudyMode == value) { return; }
				this.OnPropertyChanging("StudyMode");
				this.__StudyMode = value;
				this.OnPropertyChanged("StudyMode");
			}
		}

		protected XCRI.Interfaces.AttendanceModes _AttendanceMode
		{
			get { return this.__AttendanceMode; }
			set
			{
				if (this.__AttendanceMode == value) { return; }
				this.OnPropertyChanging("AttendanceMode");
				this.__AttendanceMode = value;
				this.OnPropertyChanged("AttendanceMode");
			}
		}

		protected XCRI.Interfaces.AttendancePatterns _AttendancePattern
		{
			get { return this.__AttendancePattern; }
			set
			{
				if (this.__AttendancePattern == value) { return; }
				this.OnPropertyChanging("AttendancePattern");
				this.__AttendancePattern = value;
				this.OnPropertyChanged("AttendancePattern");
			}
		}

		protected List<XCRI.Interfaces.Languages> _LanguageOfInstruction
		{
			get { return this.__LanguageOfInstruction; }
			set
			{
				if (this.__LanguageOfInstruction == value) { return; }
				this.OnPropertyChanging("LanguageOfInstruction");
				this.__LanguageOfInstruction = value;
				this.OnPropertyChanged("LanguageOfInstruction");
			}
		}

		protected List<XCRI.Interfaces.Languages> _LanguageOfAssessment
		{
			get { return this.__LanguageOfAssessment; }
			set
			{
				if (this.__LanguageOfAssessment == value) { return; }
				this.OnPropertyChanging("LanguageOfAssessment");
				this.__LanguageOfAssessment = value;
				this.OnPropertyChanged("LanguageOfAssessment");
			}
		}

		protected string _PlacesAvailable
		{
			get { return this.__PlacesAvailable; }
			set
			{
				if (this.__PlacesAvailable == value) { return; }
				this.OnPropertyChanging("PlacesAvailable");
				this.__PlacesAvailable = value;
				this.OnPropertyChanged("PlacesAvailable");
			}
		}

		protected string _Cost
		{
			get { return this.__Cost; }
			set
			{
				if (this.__Cost == value) { return; }
				this.OnPropertyChanging("Cost");
				this.__Cost = value;
				this.OnPropertyChanged("Cost");
			}
		}

		protected List<XCRI.Interfaces.IVenue> _Venues
		{
			get { return this.__Venues; }
			set
			{
				if (this.__Venues == value) { return; }
				this.OnPropertyChanging("Venues");
				this.__Venues = value;
				this.OnPropertyChanged("Venues");
			}
		}

		protected string _EnquireTo
		{
			get { return this.__EnquireTo; }
			set
			{
				if (this.__EnquireTo == value) { return; }
				this.OnPropertyChanging("EnquireTo");
				this.__EnquireTo = value;
				this.OnPropertyChanged("EnquireTo");
			}
		}

		protected string _ApplyTo
		{
			get { return this.__ApplyTo; }
			set
			{
				if (this.__ApplyTo == value) { return; }
				this.OnPropertyChanging("ApplyTo");
				this.__ApplyTo = value;
				this.OnPropertyChanged("ApplyTo");
			}
		}

		#endregion

		#endregion

		#region IPresentation Members

		public string Title
		{
			get { return this._Title; }
			set { this._Title = value; }
		}

		public Dictionary<XCRI.Interfaces.DescriptionTypes, string> Descriptions
		{
			get { return this._Descriptions; }
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

		public DateTime? Start
		{
			get { return this._Start; }
			set { this._Start = value; }
		}

		public DateTime? End
		{
			get { return this._End; }
			set { this._End = value; }
		}

		public string Duration
		{
			get { return this._Duration; }
			set { this._Duration = value; }
		}

		public XCRI.Interfaces.StudyModes StudyMode
		{
			get { return this._StudyMode; }
			set { this._StudyMode = value; }
		}

		public XCRI.Interfaces.AttendanceModes AttendanceMode
		{
			get { return this._AttendanceMode; }
			set { this._AttendanceMode = value; }
		}

		public XCRI.Interfaces.AttendancePatterns AttendancePattern
		{
			get { return this._AttendancePattern; }
			set { this._AttendancePattern = value; }
		}

		public List<XCRI.Interfaces.Languages> LanguageOfInstruction
		{
			get { throw new NotImplementedException(); }
		}

		public List<XCRI.Interfaces.Languages> LanguageOfAssessment
		{
			get { throw new NotImplementedException(); }
		}

		public string PlacesAvailable
		{
			get { return this._PlacesAvailable; }
			set { this._PlacesAvailable = value; }
		}

		public string Cost
		{
			get { return this._Cost; }
			set { this._Cost = value; }
		}

		public List<XCRI.Interfaces.IVenue> Venues
		{
			get { return this._Venues; }
		}

		public string EnquireTo
		{
			get { return this._EnquireTo; }
			set { this._EnquireTo = value; }
		}

		public string ApplyTo
		{
			get { return this._ApplyTo; }
			set { this._ApplyTo = value; }
		}

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
			if (this.Start.HasValue)
                writer.WriteElementString("start", Configuration.XCRINamespaceUri, this.Start.Value.ToXCRIString());
			if (this.End.HasValue)
                writer.WriteElementString("end", Configuration.XCRINamespaceUri, this.End.Value.ToXCRIString());
			if (String.IsNullOrEmpty(this.Duration) == false)
                writer.WriteElementString("duration", Configuration.XCRINamespaceUri, this.Duration);
			if (this.StudyMode != XCRI.Interfaces.StudyModes.Unknown)
			{
                writer.WriteStartElement("studyMode", Configuration.XCRINamespaceUri);
				writer.WriteAttributeString
                    (
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri,
                    String.Format("{0}:studyModeType", writer.LookupPrefix(Configuration.XCRITermsNamespaceUri))
                    );
				writer.WriteValue(this.StudyMode.ToXCRIString());
				writer.WriteEndElement();
			}
			if (this.AttendanceMode != XCRI.Interfaces.AttendanceModes.Unknown)
			{
                writer.WriteStartElement("attendanceMode", Configuration.XCRINamespaceUri);
				writer.WriteAttributeString
                    (
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri, 
                    String.Format("{0}:attendanceModeType", writer.LookupPrefix(Configuration.XCRITermsNamespaceUri))
                    );
				writer.WriteValue(this.AttendanceMode.ToXCRIString());
				writer.WriteEndElement();
			}
			foreach (Venue venue in this.Venues)
			{
				venue.GenerateTo(writer, Profile);
			}
			if (this.AttendancePattern != XCRI.Interfaces.AttendancePatterns.Unknown)
			{
                writer.WriteStartElement("attendancePattern", Configuration.XCRINamespaceUri);
				writer.WriteAttributeString
                    (
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri, 
                    String.Format("{0}:attendancePatternType", writer.LookupPrefix(Configuration.XCRITermsNamespaceUri))
                    );
				writer.WriteValue(this.AttendancePattern.ToXCRIString());
				writer.WriteEndElement();
			}
			if (String.IsNullOrEmpty(this.ApplyTo) == false)
                writer.WriteElementString("applyTo", Configuration.XCRINamespaceUri, this.ApplyTo);
			if (String.IsNullOrEmpty(this.EnquireTo) == false)
                writer.WriteElementString("enquireTo", Configuration.XCRINamespaceUri, this.EnquireTo);
            base.WriteEndElement(writer, Profile);
		}

		#endregion

	}
}
