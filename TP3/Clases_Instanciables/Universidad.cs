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

        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Profesores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }
        public static bool operator == (Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.Profesores.Contains(i);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach(Profesor profe in g.Profesores)
            {
                if(profe == clase)
                {
                    return profe;
                }
            }

            throw new SinProfesorException();
        }

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

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g != a)
            {
                g.Alumnos.Add(a);
                return g;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }

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

        public static Universidad operator +(Universidad g, EClases clase)
        {

            Jornada jornada = new Jornada(clase, g == clase);
            foreach(Alumno alumno in g.Alumnos)
            {
                if(alumno == clase)
                {
                    jornada.Alumnos.Add(alumno);
                }
            }
            g.Jornadas.Add(jornada);

            return g;
        }

        public static void Guardar(Universidad gim)
        {
            Xml<Universidad> aux = new Xml<Universidad>();
            if (aux.Guardar("Universidad.xml", gim) == false)
            {
                throw new ArchivosException("Error al guardar la universidad.");
            }
        }

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
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            foreach(Jornada jornada in gim.Jornadas)
            {
                sb.AppendLine("JORNADA: ");
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("< ----------------------------------------------------------------- >");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

    }
}
