using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{
    public interface IStudyMode : IElementWithSingleValue<string>
    {
    }
    public enum StudyModes
    {
        NotKnown = 0,
        Flexible = 1,
        FullTime = 2,
        PartOfAFullTimeProgramme = 3,
        PartTime = 4
    }
}
