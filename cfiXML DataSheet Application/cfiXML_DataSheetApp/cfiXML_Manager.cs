using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using cfiXML_Map_Reader;
using cfiXML_Model;
using cfiXML_API;

using System.Windows.Forms;

namespace cfiXML_DataSheetApp
{
    public class cfiXML_Manager
    {
        private cfiXML_Handler _cfiXML_Handler;

        private Boolean xmlIsLoadedToRead = false;
        private Boolean xmlIsLoadedToWrite = false;

        public cfiXML_Manager()
        {
            _cfiXML_Handler = new cfiXML_Handler();
        }

        public void WriteToXML(string xmlPath_Write, List<Data_MapInfo> MapData, List<Revision> RevisionList)
        {
            if (!xmlIsLoadedToWrite)
            {
                CreateXML_to_Write(xmlPath_Write);
            }

            try
            {
                WriteRevision(RevisionList);
                foreach (Data_MapInfo _map in MapData)
                {
                    MethodInfo cfiMethod = typeof(cfiXML_Handler).GetMethod(_map.Get_cfiXML_Info().GetMethodName() + "_Writer");

                    if (cfiMethod == null)
                    {
                        /* 
                            Enquanto todos os métodos para escrita e leitura do cfiXML API não estiverem implementados, este if vai existir. 
                         */
                        continue;
                    }

                    cfiMethod.Invoke(_cfiXML_Handler, new object[] { _map.GetValue() });
                  //  _cfiXML_Handler.SaveToFile();
                }
            }
            finally
            {
                _cfiXML_Handler.SaveToFile();
            }
        }

        private void WriteRevision(List<Revision> _revisionList)
        {
            _cfiXML_Handler.RevisionID_Writer(_revisionList[_revisionList.Count-1].ID_Revision);
            foreach (Revision _revision in _revisionList)
            {
                foreach (Transaction _transaction in _revision.TransactionSet)
                {
                    _cfiXML_Handler.TransactionDateTime_Writer(_transaction.Transaction_Date, _revision.ID_Revision, Enum.GetName(typeof(TransactionType), _transaction.Transaction_Type));
                    _cfiXML_Handler.TransactionPerson_Writer(_transaction.Transaction_Person, _revision.ID_Revision, Enum.GetName(typeof(TransactionType), _transaction.Transaction_Type));
                    _cfiXML_Handler.TransactionRemark_Writer(_transaction.Transaction_Remark, _revision.ID_Revision, Enum.GetName(typeof(TransactionType), _transaction.Transaction_Type));
                }
            }
            //_cfiXML_Handler.SaveToFile();
        }

        public List<Data_MapInfo> ReadFromXML(string xmlPath_Read)
        {
            IMap_XLS_To_cfiXML _mapAPI = new MapAPI610_To_cfiXML();
            List<Data_MapInfo> _maplist = _mapAPI.Get_XLS_cfi_SingleMapping();

            List<Data_MapInfo> _result_maplist = new List<Data_MapInfo>();

            if (!xmlIsLoadedToRead)
            {
                SelectXML_to_Read(xmlPath_Read);
            }

            foreach(Data_MapInfo _map in _maplist)
            
            {
                try
                {
                    object _result = typeof(cfiXML_Handler).GetMethod(_map.Get_cfiXML_Info().GetMethodName() + "_Reader").Invoke(_cfiXML_Handler, null);

                    if (!_result.Equals(null) || !_result.Equals(String.Empty))
                    {
                        _map.SetValue(_result.ToString());
                        _result_maplist.Add(_map);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return _result_maplist;
        }

        private void CreateXML_to_Write(String xmlPath)
        {
            _cfiXML_Handler.CreateXML_to_Write(xmlPath);
            xmlIsLoadedToWrite = true;
        }

        private void SelectXML_to_Read(String xmlPath)
        {
            _cfiXML_Handler.SelectXML_to_Read(xmlPath);
            xmlIsLoadedToRead = true;
        }

        public List<Revision> Read_Revision(string xmlPath_Read)
        {
            if (!xmlIsLoadedToRead)
            {
                SelectXML_to_Read(xmlPath_Read);
            }

            List<Revision> _revisionset = new List<Revision>();
            
            foreach (string revision in _cfiXML_Handler.RevisionID_All_Reader())
            {
                int _order = 1;
                List<Transaction> _transactions = new List<Transaction>();
                foreach(string _trans_type in _cfiXML_Handler.TransactionTypes_Reader(revision))                  
                {
                    _transactions.Add(new Transaction(_order,
                                                      _cfiXML_Handler.TransactionDateTime_Reader(revision, _trans_type),
                                                      _cfiXML_Handler.TransactionPerson_Reader(revision, _trans_type),
                                                      _trans_type,
                                                      _cfiXML_Handler.TransactionRemark_Reader(revision, _trans_type)));
                    _order++;
                }
                _revisionset.Add(new Revision(revision,String.Empty,String.Empty,_transactions));
            }
            return _revisionset;
        }

    }
}
