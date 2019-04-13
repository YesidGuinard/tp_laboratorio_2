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
            this.SetNumero = numero.ToString();
        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        public string BinarioDecimal(string binario)
        {
            
            foreach (char caracter in binario)
            {
                if (caracter != '0' && caracter != '1')
                {
                    return "Valor inválido";
                }
            }

            long resultado = 0;  // Variable long para convertir string grandes
            for (int i = 1; i <= binario.Length; i++)
            {
                resultado += int.Parse(binario[i - 1].ToString()) * (int)Math.Pow(2, binario.Length - i);
            }
            return resultado.ToString();

           
        }
        public string DecimalBinario(double numero)
        {
            string resultado = "Valor inválido";
            
            while (numero > 0)
            {
                resultado = (numero % 2).ToString() + resultado;
                numero = (int)numero / 2;
            }

            return resultado;
        }
        public string DecimalBinario(string numero)
        {
            string binarioRetornado = "Valor inválido";

            double numeroParseado;
            if (double.TryParse(numero, out numeroParseado))
            {
                numeroParseado = Math.Abs(numeroParseado);
                binarioRetornado = DecimalBinario(numeroParseado);
            }
            return binarioRetornado;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return  n1.numero * n2.numero; ;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
                return n1.numero / n2.numero;
            else
                return Double.MinValue;
        }
        private double ValidarNumero(string strNumero)
        {
            double numeroRetornado ;
            bool isNumber = double.TryParse(strNumero, out numeroRetornado);

            if (isNumber)
                return numeroRetornado;
            else
                return 0;
        }
    }
}
