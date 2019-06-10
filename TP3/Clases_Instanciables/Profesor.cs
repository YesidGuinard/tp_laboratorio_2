using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {

        private static Random random;
        private Queue<Universidad.EClases> clasesDelDia;

        /// <summary>
        /// Constructor
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Constructor profesor con parametros
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// verifica si profesor dicta esa clase
        /// </summary>
        /// <param name="i">profesor</param>
        /// <param name="clase">clase</param>
        /// <returns>verdadero si profesor dicta esa clase</returns>
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

        /// <summary>
        /// verifica si profesor NO dicta esa clase
        /// </summary>
        /// <param name="i">profesor</param>
        /// <param name="clase">clase</param>
        /// <returns>verdadero si no profesor dicta esa clase</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// muestra datos profesor
        /// </summary>
        /// <returns>datos profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// hace publicos datos profesor
        /// </summary>
        /// <returns>datos profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// carga clase aleatoria
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
        }

        /// <summary>
        /// Muestra clases y profesores asociados
        /// </summary>
        /// <returns>datos asociados</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA");
            if (!object.ReferenceEquals(this.clasesDelDia, null))
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
