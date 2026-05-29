using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Models
{
    internal class Modulos
    {
        public int IdModulo { get; set; }
        public string NombreModulo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public override string ToString() => NombreModulo;
    }
}
