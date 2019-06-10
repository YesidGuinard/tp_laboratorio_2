using System;

namespace Excepciones
{
    public class ProfesorRepetidoException : Exception
    {
        /// <summary>
        /// Excepcion Profesor repetido
        /// </summary>
        public ProfesorRepetidoException() : base("Profesor Repetido")
        {

        }
    }
}