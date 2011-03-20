using System;
using System.Collections.Generic;
using System.Text;

namespace XCRI.Vocabularies.XCRICAP11.Terms
{
    /// <summary>
    /// Represents a Description node that references the XCRICAP1.1 Terms namespace
    /// </summary>
    public class Description : XCRI.Description
    {

        #region Constructors

        #region Public

        public Description()
            : base()
        {
            base.XsiTypeValueNamespace = XCRI.Configuration.Namespaces.XCRICAP11TermsNamespaceUri;
            this.CompatibleWith = XCRIProfiles.XCRI_v1_1;
        }

        #endregion

        #endregion

        #region Properties and Fields

        #region Public new

        public new DescriptionTypes XsiTypeValue
        {
            get { return (DescriptionTypes)Enum.Parse(typeof(DescriptionTypes), base.XsiTypeValue); }
            set { base.XsiTypeValue = value.ToString(); }
        }

        #endregion

        #endregion

    }
}
