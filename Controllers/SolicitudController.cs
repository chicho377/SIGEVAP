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
    internal class SolicitudController
    {
        // --------------------------------------------------------
        // Insertar
        // --------------------------------------------------------
        public bool Insertar(SolicitudVacaciones s, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertarSolicitud", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEmpleado", s.IdEmpleado);
                    cmd.Parameters.AddWithValue("@idTipoPermiso", s.IdTipoPermiso);
                    cmd.Parameters.AddWithValue("@fechaInicio", s.FechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", s.FechaFin);
                    cmd.Parameters.AddWithValue("@cantidadDias", s.CantidadDias);
                    cmd.Parameters.AddWithValue("@motivo", s.Motivo);
                    cmd.Parameters.AddWithValue("@comprobante", (object)s.Comprobante ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@usuarioSesion", SesionActual.NombreUsuario);

                    var pRes = new SqlParameter("@resultado", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var pMsg = new SqlParameter("@mensaje", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(pRes);
                    cmd.Parameters.Add(pMsg);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = pMsg.Value.ToString();
                    return (int)pRes.Value == 0;
                }
            }
            catch (SqlException ex)
            {
                mensaje = "Error de base de datos al insertar solicitud: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al insertar solicitud: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Aprobar
        // --------------------------------------------------------
        public bool Aprobar(int idSolicitud, string observaciones, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_AprobarSolicitud", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);
                    cmd.Parameters.AddWithValue("@idUsuarioGestor", SesionActual.IdUsuario);
                    cmd.Parameters.AddWithValue("@observaciones", (object)observaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@usuarioSesion", SesionActual.NombreUsuario);

                    var pRes = new SqlParameter("@resultado", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var pMsg = new SqlParameter("@mensaje", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(pRes);
                    cmd.Parameters.Add(pMsg);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = pMsg.Value.ToString();
                    return (int)pRes.Value == 0;
                }
            }
            catch (SqlException ex)
            {
                mensaje = "Error de base de datos al aprobar solicitud: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al aprobar solicitud: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Rechazar
        // --------------------------------------------------------
        public bool Rechazar(int idSolicitud, string observaciones, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_RechazarSolicitud", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);
                    cmd.Parameters.AddWithValue("@idUsuarioGestor", SesionActual.IdUsuario);
                    cmd.Parameters.AddWithValue("@observaciones", observaciones);
                    cmd.Parameters.AddWithValue("@usuarioSesion", SesionActual.NombreUsuario);

                    var pRes = new SqlParameter("@resultado", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var pMsg = new SqlParameter("@mensaje", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(pRes);
                    cmd.Parameters.Add(pMsg);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = pMsg.Value.ToString();
                    return (int)pRes.Value == 0;
                }
            }
            catch (SqlException ex)
            {
                mensaje = "Error de base de datos al rechazar solicitud: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al rechazar solicitud: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Listar
        // --------------------------------------------------------
        public List<SolicitudVacaciones> Listar(int? idEmpleado = null,
                                                int? idTipoPermiso = null,
                                                string estado = null,
                                                DateTime? fechaDesde = null,
                                                DateTime? fechaHasta = null,
                                                string buscarEmp = null)
        {
            var lista = new List<SolicitudVacaciones>();
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarSolicitudes", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@filtroIdEmpleado", (object)idEmpleado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroIdTipoPermiso", (object)idTipoPermiso ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroEstado", (object)estado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroFechaDesde", (object)fechaDesde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroFechaHasta", (object)fechaHasta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroBuscarEmp", (object)buscarEmp ?? DBNull.Value);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new SolicitudVacaciones
                            {
                                IdSolicitud = (int)dr["idSolicitud"],
                                CedulaEmpleado = dr["cedula"].ToString(),
                                NombreEmpleado = dr["nombreEmpleado"].ToString(),
                                TipoPermiso = dr["tipoPermiso"].ToString(),
                                FechaInicio = (DateTime)dr["fechaInicio"],
                                FechaFin = (DateTime)dr["fechaFin"],
                                CantidadDias = (decimal)dr["cantidadDias"],
                                Motivo = dr["motivo"].ToString(),
                                Estado = dr["estado"].ToString(),
                                Observaciones = dr["observaciones"] != DBNull.Value ? dr["observaciones"].ToString() : null,
                                FechaSolicitud = (DateTime)dr["fechaSolicitud"],
                                FechaGestion = dr["fechaGestion"] != DBNull.Value ? (DateTime?)dr["fechaGestion"] : null,
                                UsuarioGestor = dr["usuarioGestor"] != DBNull.Value ? dr["usuarioGestor"].ToString() : null
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al listar solicitudes: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar solicitudes: " + ex.Message);
            }
            return lista;
        }

        // --------------------------------------------------------
        // ObtenerPorId
        // --------------------------------------------------------
        public SolicitudVacaciones ObtenerPorId(int idSolicitud)
        {
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ObtenerSolicitudPorId", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new SolicitudVacaciones
                            {
                                IdSolicitud = (int)dr["idSolicitud"],
                                IdEmpleado = (int)dr["idEmpleado"],
                                CedulaEmpleado = dr["cedula"].ToString(),
                                NombreEmpleado = dr["nombreEmpleado"].ToString(),
                                IdTipoPermiso = (int)dr["idTipoPermiso"],
                                TipoPermiso = dr["tipoPermiso"].ToString(),
                                FechaInicio = (DateTime)dr["fechaInicio"],
                                FechaFin = (DateTime)dr["fechaFin"],
                                CantidadDias = (decimal)dr["cantidadDias"],
                                Motivo = dr["motivo"].ToString(),
                                Comprobante = dr["comprobante"] != DBNull.Value ? (byte[])dr["comprobante"] : null,
                                Estado = dr["estado"].ToString(),
                                Observaciones = dr["observaciones"] != DBNull.Value ? dr["observaciones"].ToString() : null,
                                FechaSolicitud = (DateTime)dr["fechaSolicitud"],
                                FechaGestion = dr["fechaGestion"] != DBNull.Value ? (DateTime?)dr["fechaGestion"] : null
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al obtener solicitud: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener solicitud: " + ex.Message);
            }
            return null;
        }
    }
}
