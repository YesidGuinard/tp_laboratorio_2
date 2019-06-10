using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public DniInvalidoException()
        {

        }

        /// <summary>
        /// excepcion dni invalido
        /// </summary>
        /// <param name="e">excepcion</param>
        public DniInvalidoException(Exception e) :this("DNI invalido",e)
        {

        }

        /// <summary>
        /// excepcion dni invalido
        /// </summary>
        /// <param name="message">Mensaje recibido</param>
        public DniInvalidoException(string message) :this(message,null)
        {

        }

        /// <summary>
        /// excepcion dni invalido
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e) : base(message,e)
        {

        }
    }
}
