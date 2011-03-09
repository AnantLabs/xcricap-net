using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{
    public interface IAttendancePattern : IElementWithSingleValue<AttendancePatterns>
    {
    }
    public enum AttendancePatterns
    {
        Daytime = 1,
        Evening = 2,
        Twilight = 3,
        DayOrBlockRelease = 4,
        Weekend = 5,
        Short = 6,
        Customised = 7,
        StandardDays = 8
    }
}
