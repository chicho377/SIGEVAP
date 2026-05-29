using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class SesionActual
    {
        public static int IdIngreso { get; set; }   // id en BitacoraIngresosSalidas
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static int IdRol { get; set; }
        public static string NombreRol { get; set; }
        public static int IdEmpleado { get; set; }
        public static string NombreEmpleado { get; set; }

        public static void Limpiar()
        {
            IdIngreso = 0;
            IdUsuario = 0;
            NombreUsuario = null;
            IdRol = 0;
            NombreRol = null;
            IdEmpleado = 0;
            NombreEmpleado = null;
        }
    }
}
