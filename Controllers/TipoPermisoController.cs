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
    internal class TipoPermisoController
    {
        // --------------------------------------------------------
        // Insertar
        // --------------------------------------------------------
        public bool Insertar(TipoPermiso t, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertarTipoPermiso", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombrePermiso", t.NombrePermiso);
                    cmd.Parameters.AddWithValue("@descripcion", (object)t.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantMaximaDias", t.CantMaximaDias);
                    cmd.Parameters.AddWithValue("@requiereComprobante", t.RequiereComprobante);
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
                mensaje = "Error de base de datos al insertar tipo de permiso: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al insertar tipo de permiso: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Modificar
        // --------------------------------------------------------
        public bool Modificar(TipoPermiso t, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ModificarTipoPermiso", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoPermiso", t.IdTipoPermiso);
                    cmd.Parameters.AddWithValue("@nombrePermiso", t.NombrePermiso);
                    cmd.Parameters.AddWithValue("@descripcion", (object)t.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantMaximaDias", t.CantMaximaDias);
                    cmd.Parameters.AddWithValue("@requiereComprobante", t.RequiereComprobante);
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
                mensaje = "Error de base de datos al modificar tipo de permiso: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al modificar tipo de permiso: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Deshabilitar
        // --------------------------------------------------------
        public bool Deshabilitar(int idTipoPermiso, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_DeshabilitarTipoPermiso", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoPermiso", idTipoPermiso);
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
                mensaje = "Error de base de datos al deshabilitar tipo de permiso: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al deshabilitar tipo de permiso: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Listar
        // --------------------------------------------------------
        public List<TipoPermiso> Listar(bool soloActivos = true, string buscar = null)
        {
            var lista = new List<TipoPermiso>();
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarTiposPermisos", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@soloActivos", soloActivos ? 1 : 0);
                    cmd.Parameters.AddWithValue("@filtroBuscar", (object)buscar ?? DBNull.Value);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new TipoPermiso
                            {
                                IdTipoPermiso = (int)dr["idTipoPermiso"],
                                NombrePermiso = dr["nombrePermiso"].ToString(),
                                Descripcion = dr["descripcion"] != DBNull.Value ? dr["descripcion"].ToString() : null,
                                CantMaximaDias = (decimal)dr["cantMaximaDias"],
                                RequiereComprobante = (bool)dr["requiereComprobante"],
                                Estado = (bool)dr["estado"]
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al listar tipos de permisos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar tipos de permisos: " + ex.Message);
            }
            return lista;
        }
    }
}
