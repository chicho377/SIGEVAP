using Microsoft.Data.SqlClient;
using SIGEVAP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIGEVAP.Controllers
{
    internal class UsuarioController
    {
        // --------------------------------------------------------
        // Login
        // --------------------------------------------------------
        public bool Login(string nombreUsuario, string contrasena,
                          out string mensaje, out int idIngreso)
        {
            string hash = HashSHA256(contrasena);
            idIngreso = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_Login", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@hashContrasena", hash);

                    var pResultado = new SqlParameter("@resultado", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var pMensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                    var pIdIngreso = new SqlParameter("@idIngreso", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(pResultado);
                    cmd.Parameters.Add(pMensaje);
                    cmd.Parameters.Add(pIdIngreso);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    int resultado = (int)pResultado.Value;
                    mensaje = pMensaje.Value.ToString();
                    idIngreso = pIdIngreso.Value != DBNull.Value ? (int)pIdIngreso.Value : 0;

                    if (resultado == 0)
                    {
                        CargarSesion(nombreUsuario, idIngreso, cn);
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                mensaje = "Error de base de datos al iniciar sesión: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al iniciar sesión: " + ex.Message;
                return false;
            }
        }

        private void CargarSesion(string nombreUsuario, int idIngreso, SqlConnection cn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT u.idUsuario, u.idRol, r.nombreRol,
                             u.idEmpleado, e.nombreCompleto
                      FROM dbo.Usuarios u
                      INNER JOIN dbo.Roles     r ON r.idRol      = u.idRol
                      INNER JOIN dbo.Empleados e ON e.idEmpleado = u.idEmpleado
                      WHERE u.nombreUsuario = @nombreUsuario", cn);

                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        SesionActual.IdIngreso = idIngreso;
                        SesionActual.NombreUsuario = nombreUsuario;
                        SesionActual.IdUsuario = (int)dr["idUsuario"];
                        SesionActual.IdRol = (int)dr["idRol"];
                        SesionActual.NombreRol = dr["nombreRol"].ToString();
                        SesionActual.IdEmpleado = (int)dr["idEmpleado"];
                        SesionActual.NombreEmpleado = dr["nombreCompleto"].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al cargar los datos de sesión: " + ex.Message);
            }
        }

        // --------------------------------------------------------
        // CerrarSesion
        // --------------------------------------------------------
        public void CerrarSesion()
        {
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_CerrarSesion", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idIngreso", SesionActual.IdIngreso);
                    cmd.Parameters.AddWithValue("@nombreUsuario", SesionActual.NombreUsuario);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al registrar el cierre de sesión: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al cerrar sesión: " + ex.Message);
            }
            finally
            {
                // Siempre limpiar la sesión aunque falle el registro en BD
                SesionActual.Limpiar();
            }
        }

        // --------------------------------------------------------
        // VerificarPermiso
        // --------------------------------------------------------
        public bool VerificarPermiso(string nombreModulo)
        {
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_VerificarPermiso", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombreUsuario", SesionActual.NombreUsuario);
                    cmd.Parameters.AddWithValue("@nombreModulo", nombreModulo);

                    var pAcceso = new SqlParameter("@tieneAcceso", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(pAcceso);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    return (bool)pAcceso.Value;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al verificar permisos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al verificar permisos: " + ex.Message);
            }
        }

        // --------------------------------------------------------
        // Insertar
        // --------------------------------------------------------
        public bool Insertar(Usuario u, string contrasena, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombreUsuario", u.NombreUsuario);
                    cmd.Parameters.AddWithValue("@hashContrasena", HashSHA256(contrasena));
                    cmd.Parameters.AddWithValue("@idRol", u.IdRol);
                    cmd.Parameters.AddWithValue("@idEmpleado", u.IdEmpleado);
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
                mensaje = "Error de base de datos al insertar usuario: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al insertar usuario: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Modificar
        // --------------------------------------------------------
        public bool Modificar(Usuario u, string nuevaContrasena, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ModificarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", u.IdUsuario);
                    cmd.Parameters.AddWithValue("@idRol", u.IdRol);
                    cmd.Parameters.AddWithValue("@usuarioSesion", SesionActual.NombreUsuario);
                    cmd.Parameters.AddWithValue("@hashContrasena",
                        !string.IsNullOrEmpty(nuevaContrasena)
                            ? (object)HashSHA256(nuevaContrasena)
                            : DBNull.Value);

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
                mensaje = "Error de base de datos al modificar usuario: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al modificar usuario: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Deshabilitar
        // --------------------------------------------------------
        public bool Deshabilitar(int idUsuario, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_DeshabilitarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
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
                mensaje = "Error de base de datos al deshabilitar usuario: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al deshabilitar usuario: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Listar
        // --------------------------------------------------------
        public List<Usuario> Listar(int? filtroEstado = null,
                                    int? filtroIdRol = null,
                                    string buscar = null)
        {
            var lista = new List<Usuario>();
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarUsuarios", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@filtroEstado", (object)filtroEstado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroIdRol", (object)filtroIdRol ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroBuscar", (object)buscar ?? DBNull.Value);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario
                            {
                                IdUsuario = (int)dr["idUsuario"],
                                NombreUsuario = dr["nombreUsuario"].ToString(),
                                NombreEmpleado = dr["nombreEmpleado"].ToString(),
                                NombreRol = dr["nombreRol"].ToString(),
                                Estado = (bool)dr["estado"],
                                Bloqueado = (bool)dr["bloqueado"],
                                IntentosFallidos = (byte)dr["intentosFallidos"]
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al listar usuarios: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar usuarios: " + ex.Message);
            }
            return lista;
        }

        // --------------------------------------------------------
        // HashSHA256 — utilitario estático (RNF-005)
        // --------------------------------------------------------
        public static string HashSHA256(string texto)
        {
            try
            {
                using (SHA256 sha = SHA256.Create())
                {
                    byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular el hash de la contraseña: " + ex.Message);
            }
        }
    }
}
