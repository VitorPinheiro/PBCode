using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MSExcel = Microsoft.Office.Interop.Excel;
using cfiXML_Model;

namespace cfiXML_XLS_Handler
{
    public class API610_XLS_Handler:IXLS_Handler 
    {
        private MSExcel.Application _msExcelApp;

        private MSExcel.Workbook _msExcelWb;

        private MSExcel.Worksheet _API_Pages;

        
        
        /// <summary>
        /// Abre uma folha de dados em formato .xls, .xlsx ou .xlsm do MS Excel 
        /// </summary>
        /// <param name="SheetPath">Caminho completo da planilha eletrônica MS Excel.</param>
        /// <param name="toRead">Deverá ser true se a planilha for aberta para leitura, false se for aberta para escrita ou null se for aberta tanto para leitura quanto escrita.</param>
        public void OpenWorkBook(String WorkBookPath, Nullable<Boolean> toRead)
        {

            if (toRead == null)
                throw new Exception("API610_XLS_Handler:OpenWorkBook) É preciso especificar se o Workbook deve ser aberto para leitura ou para escrita.");

            try
            {
                StartExcelApplication(toRead);
                
                //VITOR // msExcelApp = (MSExcel.Application)Marshal.GetActiveObject("Excel.Application");

                if (toRead == true)
                {
                    // Para leitura
                    _msExcelWb = _msExcelApp.Workbooks.Open(WorkBookPath, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, false, false, false, false, false);
                }
                else
                {
                    // Para escrita
                    _msExcelWb = _msExcelApp.Workbooks.Open(WorkBookPath, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing, true, false, false, false, false, false);
                }

                _API_Pages = _msExcelWb.Worksheets["Page1"];
            }
            catch
            {
                _msExcelApp.Quit();
            }
        }

        /// <summary>
        /// Fecha a folha de dados API610 em formato MSExcel.
        /// </summary>
        public void CloseWorkBook(Nullable<Boolean> toRead)
        {
            if (toRead == true)
            {
                _msExcelWb.Close(false, Type.Missing, false);
            }
            else
            {
                _msExcelWb.Close(true, Type.Missing, false);
            }
            
            if (_msExcelApp.Workbooks.Count == 0)
            {
                _msExcelApp.Quit();
            }
        }

        public void SaveWorkbook()
        {
            _msExcelWb.Save();
        }

        /// <summary>
        /// Retorna uma coleção de revisões de contidas na folha de dados API610 em formato de planilha eletrônica MS Excel.
        /// </summary>
        public List<Revision> GetRevisions()
        {
            List<Revision> revision = new List<Revision>();
            List<Transaction> transaction;
            
            int i = 64;   

            for (i=64; i < 69; i++)
            {
                if (String.IsNullOrEmpty(_API_Pages.Range["B" + i.ToString()].Value) || String.IsNullOrWhiteSpace(_API_Pages.Range["B" + i.ToString()].Value))
                    continue;
                transaction = new List<Transaction>();
                MSExcel.Range transactionPerson = _API_Pages.Range["AB" + i.ToString()];
                MSExcel.Range transactionTitle = _API_Pages.Range["AB69"];

                for (int j = 1; j< 6; j++)
                {
                    if (!String.IsNullOrEmpty(transactionTitle.Value))
                    {
                        //Para datas que retornam null quando lidas da planilha, considera-se o valor default do tipo DateTime.
                        if (_API_Pages.Range["E" + i].Value == null)
                        {
                            transaction.Add(new Transaction(j,default(DateTime), transactionPerson.Value, GetTransactionType(transactionTitle), GetTransactionDescription(transactionTitle, _API_Pages.Range["K" + i.ToString()])));
                        }
                        else
                        {
                            transaction.Add(new Transaction(j,DateTime.Parse(_API_Pages.Range["E" + i].Value.ToString().Replace('/', '-')), transactionPerson.Value, GetTransactionType(transactionTitle), GetTransactionDescription(transactionTitle, _API_Pages.Range["K" + i.ToString()])));
                        }
                    }
                    transactionPerson = transactionPerson.Next[1,2];
                    transactionTitle = transactionTitle.Next[1,2];
                }
                revision.Add(new Revision(_API_Pages.Range["B" + i.ToString()].Value, String.Empty, String.Empty, transaction));
            }
            return revision;
        }


        /// <summary>
        /// Imprime um objeto revision na folha de dados em formato MS Excel. 
        /// </summary>
        /// <param name="revision">Objeto que contém uma revisão da folha de dados.</param>
        public void SetRevision(List<Revision> Revision_Colection)
        {
            int i = 64;
            
            foreach (Revision revision in Revision_Colection)
            {
                int j = 32;
                _API_Pages.Range["B" + i.ToString()].Value = revision.ID_Revision;
                foreach (Transaction transaction in revision.TransactionSet)
                {
                    if (transaction.Transaction_Type== TransactionType.Approved)
                    {
                        //Data se transaction type for "Approved":
                        _API_Pages.Range["E" + i.ToString()].Value = transaction.Transaction_Date.ToShortDateString();
                        _API_Pages.Cells[69, j].Value = Enum.GetName(typeof(TransactionType), transaction.Transaction_Type);
                        _API_Pages.Cells[i, j].Value = transaction.Transaction_Person;
                        j=j+2;
                    }
                    else if (transaction.Transaction_Type == TransactionType.Modified)
                    {
                        //Person se transaction type for "Modified", que é igual a "By" na API610:
                        _API_Pages.Range["AB" + i.ToString()].Value = transaction.Transaction_Person;
                        _API_Pages.Range["K" + i.ToString()].Value = transaction.Transaction_Remark;
                    }
                    else if (transaction.Transaction_Type == TransactionType.Checked)
                    {
                        //Person ser transaction type for "Checked":
                        _API_Pages.Range["AD" + i.ToString()].Value = transaction.Transaction_Person;
                    }
                    else if (transaction.Transaction_Type == TransactionType.Custom)
                    {
                        _API_Pages.Cells[69, j].Value = transaction.Other_Transaction_type;
                        _API_Pages.Cells[i, j].Value = transaction.Transaction_Person;
                        j=j+2;
                    }
                    else
                    {
                        _API_Pages.Cells[69, j].Value = Enum.GetName(typeof(TransactionType), transaction.Transaction_Type);
                        _API_Pages.Cells[i, j].Value = transaction.Transaction_Person;
                        j = j + 2;
                    }
                }
                i++;
            }
        }


        public Data_MapInfo ReadCell(Data_MapInfo Cell)
        {
            Data_MapInfo readedcell = Cell;
            if (Cell.GetGenericInfo().GetType() != typeof(XlsInfo))
            {
                throw new Exception("API610_XLS_Handler: A classe relacionada ao GenericInfo não é a XlsInfo");
            }
            XlsInfo xlsInfo = (XlsInfo) Cell.GetGenericInfo();

            if (_msExcelWb.Worksheets[xlsInfo.GetSheetName()].Range[xlsInfo.GetCell()].Value==null)
            {
                readedcell.SetValue(String.Empty);
                return readedcell;
            }
            else
            {
                readedcell.SetValue(_msExcelWb.Worksheets[xlsInfo.GetSheetName()].Range[xlsInfo.GetCell()].Value.ToString());
                return readedcell;
            }            
        }

        public List<Data_MapInfo> ReadGroupOfCells(List<Data_MapInfo> ListOfCells)
        {
            List<Data_MapInfo> list_readed_cells = new List<Data_MapInfo>();
            foreach (Data_MapInfo cell in ListOfCells)
            {
                list_readed_cells.Add(ReadCell(cell));
            }
            return list_readed_cells;
        }

        public void WriteCell(Data_MapInfo Cell)
        {
            XlsInfo xlsInfo = (XlsInfo)Cell.GetGenericInfo();
            _msExcelWb.Worksheets[xlsInfo.GetSheetName()].Range[xlsInfo.GetCell()].Value = Cell.GetValue();
        }

        public void WriteGroupOfCells(List<Data_MapInfo> ListOfCells)
        {
            foreach (Data_MapInfo cell in ListOfCells)
            {
                WriteCell(cell);
            }
        }


        private void StartExcelApplication(Nullable<Boolean> toRead)
        {
            if (toRead == null)
                throw new Exception("API610_XLS_Handler:StartExcelApplication) É preciso especificar se o Workbook deve ser aberto para leitura ou para escrita.");

            if (toRead == true)
            {
                // Para leitura sempre instanciar um novo processo.
                _msExcelApp = new MSExcel.Application();
            }
            else
            {
                if (Process.GetProcessesByName("EXCEL").Length > 0)
                {
                    _msExcelApp = (MSExcel.Application)Marshal.GetActiveObject("Excel.Application");
                }
                else
                {
                    _msExcelApp = new MSExcel.Application();
                }
            }
        }

        private String GetTransactionType(MSExcel.Range cell)
        {
            foreach (String types in Enum.GetNames(typeof(TransactionType)))
            {
                if (String.Equals(cell.Value, types.Replace("_", " ")))
                {
                    return types;
                }
            }
            if (String.Equals(cell.Value, String.Empty))
            {
                return Enum.GetName(typeof(TransactionType), TransactionType.Nil);
            }
            if (String.Equals(cell.Value, "By"))
            {
                return Enum.GetName(typeof(TransactionType), TransactionType.Modified);
            }
            else
            {
                return cell.Value;
            }
        }

        private String GetTransactionDescription(MSExcel.Range trans_type, MSExcel.Range trans_description)
        {
            if (String.Equals(GetTransactionType(trans_type), "Modified"))
            {
                return trans_description.Value;
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
