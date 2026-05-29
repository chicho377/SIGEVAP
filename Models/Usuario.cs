using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }   // SHA-256 hash
        public int IdRol { get; set; }
        public int IdEmpleado { get; set; }
        public byte IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public bool Estado { get; set; }

        // Propiedades de navegación (para mostrar en pantalla)
        public string NombreRol { get; set; }
        public string NombreEmpleado { get; set; }

        public override string ToString() => NombreUsuario;
    }
}
