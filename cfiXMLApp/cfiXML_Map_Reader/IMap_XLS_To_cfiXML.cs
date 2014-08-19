using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cfiXML_Model;

namespace cfiXML_Map_Reader
{
    public interface IMap_XLS_To_cfiXML
    {
        List<Data_MapInfo> Get_XLS_cfi_SingleMapping();

        List<Data_MapInfo> Get_XLS_cfi_SingleMapping(int OffSet, int TotalNumber);
    }
}
