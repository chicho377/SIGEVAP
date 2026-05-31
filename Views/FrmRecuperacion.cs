// ============================================================
// SIGEVAP — Views/FrmRecuperacion.cs
// Lógica de los 3 pasos, animaciones, estilos Paint y timer
// ============================================================

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SIGEVAP.Controllers;
using System.Threading;

namespace SIGEVAP.Views
{
    public partial class FrmRecuperacion : Form
    {
        // ── Paleta ───────────────────────────────────────────
        private readonly Color C_NEGRO = Color.FromArgb(13, 13, 13);
        private readonly Color C_AMARILLO = Color.FromArgb(245, 196, 0);
        private readonly Color C_INPUT = Color.FromArgb(26, 26, 26);
        private readonly Color C_BORDE = Color.FromArgb(40, 40, 40);
        private readonly Color C_TEXTO = Color.White;
        private readonly Color C_SUBTEXTO = Color.FromArgb(100, 100, 100);

        // ── Placeholders ─────────────────────────────────────
        private const string PH_CORREO = "usuario@empresa.com";
        private const string PH_NUEVA = "Mínimo 8 caracteres";
        private const string PH_CONFIRMAR = "Repetí la contraseña";

        // ── Estado del formulario ─────────────────────────────
        private int _pasoActual = 1;
        private string _correoActual = string.Empty;
        private int _segundos = 600;

        // ── Timers ───────────────────────────────────────────
        private System.Windows.Forms.Timer _timerFade;
        private System.Windows.Forms.Timer _timerCodigo;
        private double _opacidad = 0;

        private readonly RecuperacionController _ctrl = new RecuperacionController();

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        public FrmRecuperacion()
        {
            InitializeComponent();
            AplicarEstilos();
            ConfigurarEventos();
            IniciarFadeIn();
        }

        // ============================================================
        // ESTILOS (Paint, bordes redondeados)
        // ============================================================
        private void AplicarEstilos()
        {
            SetRegion(this, 14);
            SetRegion(picLogo, 16);
            SetRegion(picCheck, 32);   // círculo para el check
            SetRegion(btnEnviarCodigo, 10);
            SetRegion(btnVerificar, 10);
            SetRegion(btnGuardar, 10);
            SetRegion(btnIrLogin, 10);
            SetRegion(lblError, 6);
            SetRegion(lblExito, 6);

            // Paint panel izquierdo: círculos decorativos
            pnlIzquierdo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(18, 0, 0, 0)), 180, 340, 180, 180);
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(12, 0, 0, 0)), -40, -30, 130, 130);
            };

            // Paint picLogo: texto "SGV"
            picLogo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var f = new Font("Impact", 15F))
                using (var br = new SolidBrush(C_AMARILLO))
                {
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString("SGV", f, br,
                        new Rectangle(0, 0, picLogo.Width, picLogo.Height), sf);
                }
            };

            // Paint picCheck: dibuja un check "✓" en negro
            picCheck.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var f = new Font("Segoe UI", 26F, FontStyle.Bold))
                using (var br = new SolidBrush(C_NEGRO))
                {
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString("✓", f, br,
                        new Rectangle(0, 0, picCheck.Width, picCheck.Height), sf);
                }
            };

            // Paint de los wrappers de input: borde redondeado con foco amarillo
            pnlWrapCorreo.Paint += PaintWrap;
            pnlWrapNueva.Paint += PaintWrap;
            pnlWrapConfirmar.Paint += PaintWrap;

            // Estilo de los 6 inputs del código
            var codigos = new[] { txtCod1, txtCod2, txtCod3, txtCod4, txtCod5, txtCod6 };
            foreach (var c in codigos)
            {
                c.BorderStyle = BorderStyle.None;
                c.BackColor = C_INPUT;
                c.ForeColor = C_TEXTO;
                c.TextAlign = HorizontalAlignment.Center;
                c.Parent.Paint += (s, e) => { };   // forzar repaint padre
            }

            // Indicadores de paso: región circular para los números
            SetRegion(lblNumPaso1, 13);
            SetRegion(lblNumPaso2, 13);
            SetRegion(lblNumPaso3, 13);
        }

        private void PaintWrap(object sender, PaintEventArgs e)
        {
            var p = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            bool activo = p.Tag?.ToString() == "activo";
            using (var path = RectRedondeado(new Rectangle(0, 0, p.Width - 1, p.Height - 1), 8))
            using (var br = new SolidBrush(C_INPUT))
            using (var pen = new Pen(activo ? C_AMARILLO : C_BORDE, 1.5f))
            {
                e.Graphics.FillPath(br, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        // ============================================================
        // EVENTOS
        // ============================================================
        private void ConfigurarEventos()
        {
            // Cerrar
            btnCerrar.Click += (s, e) => this.Close();

            // Volver al login
            lblVolver.Click += (s, e) => this.Close();

            // Paso 1 → 2
            btnEnviarCodigo.Click += BtnEnviarCodigo_Click;
            txtCorreo.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnEnviarCodigo_Click(s, e); };

            // Paso 2 → 3
            btnVerificar.Click += BtnVerificar_Click;
            lblReenviar.Click += LblReenviar_Click;

            // Paso 3 → 4
            btnGuardar.Click += BtnGuardar_Click;
            txtNueva.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnGuardar_Click(s, e); };
            txtConfirmar.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnGuardar_Click(s, e); };

            // Paso 4: volver al login
            btnIrLogin.Click += (s, e) => this.Close();

            // Ojo de contraseñas
            btnOjoNueva.Click += (s, e) => ToggleOjo(txtNueva, btnOjoNueva);
            btnOjoConfirmar.Click += (s, e) => ToggleOjo(txtConfirmar, btnOjoConfirmar);

            // Placeholders
            ConfigurarPlaceholder(txtCorreo, pnlWrapCorreo, PH_CORREO, false);
            ConfigurarPlaceholder(txtNueva, pnlWrapNueva, PH_NUEVA, true);
            ConfigurarPlaceholder(txtConfirmar, pnlWrapConfirmar, PH_CONFIRMAR, true);

            // Auto-avance entre los 6 dígitos del código
            var codigos = new[] { txtCod1, txtCod2, txtCod3, txtCod4, txtCod5, txtCod6 };
            for (int i = 0; i < codigos.Length; i++)
            {
                int idx = i;
                codigos[idx].TextChanged += (s, e) =>
                {
                    // Avanzar al siguiente si hay un dígito
                    if (codigos[idx].Text.Length == 1 && idx < codigos.Length - 1)
                        codigos[idx + 1].Focus();
                };
                codigos[idx].KeyDown += (s, e) =>
                {
                    // Retroceder con Backspace
                    if (e.KeyCode == Keys.Back && codigos[idx].Text.Length == 0 && idx > 0)
                    {
                        codigos[idx - 1].Focus();
                        codigos[idx - 1].Clear();
                    }
                    // Verificar con Enter desde cualquier dígito
                    if (e.KeyCode == Keys.Enter) BtnVerificar_Click(s, e);
                };
                // Solo números
                codigos[idx].KeyPress += (s, e) =>
                {
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                        e.Handled = true;
                };
                // Paint del borde de cada input de código
                codigos[idx].GotFocus += (s, e) => { (s as Control).Parent?.Invalidate(); };
                codigos[idx].LostFocus += (s, e) => { (s as Control).Parent?.Invalidate(); };
            }

            // Paint panel de códigos: bordes redondeados individuales
            pnlCodigos.Paint += PnlCodigos_Paint;
        }

        // ============================================================
        // LÓGICA DE LOS 3 PASOS
        // ============================================================

        // ── Paso 1: Enviar código ─────────────────────────────
        private void BtnEnviarCodigo_Click(object sender, EventArgs e)
        {
            OcultarMensajes();
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(correo) || correo == PH_CORREO)
            {
                MostrarError("El correo electrónico es obligatorio.");
                return;
            }
            if (!correo.Contains("@") || !correo.Contains("."))
            {
                MostrarError("Ingresá un correo electrónico válido.");
                return;
            }

            btnEnviarCodigo.Enabled = false;
            btnEnviarCodigo.Text = "ENVIANDO...";

            try
            {
                bool ok = _ctrl.GenerarCodigo(correo, out string codigo, out string mensaje);

                if (ok)
                {
                    _correoActual = correo;

                    // En producción el código se envía por correo.
                    // En desarrollo se puede mostrar temporalmente:
                    // MostrarExito("Código generado: " + codigo);

                    lblSub2.Text = "Código enviado a " + correo;
                    IrAlPaso(2);
                    IniciarTimerCodigo();
                    txtCod1.Focus();
                }
                else
                {
                    MostrarError(mensaje);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error de conexión: " + ex.Message);
            }
            finally
            {
                btnEnviarCodigo.Enabled = true;
                btnEnviarCodigo.Text = "ENVIAR CÓDIGO";
            }
        }

        // ── Paso 2: Verificar código ──────────────────────────
        private void BtnVerificar_Click(object sender, EventArgs e)
        {
            OcultarMensajes();

            string codigo = txtCod1.Text + txtCod2.Text + txtCod3.Text
                          + txtCod4.Text + txtCod5.Text + txtCod6.Text;

            if (codigo.Length < 6)
            {
                MostrarError("Ingresá los 6 dígitos del código.");
                return;
            }

            btnVerificar.Enabled = false;
            btnVerificar.Text = "VERIFICANDO...";

            try
            {
                bool ok = _ctrl.VerificarCodigo(_correoActual, codigo, out string mensaje);

                if (ok)
                {
                    _timerCodigo?.Stop();
                    IrAlPaso(3);
                    txtNueva.Focus();
                }
                else
                {
                    MostrarError(mensaje);
                    LimpiarCodigos();
                    txtCod1.Focus();
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error de conexión: " + ex.Message);
            }
            finally
            {
                btnVerificar.Enabled = true;
                btnVerificar.Text = "VERIFICAR CÓDIGO";
            }
        }

        // ── Paso 2: Reenviar código ───────────────────────────
        private void LblReenviar_Click(object sender, EventArgs e)
        {
            OcultarMensajes();
            LimpiarCodigos();

            try
            {
                bool ok = _ctrl.GenerarCodigo(_correoActual, out string codigo, out string mensaje);

                if (ok)
                {
                    MostrarExito("Código reenviado exitosamente.");
                    IniciarTimerCodigo();
                    txtCod1.Focus();
                }
                else
                {
                    MostrarError(mensaje);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al reenviar: " + ex.Message);
            }
        }

        // ── Paso 3: Guardar contraseña ────────────────────────
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            OcultarMensajes();

            string nueva = txtNueva.Text;
            string confirmar = txtConfirmar.Text;

            if (string.IsNullOrEmpty(nueva) || nueva == PH_NUEVA)
            {
                MostrarError("Ingresá la nueva contraseña.");
                txtNueva.Focus();
                return;
            }
            if (nueva.Length < 8)
            {
                MostrarError("La contraseña debe tener al menos 8 caracteres.");
                txtNueva.Focus();
                return;
            }
            if (nueva != confirmar)
            {
                MostrarError("Las contraseñas no coinciden.");
                txtConfirmar.Focus();
                return;
            }

            btnGuardar.Enabled = false;
            btnGuardar.Text = "GUARDANDO...";

            try
            {
                bool ok = _ctrl.CambiarContrasena(_correoActual, nueva, out string mensaje);

                if (ok)
                    IrAlPaso(4);
                else
                    MostrarError(mensaje);
            }
            catch (Exception ex)
            {
                MostrarError("Error de conexión: " + ex.Message);
            }
            finally
            {
                btnGuardar.Enabled = true;
                btnGuardar.Text = "GUARDAR CONTRASEÑA";
            }
        }

        // ============================================================
        // NAVEGACIÓN ENTRE PASOS
        // ============================================================
        private void IrAlPaso(int paso)
        {
            // Ocultar panel actual con fade rápido y mostrar el nuevo
            var paneles = new[] { pnlStep1, pnlStep2, pnlStep3, pnlStep4 };
            foreach (var p in paneles) p.Visible = false;
            paneles[paso - 1].Visible = true;

            _pasoActual = paso;
            ActualizarIndicadores(paso);
            OcultarMensajes();
        }

        private void ActualizarIndicadores(int pasoActivo)
        {
            // lblNumPasoX: activo = fondo negro + texto amarillo
            // inactivo   = fondo negro + texto gris
            var nums = new[] { lblNumPaso1, lblNumPaso2, lblNumPaso3 };
            var textos = new[] { lblTextoPaso1, lblTextoPaso2, lblTextoPaso3 };

            for (int i = 0; i < 3; i++)
            {
                bool activo = (i + 1 == pasoActivo);
                nums[i].ForeColor = activo ? C_AMARILLO : Color.FromArgb(60, 60, 60);
                textos[i].Font = new Font("Segoe UI", 9F,
                                               activo ? FontStyle.Bold : FontStyle.Regular);
                textos[i].ForeColor = activo ? C_NEGRO : Color.FromArgb(80, 80, 80);
            }
        }

        // ============================================================
        // TIMER DEL CÓDIGO (10 minutos)
        // ============================================================
        private void IniciarTimerCodigo()
        {
            _segundos = 600;
            _timerCodigo?.Stop();
            _timerCodigo = new System.Windows.Forms.Timer { Interval = 1000 };
            _timerCodigo.Tick += (s, e) =>
            {
                _segundos--;
                int m = _segundos / 60;
                int sec = _segundos % 60;
                lblTimer.Text = $"Código válido por {m:D2}:{sec:D2}";

                if (_segundos <= 0)
                {
                    _timerCodigo.Stop();
                    lblTimer.Text = "El código ha expirado. Solicitá uno nuevo.";
                    lblTimer.ForeColor = Color.FromArgb(240, 149, 149);
                    btnVerificar.Enabled = false;
                }
            };
            lblTimer.ForeColor = C_SUBTEXTO;
            btnVerificar.Enabled = true;
            _timerCodigo.Start();
        }

        private void LimpiarCodigos()
        {
            foreach (var c in new[] { txtCod1, txtCod2, txtCod3, txtCod4, txtCod5, txtCod6 })
                c.Clear();
        }

        // ============================================================
        // ANIMACIÓN FADE-IN
        // ============================================================
        private void IniciarFadeIn()
        {
            this.Opacity = 0;
            _timerFade = new System.Windows.Forms.Timer { Interval = 16 };
            _timerFade.Tick += (s, e) =>
            {
                _opacidad += 0.07;
                if (_opacidad >= 1) { _opacidad = 1; _timerFade.Stop(); }
                this.Opacity = _opacidad;
            };
            this.Shown += (s, e) => _timerFade.Start();
        }

        // ============================================================
        // HELPERS
        // ============================================================
        private void ToggleOjo(TextBox txt, Button btn)
        {
            string ph = txt == txtNueva ? PH_NUEVA : PH_CONFIRMAR;
            if (txt.Text == ph) return;
            txt.UseSystemPasswordChar = !txt.UseSystemPasswordChar;
            btn.Text = txt.UseSystemPasswordChar ? "👁" : "🙈";
            btn.ForeColor = txt.UseSystemPasswordChar ? C_SUBTEXTO : C_AMARILLO;
            txt.Focus();
        }

        private void ConfigurarPlaceholder(TextBox txt, Panel wrap,
                                           string placeholder, bool esPassword)
        {
            txt.UseSystemPasswordChar = false;
            txt.Text = placeholder;
            txt.ForeColor = C_SUBTEXTO;

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = string.Empty;
                    txt.ForeColor = C_TEXTO;
                    if (esPassword) txt.UseSystemPasswordChar = true;
                }
                wrap.Tag = "activo";
                wrap.Invalidate();
            };
            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrEmpty(txt.Text))
                {
                    txt.UseSystemPasswordChar = false;
                    txt.Text = placeholder;
                    txt.ForeColor = C_SUBTEXTO;
                }
                wrap.Tag = "";
                wrap.Invalidate();
            };
        }

        private void MostrarError(string msg)
        {
            lblError.Text = "  ⚠  " + msg;
            lblError.Visible = true;
            lblExito.Visible = false;
        }

        private void MostrarExito(string msg)
        {
            lblExito.Text = "  ✓  " + msg;
            lblExito.Visible = true;
            lblError.Visible = false;
        }

        private void OcultarMensajes()
        {
            lblError.Visible = false;
            lblExito.Visible = false;
        }

        // ── Paint bordes redondeados de cada input de código ──
        private void PnlCodigos_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var codigos = new[] { txtCod1, txtCod2, txtCod3, txtCod4, txtCod5, txtCod6 };

            foreach (var c in codigos)
            {
                bool foco = c.Focused;
                Color borde = foco ? C_AMARILLO : C_BORDE;

                using (var path = RectRedondeado(
                           new Rectangle(c.Left - 1, c.Top - 1, c.Width + 2, c.Height + 2), 8))
                using (var br = new SolidBrush(C_INPUT))
                using (var pen = new Pen(borde, 1.5f))
                {
                    e.Graphics.FillPath(br, path);
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        // ── Helpers de dibujo ─────────────────────────────────
        private void SetRegion(Control ctrl, int radio)
        {
            ctrl.Region = new Region(RectRedondeado(
                new Rectangle(0, 0, ctrl.Width, ctrl.Height), radio));
        }

        private GraphicsPath RectRedondeado(Rectangle r, int radio)
        {
            int d = radio * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ── Arrastrar ventana ─────────────────────────────────
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        // Limpiar timer al cerrar
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerCodigo?.Stop();
            _timerFade?.Stop();
            base.OnFormClosed(e);
        }
    }
}