using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepcion archivo
        /// </summary>
        public ArchivosException() : this("Error de archivo.")
        {

        }
        /// <summary>
        /// Excepcion archivo
        /// </summary>
        /// <param name="message"></param>
        public ArchivosException(string message) : base(message)
        {
        }
    }
}
