using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dulce : Producto
    {
        public Dulce(EMarca marca, string codigoDeBarras, ConsoleColor color):base(codigoDeBarras,marca,color)
        {
        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        private override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(this.Mostrar());
            sb.AppendLine("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb;
        }
    }
}
