using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{
    public interface IAttendanceMode : IElementWithSingleValue<AttendanceModes>
    {
    }
    public enum AttendanceModes
    {
        Campus = 1,
        DistanceWithAttendance = 2,
        DistanceWithoutAttendance = 3,
        WorkBased = 4,
        MixedMode = 5
    }
}
