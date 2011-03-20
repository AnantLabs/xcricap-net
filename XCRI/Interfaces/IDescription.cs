using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
    /// <summary>
    /// Represents the Description node in the XCRI definition.
    /// http://www.xcri.org/wiki/index.php/Description.
    /// </summary>
    public interface IDescription : XCRICAP11.IDescription, XCRICAP12.IDescription
    {
    }

    public enum DescriptionContentTypes
    {
        Text = 1,
        XHTML = 2,
        Href = 3
    }
}
