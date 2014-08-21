﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cfiXML_API
{
    class Utils
    {
        /// <summary>
        /// VITOR:
        /// O parser do altova subistitui qualquer caracter que nao seja uma letra para underline quando pega a string do xsd.
        /// 
        /// A string enviada para este componente vai ser a string do xsd.
        /// Esta função deveria ser capaz de remontar a string do xsd. (100% perfeita)
        /// Como isso não é possível, eu teria que dizer para quando ele for comparar ele permitir que quando o comparador encontra um underline ele deixa que a outra tenha qualquer coisa.
        /// 
        /// Preciso verificar como o "print" das funções do altova conseguem reconstituir a string xsd original.
        /// 
        /// 
        /// Método utilizado para subistituir todos os underlines de uma string por um espaço e retirar a primeira letra. Criado para processar os valores dos enums cfiXML gerados pelo código do software Altova.
        /// Ex: "eAPI_610" => "API 610"
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static String processEnumValue(String enumValue)
        {
            String processedEnum = enumValue.Replace("_", " ");
            return enumValue.Substring(1);
        }

        public static String processYesOrNo(String boolean)
        {
            if (String.IsNullOrEmpty(boolean))
            {
                return null;
            }
            else if (boolean.Equals("Yes")||boolean.Equals("YES"))
            {
                return "true";
            }
            else if (boolean.Equals("No") || boolean.Equals("NO"))
            {
                return "false";
            }
            else
            {
                throw new Exception("valor de boolean não disponível ('YES', 'Yes', 'NO' ou 'No')");
            }
        }
    }
}