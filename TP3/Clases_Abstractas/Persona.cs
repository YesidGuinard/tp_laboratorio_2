using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;
namespace Clases_Abstractas
{
    public abstract class Persona
    {

        public enum ENacionalidad { Argentino, Extranjero }
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion
        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = Persona.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = Persona.ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = Persona.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = Persona.ValidarDni(this.nacionalidad, value);
            }

        }
        #endregion

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido,
            nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0} {1}\n", this.Apellido, this.Nombre);
            //sb.AppendFormat("Dni: {0}\n", this.DNI);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 89999999 || dato <= 0)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no coincide con el numero de DNI ");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato > 99999999 || dato < 90000000)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no coincide con el numero de DNI ");
                    }
                    break;


            }
            return dato;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".", "");

            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException("Dni invalido");

            int dni;

            try
            {
                dni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException("Dni invalido");
            }

            return ValidarDni(nacionalidad, dni);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static string ValidarNombreApellido(string dato)
        {
            foreach (char letra in dato)
            {
                if (!(char.IsLetter(letra)))
                {
                    dato = "";
                    break;
                }

            }
            return dato;
        }

        #endregion







    }
}
