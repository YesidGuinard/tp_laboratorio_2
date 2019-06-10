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

        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE: {0} POR:  {1}", this.Clase, this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach(Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            return sb.ToString();
        }


        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.Alumnos.Contains(a);
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            j.Alumnos.Add(a);
            return j;
        }

        public static void Guardar(Jornada jornada)
        {
            Texto aux = new Texto();
            if(aux.Guardar("Jornada.txt", jornada.ToString()) == false)
            {
                throw new ArchivosException("No se puede guardar la jornada.");
            }
        }

    }
}
