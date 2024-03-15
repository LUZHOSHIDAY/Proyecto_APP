using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaLogica;

namespace CapaPresentacion
{
    public partial class FrmModuloEspecialista : Form
    {
        public FrmModuloEspecialista()
        {
            InitializeComponent();
        }

        //Mostrar mensaje de ok
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Clinico",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        //Mostrar mensaje Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Clinico",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void Limpiar()
        {
            this.txtEspecialistaCMP.Text = int.Empty;
            this.txtEspecialistaNombre.Text = string.Empty;
            this.txtEspecialistaApellido.Text = string.Empty;
            this.txt.EspecialidadCodigoText = int.Empty;

        }

        private void FrmModuloEpecialista_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbxEECC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
