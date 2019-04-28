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
        /// <summary>
        /// Propiedad para setear atributo numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
       
        //Constructor por defecto. Inicializa el atributo numero en cero.
        public Numero():this(Convert.ToString(0))
        {
        }
        /// <summary>
        /// Contructor que recibe parametro tipo doblue y asigna este atributo usando sobrecarga
        /// </summary>
        /// <param name="numero">parametro</param>
        public Numero(double numero):this(numero.ToString())
        {
        }
        /// <summary>
        /// Constructor  que recibe string y asigna la propiedad
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Convierte Numero Binario a Decimal
        /// </summary>
        /// <param name="binario">Numero en binario</param>
        /// <returns>Numero en base 10</returns>
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

        /// <summary>
        /// Convierte Numero Decimal a Binario
        /// </summary>
        /// <param name="numero">Numero en decimal</param>
        /// <returns>Numero en base 2</returns>
        public string DecimalBinario(double numero) // se sugiere que este metodo sea Privado
        {
            string resultado = "";
            int numeroEntero;
            numeroEntero = Math.Abs((int)numero);
            if (numeroEntero == 0)
            {
                resultado = "0";
            }
            else
            {
                while (numeroEntero > 0)
                {
                    resultado = (numeroEntero % 2).ToString() + resultado;
                    numeroEntero = numeroEntero / 2;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Sobrecarga del Metodo Decimal a Binario en caso de ser menor a cero  quedandose con el valor absoluto del double
        /// </summary>
        /// <param name="numero">Numero en Decimal</param>
        /// <returns>Numero convertido en Base 2</returns>
        public string DecimalBinario(string numero)
        {
            string binarioRetornado = "Valor inválido";
            double numeroParseado;

            if (double.TryParse(numero, out numeroParseado))
            {
                //numeroParseado = Math.Abs(numeroParseado);
                binarioRetornado = DecimalBinario(numeroParseado);
            }
            return binarioRetornado;
        }
        
        /// <summary>
        /// Reliza la sobrecarga de + sumando dos obj numero 
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>resultado Arimetico de suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Reliza la sobrecarga de - Restando dos obj numero 
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>resultado Arimetico de resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        
        /// <summary>
        /// Reliza la sobrecarga de * Multiplicando dos obj numero 
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>resultado Arimetico de mulplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return  n1.numero * n2.numero; ;
        }

        /// <summary>
        /// Reliza la sobrecarga de / sumando dos obj numero y valida divisor!=0
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>resultado Arimetico de la division, si divisor = 0 retorna MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
                return n1.numero / n2.numero;
            else
                return Double.MinValue;
        }
        
        /// <summary>
        /// Valida que el parametro sea de tipo numerico 
        /// </summary>
        /// <param name="strNumero">string a validar</param>
        /// <returns>devuelve numero parseado a float si es invalido retorna 0.0 </returns>
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
