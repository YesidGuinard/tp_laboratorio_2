using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Profesor instructor;
        private Universidad.EClases clase;

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Constructor por Defecto
        /// </summary>
        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="clase">clase</param>
        /// <param name="instructor">profesor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Muestra datos de la Jornada
        /// </summary>
        /// <returns>datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE: {0} POR:  {1}", this.Clase, this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Verifica si Alumno pertenece a la Jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>verdadero si alumno en jornada</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.Alumnos.Contains(a);
        }

        /// <summary>
        /// Verifica si Alumno No pertenece a la Jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>verdadero si alumno no esta en la jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega Alumno a Jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>Jornada con alumno agregado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {

            if (j == a)
                throw new AlumnoRepetidoException();
            else
                j.Alumnos.Add(a);
            return j;

        }

        /// <summary>
        /// Guarda Jornada en Archivo
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Verdadero si pudo guardar</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string path = "Jornada.txt";
            bool retorno = false;
            retorno = texto.Guardar(path, jornada.ToString());
            return retorno;
        }

        /// <summary>
        /// Lee Jornada desde Archivo
        /// </summary>
        /// <returns>Jornada leida</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string path = "Jornada.txt";
            string leido = "";
            texto.Leer(path, out leido);
            return leido;
        }
    }
}
