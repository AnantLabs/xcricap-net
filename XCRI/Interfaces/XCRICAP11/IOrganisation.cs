using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces.XCRICAP11
{
    public interface IOrganisation : IGeneric
    {
        Interfaces.ILocation Address { get; set; }
        string PhoneNumber { get; set; }
        string FaxNumber { get; set; }
        string EmailAddress { get; set; }
    }
}
