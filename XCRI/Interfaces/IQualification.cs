using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	/// <summary>
	/// Represents the Qualification element in the XCRI standard
	/// </summary>
	public interface IQualification : IXmlElement, IXmlElementWithIdentifiers
	{

		IList<ITitle> Titles { get; }
        IList<IDescription> Descriptions { get; }
		Uri Url { get; set; }
        Image Image { get; set; }
        IQualificationLevel Level { get; set; }
        IQualificationType Type { get; set; }
        IList<IQualificationAwardedBy> AwardedBy { get; }
        IList<IQualificationAccreditedBy> AccreditedBy { get; }

	}

    public interface IQualificationLevel : IXmlElementWithSingleValue<string>
    {
    }

    public interface IQualificationType : IXmlElementWithSingleValue<string>
    {
    }

    public interface IQualificationAwardedBy : IXmlElementWithSingleValue<string>
    {
    }

    public interface IQualificationAccreditedBy : IXmlElementWithSingleValue<string>
    {
    }

}
