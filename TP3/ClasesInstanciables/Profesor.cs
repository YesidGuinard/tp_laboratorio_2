using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor: Universitario
    {

        private static Random random;
        private Queue<Universidad.Eclases> clasesDelDia;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido,string dni,ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.Eclases>();
            this._randomClases();
        }

        public static bool operator ==(Profesor i, Universidad.Eclases clase)
        {
            bool retorno = false;
            foreach (Universidad.Eclases claseAux in i.clasesDelDia)
            {
                if (clase == claseAux)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.Eclases clase)
        {
            return !(i == clase);
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.Eclases)Profesor.random.Next(0,4));
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA");
            if (!object.ReferenceEquals(this.clasesDelDia,null))
            {
                foreach (Universidad.Eclases claseAux in this.clasesDelDia)
                {
                    sb.AppendFormat("{0}\n", claseAux);
                }
            }

            return sb.ToString();
        }
    }
}
