using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12.EducationalCredit
{
    public interface ICredit : IElement
    {

        IList<string> Schemes { get; }
        IList<string> Levels { get; }
        IList<string> Values { get; }

    }
}
