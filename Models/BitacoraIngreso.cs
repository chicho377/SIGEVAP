using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class BitacoraIngreso
    {
        public int IdIngreso { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaHoraIngreso { get; set; }
        public DateTime? FechaHoraSalida { get; set; }   // null si sesión activa
        public int? DuracionMinutos { get; set; }   // calculado por SP_ConsultarBitacoraIngresos
    }
}
