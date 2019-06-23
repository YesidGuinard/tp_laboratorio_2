using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Excepcion de id repetido
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        { }

        /// <summary>
        /// Excepcion de id repetido con inner exception
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        { }
    }
}
