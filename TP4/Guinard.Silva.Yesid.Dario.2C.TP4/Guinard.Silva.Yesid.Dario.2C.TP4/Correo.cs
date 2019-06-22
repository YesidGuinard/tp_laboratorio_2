using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guinard.Silva.Yesid.Dario._2C.TP4
{
    public class Correo
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return null; }
            set { }
        }

        public Correo()
        { }
        public void FinEntregas() { }
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            return "";
        }
        public static Correo operator +(Correo c, Paquete p)
        {
            return null;
        }

    }
}
