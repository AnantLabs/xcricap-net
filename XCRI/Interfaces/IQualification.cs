using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
    public interface IQualification : XCRICAP11.IQualification, XCRICAP12.IQualification
    {
        new IList<Interfaces.IIdentifier> Identifiers { get; }
        new IList<Interfaces.ITitle> Titles { get; }
        new IList<Interfaces.ISubject> Subjects { get; }
        new IList<Interfaces.IDescription> Descriptions { get; }
        new Uri Url { get; set; }
        new Interfaces.IImage Image { get; set; }
        new Interfaces.IQualificationLevel Level { get; set; }
        new Interfaces.IQualificationType Type { get; set; }
        new IList<Interfaces.IQualificationAwardedBy> AwardedBy { get; }
        new IList<Interfaces.IQualificationAccreditedBy> AccreditedBy { get; }
    }

}
