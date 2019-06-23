using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        /// <summary>
        /// metodo que intenta agregar paquete de no estar repetido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            paquete.InformarEstado += this.paq_InformaEstado;
            paquete.InformarError += this.InformaErrorConexion;
            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.ActualizarEstados();

        }

        /// <summary>
        /// Muestra en rtbMostrar todos los paquetes y estado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// metodo que refresca en lst el estado de paquetes
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;

                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;

                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }

            }

        }

        /// <summary>
        /// closing del form que finaliza todos los hilos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra informacion en rtbMostrar y almacena e archivo salida.txt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!object.ReferenceEquals(elemento, null))
            {
                string info = elemento.MostrarDatos(elemento);

                this.rtbMostrar.Text = info;
                try
                {
                    info.Guardar("salida.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al guardar archivo salida.txt");
                }
            }

        }

        /// <summary>
        ///  revisa el estado de paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }

        }
        
        /// <summary>
        /// Informa por msgbox Cualquier error de conexion sql
        /// </summary>
        /// <param name="mensaje"></param>
        private void InformaErrorConexion(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        /// <summary>
        /// Si paquete estado es entregado, al hacer click secundario muestar informacion de paquete entregado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
