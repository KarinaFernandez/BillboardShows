using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Herramientas
    {
        public static bool ochoCaracteres(string pValor)
        {
            bool resultado = false;
            if (pValor.Length >= 8)
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool esNumero(string pCadena)
        {
            bool retorno = false;
            int resultado = 0;

            retorno = int.TryParse(pCadena, out resultado);
            return retorno;
        }

        public static bool esHora(string pCadena)
        {
            bool retorno = false;
            TimeSpan resultado;
            retorno = TimeSpan.TryParse(pCadena, out resultado);
            return retorno;
        }
    }
}
