using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class RolPermiso
    {
        public int IdRolPermiso { get; set; }
        public int IdRol { get; set; }
        public int IdModulo { get; set; }
        public bool TieneAcceso { get; set; }

        // Propiedades de navegación (para mostrar en pantalla)
        public string NombreRol { get; set; }
        public string NombreModulo { get; set; }
    }
}
