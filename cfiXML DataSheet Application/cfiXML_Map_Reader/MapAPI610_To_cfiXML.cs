using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using cfiXML_Model;


namespace cfiXML_Map_Reader
{
    /// <summary>
    /// Classe que contém o mapeamento da folha de dados e planilha eletrônica MS Excel da API610 e o xml no formato cfi.
    /// </summary>
    public class MapAPI610_To_cfiXML:IMap_XLS_To_cfiXML
    {
        
        private StreamReader _reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(Assembly.GetExecutingAssembly().GetManifestResourceNames()[0]));

        private List<string> _aex_name = new List<string>();
        private List<string> _page = new List<string>();
        private List<string> _cell = new List<string>();
        private List<string> _isenum = new List<string>();
        private int lines;
        private void LoadReader()
        {
            lines = 0;
            _reader.ReadLine();
            while (!_reader.EndOfStream)
            {
                string[] line = _reader.ReadLine().Split(';');
                _aex_name.Add(line[0]);
                _page.Add(line[1]);
                _cell.Add(line[2]);
                _isenum.Add(line[3]);
                lines++;
            }
        }

        public List<Data_MapInfo> Get_XLS_cfi_SingleMapping()
        {
            LoadReader();
            List<Data_MapInfo> maplist = new List<Data_MapInfo>();
            
            Data_MapInfo map;
            cfiXML_Info cfiXML_info;
            XlsInfo xlsinfo;

            for (int i = 0; i < lines; i++)
            {
                xlsinfo = new XlsInfo();
                cfiXML_info = new cfiXML_Info(_aex_name[i]);
                if (_isenum[i] == "not_enum")
                {
                    map = new SimpleData_MapInfo();

                    xlsinfo.SetSheetName(_page[i]);
                    xlsinfo.SetCell(_cell[i]);
                }

                //Aguardando definição do como serão atribuidos os valores dos mapeamentos dos enumarations
                else
                {
                    map = new MultiData_MapInfo();

                    xlsinfo.SetSheetName(_page[i]);
                    xlsinfo.SetCell(_cell[i]);
                    // mais métodos sobre  o mapeamento incluindo os enumerations
                    //...
                    //...
                    // mais métodos sobre  o mapeamento incluindo os enumerations
                }
                map.Set_cfiXML_Info(cfiXML_info);
                map.Set_GenericInfo(xlsinfo);
                
                maplist.Add(map);
            }
            return maplist;
        }


        public List<Data_MapInfo> Get_XLS_cfi_SingleMapping(int OffSet, int TotalNumber)
        {
            if (OffSet < 0 || TotalNumber < 0) return null;
            LoadReader();
            List<Data_MapInfo> maplist = new List<Data_MapInfo>();
            Data_MapInfo map;
            cfiXML_Info cfiXML_info;
            XlsInfo xlsinfo;

            int offsetlimit = OffSet + TotalNumber;

            if (offsetlimit > lines) offsetlimit = lines;

            for (int i = OffSet; i < offsetlimit; i++)
            {
                xlsinfo = new XlsInfo();
                cfiXML_info = new cfiXML_Info(_aex_name[i]);
                if (_isenum[i] == "not_enum")
                {
                    map = new SimpleData_MapInfo();

                    xlsinfo.SetSheetName(_page[i]);
                    xlsinfo.SetCell(_cell[i]);
                }

                else
                {//Aguardando definição do como serão atribuidos os valores dos mapeamentos dos enumarations
                    map = new MultiData_MapInfo();

                    xlsinfo.SetSheetName(_page[i]);
                    xlsinfo.SetCell(_cell[i]);
                    // mais métodos sobre  o mapeamento incluindo os enumerations
                    //...
                    //...
                    // mais métodos sobre  o mapeamento incluindo os enumerations
                }
                map.Set_cfiXML_Info(cfiXML_info);
                map.Set_GenericInfo(xlsinfo);

                maplist.Add(map);
            }
            return maplist;
        }
    }
}
