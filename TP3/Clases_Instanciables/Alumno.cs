using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;


        /// <summary>
        /// Constructor por Defecto
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni,
            nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Muestra clases que toma alumno
        /// </summary>
        /// <returns>datos clases tomadas</returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASE DE :{0}", this.claseQueToma);
        }

        /// <summary>
        /// hace publicos datos de alumno
        /// </summary>
        /// <returns>datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// veerifica si el alumno toma esa clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">clase</param>
        /// <returns>Verdadero si alumno toma clase y estado de cuenta diferente de deudor</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// verifica si no alumno toma clase 
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="clase">clase</param>
        /// <returns>verdadero si no la toma</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);

        }

        /// <summary>
        /// muestra dato del alumno
        /// </summary>
        /// <returns>datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("ESTADO DE CUENTA: Cuota al dia");
            }
            else
            {
                sb.AppendFormat("ESTADO De CUENTA:{0}\n", this.estadoCuenta);
            }
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
    }
}
