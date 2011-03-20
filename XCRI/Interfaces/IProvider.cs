using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI.Interfaces
{
    /// <summary>
    /// Represents the Provider element in the XCRI standard.
    /// </summary>
    public interface IProvider : XCRICAP11.IProvider, XCRICAP12.IProvider
    {
        new IList<Interfaces.ICourse> Courses { get; }
    }
}
