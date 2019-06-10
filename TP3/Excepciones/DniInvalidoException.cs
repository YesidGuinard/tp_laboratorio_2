using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        public DniInvalidoException(string documentoNoValido)
        {
            throw new NotImplementedException();
        }

        public DniInvalidoException(Exception documentoNoValido)
        {
            throw new NotImplementedException();
        }
    }
}
