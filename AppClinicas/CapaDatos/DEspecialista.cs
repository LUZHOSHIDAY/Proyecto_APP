using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CapaDatos
{
    public class DEspecialista
    {
    
        private int _EspecialistaCMP;

        /// <summary>
        /// Metodo get, set del codigo del paciente
        /// </summary>
        public int EspecialistaCMP
        {
            get { return _EspecialistaCMP; }
            set { _EspecialistaCMP = value; }
        }

        private string _EspecialistaNombre;
        public string EspecialistaNombre
        {
            get { return _EspecialistaNombre; }
            set { _EspecialistaNombre = value; }
        }
        private string _EspecialistaApellido;
        public string EspecialistaApellido
        {
            get { return _EspecialistaApellido; }
            set { _EspecialistaApellido= value; }
        }
        private int _EspecialistaCodigo;
        public int EspecialistaCodigo
        {
            get { return _EspecialistaCodigo; }
            set { _EspecialistaCodigo = value; }
        }


    }
}
