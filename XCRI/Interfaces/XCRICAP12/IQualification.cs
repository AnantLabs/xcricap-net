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
        string Abbreviation { get; }
        IList<Interfaces.IDescription> Descriptions { get; }
        Interfaces.IEducationLevel EducationLevel { get; set; }
        //IList<Interfaces.IHasPart> HasParts { get; }
        //IList<Interfaces.IIsPartOf> IsPartOf { get; }
        Interfaces.IType Type { get; set; }
        Interfaces.IQualificationAwardedBy AwardedBy { get; set; }
        Interfaces.IQualificationAccreditedBy AccreditedBy { get; set; }

    }
}
