using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }

        #region Atributos
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        private EMarca marca;
        #endregion

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias
        { get;}

        #region Constructores

        public Producto(string codigoDeBarras, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigoDeBarras;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

       #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Devuelve toda la información de producto
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static explicit operator string(Producto p)
        {
            if (p is null)
            {
                return "\nError! Producto null\n";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
                sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
                sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
                sb.AppendLine("---------------------");
                return sb.ToString();
            }

        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1.codigoDeBarras == v2.codigoDeBarras);
        }
        #endregion
    }
}
