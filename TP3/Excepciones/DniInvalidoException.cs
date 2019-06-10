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
        /// 
        /// </summary>
        public DniInvalidoException()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e) :this("DNI invalido",e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) :this(message,null)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e) : base(message,e)
        {

        }
    }
}
