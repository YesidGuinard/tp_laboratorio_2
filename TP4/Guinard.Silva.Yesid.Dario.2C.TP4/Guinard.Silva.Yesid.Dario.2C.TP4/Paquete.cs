using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guinard.Silva.Yesid.Dario._2C.TP4
{
    public class Paquete:IMostrar<Paquete>

    {
        public delegate void  DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;

        /*public delegate void DelegadoSql(string mensaje);
        public event DelegadoSql InformarError;
        */
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public string DireccionEntrega
        {
            get { return ""; }
            set { }
        }

        public EEstado Estado
        {
            get { return EEstado.Entregado; }
            set { }
        }

        public string TrackinID
        {
            get { return ""; }
            set { }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {

        }

        public void MockCicloDeVida() { }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return "";
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1==p2);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
