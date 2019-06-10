using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        public ArchivosException():this("Error de archivo.")
        {

        }

        public ArchivosException(string message):base(message)
        {
        }
    }
}
