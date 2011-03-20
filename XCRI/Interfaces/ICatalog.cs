using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XCRI.Interfaces
{
    /// <summary>
    /// Represents the default root "Catalog" node in the XCRI definition.
    /// http://www.xcri.org/wiki/index.php/Catalog.
    /// </summary>
    public interface ICatalog : IElement, XCRICAP11.ICatalog, XCRICAP12.ICatalog
    {
        new IList<Interfaces.IProvider> Providers { get; }
        new DateTimeOffset? Generated { get; set; }
    }
}
