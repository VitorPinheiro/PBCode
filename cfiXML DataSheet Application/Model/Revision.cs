using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cfiXML_Model
{
    /// <summary>
    /// Classe que representa uma revisão da folha de dados.
    /// </summary>
    public class Revision
    {
        /// <summary>
        /// Identificador da revisão.
        /// </summary>
        public string ID_Revision { get; set; }

        /// <summary>
        /// Versão da revisão.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Índice da versão da revisão.
        /// </summary>
        public string Version_Index { get; set; }
    
        /// <summary>
        /// Coleção de etapas da revisão.
        /// </summary>
        public List<Transaction> TransactionSet{get;set;}
        
        /// <summary>
        /// Classe que representa uma revisão da folha de dados.
        /// </summary>
        /// <param name="id_revision">Identificador da revisão.</param>
        /// <param name="version">Versão da revisão.</param>
        /// <param name="version_index">Índice da revisão da versão.</param>
        /// <param name="transaction_set">Coleção de etapas da revisão.</param>
        public Revision(string id_revision, string version, string version_index, List<Transaction> transaction_set)
        {
            ID_Revision=id_revision;
            Version = version;
            Version_Index = version_index;
            TransactionSet = transaction_set;
        }

    }
}
