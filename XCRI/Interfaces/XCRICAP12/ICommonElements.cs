using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP12
{
    public interface ICommonElements : IElement
    {

        //IList<Interfaces.IHasPart> HasParts { get; }
        IList<Interfaces.IContributor> Contributors { get; }
        //IList<Interfaces.IDate> Dates { get; }
        IList<Interfaces.IDescription> Descriptions { get; }
        IList<Interfaces.IIdentifier> Identifiers { get; }
        Interfaces.IImage Image { get; set; }
        IList<Interfaces.ISubject> Subjects { get; }
        IList<Interfaces.ITitle> Titles { get; }
        IList<Interfaces.IType> Types { get; }
        Uri Url { get; set; }

    }
}
