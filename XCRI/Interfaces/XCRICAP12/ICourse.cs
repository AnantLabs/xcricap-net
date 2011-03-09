using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{
    public interface ICourse : ICommonAndCommonDescriptiveElements
    {

        IList<Interfaces.ICourseLevel> Levels { get; }
        IList<Interfaces.IQualification> Qualifications { get; }
        IList<Interfaces.ICredit> Credits { get; }
        IList<Interfaces.IPresentation> Presentations { get; }

    }
}
