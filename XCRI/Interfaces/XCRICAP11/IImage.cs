using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP11
{
    public interface IImage : IElement
    {
        Uri Source { get; set; }
        string Title { get; set; }
        string Alt { get; set; }
    }
}
