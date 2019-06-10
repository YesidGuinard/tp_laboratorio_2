using System;

namespace Excepciones
{
    public class ProfesorRepetidoException:Exception
    {
        public ProfesorRepetidoException() :base("Profesor Repetido")
        {

        }
    }
}