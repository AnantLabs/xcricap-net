using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{
    public interface IAttendanceMode : IElementWithSingleValue<string>
    {
    }
    public enum AttendanceModes
    {
        Campus = 1,
        DistanceWithAttendance = 2,
        DistanceWithoutAttendance = 3,
        FaceToFaceNonCampus = 4,
        WorkBased = 5,
        MixedMode = 6,
        OnlineWithoutAttendance = 7
    }
}
