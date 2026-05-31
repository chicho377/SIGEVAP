// ============================================================
// SIGEVAP — Views/FrmLogin.cs
// Lógica, eventos, animaciones y estilos que WinForms Designer
// no soporta (bordes redondeados, fade-in, placeholder, Paint)
// ============================================================

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SIGEVAP.Controllers;

namespace SIGEVAP.Views
{
    public partial class FrmLogin : Form
    {
        // ── Paleta de colores (cambialos aquí para toda la form) ──
        private readonly Color C_NEGRO = Color.FromArgb(13, 13, 13);
        private readonly Color C_PANEL = Color.FromArgb(17, 17, 17);
        private readonly Color C_AMARILLO = Color.FromArgb(245, 196, 0);
        private readonly Color C_INPUT = Color.FromArgb(26, 26, 26);
        private readonly Color C_BORDE = Color.FromArgb(40, 40, 40);
        private readonly Color C_TEXTO = Color.White;
        private readonly Color C_SUBTEXTO = Color.FromArgb(100, 100, 100);

        // ── Placeholder original de cada campo ───────────────────
        private const string PH_USUARIO = "Nombre de usuario";
        private const string PH_CONTRASENA = "Contraseña";

        // ── Timer para fade-in de entrada ────────────────────────
        private System.Windows.Forms.Timer _timerFade;
        private double _opacidad = 0;

        private readonly UsuarioController _ctrlUsuario = new UsuarioController();
        private readonly RecuperacionController _ctrlRecuperacion = new RecuperacionController();

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        public FrmLogin()
        {
            InitializeComponent();   // carga el Designer
            AplicarEstilos();        // bordes redondeados y región
            ConfigurarEventos();     // eventos de lógica
            IniciarFadeIn();         // animación de entrada
        }

        // ============================================================
        // ESTILOS QUE EL DESIGNER NO SOPORTA
        // (bordes redondeados, región, Paint de paneles y picLogo)
        // ============================================================
        private void AplicarEstilos()
        {
            // Región redondeada del formulario completo
            SetRegionRedondeada(this, 14);

            // Borde redondeado del logo negro
            SetRegionRedondeada(picLogo, 18);

            // Borde redondeado del botón ingresar
            SetRegionRedondeada(btnIngresar, 10);

            // Borde redondeado del label de error
            SetRegionRedondeada(lblError, 6);

            // Paint del panel izquierdo: círculos decorativos
            pnlIzquierdo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(
                    new SolidBrush(Color.FromArgb(18, 0, 0, 0)),
                    210, 360, 200, 200);
                e.Graphics.FillEllipse(
                    new SolidBrush(Color.FromArgb(12, 0, 0, 0)),
                    -60, -40, 160, 160);
            };

            // Paint del picLogo: dibuja "SGV" en amarillo
            picLogo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var f = new Font("Impact", 16F))
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

            // Paint de los paneles-wrapper de inputs: borde redondeado con
            // color amarillo cuando el campo adentro tiene el foco
            pnlWrapUsuario.Paint += PaintWrap;
            pnlWrapContrasena.Paint += PaintWrap;
        }

        private void PaintWrap(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool activo = panel.Tag?.ToString() == "activo";
            Color borde = activo ? C_AMARILLO : C_BORDE;

            using (var path = RectRedondeado(
                       new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 8))
            using (var br = new SolidBrush(C_INPUT))
            using (var pen = new Pen(borde, 1.5f))
            {
                e.Graphics.FillPath(br, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        // ============================================================
        // EVENTOS DE LÓGICA
        // ============================================================
        private void ConfigurarEventos()
        {
            // Cerrar aplicación
            btnCerrar.Click += (s, e) => Application.Exit();

            // Botón ingresar y Enter
            btnIngresar.Click += BtnIngresar_Click;
            txtUsuario.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnIngresar_Click(s, e); };
            txtContrasena.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnIngresar_Click(s, e); };

            // Botón mostrar/ocultar contraseña
            btnMostrar.Click += BtnMostrar_Click;

            // ¿Olvidaste tu contraseña?
            lblOlvide.Click += (s, e) => new FrmRecuperacion().ShowDialog(this);

            // Placeholder usuario
            ConfigurarPlaceholder(txtUsuario, pnlWrapUsuario, PH_USUARIO, false);

            // Placeholder contraseña
            ConfigurarPlaceholder(txtContrasena, pnlWrapContrasena, PH_CONTRASENA, true);
        }

        // ── Placeholder manual (WinForms no tiene uno nativo) ────
        private void ConfigurarPlaceholder(TextBox txt, Panel wrap,
                                           string placeholder, bool esPassword)
        {
            // Mostrar placeholder visible (sin asteriscos) al inicio
            txt.UseSystemPasswordChar = false;
            txt.Text = placeholder;
            txt.ForeColor = C_SUBTEXTO;

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = string.Empty;
                    txt.ForeColor = C_TEXTO;
                    // Activar asteriscos solo cuando el usuario empieza a escribir
                    if (esPassword) txt.UseSystemPasswordChar = true;
                }
                wrap.Tag = "activo";
                wrap.Invalidate();
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrEmpty(txt.Text))
                {
                    // Volver al placeholder visible (sin asteriscos)
                    txt.UseSystemPasswordChar = false;
                    txt.Text = placeholder;
                    txt.ForeColor = C_SUBTEXTO;
                }
                wrap.Tag = "";
                wrap.Invalidate();
            };
        }

        // ============================================================
        // EVENTOS DE BOTONES
        // ============================================================
        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            // Solo actúa si el campo tiene contenido real (no el placeholder)
            if (txtContrasena.Text == PH_CONTRASENA) return;

            txtContrasena.UseSystemPasswordChar = !txtContrasena.UseSystemPasswordChar;
            btnMostrar.Text = txtContrasena.UseSystemPasswordChar ? "👁" : "🙈";
            btnMostrar.ForeColor = txtContrasena.UseSystemPasswordChar
                                   ? C_SUBTEXTO
                                   : C_AMARILLO;
            txtContrasena.Focus();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            OcultarError();

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            // Validaciones básicas RF-006
            if (string.IsNullOrEmpty(usuario) || usuario == PH_USUARIO)
            {
                MostrarError("El campo usuario es obligatorio.");
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrEmpty(contrasena) || contrasena == PH_CONTRASENA)
            {
                MostrarError("El campo contraseña es obligatorio.");
                txtContrasena.Focus();
                return;
            }

            btnIngresar.Enabled = false;
            btnIngresar.Text = "VERIFICANDO...";

            try
            {
                bool ok = _ctrlUsuario.Login(usuario, contrasena,
                                             out string mensaje, out int idIngreso);
                if (ok)
                {
                    var menu = new FrmMenu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MostrarError(mensaje);
                    txtContrasena.Text = PH_CONTRASENA;
                    txtContrasena.ForeColor = C_SUBTEXTO;
                    txtContrasena.UseSystemPasswordChar = false;
                    txtContrasena.Focus();
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error de conexión: " + ex.Message);
            }
            finally
            {
                btnIngresar.Enabled = true;
                btnIngresar.Text = "INGRESAR AL SISTEMA";
            }
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
                _opacidad += 0.055;
                if (_opacidad >= 1) { _opacidad = 1; _timerFade.Stop(); }
                this.Opacity = _opacidad;
            };
            this.Shown += (s, e) => _timerFade.Start();
        }

        // ============================================================
        // HELPERS DE ERROR
        // ============================================================
        private void MostrarError(string mensaje)
        {
            lblError.Text = "  ⚠  " + mensaje;
            lblError.Visible = true;
        }

        private void OcultarError()
        {
            lblError.Text = string.Empty;
            lblError.Visible = false;
        }

        // ============================================================
        // HELPERS DE DIBUJO
        // ============================================================
        private void SetRegionRedondeada(Control ctrl, int radio)
        {
            var path = RectRedondeado(
                new Rectangle(0, 0, ctrl.Width, ctrl.Height), radio);
            ctrl.Region = new Region(path);
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

        // ── API Windows para arrastrar ventana sin bordes ────────
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
    }
}