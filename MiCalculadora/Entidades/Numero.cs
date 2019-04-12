using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            //parse str y usar contructor double
        }
        public string BinarioDecimal(string binario)
        {
            string decimalRetornado = "Valor inválido";

            return decimalRetornado;
        }
        public string DecimalBinario(double numero)
        {
            string binarioRetornado = "Valor inválido";

            return binarioRetornado;
        }
        public string DecimalBinario(string numero)
        {
            string binarioRetornado = "Valor inválido";

            return binarioRetornado;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return 0;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return 0;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return 0;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return 0;
        }
        private double ValidarNumero(string strNumero)
        {
            double numeroRetornado = 0;
            return numeroRetornado;
        }
    }
}
