using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cfiXML_Model
{

    /// <summary>
    /// Objeto que contém o endereço das células da planilha eletrônica MS Excel.
    /// </summary>
    public abstract class Data_MapInfo
    {
        private string _value;

        private GenericInfo _genericinfo;

        private cfiXML_Info _cfiXML_Info;        

        /// <summary>
        /// Retorna o valor contido na célula referenciada no objeto Data_MapInfo.
        /// </summary>
        /// <returns>Valor da célula da planilha MS Excel</returns>
        public string GetValue()
        {
            return _value;
        }

        /// <summary>
        /// Atribui o valor da célula representada pelo objeto Data_MapInfo.
        /// </summary>
        /// <param name="Value">Valor alocado na célula MS Excel.</param>
        public void SetValue(string Value)
        {
            _value = Value;
        }

        /// <summary>
        /// Atribui o objeto cfiXML_Info.
        /// </summary>
        /// <param name="cfiXML_info">Objeto que contém o nome do método AEX que lê e escreve no xml formato cfi.</param>
        public void Set_cfiXML_Info(cfiXML_Info cfiXML_info)
        {
            _cfiXML_Info = cfiXML_info;
        }

        /// <summary>
        /// Retorna o objeto cfiXML_Info.
        /// </summary>
        /// <returns>Retorna o objeto cfiXML que contem o valor do método AEX que lê e escreve no xml formato cfi.</returns>
        public cfiXML_Info Get_cfiXML_Info()
        {
            return _cfiXML_Info;
        }

        /// <summary>
        /// Classe que contém as informações de mapeamento de uma determinada fonte de dados.
        /// </summary>
        /// <param name="generic_info">Instância da classe genérica de mapeamento.</param>
        public void Set_GenericInfo(GenericInfo generic_info)
        {
            _genericinfo = generic_info;
        }

        /// <summary>
        /// Retorna aclasse genérica de mapeamento de uma fonte de dados.
        /// </summary>
        /// <returns></returns>
        public GenericInfo GetGenericInfo()
        {
            return _genericinfo;
        }

    }
}
