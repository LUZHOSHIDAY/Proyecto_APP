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

        private void InsertaPaciente()
        {
            string pacienteCodigo = txtCodigoPaciente.Text.Trim();
            string pacienteNombre = txtNombrePaciente.Text.Trim();
            string pacienteApellido = txtApellidoPaciente.Text.Trim();
            string pacienteDireccion = txtDireccionPaciente.Text.Trim();
            int pacienteTelefono; // Declaramos "pacienteTelefono" como un entero
            string pacienteNacimiento = txtFechaNacimientoPaciente.Text.Trim();
            int eecccodigo; // Asumimos que EECC es un código entero
            int generocodigo; // Asumimos que Genero es un código entero

            // Validación básica (puedes agregar más validaciones)
            if (string.IsNullOrEmpty(pacienteCodigo) ||
                string.IsNullOrEmpty(pacienteNombre) ||
                string.IsNullOrEmpty(pacienteApellido))
            {
                MessageBox.Show("Los campos código, nombre y apellido son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación del teléfono
            if (!int.TryParse(txtTelefonoPaciente.Text.Trim(), out pacienteTelefono))
            {
                MessageBox.Show("El teléfono debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica si EECC y Genero son enteros antes de convertirlos
            if (int.TryParse(cbxEECC.SelectedItem.ToString(), out eecccodigo) &&
                int.TryParse(cbxGenero.SelectedItem.ToString(), out generocodigo))
            {
                NPaciente.Insertar(pacienteCodigo, pacienteNombre, pacienteApellido, pacienteDireccion, pacienteTelefono, pacienteNacimiento, eecccodigo, generocodigo);
                // ... (Maneja la respuesta de la función Insertar)
            }
            else
            {
                MessageBox.Show("Error en los valores de EECC o Género.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificaPaciente()
        {
            string pacienteCodigo = txtCodigoPaciente.Text.Trim();
            string pacienteNombre = txtNombrePaciente.Text.Trim();
            string pacienteApellido = txtApellidoPaciente.Text.Trim();
            string pacienteDireccion = txtDireccionPaciente.Text.Trim();
            int pacienteTelefono; // Declaramos "pacienteTelefono" como un entero
            string pacienteNacimiento = txtFechaNacimientoPaciente.Text.Trim();
            int eecccodigo; // Asumimos que EECC es un código entero
            int generocodigo; // Asumimos que Genero es un código entero

            // Validación básica (puedes agregar más validaciones)
            if (string.IsNullOrEmpty(pacienteCodigo) ||
                string.IsNullOrEmpty(pacienteNombre) ||
                string.IsNullOrEmpty(pacienteApellido))
            {
                MessageBox.Show("Los campos código, nombre y apellido son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación del teléfono
            if (!int.TryParse(txtTelefonoPaciente.Text.Trim(), out pacienteTelefono))
            {
                MessageBox.Show("El teléfono debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica si EECC y Genero son enteros antes de convertirlos
            if (int.TryParse(cbxEECC.SelectedItem.ToString(), out eecccodigo) &&
                int.TryParse(cbxGenero.SelectedItem.ToString(), out generocodigo))
            {
                NPaciente.Actualizar(pacienteCodigo, pacienteNombre, pacienteApellido, pacienteDireccion, pacienteTelefono, pacienteNacimiento, eecccodigo, generocodigo);
                // ... (Maneja la respuesta de la función Insertar)
            }
            else
            {
                MessageBox.Show("Error en los valores de EECC o Género.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertaPaciente();
            CargarDatosPaciente();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModificaPaciente();
            CargarDatosPaciente();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombrePaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtApellidoPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccionPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxEECC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefonoPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtFechaNacimientoPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvPaciente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
