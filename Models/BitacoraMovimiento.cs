using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class BitacoraMovimiento
    {
        public int IdMovimiento { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoMovimiento { get; set; }   // Inserción / Modificación / Eliminación / Consulta
        public string Modulo { get; set; }
        public string Detalle { get; set; }
    }
}
