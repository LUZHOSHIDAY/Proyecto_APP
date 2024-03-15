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
    public partial class FrmModuloPaciente : Form
    {
        public FrmModuloPaciente()
        {
            InitializeComponent();
        }

        //Mostrar mensaje de ok
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje,"Sistema Clinico",
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
            this.txtCodigoPaciente.Text= string.Empty;
            this.txtNombrePaciente.Text= string.Empty;
            this.txtApellidoPaciente.Text = string.Empty;
            this.txtDireccionPaciente.Text = string.Empty;
            this.txtTelefonoPaciente.Text = string.Empty;
            this.txtFechaNacimientoPaciente.Text = string.Empty;
            this.cbxEECC.SelectedIndex = -1;
            this.cbxGenero.SelectedIndex = -1;
        }

        //Cargar Datos en GV
        private void CargarDatosPaciente()
        {
            try
            {
                DataTable dtPaciente = NPaciente.ListarPaciente();
                if (dtPaciente != null && dtPaciente.Rows.Count > 0)
                {
                    this.dgvPaciente.DataSource = dtPaciente;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos de pacientes.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de pacientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarDatosPaciente() {
            this.dgvPaciente.DataSource = 
                NPaciente.ListarPacienteDNI
                (this.txtCodigoPaciente.Text);
        }


        private void FrmModuloPaciente_Load(object sender, EventArgs e)
        {
            CargarDatosPaciente();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuscarDatosPaciente();
        }

        private void cbxEECC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
