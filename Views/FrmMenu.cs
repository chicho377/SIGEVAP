// ============================================================
// SIGEVAP — Views/FrmMenu.cs
// Lógica, eventos, animaciones y estilos Paint del menú principal
// ============================================================

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SIGEVAP.Controllers;
using SIGEVAP.Models;

namespace SIGEVAP.Views
{
    public partial class FrmMenu : Form
    {
        // ── Paleta ───────────────────────────────────────────
        private readonly Color C_NEGRO = Color.FromArgb(13, 13, 13);
        private readonly Color C_PANEL = Color.FromArgb(17, 17, 17);
        private readonly Color C_CARD = Color.FromArgb(22, 22, 22);
        private readonly Color C_AMARILLO = Color.FromArgb(245, 196, 0);
        private readonly Color C_TEXTO = Color.White;
        private readonly Color C_SUBTEXTO = Color.FromArgb(80, 80, 80);
        private readonly Color C_BORDE = Color.FromArgb(35, 35, 35);

        // ── Botón activo en sidebar ───────────────────────────
        private Button _btnActivo;

        // ── Timers ───────────────────────────────────────────
        private System.Windows.Forms.Timer _timerFade;
        private System.Windows.Forms.Timer _timerFecha;
        private double _opacidad = 0;

        // ── Controllers ──────────────────────────────────────
        private readonly EmpleadoController _ctrlEmp = new EmpleadoController();
        private readonly SolicitudController _ctrlSol = new SolicitudController();
        private readonly UsuarioController _ctrlUsr = new UsuarioController();

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        public FrmMenu()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarSesion();
            ConfigurarEventos();
            CargarDashboard();
            IniciarFadeIn();
            IniciarReloj();
        }

        // ============================================================
        // ESTILOS (Paint, bordes, regiones)
        // ============================================================
        private void AplicarEstilos()
        {
            // Región redondeada del form
            this.Resize += (s, e) => SetRegion(this, 12);
            SetRegion(this, 12);

            // Separador visual entre sidebar y main
            pnlSidebar.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(30, 255, 255, 255), 1))
                    e.Graphics.DrawLine(pen, pnlSidebar.Width - 1, 0,
                                             pnlSidebar.Width - 1, pnlSidebar.Height);
            };

            // Separador topbar
            pnlTopBar.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(30, 255, 255, 255), 1))
                    e.Graphics.DrawLine(pen, 0, pnlTopBar.Height - 1,
                                             pnlTopBar.Width, pnlTopBar.Height - 1);
            };

            // Paint del logo del sidebar: "SGV" en negro sobre fondo amarillo
            picLogoSb.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var f = new Font("Impact", 11F))
                using (var br = new SolidBrush(C_NEGRO))
                {
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString("SGV", f, br,
                        new Rectangle(0, 0, picLogoSb.Width, picLogoSb.Height), sf);
                }
            };
            SetRegion(picLogoSb, 9);

            // Paint del avatar: iniciales del usuario
            picAvatar.Paint += PicAvatar_Paint;
            SetRegion(picAvatar, 16);

            // Paint del ícono de bienvenida: sol ☀
            picWelcomeIcon.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var f = new Font("Segoe UI", 20F))
                using (var br = new SolidBrush(C_NEGRO))
                {
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString("☀", f, br,
                        new Rectangle(0, 0, picWelcomeIcon.Width, picWelcomeIcon.Height), sf);
                }
            };
            SetRegion(picWelcomeIcon, 10);

            // Paint del welcome bar: borde izquierdo amarillo
            pnlWelcome.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                // Borde amarillo izquierdo
                using (var br = new SolidBrush(C_AMARILLO))
                    e.Graphics.FillRectangle(br, 0, 0, 3, pnlWelcome.Height);
                // Borde general
                using (var pen = new Pen(Color.FromArgb(60, 245, 196, 0), 1))
                    e.Graphics.DrawRectangle(pen,
                        new Rectangle(0, 0, pnlWelcome.Width - 1, pnlWelcome.Height - 1));
            };
            SetRegion(pnlWelcome, 10);

            // Paint de las cards: borde redondeado con hover amarillo
            var cards = new[] { cardEmpleados, cardSolicitudes, cardReportes,
                                 cardUsuarios,  cardRoles,       cardBitacoras };
            foreach (var card in cards)
            {
                card.Paint += Card_Paint;
                SetRegion(card, 10);
            }

            // Paint de los stats: borde redondeado
            var stats = new[] { statEmpleados, statPendientes, statAprobadas, statUsuarios };
            foreach (var st in stats)
            {
                st.Paint += Stat_Paint;
                SetRegion(st, 10);
            }

            // Botón activo inicial: Inicio
            SetBtnActivo(btnNavInicio);
        }

        private void PicAvatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            string iniciales = ObtenerIniciales(SesionActual.NombreEmpleado);
            using (var f = new Font("Segoe UI", 10F, FontStyle.Bold))
            using (var br = new SolidBrush(C_NEGRO))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(iniciales, f, br,
                    new Rectangle(0, 0, picAvatar.Width, picAvatar.Height), sf);
            }
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            var card = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            bool hover = card.Tag?.ToString() == "hover";
            Color borde = hover ? Color.FromArgb(80, 245, 196, 0) : Color.FromArgb(35, 35, 35);

            using (var path = RectRedondeado(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 10))
            using (var br = new SolidBrush(C_CARD))
            using (var pen = new Pen(borde, 1f))
            {
                e.Graphics.FillPath(br, path);
                e.Graphics.DrawPath(pen, path);

                // Línea inferior amarilla en hover
                if (hover)
                {
                    using (var linea = new Pen(C_AMARILLO, 2f))
                        e.Graphics.DrawLine(linea, 10, card.Height - 2,
                                                       card.Width - 10, card.Height - 2);
                }
            }
        }

        private void Stat_Paint(object sender, PaintEventArgs e)
        {
            var st = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RectRedondeado(new Rectangle(0, 0, st.Width - 1, st.Height - 1), 10))
            using (var br = new SolidBrush(C_CARD))
            using (var pen = new Pen(C_BORDE, 1f))
            {
                e.Graphics.FillPath(br, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        // ============================================================
        // CARGAR DATOS DE SESIÓN
        // ============================================================
        private void CargarSesion()
        {
            lblUserNombre.Text = SesionActual.NombreEmpleado;
            lblUserRol.Text = SesionActual.NombreRol;
            lblWelcomeTitulo.Text = "Bienvenido, " + SesionActual.NombreEmpleado.Split(' ')[0];
            picAvatar.Invalidate();

            // Ocultar módulos según rol (RF-003)
            AplicarPermisosMenu();
        }

        private void AplicarPermisosMenu()
        {
            try
            {
                // Ocultar cada botón si el usuario no tiene permiso al módulo
                var mapa = new (Button btn, string modulo)[]
                {
                    (btnNavEmpleados,    "MantenimientoEmpleados"),
                    (btnNavUsuarios,     "MantenimientoUsuarios"),
                    (btnNavRoles,        "MantenimientoRolesPermisos"),
                    (btnNavTiposPermiso, "MantenimientoTiposPermisos"),
                    (btnNavGestion,      "GestionSolicitudes"),
                    (btnNavReportes,     "Reportes"),
                    (btnNavBitacoras,    "BitacoraMovimientos"),
                };

                foreach (var (btn, modulo) in mapa)
                {
                    bool acceso = _ctrlUsr.VerificarPermiso(modulo);
                    btn.Visible = acceso;
                }

                // Cards del dashboard según permisos
                cardEmpleados.Visible = btnNavEmpleados.Visible;
                cardUsuarios.Visible = btnNavUsuarios.Visible;
                cardRoles.Visible = btnNavRoles.Visible;
                cardSolicitudes.Visible = btnNavGestion.Visible;
                cardReportes.Visible = btnNavReportes.Visible;
                cardBitacoras.Visible = btnNavBitacoras.Visible;
            }
            catch { /* Si falla no bloquear el menú */ }
        }

        // ============================================================
        // DASHBOARD: cargar estadísticas
        // ============================================================
        private void CargarDashboard()
        {
            try
            {
                // Empleados activos
                var empleados = _ctrlEmp.Listar(filtroEstado: 1);
                lblStatEmpVal.Text = empleados.Count.ToString();

                // Solicitudes
                var pendientes = _ctrlSol.Listar(estado: "Pendiente");
                var aprobadas = _ctrlSol.Listar(estado: "Aprobada");
                lblStatPenVal.Text = pendientes.Count.ToString();
                lblStatAprVal.Text = aprobadas.Count.ToString();

                // Usuarios activos
                var usuarios = _ctrlUsr.Listar(filtroEstado: 1);
                lblStatUsVal.Text = usuarios.Count.ToString();

                // Mensaje de bienvenida con pendientes
                if (pendientes.Count > 0)
                    lblWelcomeSub.Text = $"Tenés {pendientes.Count} solicitud(es) pendiente(s) de aprobación.";
                else
                    lblWelcomeSub.Text = "No hay solicitudes pendientes. ¡Todo al día!";
            }
            catch
            {
                lblWelcomeSub.Text = "No se pudieron cargar las estadísticas.";
            }
        }

        // ============================================================
        // EVENTOS
        // ============================================================
        private void ConfigurarEventos()
        {
            // Ventana
            btnTopBarCerrar.Click += (s, e) => CerrarAplicacion();
            btnTopBarMin.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            btnTopBarMax.Click += (s, e) =>
            {
                this.WindowState = this.WindowState == FormWindowState.Maximized
                                   ? FormWindowState.Normal
                                   : FormWindowState.Maximized;
                SetRegion(this, 12);
            };

            // Arrastrar ventana desde topbar
            pnlTopBar.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };

            // Navegación
            btnNavInicio.Click += (s, e) => NavIr(btnNavInicio, "Inicio", null);
            btnNavEmpleados.Click += (s, e) => NavIr(btnNavEmpleados, "Empleados", typeof(FrmEmpleados));
            btnNavUsuarios.Click += (s, e) => NavIr(btnNavUsuarios, "Usuarios", typeof(FrmUsuarios));
            btnNavRoles.Click += (s, e) => NavIr(btnNavRoles, "Roles y Permisos", typeof(FrmRoles));
            btnNavTiposPermiso.Click += (s, e) => NavIr(btnNavTiposPermiso, "Tipos de Permiso", typeof(FrmTiposPermiso));
            btnNavSolicitar.Click += (s, e) => NavIr(btnNavSolicitar, "Solicitar Vacaciones", typeof(FrmSolicitar));
            btnNavGestion.Click += (s, e) => NavIr(btnNavGestion, "Gestión de Solicitudes", typeof(FrmGestionSolicitudes));
            btnNavReportes.Click += (s, e) => NavIr(btnNavReportes, "Reportes", typeof(FrmReportes));
            btnNavBitacoras.Click += (s, e) => NavIr(btnNavBitacoras, "Bitácoras", typeof(FrmBitacoras));
            btnNavAyuda.Click += (s, e) => NavIr(btnNavAyuda, "Ayuda", typeof(FrmAyuda));
            btnNavAcercaDe.Click += (s, e) => NavIr(btnNavAcercaDe, "Acerca de", typeof(FrmAcercaDe));
            btnNavCerrarSesion.Click += BtnCerrarSesion_Click;
            btnNavSalir.Click += (s, e) => CerrarAplicacion();

            // Cards del dashboard
            cardEmpleados.Click += (s, e) => NavIr(btnNavEmpleados, "Empleados", typeof(FrmEmpleados));
            cardSolicitudes.Click += (s, e) => NavIr(btnNavGestion, "Gestión de Solicitudes", typeof(FrmGestionSolicitudes));
            cardReportes.Click += (s, e) => NavIr(btnNavReportes, "Reportes", typeof(FrmReportes));
            cardUsuarios.Click += (s, e) => NavIr(btnNavUsuarios, "Usuarios", typeof(FrmUsuarios));
            cardRoles.Click += (s, e) => NavIr(btnNavRoles, "Roles y Permisos", typeof(FrmRoles));
            cardBitacoras.Click += (s, e) => NavIr(btnNavBitacoras, "Bitácoras", typeof(FrmBitacoras));

            // Hover en cards (efecto borde amarillo)
            foreach (var card in new[] { cardEmpleados, cardSolicitudes, cardReportes,
                                          cardUsuarios,  cardRoles,       cardBitacoras })
            {
                card.MouseEnter += (s, e) => { ((Panel)s).Tag = "hover"; ((Panel)s).Invalidate(); };
                card.MouseLeave += (s, e) => { ((Panel)s).Tag = ""; ((Panel)s).Invalidate(); };
            }
        }

        // ============================================================
        // NAVEGACIÓN
        // ============================================================
        private void NavIr(Button btnOrigen, string titulo, Type tipoForm)
        {
            lblTopBarTitulo.Text = titulo;
            SetBtnActivo(btnOrigen);

            // Si es el inicio, mostrar el dashboard
            if (tipoForm == null)
            {
                pnlContent.Controls.Clear();
                pnlContent.Controls.Add(pnlInicio);
                CargarDashboard();
                return;
            }

            // Abrir el formulario correspondiente dentro del pnlContent
            try
            {
                var frm = (Form)Activator.CreateInstance(tipoForm);
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlContent.Controls.Clear();
                pnlContent.Controls.Add(frm);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el módulo: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetBtnActivo(Button btn)
        {
            // Resetear anterior
            if (_btnActivo != null)
            {
                _btnActivo.BackColor = Color.Transparent;
                _btnActivo.ForeColor = Color.FromArgb(120, 120, 120);
                _btnActivo.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            }

            // Activar nuevo
            btn.BackColor = Color.FromArgb(25, 245, 196, 0);
            btn.ForeColor = C_AMARILLO;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 245, 196, 0);
            _btnActivo = btn;
        }

        // ============================================================
        // CERRAR SESIÓN / SALIR
        // ============================================================
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Estás seguro de que querés cerrar la sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                new UsuarioController().CerrarSesion();
            }
            catch { /* No bloquear aunque falle el registro */ }

            var login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void CerrarAplicacion()
        {
            var confirm = MessageBox.Show(
                "¿Estás seguro de que querés salir del sistema?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try { new UsuarioController().CerrarSesion(); } catch { }
            Application.Exit();
        }

        // ============================================================
        // RELOJ EN TOPBAR
        // ============================================================
        private void IniciarReloj()
        {
            ActualizarFecha();
            _timerFecha = new System.Windows.Forms.Timer { Interval = 60000 };
            _timerFecha.Tick += (s, e) => ActualizarFecha();
            _timerFecha.Start();
        }

        private void ActualizarFecha()
        {
            string dia = System.Globalization.CultureInfo
                             .GetCultureInfo("es-CR")
                             .TextInfo.ToTitleCase(
                                 DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy",
                                     System.Globalization.CultureInfo.GetCultureInfo("es-CR")));
            lblTopBarFecha.Text = dia;
        }

        // ============================================================
        // FADE-IN
        // ============================================================
        private void IniciarFadeIn()
        {
            this.Opacity = 0;
            _timerFade = new System.Windows.Forms.Timer { Interval = 16 };
            _timerFade.Tick += (s, e) =>
            {
                _opacidad += 0.06;
                if (_opacidad >= 1) { _opacidad = 1; _timerFade.Stop(); }
                this.Opacity = _opacidad;
            };
            this.Shown += (s, e) => _timerFade.Start();
        }

        // ============================================================
        // HELPERS
        // ============================================================
        private string ObtenerIniciales(string nombreCompleto)
        {
            if (string.IsNullOrEmpty(nombreCompleto)) return "??";
            var partes = nombreCompleto.Trim().Split(' ');
            if (partes.Length == 1) return partes[0].Substring(0, Math.Min(2, partes[0].Length)).ToUpper();
            return (partes[0][0].ToString() + partes[1][0].ToString()).ToUpper();
        }

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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerFade?.Stop();
            _timerFecha?.Stop();
            base.OnFormClosed(e);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}