using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlGeneration
{
    public static class XmlGeneratorFactory
    {
        public static Interfaces.IXmlGenerator GetXmlGenerator(XCRIProfiles profile)
        {
            switch (profile)
            {
                case XCRIProfiles.XCRI_v1_1:
                    return new XCRI.XmlGeneration.XCRICAP11.Generator();
                case XCRIProfiles.XCRI_v1_2:
                    return new XCRI.XmlGeneration.XCRICAP12.Generator();
                default:
                    throw new NotSupportedException("The XCRI profile provided was not supported by the factory object");
            }
        }
    }
}
