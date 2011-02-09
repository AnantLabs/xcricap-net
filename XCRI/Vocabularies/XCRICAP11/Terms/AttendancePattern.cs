using System;
using System.Collections.Generic;
using System.Text;

namespace XCRI.Vocabularies.XCRICAP11.Terms
{
    /// <summary>
    /// Represents a Description node that references the XCRICAP1.1 Terms namespace
    /// </summary>
    public class AttendancePattern : XCRI.AttendancePattern
    {

        #region Constructors

        #region Public

        public AttendancePattern()
            : base()
        {
            base.XsiTypeValue = "attendancePatternType";
            base.XsiTypeValueNamespace = XCRI.Configuration.Namespaces.XCRICAP11TermsNamespaceUri;
        }

        #endregion

        #endregion

        #region Properties and Fields

        #region Public new

        public new AttendancePatternTypes Value
        {
            get { return (AttendancePatternTypes)Enum.Parse(typeof(AttendancePatternTypes), base.Value); }
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
