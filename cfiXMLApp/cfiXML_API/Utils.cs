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

        public static Nullable<Boolean> processYesOrNo(String boolean)
        {
            if (String.IsNullOrEmpty(boolean))
            {
                return null;
            }
            else if (boolean.Equals("Yes"))
            {
                return true;
            }
            else if (boolean.Equals("No"))
            {
                return false;
            }
            else
            {
                throw new Exception("valor de boolean não disponível ('Yes' ou 'No')");
            }
        }
    }
}
