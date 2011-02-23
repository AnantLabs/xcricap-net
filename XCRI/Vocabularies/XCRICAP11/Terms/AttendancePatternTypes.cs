using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Vocabularies.XCRICAP11.Terms
{
    /// <summary>
    /// Represents the suggested terms for the attendance patterns
    /// property as defined within http://www.xcri.org/wiki/index.php/XCRI_Terms_1.1
    /// </summary>
    public enum AttendancePatternTypes
    {
        Unknown,
        Daytime,
        Evening,
        Twilight,
        DayOrBlockRelease,
        Weekend,
        Short,
        Customised,
        StandardDays
    }
}
