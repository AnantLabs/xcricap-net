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
        private List<Interfaces.ICourseLevel> __Levels = new List<Interfaces.ICourseLevel>();
        private List<Interfaces.ICredit> __Credits = new List<Interfaces.ICredit>();
        private List<Interfaces.IAbstract> __Abstracts = new List<Interfaces.IAbstract>();
        private List<Interfaces.IApplicationProcedure> __ApplicationProcedures = new List<Interfaces.IApplicationProcedure>();
        private List<Interfaces.IAssessment> __Assessments = new List<Interfaces.IAssessment>();
        private List<Interfaces.ILearningOutcome> __LearningOutcomes = new List<Interfaces.ILearningOutcome>();
        private List<Interfaces.IObjective> __Objectives = new List<Interfaces.IObjective>();
        private List<Interfaces.IPrerequisite> __Prerequisites = new List<Interfaces.IPrerequisite>();
        private List<Interfaces.IRegulations> __Regulations = new List<Interfaces.IRegulations>();
        private List<Interfaces.IContributor> __Contributors = new List<Interfaces.IContributor>();
        private List<Interfaces.IType> __Types = new List<Interfaces.IType>();

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
        protected IList<Interfaces.ICourseLevel> _Levels
		{
            get { return this.__Levels; }
		}
        protected IList<Interfaces.ICredit> _Credits
		{
            get { return this.__Credits; }
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
        protected IList<Interfaces.IRegulations> _Regulations
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
        public IList<Interfaces.ICourseLevel> Levels
        {
            get { return this._Levels; }
        }
        public IList<Interfaces.ICredit> Credits
        {
            get { return this._Credits; }
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
        public IList<Interfaces.IRegulations> Regulations
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
