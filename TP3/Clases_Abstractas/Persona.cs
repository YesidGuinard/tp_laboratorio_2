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
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor Persona con dni
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor Persona con dni tpo string
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido,
            nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Muestra datos de persona
        /// </summary>
        /// <returns>Datos de persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0} {1}\n", this.Apellido, this.Nombre);
            //sb.AppendFormat("Dni: {0}\n", this.DNI);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Valida dni de tipo int
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">dni a validar</param>
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
        /// Valida dni de tipo string
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">dni a validar</param>
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
        /// Valida Nombre y Apellido
        /// </summary>
        /// <param name="dato">ato a validar</param>
        /// <returns>Retorna Nombre o Apellido si es valido</returns>
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
