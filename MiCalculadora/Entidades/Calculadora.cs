using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace MiCalculadora
{
    public class Calculadora
    {
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = Double.MinValue;
            return resultado;

        }

        private static string ValidarOperador(string operador)
        {
            string operadorDeRetorno = "+";
            return operadorDeRetorno;
        }
    }
}
