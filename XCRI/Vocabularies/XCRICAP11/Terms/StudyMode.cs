using System;
using System.Collections.Generic;
using System.Text;

namespace XCRI.Vocabularies.XCRICAP11.Terms
{
    /// <summary>
    /// Represents a Description node that references the XCRICAP1.1 Terms namespace
    /// </summary>
    public class StudyMode : XCRI.StudyMode
    {

        #region Constructors

        #region Public

        public StudyMode()
            : base()
        {
            base.XsiTypeValue = "studyModeType";
            base.XsiTypeValueNamespace = XCRI.Configuration.Namespaces.XCRICAP11TermsNamespaceUri;
            this.CompatibleWith = XCRIProfiles.XCRI_v1_1;
        }

        #endregion

        #endregion

        #region Properties and Fields

        #region Public new

        public new StudyModeTypes Value
        {
            get { return (StudyModeTypes)Enum.Parse(typeof(StudyModeTypes), base.Value); }
            set { base.Value = value.ToString(); }
        }

        #endregion

        #endregion

        #region Methods

        #region Public override

        public override string GetElementValueAsString()
        {
            return this.Value.ToXCRIString();
        }

        #endregion

        #endregion

    }
}
