using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cfiXML_Model
{
    public class MultiData_MapInfo:Data_MapInfo
    {
        private string _other_value;

        private GenericInfo _other_genericinfo;

        private Dictionary<string, string> _enumMap;

        public void SetEnumMap(Dictionary<string, string> enumMap)
        {
            _enumMap = enumMap;
        }

        public Dictionary<string, string> GetEnumMap()
        {
            return _enumMap;
        }

        public void SetOtherValue(string other_value)
        {
            _other_value = other_value;
        }

        public string GetOtherValue()
        {
            return _other_value;
        }
        
        /// <summary>
        /// Classe que contém as informações de mapeamento de uma determinada fonte de dados.
        /// </summary>
        /// <param name="generic_info">Instância da classe genérica de mapeamento.</param>
        public void Set_OtherGenericInfo(GenericInfo other_generic_info)
        {
            _other_genericinfo= other_generic_info;
        }

        /// <summary>
        /// Retorna aclasse genérica de mapeamento de uma fonte de dados.
        /// </summary>
        /// <returns></returns>
        public GenericInfo GetOtherGenericInfo()
        {
            return _other_genericinfo;
        }
    }
}