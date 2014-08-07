using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cfiXML_API
{
    static class Messages
    {
        public static String _transactionWithTypeError1 = "O Parâmetro revision do método transactionWithType possui um valor maior do que a revisão corrente. A revisão desejada não pode ser maior do que a revisão do xml corrente.";
        public static String _transactionWithTypeError2 = "O parâmetro transactionType do método transactionWithType precisa receber um valor diferente de null e de uma string vazia.";

        public static String _saveToFileErrorMessage = "É preciso definir o xml utilizado antes de salvar dados no mesmo.";
    }
}
