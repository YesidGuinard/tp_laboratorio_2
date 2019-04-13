using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace MiCalculadora
{
    public static class Calculadora
    {
        /// <summary>
        /// Opera arimeticamente dos numeros segun operador
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo Operando</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
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
        /// <summary>
        /// Valida Operador Arimetico sea +,-,*,/
        /// </summary>
        /// <param name="operador">string a Validar</param>
        /// <returns>Operador Valido, si es invalido retorna +</returns>
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
