using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class Rol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        // Para mostrar en ComboBox o DataGridView
        public override string ToString() => NombreRol;
    }
}
