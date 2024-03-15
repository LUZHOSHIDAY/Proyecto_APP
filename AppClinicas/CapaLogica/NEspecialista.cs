using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;


namespace CapaLogica
{
    public class NEspecialista
    {
        public static string Insertar( int especialistaCMP, string especialistaNombre, string especialistaApellido, int especialidadCodigo)
        {
            DEspecialista ObjEspecialista = new DEspecialista();

            ObjEspecialista.EspecialistaCMP = especialistaCMP;
            ObjEspecialista.EspecialistaNombre = especialistaNombre;
            ObjEspecialista.EspecialistaApellido = especialistaApellido;
            ObjEspecialista.EspecialidadCodigo = especialidadCodigo;


            return ObjEspecialista.Insertar(ObjEspecialista);
        }

        public class NEspecialista
        {
            public static string Actualizar(int especialistaCMP, string especialistaNombre, string especialistaApellido, int especialidadCodigo)
            {
                DEspecialista ObjEspecialista = new DEspecialista();

                ObjEspecialista.EspecialistaCMP = especialistaCMP;
                ObjEspecialista.EspecialistaNombre = especialistaNombre;
                ObjEspecialista.EspecialistaApellido = especialistaApellido;
                ObjEspecialista.EspecialidadCodigo = especialidadCodigo;


                return ObjEspecialista.Actualizar(ObjEspecialista);
            }


            public static string Eliminar(int especialistaCMP)
        {
            DEspecialista ObjEspecialista = new DEspecialista();

                ObjEspecialista.EspecialistaCMP = especialistaCMP;

            return ObjEspecialista.Eliminar(ObjEspecialista);
        }

        public static DataTable ListarEspecialista()
        {
            return new DEspecialista().Especialista);
        }

        public static DataTable ListarEspecialistaDNI(string especialistaCMP)
        {
            DEspecialista ObjEspecialista = new DEspecialista();

                ObjEspecialista.EspecialistaCMP = especialistaCMP;

            return ObjEspecialista.ListarEspecialistaDNI(ObjEspecialista);
        }
    }
        //Cargar Datos en GV
        private void CargarDatosEspecialista()
        {
            try
            {
                DataTable dtEspecialista = NEspecialista.ListarEspecialista();
                if (dtEspecialista != null && dtEspecialista.Rows.Count > 0)
                {
                    this.dgvEspecialista.DataSource = dtEspecialista;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos de Especialista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de Especialista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
