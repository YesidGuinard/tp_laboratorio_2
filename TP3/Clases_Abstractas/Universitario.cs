using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Constructor universitario con parametros
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Override metodo Equal para comparar
        /// </summary>
        /// <param name="obj">Universitario</param>
        /// <returns>verdadero si universitarios son iguales</returns>
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
    
        /// <summary>
        /// Muestra datos universitario
        /// </summary>
        /// <returns>datos universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}", this.legajo);
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// compara si uuniversitarios son diferentes
        /// </summary>
        /// <param name="pg1">universitario</param>
        /// <param name="pg2">universitario</param>
        /// <returns>verdadero si son diferentes</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// compara si uuniversitarios son iguales
        /// </summary>
        /// <param name="pg1">universitario</param>
        /// <param name="pg2">universitario</param>
        /// <returns>verdadero si son iguales</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

    }
}
