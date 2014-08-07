using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cfiXML_DataSheetApp;
using System.IO;
using cfiXML_Model;

namespace cfiXML_ExeForExcel
{
    class Program
    {
        /// <summary>
        /// XLS -> XML
        ///     Primeiro argumento será o modo XLS_TO_cfiXML
        ///     Segundo argumento será o path do excel
        ///     Terceiro argumento será o path do XML (pode ser null), se for null ele vai criar o XML na mesma pasta do executável e com o mesmo nome do arquivo excel
        /// 
        /// XML -> XLS
        ///     Primeiro argumento será o modo cfiXML_TO_XLS
        ///     Segundo argumento será o path do excel
        ///     Terceiro argumento será o path do XML
        ///     
        /// </summary>
        /// <param name="args"></param>
        /// <returns> 1 se ocorreu algum erro ou 0 caso contrário. </returns>
        static int Main(string[] args)
        {
            if (args[0] == null || args[1] == null)
                return 1; // Erro

            ApplicationManager appMan;

            //Console.WriteLine("ProgramMode.XLS_TO_cfiXML = " + ProgramMode.XLS_TO_cfiXML.ToString());

            // on\ArquivosExemplo\API_610_11th_Datasheets_Vitor.xlsm" 

            // Modo leitura do XLS e escrita no XML            
            if (args[0].ToString().Equals(ProgramMode.XLS_TO_cfiXML.ToString()))
            {
                String xmlPath = "";

                if (args.Length <= 2)
                {
                    // Preparando nome caminho do arquivo XML
                    String fileName = Path.GetFileName(args[1]).ToString();
                    int numPoint = fileName.IndexOf(".");
                    fileName = fileName.Remove(numPoint);
                    xmlPath = AppDomain.CurrentDomain.BaseDirectory + fileName + @".xml";
                }
                else
                    xmlPath = args[2];

                // Executando exportação XLS para XML
                appMan = new ApplicationManager();
                appMan.ExportToXML(args[1], xmlPath, XLS_Model.API610_V11.ToString());
            }

            // Modo leitura do XML e escrita no XLS
            else if (args[0].ToString().Equals(ProgramMode.cfiXML_TO_XLS.ToString()))
            {
                appMan = new ApplicationManager();

                String executionMode = XLS_Model.API610_V11_TXT_File.ToString();

                // Executando a importação do XML para o XLS
                appMan.ImportFromXML(args[1], args[2], executionMode);

                if (executionMode.Equals(XLS_Model.API610_V11_TXT_File.ToString()))
                {
                    // Cria um arquivo que não contém nada só para avisar ao Excel que chamou este executável que a saída txt já está pronta para ser lida
                    System.IO.StreamWriter _fileTemp = null;
                    String _outputTempTxtFile; 
                    _outputTempTxtFile = AppDomain.CurrentDomain.BaseDirectory + @"\OutputDone.txt";

                    if (_fileTemp == null)
                        _fileTemp = new System.IO.StreamWriter(_outputTempTxtFile);

                    if (_fileTemp != null)
                    {
                        _fileTemp.Close();
                        _fileTemp = null;
                    }
                }
            }



            

            return 0;
        }


        enum ProgramMode
        {
            XLS_TO_cfiXML,
            cfiXML_TO_XLS
        }

    }
}
