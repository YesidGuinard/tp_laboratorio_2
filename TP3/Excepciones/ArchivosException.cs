using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public ArchivosException():this("Error de archivo.")
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ArchivosException(string message):base(message)
        {
        }
    }
}
