using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
    /// <summary>
    /// Only used with the delta update pattern (not currently supported).
    /// Should be set to ResourceStatus.Unknown to ensure not output
    /// </summary>
    public enum ResourceStatus
    {
        Unknown = 0,
        Added = 1,
        Deleted = 2
    }
}
