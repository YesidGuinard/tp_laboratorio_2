using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        #endregion

             #region Metodos
        public override string ToString()
        {
            return base.ToString();
        }

        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return 0;
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
