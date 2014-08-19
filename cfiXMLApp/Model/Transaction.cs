using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cfiXML_Model
{
    /// <summary>
    /// Enumeration que contém os tipos de "Transaction".
    /// </summary>
    public enum TransactionType
    {
        Approved,
        Archived,
        Checked,
        Created,
        Deleted,
        Modified,
        Modified_Copy,
        New_Revision,
        Ownership_Changed,
        Published,
        Nil,
        Custom
    }

    /// <summary>
    /// Classe que representa uma das etapas de uma revisão.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Ordem seqüencial da etapa da revisão atual.
        /// </summary>
        public int Transaction_Order { get; set; }

        /// <summary>
        /// Data que ocorreu a etapa da revisão atual.
        /// </summary>
        public DateTime Transaction_Date { get; set; }

        /// <summary>
        /// Pessoa responsável pela etapa da revisão.
        /// </summary>
        public string Transaction_Person { get; set; }
        
        /// <summary>
        /// (Somente Leitura) Tipo de etapa de revisão. Assume os valores "Approved", "Archived", "Checked", "Created", "Deleted", "Issued", "Modified", "Modified copy", "New revision", "Ownership changed", "Published", "Nil" e "custom"
        /// </summary>
        public TransactionType Transaction_Type{get; private set;}

        /// <summary>
        /// (Somente Leitura) Descrição do tipo de "Transaction" caso o "Transaction Type" não esteja contido no enumeration. Se o "Transaction Type" for igual a algum valor do enumeration, assum o valor vazio.
        /// </summary>
        public string Other_Transaction_type { get; private set; }

        /// <summary>
        /// Método utilizado para preencher as propriedades "Transation_Type" e "Other_Transaction_Type" adequadamente.
        /// </summary>
        /// <param name="transaction_Type">Descrição do tipo de etapa da revisão.</param>
        public void Get_Transaction_Type(string transaction_Type)
        {
            foreach(string type in Enum.GetNames(typeof(TransactionType)))
            {
                if (String.Equals(transaction_Type,type))
                {
                    Transaction_Type = (TransactionType)Enum.Parse(typeof(TransactionType), transaction_Type);
                    Other_Transaction_type = String.Empty;
                    return;
                }
            }
            Transaction_Type = TransactionType.Custom;
            Other_Transaction_type = transaction_Type;
        }

        /// <summary>
        /// Comentários da etapa da revisão. Em caso de "Transaction_Type = 'Modified'", "Transaction_Remark" é considerado a descrição da revisão.
        /// </summary>
        public string Transaction_Remark { get;set; }

        /// <summary>
        /// Classe que representa uma das etapas de uma revisão.
        /// </summary>
        /// <param name="transaction_order">Ordem seqüencial da etapa da revisão atual.</param>
        /// <param name="transaction_date">Data que ocorreu a etapa da revisão atual.</param>
        /// <param name="transaction_person">Pessoa responsável pela etapa da revisão.</param>
        /// <param name="transaction_type">Tipo de etapa de revisão.</param>
        /// <param name="transaction_remark">Comentários da etapa da revisão.</param>
        public Transaction(int transaction_order, DateTime transaction_date, string transaction_person, string transaction_type, string transaction_remark)
        {
            Transaction_Order = transaction_order;
            Transaction_Date = transaction_date;            
            Transaction_Person = transaction_person;
            Transaction_Remark = transaction_remark;
            Get_Transaction_Type(transaction_type);
        }
    }
}
