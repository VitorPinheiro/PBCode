using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cfiXML_API
{
    class Utils
    {
        public static String processEnumValue(String enumValue)
        {
            return enumValue.Substring(1);
        }
    }
}
