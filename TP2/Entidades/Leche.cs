﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        #region Atributos
        private ETipo tipo;
        #endregion

        /// <summary>
        /// Por defecto, tipo entero.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigoDeBarras"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor color)
            : this(marca, codigoDeBarras, color, ETipo.Entera)
        {

        }

        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor color, ETipo tipo)
    : base(codigoDeBarras, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Override del metodo Mostrar producto.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
