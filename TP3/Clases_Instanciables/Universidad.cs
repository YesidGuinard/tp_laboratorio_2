using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD

        }

        private List<Jornada> jornadas;
        private List<Alumno> alumnos;
        private List<Profesor> profesores;

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

        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    return this.Jornadas[i];
                else
                    return null;
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    this.Jornadas[i] = value;
            }
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Profesores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Verifica si alumno inscripto en universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>Verdadero si si encuentra inscripto</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }

        /// <summary>
        /// Verifica si alumno no se encuentra inscripto en universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>Verdadero si no se encuentra inscripto</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica si profesor inscripto en universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="i">profesor</param>
        /// <returns>Verdadero si si encuentra inscripto</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.Profesores.Contains(i);
        }


        /// <summary>
        /// Verifica si profesor no se encuentra inscripto en universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="i">profesor</param>
        /// <returns>Verdadero si no se encuentra inscripto</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// revisa si profesor dicta esa clase
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns>primer profesor encontrado</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profe in g.Profesores)
            {
                if (profe == clase)
                {
                    return profe;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// revisa si profesor NO dicta esa clase
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns>primer profesor encontrado que no dicte clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profe in g.Profesores)
            {
                if (profe != clase)
                {
                    return profe;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega alumno a universidad si no esta inscripto 
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
                return g;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }

        /// <summary>
        /// Agrega profesor a universidad si no esta inscripto 
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="i">profesor</param>
        /// <returns>universidad</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Profesores.Add(i);
                return g;
            }
            else
            {
                throw new ProfesorRepetidoException();
            }
        }

        /// <summary>
        /// Agrega una nueva clase y nueva Jornada
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns>universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {

            Jornada jornada = new Jornada(clase, g == clase);
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada.Alumnos.Add(alumno);
                }
            }
            g.Jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Guarda en archivo XML Datos de Universidad
        /// </summary>
        /// <param name="uni">universidad</param>
        public static void Guardar(Universidad uni)
        {
            Xml<Universidad> aux = new Xml<Universidad>();
            if (aux.Guardar("Universidad.xml", uni) == false)
            {
                throw new ArchivosException("Error al guardar la universidad.");
            }
        }

        /// <summary>
        /// lee desde archivo xml datos de universidad
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            Xml<Universidad> aux = new Xml<Universidad>();
            if (aux.Leer("Universidad.xml", out retorno) == false)
            {
                throw new ArchivosException("Error al leer la universidad.");
            }
            return retorno;
        }

        /// <summary>
        /// muestra datos de universidad
        /// </summary>
        /// <param name="uni">universidad</param>
        /// <returns>datos universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine("JORNADA: ");
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("< ----------------------------------------------------------------- >");
            }

            return sb.ToString();
        }

        /// <summary>
        /// hace publicos datos de universidad
        /// </summary>
        /// <returns>datos universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

    }
}
