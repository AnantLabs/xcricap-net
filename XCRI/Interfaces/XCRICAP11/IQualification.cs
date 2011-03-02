using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP11
{
	/// <summary>
	/// Represents the Qualification element in the XCRI standard
	/// </summary>
    public interface IQualification : IElement, XCRICAP11.IGeneric
	{
        Interfaces.IQualificationLevel Level { get; set; }
        Interfaces.IQualificationType Type { get; set; }
        IList<Interfaces.IQualificationAwardedBy> AwardedBy { get; }
        IList<Interfaces.IQualificationAccreditedBy> AccreditedBy { get; }
	}

}
