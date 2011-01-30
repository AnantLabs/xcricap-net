using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
    public interface ICatalog
    {

        DateTime? Generated { get; set; }
        ResourceStatus RecStatus { get; set; }
        IList<IIdentifier> Identifiers { get; }
        IList<ITitle> Titles { get; }
        IList<ISubject> Subjects { get; }
        IList<IDescription> Descriptions { get; }
        Uri Url { get; }
        Image Image { get; }
        IList<IProvider> Providers { get; }

    }
}
