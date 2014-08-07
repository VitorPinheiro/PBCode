using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cfiXML_Model
{
    /// <summary>
    /// Objeto que representa as informações relativas ao mapeamento da uma planilha eletrônica MS Excel.
    /// </summary>
    public class XlsInfo:GenericInfo
    {
        private string _sheet;

        private string _cell;

        /// <summary>
        /// Atribiu o nome da planilha referente ao objeto XlsInfo.
        /// </summary>
        /// <param name="sheetName">Nome da planilha("sheet").</param>
        public void SetSheetName(string sheetName)
        {
            _sheet = sheetName;
        }

        /// <summary>
        /// Retorna o nome da planilha do mapeamento.
        /// </summary>
        /// <returns>Nome da Panilha ("sheet").</returns>
        public string GetSheetName()
        {
            return _sheet;
        }

        /// <summary>
        /// Atribui o número da linha. Recebe um inteiro e o transforma em caracter.
        /// </summary>
        /// <param name="row">número da linha.</param>
        public void SetCell(string cell)
        {
            _cell = cell.ToString();
        }

        /// <summary>
        /// Retorna a célula referente ao mapeamento.
        /// </summary>
        /// <returns>Célula do mapeamento.</returns>
        public string GetCell()
        {
            return _cell;
        }
    }
}
