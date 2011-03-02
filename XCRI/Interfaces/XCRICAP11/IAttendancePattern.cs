using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP11
{
    /// <summary>
    /// Represents the period of the day and/or frequency during which attendance is required.
    /// http://www.xcri.org/wiki/index.php/AttendancePattern.
    /// </summary>
    public interface IAttendancePattern : IElementWithSingleValue<string>
    {

    }
}
