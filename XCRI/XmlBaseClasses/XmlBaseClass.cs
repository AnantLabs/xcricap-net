using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlBaseClasses
{
    public abstract class XmlBaseClass : NotifyBaseClass, Interfaces.IXmlGenerator
    {

       #region IXmlGenerator Members

        public abstract void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile);

        #endregion

    }
}
