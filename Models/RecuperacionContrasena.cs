using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class RecuperacionContrasena
    {
        public int IdRecuperacion { get; set; }
        public int IdUsuario { get; set; }
        public string CodigoVerif { get; set; }   // 6 dígitos
        public DateTime FechaGeneracion { get; set; }
        public DateTime FechaExpiracion { get; set; }   // +10 minutos
        public bool Utilizado { get; set; }
    }
}
