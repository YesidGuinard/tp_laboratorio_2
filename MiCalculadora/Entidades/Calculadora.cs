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
            double resultado = 0;
            string operadorValido = Calculadora.ValidarOperador(operador);

            
            switch (operadorValido)
            {
                case "-":
                    resultado = num1 - num2;
                    break;
                case "+":
                    resultado = num1 + num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;

        }

        private static string ValidarOperador(string operador)
        {
            string operadorDeRetorno = "+";

            if (operador == "-")
                operadorDeRetorno = "-";
            else if (operador == "*")
                operadorDeRetorno = "*";
            else if (operador == "/")
                operadorDeRetorno = "/";
            
            return operadorDeRetorno;
        }
    }
}
