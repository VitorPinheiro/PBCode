using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cfiXML_Model;

namespace cfiXML_XLS_Handler
{
    public class TXT_Handler : IXLS_Handler 
    {
        System.IO.StreamWriter _file = null;
        String _outputTxtFile; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WorkBookPath"></param>
        /// <param name="toRead"></param>
        public void OpenWorkBook(string WorkBookPath, Nullable<Boolean> toRead)
        {
            _outputTxtFile = AppDomain.CurrentDomain.BaseDirectory + @"\Output.txt";
            
            if (_file == null)
                _file = new System.IO.StreamWriter(_outputTxtFile);
        }

        public void CloseWorkBook(Nullable<Boolean> toRead)
        {
            if (_file != null)
            {
                _file.Close();
                _file = null;
            }
        }

        public void SaveWorkbook()
        {
            throw new NotImplementedException();
        }





        public List<cfiXML_Model.Revision> GetRevisions()
        {
            throw new NotImplementedException();
        }

        public void SetRevision(List<cfiXML_Model.Revision> Revision_Colection)
        { // Usado para escrita 
            int i = 64;

            foreach (Revision revision in Revision_Colection)
            {
                int j = 32;

                _file.WriteLine("Page1|B64|" + revision.ID_Revision);

                foreach (Transaction transaction in revision.TransactionSet)
                {
                    if (transaction.Transaction_Type == TransactionType.Approved)
                    {
                        //Data se transaction type for "Approved":
                        _file.WriteLine("Page1|E" + i.ToString() + "|" + transaction.Transaction_Date.ToShortDateString());
                        _file.WriteLine("Page1|" + ConvertNumberToExcelLetter(j) + "69|" + Enum.GetName(typeof(TransactionType), transaction.Transaction_Type));
                        _file.WriteLine("Page1|" + ConvertNumberToExcelLetter(j) + "" + i + "|" + transaction.Transaction_Person);

                        j = j + 2;
                    }
                    else if (transaction.Transaction_Type == TransactionType.Modified)
                    {
                        //Person se transaction type for "Modified", que é igual a "By" na API610:
                        _file.WriteLine("Page1|AB" + i + "|" + transaction.Transaction_Person);
                        _file.WriteLine("Page1|K" + i + "|" + transaction.Transaction_Remark);
                    }
                    else if (transaction.Transaction_Type == TransactionType.Checked)
                    {
                        //Person ser transaction type for "Checked":
                        _file.WriteLine("Page1|AD" + i + "|" + transaction.Transaction_Person);
                    }
                    else if (transaction.Transaction_Type == TransactionType.Custom)
                    {
                        _file.WriteLine("Page1|" + ConvertNumberToExcelLetter(j) + "69|" + transaction.Other_Transaction_type);
                        _file.WriteLine("Page1|" + ConvertNumberToExcelLetter(j) + "" + i + "|" + transaction.Transaction_Person);

                        j = j + 2;
                    }
                    else
                    {
                        _file.WriteLine("Page1|" + ConvertNumberToExcelLetter(j) + "69|" + Enum.GetName(typeof(TransactionType), transaction.Transaction_Type));
                        _file.WriteLine("Page1|" + ConvertNumberToExcelLetter(j) + "" + i + "|" + transaction.Transaction_Person);
                        
                        j = j + 2;
                    }
                }
                i++;
            }
        }

        

        public cfiXML_Model.Data_MapInfo ReadCell(cfiXML_Model.Data_MapInfo Cell)
        {
            throw new NotImplementedException();
        }

        public List<cfiXML_Model.Data_MapInfo> ReadGroupOfCells(List<cfiXML_Model.Data_MapInfo> ListOfCells)
        {
            throw new NotImplementedException();
        }

        public void WriteCell(cfiXML_Model.Data_MapInfo Cell)
        {
            XlsInfo xlsInfo = (XlsInfo)Cell.GetGenericInfo();

            _file.WriteLine("" + xlsInfo.GetSheetName() + "|" + xlsInfo.GetCell() + "|" + Cell.GetValue());
        }

        public void WriteGroupOfCells(List<cfiXML_Model.Data_MapInfo> ListOfCells)
        { // Esse
            foreach (Data_MapInfo cell in ListOfCells)
            {
                WriteCell(cell);
            }
        }

        /// <summary>
        /// Converte um numero de coluna excel para sua letra correspondente.
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        private String ConvertNumberToExcelLetter(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
    }
}
