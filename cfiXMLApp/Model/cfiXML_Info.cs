using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cfiXML_Model
{
    /// <summary>
    /// Classe que contem os nomes dos métodos do cfi.
    /// </summary>
    public class cfiXML_Info 
    {
        private string _methodName;

        /// <summary>
        /// Guarda o nome do método cfi para o objeto cfiXML_Info.
        /// </summary>
        /// <param name="MethodName">Nome do método.</param>
        public void SetMethodName(string MethodName)
        {
            _methodName = MethodName;
        }

        /// <summary>
        /// Retorna o nome do método cfi do objeto cfiXML_Info.
        /// </summary>
        /// <returns>Nome do método.</returns>
        public string GetMethodName()
        {
            return _methodName;
        }

        /// <summary>
        /// Classe que contem os nomes dos métodos do cfi.
        /// </summary>
        /// <param name="MethodName">Nome do método cfi.</param>
        public cfiXML_Info(string MethodName)
        {
            _methodName = MethodName;
        }
    }
}
