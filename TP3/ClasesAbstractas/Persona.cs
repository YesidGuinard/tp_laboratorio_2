using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace ClasesAbstractas
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
                this.apellido = this.ValidarNombreApellido(value);
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
                this.dni = this.ValidarDni(this.nacionalidad,value);
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
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }

        }
        #endregion

        #region Constructores

        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad): this (nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido,
            nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre: {0} {1}\n", this.Nombre, this.Apellido);
            sb.AppendFormat("Dni: {0}\n", this.DNI);
            sb.AppendFormat("Nacionalidad: {0}\n", this.Nacionalidad);
            return sb.ToString();
        }

        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato>=89999999 || dato<=1)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no coincide con el numero de DNI ");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 99999999 || dato <= 90000000)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no coincide con el numero de DNI ");
                    }
                    break;
                default:
                    throw  new NacionalidadInvalidaException("Dni fuera de rango");
            }
            return dato;
        }

        public int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 0;
        }

        public string ValidarNombreApellido(string dato)
        {
            return "";
        }

        #endregion







    }
}
