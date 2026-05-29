using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class TipoPermiso
    {
        public int IdTipoPermiso { get; set; }
        public string NombrePermiso { get; set; }
        public string Descripcion { get; set; }
        public decimal CantMaximaDias { get; set; }
        public bool RequiereComprobante { get; set; }
        public bool Estado { get; set; }

        public override string ToString() => NombrePermiso;
    }
}
