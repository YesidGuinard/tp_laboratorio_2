using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>

    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;

        public delegate void DelegadoSQL(string mensaje);
        public event DelegadoSQL InformarError;


        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        
        /// <summary>
        /// Propiedad para Direccion de entrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        
        /// <summary>
        /// Propiedad Estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad tracking
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        
        /// <summary>
        /// Constructor de clase 
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// Metodo que cambia estados de paquetes
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.Estado != Paquete.EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformarEstado(this.Estado, EventArgs.Empty);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                this.InformarError(e.Message);
            }

        }

        /// <summary>
        /// Mostrar datos de paquetes
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return String.Format("{0} para {1}", p.TrackingID, p.DireccionEntrega);
        }

        /// <summary>
        /// verifica si dos paquetes son diferentes
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// verifica si dos paquetes son iguales si ID son iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        /// sobrecarga del metodo string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }


    }
}
