using System;
using System.Collections.Generic;
using System.Text;
using XCRI.Vocabularies.XCRICAP11.Terms;

namespace XCRI.Vocabularies.XCRICAP11.Terms
{
    /// <summary>
    /// Represents a Description node that references the XCRICAP1.1 Terms namespace
    /// </summary>
    public class AttendanceMode : XCRI.AttendanceMode
    {

        #region Constructors

        #region Public

        public AttendanceMode()
            : base()
        {
            base.XsiTypeValue = "attendanceModeType";
            base.XsiTypeValueNamespace = XCRI.Configuration.Namespaces.XCRICAP11TermsNamespaceUri;
        }

        #endregion

        #endregion

        #region Properties and Fields

        #region Public new

        public new AttendanceModeTypes Value
        {
            get { return (AttendanceModeTypes)Enum.Parse(typeof(AttendanceModeTypes), base.Value); }
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
