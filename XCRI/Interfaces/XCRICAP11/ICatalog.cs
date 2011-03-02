using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XCRI.Interfaces.XCRICAP11
{
    /// <summary>
    /// Represents the default root "Catalog" node in the XCRI definition.
    /// http://www.xcri.org/wiki/index.php/Catalog.
    /// </summary>
    public interface ICatalog : IElement, XCRICAP11.IGeneric
    {

        /// <summary>
        /// The date and time at which the catalog was generated.
        /// If set to null - which should be the default - the server time will be used.
        /// </summary>
        DateTime? Generated { get; set; }
        /// <summary>
        /// The providers which this catalog contains.
        /// In almost all cases there should be only one provider in a feed, however if this
        /// feed contains information from multiple registered providers (e.g. including
        /// a separate business-centred learning provider), multiple providers can be used.
        /// </summary>
        IList<Interfaces.IProvider> Providers { get; }
    }
}
