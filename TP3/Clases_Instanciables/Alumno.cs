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

        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni,
            nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASE DE :{0}", this.claseQueToma);
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);

        }
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
