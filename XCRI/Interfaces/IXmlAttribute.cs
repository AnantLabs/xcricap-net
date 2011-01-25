using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
    public interface IXmlAttribute
    {

        string AttributeName { get; set; }
        string AttributeNamespace { get; set; }
        string Value { get; set; }

    }
}
