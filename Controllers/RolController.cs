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
    internal class RolController
    {
        // --------------------------------------------------------
        // Insertar
        // --------------------------------------------------------
        public bool Insertar(Rol r, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertarRol", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombreRol", r.NombreRol);
                    cmd.Parameters.AddWithValue("@descripcion", (object)r.Descripcion ?? DBNull.Value);
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
                mensaje = "Error de base de datos al insertar rol: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al insertar rol: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Modificar
        // --------------------------------------------------------
        public bool Modificar(Rol r, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ModificarRol", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRol", r.IdRol);
                    cmd.Parameters.AddWithValue("@nombreRol", r.NombreRol);
                    cmd.Parameters.AddWithValue("@descripcion", (object)r.Descripcion ?? DBNull.Value);
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
                mensaje = "Error de base de datos al modificar rol: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al modificar rol: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Deshabilitar
        // --------------------------------------------------------
        public bool Deshabilitar(int idRol, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_DeshabilitarRol", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRol", idRol);
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
                mensaje = "Error de base de datos al deshabilitar rol: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al deshabilitar rol: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Listar
        // --------------------------------------------------------
        public List<Rol> Listar(bool soloActivos = true)
        {
            var lista = new List<Rol>();
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarRoles", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@soloActivos", soloActivos ? 1 : 0);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol
                            {
                                IdRol = (int)dr["idRol"],
                                NombreRol = dr["nombreRol"].ToString(),
                                Descripcion = dr["descripcion"] != DBNull.Value ? dr["descripcion"].ToString() : null,
                                Estado = (bool)dr["estado"]
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al listar roles: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar roles: " + ex.Message);
            }
            return lista;
        }

        // --------------------------------------------------------
        // GuardarPermisos
        // --------------------------------------------------------
        public bool GuardarPermisos(int idRol, List<int> modulosActivos, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                string csv = string.Join(",", modulosActivos);
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_GuardarPermisosRol", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.Parameters.AddWithValue("@modulosActivos", csv);
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
                mensaje = "Error de base de datos al guardar permisos: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al guardar permisos: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // ObtenerPermisos
        // --------------------------------------------------------
        public List<RolPermiso> ObtenerPermisos(int idRol)
        {
            var lista = new List<RolPermiso>();
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ObtenerPermisosRol", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRol", idRol);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new RolPermiso
                            {
                                IdModulo = (int)dr["idModulo"],
                                NombreModulo = dr["nombreModulo"].ToString(),
                                TieneAcceso = (bool)dr["tieneAcceso"]
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al obtener permisos del rol: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener permisos del rol: " + ex.Message);
            }
            return lista;
        }
    }
}
