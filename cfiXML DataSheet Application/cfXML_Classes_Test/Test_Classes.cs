using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cfiXML_XLS_Handler;
using cfiXML_Model;
using cfiXML_Map_Reader;
using cfiXML_API;
using cfiXML_DataSheetApp;
using System.Reflection;
using System.IO;

namespace cfiXML_Classes_Test
{
    class Test_Classes
    {
        static void Main(string[] args)
        {




//Teste da classe cfiXML_Manager que invoca os métodos que lêem e escrevem no xml. Teste para Revision.
//***************************************************************************************************************************************************************************************************************************            
            //cfiXML_Manager man = new cfiXML_Manager(@"C:\Users\E9JR\Desktop\EXEMPLOS_FUNCIONAIS_CFXML\CPumpAsBuilt_full.xml", @"C:\Users\E9JR\Desktop\EXEMPLOS_FUNCIONAIS_CFXML\Teste_Writer.xml");
            //List<Data_MapInfo> maplist = man.ReadFromXML();

            //List<Revision> revs = man.Read_Revision();
            //foreach (Revision rev in man.Read_Revision())
            //{
            //    Console.WriteLine("> REV ID             = " + rev.ID_Revision);
            //    Console.WriteLine("> REV VERSION        = " + rev.Version);
            //    Console.WriteLine("> REV VERSION INDEX  = " + rev.Version_Index);

            //    foreach (Transaction tran in rev.TransactionSet)
            //    {
            //        Console.WriteLine(Environment.NewLine + "> TRANS ORDER        = " + tran.Transaction_Order.ToString());
            //        Console.WriteLine("> TRANS TYPE         = " + Enum.GetName(tran.Transaction_Type.GetType(),tran.Transaction_Type));
            //        Console.WriteLine("> TRANS OTHER TYPE   = " + tran.Other_Transaction_type);
            //        Console.WriteLine("> TRANS DATE         = " + tran.Transaction_Date.ToString());
            //        Console.WriteLine("> TRANS PERSON       = " + tran.Transaction_Person);
            //        Console.WriteLine("> TRANS REMARK       = " + tran.Transaction_Remark);
            //    }
            //    Console.WriteLine(Environment.NewLine + "###############################################################################################################");
            //    Console.ReadKey();
            //}

            //Console.WriteLine(":>  ESCREVENDO XML UTILIZANDO A CLASSE cfiXML_Manager...");

            //man.WriteToXML(maplist);
            //man.WriteRevision(revs);
            
            //Console.WriteLine("TERMINOU... TESTANDO A CLASSE APPLICATION MANAGER...  PRESSIONE UMA TECLA PARA PROSSEGUIR...");
            //Console.ReadKey();
//***************************************************************************************************************************************************************************************************************************

//Teste da classe que escreve na planilha
//***************************************************************************************************************************************************************************************************************************            
            //IXLS_Handler _xlsHandler = new API610_XLS_Handler();
            //_xlsHandler.OpenWorkBook(@"C:\Users\E9JR\Desktop\EXEMPLOS_FUNCIONAIS_CFXML\API_610_11th_Datasheets.xlsx");
            //IMap_XLS_To_cfiXML _map = new MapAPI610_To_cfiXML();
            //List<Data_MapInfo> mapinfo= _map.Get_XLS_cfi_SingleMapping();

            //_xlsHandler.WriteCell(mapinfo[0]);
            ApplicationManager appMan = new ApplicationManager();

            Console.WriteLine("Testando Ler do XLS e escrever no XML:");
            appMan.ExportToXML(@"C:\Users\e6z5\Desktop\cfiXML DataSheet Application\ArquivosExemplo\API_610_11th_Datasheets_Caue.xlsm", @"C:\Users\e6z5\Desktop\cfiXML DataSheet Application\ArquivosExemplo\TestXML_Caue.xml", "API610_V11");
            //String fileName = Path.GetFileName(@"C:\Users\e9vp\.Nimi Places\Containers\Projetos Visual Studio\cfiXML DataSheet Application\ArquivosExemplo\API_610_11th_Datasheets_Joao.xlsm").ToString();
            //int numPoint = fileName.IndexOf(".");
            //fileName = fileName.Remove(numPoint);
            Console.WriteLine("OK");
            Console.WriteLine("Testando Ler do XML e escrever no XLS:");
            appMan.ImportFromXML(@"C:\Users\e6z5\Desktop\cfiXML DataSheet Application\ArquivosExemplo\API_610_11th_Datasheets_Caue_4.xlsm", @"C:\Users\e6z5\Desktop\cfiXML DataSheet Application\ArquivosExemplo\TestXML_Caue.xml", "API610_V11");
            //Console.WriteLine("OK");

//***************************************************************************************************************************************************************************************************************************

            //cfiXML_Manager man = new cfiXML_Manager();
            //StreamWriter writer = new StreamWriter(@"C:\Users\E9JR\Desktop\ListadeMetodos.txt");
            //int i = 1;
            //foreach (MethodInfo info in typeof(cfiXML_Handler).GetMethods())
            //{
            //    string name = i.ToString() + " - " + info.Name;
            //    if (i < 10)
            //    {
            //        Console.WriteLine(" " + name);
            //        writer.WriteLine(" " + name);
            //    }
            //    else
            //    {
            //        Console.WriteLine(name);
            //        writer.WriteLine(name);
            //    }
            //    i++;
            //}
            //writer.Close();
//***************************************************************************************************************************************************************************************************************************
            Console.WriteLine(Environment.NewLine + "    >  CONTAGEM DE MÉTODOS implementados no componente cfiXML API: " + typeof(cfiXML_Handler).GetMethods().Count().ToString() + Environment.NewLine);
            Console.WriteLine("TERMINOU. Pressione qualquer tecla para terminar o programa.");
          
            
            Console.ReadKey();
        }
    }
}
