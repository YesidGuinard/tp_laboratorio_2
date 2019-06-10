using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor: Universitario
    {

        private static Random random;
        private Queue<Universidad.EClases> clasesDelDia;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido,string dni,ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases claseAux in i.clasesDelDia)
            {
                if (clase == claseAux)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
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
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0,4));
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA");
            if (!object.ReferenceEquals(this.clasesDelDia,null))
            {
                foreach (Universidad.EClases claseAux in this.clasesDelDia)
                {
                    sb.AppendFormat("{0}\n", claseAux);
                }
            }

            return sb.ToString();
        }
    }
}
