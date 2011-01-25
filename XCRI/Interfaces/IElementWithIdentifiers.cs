using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
    public interface IElementWithIdentifiers
    {
        IEnumerable<Identifier> Identifiers { get; }
    }
}
