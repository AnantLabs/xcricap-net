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
    public interface ICatalog : INotifyPropertyChanging, INotifyPropertyChanged
    {

        /// <summary>
        /// The date and time at which the catalog was generated.
        /// If set to null - which should be the default - the server time will be used.
        /// </summary>
        DateTime? Generated { get; set; }
        /// <summary>
        /// Identifiers of this catalog
        /// </summary>
        IList<IIdentifier> Identifiers { get; }
        /// <summary>
        /// Titles for the resource
        /// </summary>
        IList<ITitle> Titles { get; }
        /// <summary>
        /// Tags describing the resource
        /// </summary>
        IList<ISubject> Subjects { get; }
        /// <summary>
        /// Descriptive information about the resource
        /// </summary>
        IList<IDescription> Descriptions { get; }
        /// <summary>
        /// A url for further information about the resource
        /// </summary>
        Uri Url { get; }
        /// <summary>
        /// An image that represents the resource, such as a photo or logo
        /// </summary>
        Image Image { get; }
        /// <summary>
        /// The providers which this catalog contains.
        /// In almost all cases there should be only one provider in a feed, however if this
        /// feed contains information from multiple registered providers (e.g. including
        /// a separate business-centred learning provider), multiple providers can be used.
        /// </summary>
        IList<IProvider> Providers { get; }
        /// <summary>
        /// When used with the delta update pattern (http://www.xcri.org/wiki/index.php/Delta_update_pattern)
        /// indicates the status of this resource.
        /// </summary>
        ResourceStatus ResourceStatus { get; set; }
    }
}
