using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            Aldia,
            Deudor,
            Becado
        }
        private Universidad.Eclases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.Eclases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.Eclases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni,
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

        public static bool operator ==(Alumno a, Universidad.Eclases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }
        public static bool operator !=(Alumno a, Universidad.Eclases clase)
        {
            return (a.claseQueToma != clase);

        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            if (this.estadoCuenta == EEstadoCuenta.Aldia)
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
