using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{
    public interface IQualification : IElement
    {

        IList<Interfaces.IIdentifier> Identifiers { get; }
        IList<Interfaces.ITitle> Titles { get; }
        Interfaces.IAbbreviation Abbreviation { get; set; }
        IList<Interfaces.IDescription> Descriptions { get; }
        Interfaces.IEducationLevel EducationLevel { get; set; }
        //IList<Interfaces.IHasPart> HasParts { get; }
        //IList<Interfaces.IIsPartOf> IsPartOf { get; }
        Interfaces.IQualificationType Type { get; set; }
        IList<Interfaces.IQualificationAwardedBy> AwardedBy { get; }
        IList<Interfaces.IQualificationAccreditedBy> AccreditedBy { get; }

    }
}
