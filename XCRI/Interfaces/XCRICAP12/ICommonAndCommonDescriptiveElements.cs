using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{
    public interface ICommonAndCommonDescriptiveElements : ICommonElements
    {

        IList<Interfaces.IAbstract> Abstracts { get; }
        IList<Interfaces.IApplicationProcedure> ApplicationProcedures { get; }
        IList<Interfaces.IAssessment> Assessments { get; }
        IList<Interfaces.ILearningOutcome> LearningOutcomes { get; }
        IList<Interfaces.IObjective> Objectives { get; }
        IList<Interfaces.IPrerequisite> Prerequisites { get; }
        IList<Interfaces.IRegulations> Regulations { get; }

    }
}
