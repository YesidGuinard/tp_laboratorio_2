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
namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operando1 = txtNumero1.Text;
            string operando2 = txtNumero2.Text;
            string operacion = cmbOperador.Text;
            double resultado = Operar(operando1,operando2,operacion);
            lblResultado.Text = resultado.ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numero = lblResultado.Text;
            Entidades.Numero resultado = new Numero();
            lblResultado.Text = resultado.DecimalBinario(numero);
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numero = lblResultado.Text;
            Entidades.Numero resultado = new Numero();
            lblResultado.Text = resultado.BinarioDecimal(numero);
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }
        
        /// <summary>
        /// Limpia campos de texto de Captura de datos y resultados 
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// Realiza la operacion arimetica Usando metodo estatico de la Clase Calculadora
        /// </summary>
        /// <param name="numero1">Operando 1</param>
        /// <param name="numero2">Operando 2</param>
        /// <param name="operador">Resultado operacion</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            return Calculadora.Operar(num1, num2, operador);
        }


    }
}
