using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	/// <summary>
	/// Represents the Qualification element in the XCRI standard
	/// </summary>
	public interface IQualification : IElement, IElementWithIdentifiers
	{

		IList<ITitle> Titles { get; }
        IList<IDescription> Descriptions { get; }
		Uri Url { get; set; }
        Image Image { get; set; }
        IQualificationLevel Level { get; set; }
        IQualificationType Type { get; set; }
        IList<IQualificationAwardedBy> AwardedBy { get; }
        IList<IQualificationAccreditedBy> AccreditedBy { get; }
        /// <summary>
        /// When used with the delta update pattern (http://www.xcri.org/wiki/index.php/Delta_update_pattern)
        /// indicates the status of this resource.
        /// </summary>
        ResourceStatus ResourceStatus { get; set; }

	}

}
