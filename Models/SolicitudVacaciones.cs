using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class SolicitudVacaciones
    {
        public int IdSolicitud { get; set; }
        public int IdEmpleado { get; set; }
        public int IdTipoPermiso { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal CantidadDias { get; set; }
        public string Motivo { get; set; }
        public byte[] Comprobante { get; set; }   // BLOB PDF/JPG/PNG
        public string Estado { get; set; }   // Pendiente / Aprobada / Rechazada
        public string Observaciones { get; set; }
        public int? IdUsuarioGestor { get; set; }
        public DateTime? FechaGestion { get; set; }
        public DateTime FechaSolicitud { get; set; }

        // Propiedades de navegación (para mostrar en pantalla y reportes)
        public string NombreEmpleado { get; set; }
        public string CedulaEmpleado { get; set; }
        public string TipoPermiso { get; set; }
        public string UsuarioGestor { get; set; }
    }
}
