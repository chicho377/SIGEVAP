using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Controllers
{
    internal class ConexionDB
    {
        private static readonly string _cadena =
        ConfigurationManager.ConnectionStrings["SIGEVAP_DB"].ConnectionString;

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadena);
        }
    }
}
