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
    internal class EmpleadoController
    {
        // --------------------------------------------------------
        // Insertar
        // --------------------------------------------------------
        public bool Insertar(Empleado e, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cedula", e.Cedula);
                    cmd.Parameters.AddWithValue("@nombreCompleto", e.NombreCompleto);
                    cmd.Parameters.AddWithValue("@correoElectronico", e.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@telefono", (object)e.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", (object)e.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@puesto", e.Puesto);
                    cmd.Parameters.AddWithValue("@fechaIngreso", e.FechaIngreso);
                    cmd.Parameters.AddWithValue("@salario", e.Salario);
                    cmd.Parameters.AddWithValue("@imagen", (object)e.Imagen ?? DBNull.Value);
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
                mensaje = "Error de base de datos al insertar empleado: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al insertar empleado: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Modificar
        // --------------------------------------------------------
        public bool Modificar(Empleado e, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ModificarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEmpleado", e.IdEmpleado);
                    cmd.Parameters.AddWithValue("@cedula", e.Cedula);
                    cmd.Parameters.AddWithValue("@nombreCompleto", e.NombreCompleto);
                    cmd.Parameters.AddWithValue("@correoElectronico", e.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@telefono", (object)e.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", (object)e.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@puesto", e.Puesto);
                    cmd.Parameters.AddWithValue("@fechaIngreso", e.FechaIngreso);
                    cmd.Parameters.AddWithValue("@salario", e.Salario);
                    cmd.Parameters.AddWithValue("@imagen", (object)e.Imagen ?? DBNull.Value);
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
                mensaje = "Error de base de datos al modificar empleado: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al modificar empleado: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Deshabilitar
        // --------------------------------------------------------
        public bool Deshabilitar(int idEmpleado, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_DeshabilitarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
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
                mensaje = "Error de base de datos al deshabilitar empleado: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al deshabilitar empleado: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // Listar
        // --------------------------------------------------------
        public List<Empleado> Listar(int? filtroEstado = null,
                                     string filtroPuesto = null,
                                     DateTime? fechaDesde = null,
                                     DateTime? fechaHasta = null,
                                     string buscar = null)
        {
            var lista = new List<Empleado>();
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarEmpleados", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@filtroEstado", (object)filtroEstado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroPuesto", (object)filtroPuesto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroFechaIngresoDesde", (object)fechaDesde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroFechaIngresoHasta", (object)fechaHasta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@filtroBuscar", (object)buscar ?? DBNull.Value);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Empleado
                            {
                                IdEmpleado = (int)dr["idEmpleado"],
                                Cedula = dr["cedula"].ToString(),
                                NombreCompleto = dr["nombreCompleto"].ToString(),
                                CorreoElectronico = dr["correoElectronico"].ToString(),
                                Telefono = dr["telefono"] != DBNull.Value ? dr["telefono"].ToString() : null,
                                Puesto = dr["puesto"].ToString(),
                                FechaIngreso = (DateTime)dr["fechaIngreso"],
                                Salario = (decimal)dr["salario"],
                                DiasVacacionesDisponibles = (decimal)dr["diasVacacionesDisponibles"],
                                Estado = (bool)dr["estado"]
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al listar empleados: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar empleados: " + ex.Message);
            }
            return lista;
        }

        // --------------------------------------------------------
        // ObtenerPorId
        // --------------------------------------------------------
        public Empleado ObtenerPorId(int idEmpleado)
        {
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ObtenerEmpleadoPorId", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new Empleado
                            {
                                IdEmpleado = (int)dr["idEmpleado"],
                                Cedula = dr["cedula"].ToString(),
                                NombreCompleto = dr["nombreCompleto"].ToString(),
                                CorreoElectronico = dr["correoElectronico"].ToString(),
                                Telefono = dr["telefono"] != DBNull.Value ? dr["telefono"].ToString() : null,
                                Direccion = dr["direccion"] != DBNull.Value ? dr["direccion"].ToString() : null,
                                Puesto = dr["puesto"].ToString(),
                                FechaIngreso = (DateTime)dr["fechaIngreso"],
                                Salario = (decimal)dr["salario"],
                                DiasVacacionesDisponibles = (decimal)dr["diasVacacionesDisponibles"],
                                Imagen = dr["imagen"] != DBNull.Value ? (byte[])dr["imagen"] : null,
                                Estado = (bool)dr["estado"]
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al obtener empleado: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener empleado: " + ex.Message);
            }
            return null;
        }
    }
}
