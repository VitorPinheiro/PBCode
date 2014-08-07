using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cfiXML_Model;

namespace cfiXML_XLS_Handler
{
    /// <summary>
    /// Interface que lê e grava dados em uma folha de dados no formato de planilha eletrônica MS Excel.
    /// </summary>
    public interface IXLS_Handler
    {
        /// <summary>
        /// Abre uma folha de dados em formato .xls, .xlsx ou .xlsm do MS Excel 
        /// </summary>
        /// <param name="SheetPath">Caminho completo da planilha eletrônica MS Excel.</param>
        /// <param name="toRead">Se true, a conecção será aberta para leitura, se false será aberta para escrita e se for null a conecção será aberta de uma forma padrão para leitura e escrita.</param>
        void OpenWorkBook(String WorkBookPath, Nullable<Boolean> toRead);

        /// <summary>
        /// Fecha a folha de dados em formato MSExcel.
        /// </summary>
        void CloseWorkBook(Nullable<Boolean> toRead);

        void SaveWorkbook();

        /// <summary>
        /// Retorna uma coleção de revisões de contidas na folha de dados em formato de planilha eletrônica MS Excel.
        /// </summary>
        List<Revision> GetRevisions();

        /// <summary>
        /// Imprime um objeto revision na folha de dados em formato MS Excel.
        /// </summary>
        void SetRevision(List<Revision> Revision_Colection);

        Data_MapInfo ReadCell(Data_MapInfo Cell);

        List<Data_MapInfo> ReadGroupOfCells(List<Data_MapInfo> ListOfCells);

        void WriteCell(Data_MapInfo Cell);

        void WriteGroupOfCells(List<Data_MapInfo> ListOfCells);
    }
}
