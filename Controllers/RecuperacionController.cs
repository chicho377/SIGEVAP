using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace SIGEVAP.Controllers
{
    internal class RecuperacionController
    {
        // --------------------------------------------------------
        // GenerarCodigo + Enviar correo
        // --------------------------------------------------------
        public bool GenerarCodigo(string correo, out string codigo, out string mensaje)
        {
            codigo = null;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_GenerarCodigoRecuperacion", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@correoElectronico", correo);

                    var pCodigo = new SqlParameter("@codigo", SqlDbType.VarChar, 6) { Direction = ParameterDirection.Output };
                    var pRes = new SqlParameter("@resultado", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var pMsg = new SqlParameter("@mensaje", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(pCodigo);
                    cmd.Parameters.Add(pRes);
                    cmd.Parameters.Add(pMsg);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    mensaje = pMsg.Value.ToString();
                    codigo = pCodigo.Value != DBNull.Value ? pCodigo.Value.ToString() : null;
                    bool ok = (int)pRes.Value == 0;

                    // Si el SP generó el código correctamente, enviarlo por correo
                    if (ok && !string.IsNullOrEmpty(codigo))
                    {
                        bool enviado = EnviarCorreoCodigo(correo, codigo, out string errCorreo);
                        if (!enviado)
                        {
                            // El código se generó en BD pero no se pudo enviar el correo
                            mensaje = "Código generado pero no se pudo enviar el correo: " + errCorreo;
                            return false;
                        }
                    }

                    return ok;
                }
            }
            catch (SqlException ex)
            {
                mensaje = "Error de base de datos al generar código: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al generar código: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // EnviarCorreoCodigo — SMTP Gmail con template HTML
        // --------------------------------------------------------
        private bool EnviarCorreoCodigo(string destinatario, string codigo, out string error)
        {
            error = string.Empty;
            try
            {
                // Leer credenciales del App.config
                string remitente = ConfigurationManager.AppSettings["SmtpCorreo"];
                string claveApp = ConfigurationManager.AppSettings["SmtpClave"];
                string nombreSistema = ConfigurationManager.AppSettings["SistemaNombre"] ?? "SIGEVAP";

                if (string.IsNullOrEmpty(remitente) || string.IsNullOrEmpty(claveApp))
                {
                    error = "No se encontraron las credenciales SMTP en App.config.";
                    return false;
                }

                // Separar los dígitos para mostrarlos grandes en el correo
                string d1 = codigo[0].ToString();
                string d2 = codigo[1].ToString();
                string d3 = codigo[2].ToString();
                string d4 = codigo[3].ToString();
                string d5 = codigo[4].ToString();
                string d6 = codigo[5].ToString();

                string html = $@"
<!DOCTYPE html>
<html lang='es'>
<head>
  <meta charset='UTF-8'>
  <meta name='viewport' content='width=device-width, initial-scale=1.0'>
  <title>Código de recuperación</title>
</head>
<body style='margin:0;padding:0;background-color:#0d0d0d;font-family:Segoe UI,Arial,sans-serif;'>

  <!-- Wrapper -->
  <table width='100%' cellpadding='0' cellspacing='0' style='background-color:#0d0d0d;padding:40px 0;'>
    <tr>
      <td align='center'>

        <!-- Card principal -->
        <table width='520' cellpadding='0' cellspacing='0'
               style='background-color:#111111;border-radius:16px;overflow:hidden;'>

          <!-- Header amarillo -->
          <tr>
            <td align='center'
                style='background-color:#F5C400;padding:36px 40px 28px;'>

              <!-- Logo -->
              <table cellpadding='0' cellspacing='0'>
                <tr>
                  <td align='center'
                      style='background-color:#0d0d0d;border-radius:14px;
                             width:64px;height:64px;'>
                    <span style='font-size:18px;font-weight:900;
                                 color:#F5C400;letter-spacing:2px;
                                 font-family:Impact,Arial Black,sans-serif;'>
                      SGV
                    </span>
                  </td>
                </tr>
              </table>

              <p style='margin:14px 0 4px;font-size:26px;font-weight:900;
                        color:#0d0d0d;letter-spacing:2px;
                        font-family:Impact,Arial Black,sans-serif;'>
                {nombreSistema}
              </p>
              <p style='margin:0;font-size:11px;color:rgba(0,0,0,0.5);
                        letter-spacing:1.5px;text-transform:uppercase;'>
                Sistema de Gestión de Vacaciones y Permisos
              </p>
            </td>
          </tr>

          <!-- Cuerpo -->
          <tr>
            <td style='padding:40px 48px 32px;'>

              <p style='margin:0 0 6px;font-size:20px;font-weight:700;
                        color:#ffffff;'>
                Recuperación de contraseña
              </p>
              <p style='margin:0 0 28px;font-size:14px;color:rgba(255,255,255,0.45);
                        line-height:1.6;'>
                Recibiste este correo porque solicitaste restablecer tu contraseña en
                <strong style='color:rgba(255,255,255,0.7);'>{nombreSistema}</strong>.
                Usá el siguiente código de verificación:
              </p>

              <!-- Dígitos del código -->
              <table cellpadding='0' cellspacing='0' width='100%'>
                <tr>
                  <td align='center' style='padding-bottom:28px;'>
                    <table cellpadding='0' cellspacing='0'>
                      <tr>
                        {DigitoHtml(d1)}
                        <td width='10'></td>
                        {DigitoHtml(d2)}
                        <td width='10'></td>
                        {DigitoHtml(d3)}
                        <td width='18'></td>
                        {DigitoHtml(d4)}
                        <td width='10'></td>
                        {DigitoHtml(d5)}
                        <td width='10'></td>
                        {DigitoHtml(d6)}
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>

              <!-- Aviso de expiración -->
              <table cellpadding='0' cellspacing='0' width='100%'
                     style='background-color:#1a1a1a;border-radius:10px;
                            margin-bottom:28px;'>
                <tr>
                  <td style='padding:14px 18px;'>
                    <p style='margin:0;font-size:13px;color:rgba(255,255,255,0.5);
                              line-height:1.5;'>
                      ⏱&nbsp; Este código es válido por
                      <strong style='color:#F5C400;'>10 minutos</strong>
                      a partir de este momento. No lo compartás con nadie.
                    </p>
                  </td>
                </tr>
              </table>

              <!-- Aviso de seguridad -->
              <table cellpadding='0' cellspacing='0' width='100%'
                     style='border-left:3px solid #F5C400;
                            background-color:rgba(245,196,0,0.06);
                            border-radius:0 8px 8px 0;
                            margin-bottom:32px;'>
                <tr>
                  <td style='padding:12px 16px;'>
                    <p style='margin:0;font-size:12px;
                              color:rgba(255,255,255,0.4);line-height:1.6;'>
                      Si no solicitaste este código, podés ignorar este correo.
                      Tu contraseña <strong style='color:rgba(255,255,255,0.6);'>
                      no cambiará</strong> a menos que lo ingreses en el sistema.
                    </p>
                  </td>
                </tr>
              </table>

            </td>
          </tr>

          <!-- Footer -->
          <tr>
            <td style='background-color:#0d0d0d;padding:20px 48px;
                       border-top:1px solid rgba(255,255,255,0.06);'>
              <p style='margin:0;font-size:11px;color:rgba(255,255,255,0.2);
                        text-align:center;line-height:1.7;'>
                {nombreSistema} &nbsp;·&nbsp; Este es un correo automático,
                por favor no respondas a este mensaje.<br>
                © {DateTime.Now.Year} Todos los derechos reservados.
              </p>
            </td>
          </tr>

        </table>
        <!-- Fin card -->

      </td>
    </tr>
  </table>

</body>
</html>";

                // Configurar el mensaje
                var mail = new MailMessage
                {
                    From = new MailAddress(remitente, nombreSistema),
                    Subject = $"🔐 Tu código de verificación: {codigo} — {nombreSistema}",
                    Body = html,
                    IsBodyHtml = true
                };
                mail.To.Add(destinatario);

                // Configurar cliente SMTP Gmail
                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(remitente, claveApp),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                smtp.Send(mail);
                return true;
            }
            catch (SmtpException ex)
            {
                error = "Error SMTP al enviar el correo: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                error = "Error inesperado al enviar el correo: " + ex.Message;
                return false;
            }
        }

        // Helper: genera el TD de un dígito del código
        private string DigitoHtml(string digito)
        {
            return $@"
              <td align='center'
                  style='background-color:#1a1a1a;
                         border:1.5px solid #F5C400;
                         border-radius:10px;
                         width:52px;height:58px;
                         font-size:28px;font-weight:900;
                         color:#F5C400;
                         font-family:Courier New,monospace;'>
                {digito}
              </td>";
        }

        // --------------------------------------------------------
        // VerificarCodigo
        // --------------------------------------------------------
        public bool VerificarCodigo(string correo, string codigo, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_VerificarCodigoRecuperacion", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@correoElectronico", correo);
                    cmd.Parameters.AddWithValue("@codigoIngresado", codigo);

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
                mensaje = "Error de base de datos al verificar código: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al verificar código: " + ex.Message;
                return false;
            }
        }

        // --------------------------------------------------------
        // CambiarContrasena
        // --------------------------------------------------------
        public bool CambiarContrasena(string correo, string nuevaContrasena, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                string hash = UsuarioController.HashSHA256(nuevaContrasena);
                using (SqlConnection cn = ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_CambiarContrasena", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@correoElectronico", correo);
                    cmd.Parameters.AddWithValue("@hashNuevaContrasena", hash);
                    cmd.Parameters.AddWithValue("@usuarioSesion", "RECUPERACION");

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
                mensaje = "Error de base de datos al cambiar contraseña: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado al cambiar contraseña: " + ex.Message;
                return false;
            }
        }
    }
}