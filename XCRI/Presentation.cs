using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI
{
	public class Presentation : Element, Interfaces.IPresentation
	{

		#region Properties and Fields

		#region Private

		private List<Interfaces.ITitle> __Titles = new List<Interfaces.ITitle>();
        private List<XCRI.Interfaces.IDescription> __Descriptions = new List<Interfaces.IDescription>();
        private List<XCRI.Interfaces.ISubject> __Subjects = new List<Interfaces.ISubject>();
        private Uri __Url = null;
		private Interfaces.IImage __Image = null;
		private Interfaces.IDate __Start = null;
        private Interfaces.IDate __End = null;
        private TimeSpan? __Duration = null;
        private Interfaces.IStudyMode __StudyMode = new StudyMode();
        private Interfaces.IAttendanceMode __AttendanceMode = new AttendanceMode();
        private Interfaces.IAttendancePattern __AttendancePattern = new AttendancePattern();
        private List<string> __LanguageOfInstruction = new List<string>();
        private List<string> __LanguageOfAssessment = new List<string>();
		private string __PlacesAvailable = String.Empty;
		private string __Cost = String.Empty;
		private List<XCRI.Interfaces.IVenue> __Venues = new List<XCRI.Interfaces.IVenue>();
		private string __EnquireTo = String.Empty;
        private string __ApplyTo = String.Empty;
        private ResourceStatus __ResourceStatus = XCRI.ResourceStatus.Unknown;
        private List<Interfaces.IIdentifier> __Identifiers = new List<Interfaces.IIdentifier>();
        private List<Interfaces.IAbstract> __Abstracts = new List<Interfaces.IAbstract>();
        private List<Interfaces.IApplicationProcedure> __ApplicationProcedures = new List<Interfaces.IApplicationProcedure>();
        private List<Interfaces.IAssessment> __Assessments = new List<Interfaces.IAssessment>();
        private List<Interfaces.ILearningOutcome> __LearningOutcomes = new List<Interfaces.ILearningOutcome>();
        private List<Interfaces.IObjective> __Objectives = new List<Interfaces.IObjective>();
        private List<Interfaces.IPrerequisite> __Prerequisites = new List<Interfaces.IPrerequisite>();
        private List<Interfaces.IRegulation> __Regulations = new List<Interfaces.IRegulation>();
        private List<Interfaces.IContributor> __Contributors = new List<Interfaces.IContributor>();
        private List<Interfaces.IType> __Types = new List<Interfaces.IType>();
        private IList<Interfaces.IEngagement> __Engagements = new List<Interfaces.IEngagement>();
        private string __AgeRange = String.Empty;

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

		protected List<Interfaces.ITitle> _Titles
		{
			get { return this.__Titles; }
		}

		protected List<Interfaces.IDescription> _Descriptions
		{
			get { return this.__Descriptions; }
		}

        protected List<Interfaces.ISubject> _Subjects
        {
            get { return this.__Subjects; }
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

        protected Interfaces.IDate _Start
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

        protected Interfaces.IDate _End
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

        protected TimeSpan? _Duration
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

        protected Interfaces.IStudyMode _StudyMode
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

        protected Interfaces.IAttendanceMode _AttendanceMode
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

        protected Interfaces.IAttendancePattern _AttendancePattern
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

        protected List<string> _LanguageOfInstruction
		{
			get { return this.__LanguageOfInstruction; }
		}

        protected List<string> _LanguageOfAssessment
		{
			get { return this.__LanguageOfAssessment; }
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
        protected IList<Interfaces.IAbstract> _Abstracts
        {
            get { return this.__Abstracts; }
        }
        protected IList<Interfaces.IApplicationProcedure> _ApplicationProcedures
        {
            get { return this.__ApplicationProcedures; }
        }
        protected IList<Interfaces.IAssessment> _Assessments
        {
            get { return this.__Assessments; }
        }
        protected IList<Interfaces.ILearningOutcome> _LearningOutcomes
        {
            get { return this.__LearningOutcomes; }
        }
        protected IList<Interfaces.IObjective> _Objectives
        {
            get { return this.__Objectives; }
        }
        protected IList<Interfaces.IPrerequisite> _Prerequisites
        {
            get { return this.__Prerequisites; }
        }
        protected IList<Interfaces.IRegulation> _Regulations
        {
            get { return this.__Regulations; }
        }
        protected IList<Interfaces.IContributor> _Contributors
        {
            get { return this.__Contributors; }
        }
        protected IList<Interfaces.IType> _Types
        {
            get { return this.__Types; }
        }
        protected IList<Interfaces.IEngagement> _Engagements
        {
            get { return this.__Engagements; }
        }
        protected string _AgeRange
		{
			get { return this.__AgeRange; }
			set
			{
				if (this.__AgeRange == value) { return; }
				this.OnPropertyChanging("AgeRange");
				this.__AgeRange = value;
				this.OnPropertyChanged("AgeRange");
			}
        }

		#endregion

		#endregion

        #region IPresentation Members

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

        public IList<Interfaces.IDescription> Descriptions
        {
            get { return this._Descriptions; }
        }

        public IList<Interfaces.ISubject> Subjects
        {
            get { return this._Subjects; }
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

        public Interfaces.IDate Start
		{
			get { return this._Start; }
			set { this._Start = value; }
		}

        public Interfaces.IDate End
		{
			get { return this._End; }
			set { this._End = value; }
		}

        public TimeSpan? Duration
		{
			get { return this._Duration; }
			set { this._Duration = value; }
		}

        public Interfaces.IStudyMode StudyMode
		{
			get { return this._StudyMode; }
			set { this._StudyMode = value; }
		}

        public Interfaces.IAttendanceMode AttendanceMode
		{
			get { return this._AttendanceMode; }
			set { this._AttendanceMode = value; }
		}

        public Interfaces.IAttendancePattern AttendancePattern
		{
			get { return this._AttendancePattern; }
			set { this._AttendancePattern = value; }
		}

        public IList<string> LanguagesOfInstruction
		{
			get { return this._LanguageOfInstruction; }
		}

        public IList<string> LanguagesOfAssessment
		{
			get { return this._LanguageOfAssessment; }
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

		public IList<XCRI.Interfaces.IVenue> Venues
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

        public IList<Interfaces.IEngagement> Engagements
        {
            get{ return this._Engagements; }
        }

        public string AgeRange
        {
            get { return this._AgeRange; }
            set { this._AgeRange = value; }
        }
        public IList<Interfaces.IAbstract> Abstracts
        {
            get { return this._Abstracts; }
        }
        public IList<Interfaces.IApplicationProcedure> ApplicationProcedures
        {
            get { return this._ApplicationProcedures; }
        }
        public IList<Interfaces.IAssessment> Assessments
        {
            get { return this._Assessments; }
        }
        public IList<Interfaces.ILearningOutcome> LearningOutcomes
        {
            get { return this._LearningOutcomes; }
        }
        public IList<Interfaces.IObjective> Objectives
        {
            get { return this._Objectives; }
        }
        public IList<Interfaces.IPrerequisite> Prerequisites
        {
            get { return this._Prerequisites; }
        }
        public IList<Interfaces.IRegulation> Regulations
        {
            get { return this._Regulations; }
        }
        public IList<Interfaces.IContributor> Contributors
        {
            get { return this._Contributors; }
        }
        public IList<Interfaces.IType> Types
        {
            get { return this._Types; }
        }

        #endregion

    }
}
