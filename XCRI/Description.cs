using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
    public class Description : XmlBaseClasses.ElementWithSingleValue<string>, Interfaces.IDescription
    {

        #region Constructors

        #region Public

        public Description()
            : base("description", Configuration.XCRICAP11NamespaceUri)
        {

        }

        #endregion

        #endregion

    }
}
