using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{/// <summary>
    /// Represents the Description node in the XCRI definition.
    /// http://www.xcri.org/wiki/index.php/XCRI_CAP_1.2#the_.3Cdescription.3E_element
    /// </summary>
    public interface IDescription : IElementWithSingleValue<string>
    {
        Uri Href { get; set; }
        DescriptionContentTypes ContentType { get; set; }
    }
}
