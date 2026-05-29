using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Puesto { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal Salario { get; set; }
        public decimal DiasVacacionesDisponibles { get; set; }
        public byte[] Imagen { get; set; }   // BLOB foto
        public bool Estado { get; set; }

        public override string ToString() => NombreCompleto;
    }
}
