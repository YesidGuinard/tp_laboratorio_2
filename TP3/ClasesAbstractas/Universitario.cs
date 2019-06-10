using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (!ReferenceEquals(obj, null) && obj is Universitario)
            {
                Universitario universitarioAux = (Universitario)obj;
                if (universitarioAux.legajo == this.legajo || universitarioAux.DNI == this.DNI)
                    retorno = true;
            }

            return retorno;
        }
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("\nLEGAJO NUMERO: {0}", this.legajo);
            return sb.ToString();
        }
        protected abstract string ParticiparEnClase();

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

    }
}
