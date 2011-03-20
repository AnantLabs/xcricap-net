using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
    /// <summary>
    /// Represents the type of location at which the student will undertake the learning opportunity
    /// http://www.xcri.org/wiki/index.php/AttendanceMode.
    /// </summary>
    public interface IAttendanceMode : XCRICAP11.IAttendanceMode, XCRICAP12.IAttendanceMode
    {
    }
}
