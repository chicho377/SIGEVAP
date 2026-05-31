using Microsoft.Data.SqlClient;
using SIGEVAP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Controllers
{
    internal class BitacoraController
    {
        // --------------------------------------------------------
        // ConsultarMovimientos
        // --------------------------------------------------------
        public List<BitacoraMovimiento> ConsultarMovimientos(string usuario = null,
                                                             DateTime? desde = null,
                                                             DateTime? hasta = null,
                                                             string tipo = null,
                                                             string modulo = null)
        {
            var lista = new List<BitacoraMovimiento>();
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ConsultarBitacoraMovimientos", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@filtroUsuario", (object)usuario ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroFechaDesde", (object)desde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroFechaHasta", (object)hasta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroTipo", (object)tipo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroModulo", (object)modulo ?? DBNull.Value);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new BitacoraMovimiento
                            {
                                IdMovimiento = (int)dr["idMovimiento"],
                                NombreUsuario = dr["nombreUsuario"].ToString(),
                                FechaHora = (DateTime)dr["fechaHora"],
                                TipoMovimiento = dr["tipoMovimiento"].ToString(),
                                Modulo = dr["modulo"].ToString(),
                                Detalle = dr["detalle"] != DBNull.Value ? dr["detalle"].ToString() : null
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al consultar bitácora de movimientos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al consultar bitácora de movimientos: " + ex.Message);
            }
            return lista;
        }

        // --------------------------------------------------------
        // ConsultarIngresos
        // --------------------------------------------------------
        public List<BitacoraIngreso> ConsultarIngresos(string usuario = null,
                                                       DateTime? desde = null,
                                                       DateTime? hasta = null)
        {
            var lista = new List<BitacoraIngreso>();
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ConsultarBitacoraIngresos", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@filtroUsuario", (object)usuario ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroFechaDesde", (object)desde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroFechaHasta", (object)hasta ?? DBNull.Value);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new BitacoraIngreso
                            {
                                IdIngreso = (int)dr["idIngreso"],
                                NombreUsuario = dr["nombreUsuario"].ToString(),
                                FechaHoraIngreso = (DateTime)dr["fechaHoraIngreso"],
                                FechaHoraSalida = dr["fechaHoraSalida"] != DBNull.Value ? (DateTime?)dr["fechaHoraSalida"] : null,
                                DuracionMinutos = dr["duracionMinutos"] != DBNull.Value ? (int?)dr["duracionMinutos"] : null
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al consultar bitácora de ingresos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al consultar bitácora de ingresos: " + ex.Message);
            }
            return lista;
        }
    }
}
