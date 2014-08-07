using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cfiXML_XLS_Handler;
using cfiXML_Model;
using cfiXML_Map_Reader;

namespace cfiXML_DataSheetApp
{
    public class ApplicationManager
    {
        private string _worksheetPath;

        private cfiXML_Manager _cfiXML_Manager;

        private XLS_Model _xlsModelToUse;

        private IMap_XLS_To_cfiXML _mapAPI610_to_cfiXML;

        private IXLS_Handler _xlsHandler;

        /// <summary>
        /// Construtor
        /// </summary>
        public ApplicationManager()
        {
            _cfiXML_Manager = new cfiXML_Manager();
        }

        private void SelectOutput_Type(string outputType)
        {
            if (String.Equals(outputType, Enum.GetName(typeof(XLS_Model), XLS_Model.API610_V11)))
            {
                _xlsHandler = new API610_XLS_Handler();
                _mapAPI610_to_cfiXML = new MapAPI610_To_cfiXML();
                
            }
            else if (String.Equals(outputType, Enum.GetName(typeof(XLS_Model), XLS_Model.API610_V11_TXT_File)))
            {
                _xlsHandler = new TXT_Handler();
                _mapAPI610_to_cfiXML = new MapAPI610_To_cfiXML();
            }

        }

        public void ImportFromXML(string blankFilePath, string xmlPath, string blankFileModel)
        {  
            SelectOutput_Type(blankFileModel);
            _xlsHandler.OpenWorkBook(blankFilePath, false);

            _xlsHandler.WriteGroupOfCells(_cfiXML_Manager.ReadFromXML(xmlPath));
            _xlsHandler.SetRevision(_cfiXML_Manager.Read_Revision(xmlPath));
            
            _xlsHandler.CloseWorkBook(false);
        }

        public void ExportToXML(string inputFilePath,string xmlPath, string inputModel)
        {
            SelectOutput_Type(inputModel);
            _xlsHandler.OpenWorkBook(inputFilePath, true);
            
            _cfiXML_Manager.WriteToXML(xmlPath, _xlsHandler.ReadGroupOfCells(_mapAPI610_to_cfiXML.Get_XLS_cfi_SingleMapping()), _xlsHandler.GetRevisions());

            _xlsHandler.CloseWorkBook(true);
        }

    }
}
