using System;

namespace Excepciones
{
    public class ProfesorRepetidoException:Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public ProfesorRepetidoException() :base("Profesor Repetido")
        {

        }
    }
}