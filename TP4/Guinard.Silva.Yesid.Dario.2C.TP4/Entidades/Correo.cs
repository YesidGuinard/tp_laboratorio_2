using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo: IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        public void FinEntregas()
        {
            foreach (Thread hilos in this.mockPaquetes)
            {
                if (hilos.IsAlive == true)
                    hilos.Abort();
            }
        }
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            List<Paquete> lista = (List<Paquete>)((Correo)elementos).Paquetes;
            foreach (Paquete p in lista)
            {
                sb.AppendFormat("{0} para {1} ({2})\n",p.TrackingID,p.DireccionEntrega,p.Estado.ToString());
            }

            return sb.ToString();
        }
        public static Correo operator +(Correo c, Paquete p)
        {
            bool paqueteYaEnCorreo = false;
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    paqueteYaEnCorreo = true;
                    break;
                }
            }

            if (paqueteYaEnCorreo == true)
            {
                throw new TrackingIdRepetidoException("El paquete ya se encuentra en la lista");
            }
            else
            {
                c.Paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
            }
            return c;
        }

    }
}
