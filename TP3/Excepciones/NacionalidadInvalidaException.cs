using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Contructor por defecto
        /// </summary>
        public NacionalidadInvalidaException()
        {

        }
        /// <summary>
        /// Nacionalidad Invalida
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {
        }
    }
}