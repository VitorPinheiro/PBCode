using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cfiXML_Model
{
    public enum XLS_Model
    {
        /// <summary>
        /// Um arquivo excel que está no padrão API610 versão 11 http://locator.gouldspumps.com/API610.html .
        /// </summary>
        API610_V11,

        /// <summary>
        /// Um arquivo txt que contém valores associados a células correspondentes as posições de uma planilha API610.
        /// Este TXT descreve cada valor que cada célula da planilha API610 deve conter.
        /// </summary>
        API610_V11_TXT_File
    }
}
