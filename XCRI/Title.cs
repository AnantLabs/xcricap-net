using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
    public class Title : XmlBaseClasses.ElementWithSingleValue<string>, Interfaces.ITitle
    {

        #region Constructors

        #region Public

        public Title()
            : base("title", Configuration.XCRICAP11NamespaceUri)
        {
        }

        #endregion

        #endregion

    }
}
