using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP11
{
    public interface IGeneric : IElement
    {
        /// <summary>
        /// Identifiers of this resource
        /// </summary>
        IList<Interfaces.IIdentifier> Identifiers { get; }
        /// <summary>
        /// Titles for the resource
        /// </summary>
        IList<Interfaces.ITitle> Titles { get; }
        /// <summary>
        /// Tags describing the resource
        /// </summary>
        IList<Interfaces.ISubject> Subjects { get; }
        /// <summary>
        /// Descriptive information about the resource
        /// </summary>
        IList<Interfaces.IDescription> Descriptions { get; }
        /// <summary>
        /// A url for further information about the resource
        /// </summary>
        Uri Url { get; set; }
        /// <summary>
        /// An image that represents the resource, such as a photo or logo
        /// </summary>
        Interfaces.IImage Image { get; set; }
        /// <summary>
        /// When used with the delta update pattern (http://www.xcri.org/wiki/index.php/Delta_update_pattern)
        /// indicates the status of this resource.
        /// </summary>
        ResourceStatus ResourceStatus { get; set; }
    }
}
