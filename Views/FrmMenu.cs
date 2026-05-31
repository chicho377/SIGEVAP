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

        // ── Grupos del sidebar creados fuera del Designer ─────
        private Button _btnGrpAdmin;
        private Button _btnGrpVacaciones;
        private Button _btnGrpReportes;
        private FlowLayoutPanel _flpGrpAdmin;
        private FlowLayoutPanel _flpGrpVacaciones;
        private FlowLayoutPanel _flpGrpReportes;
        private bool _grpAdminExpandido = true;
        private bool _grpVacacionesExpandido = true;
        private bool _grpReportesExpandido = true;

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
            ConfigurarContenidoDinamico();
            AplicarEstilos();
            CargarSesion();
            MostrarCardsInicio();
            ConfigurarEventos();
            CargarDashboard();
            IniciarFadeIn();
            IniciarReloj();
        }

        // ============================================================
        // CONTROLES QUE EL DESIGNER NO PROCESA BIEN
        // ============================================================
        private void ConfigurarContenidoDinamico()
        {
            lblWelcomeSub.Size = new Size(760, 24);
            ConfigurarCardsDashboard();
            ConfigurarStatsDashboard();
        }

        private void ConfigurarCardsDashboard()
        {
            flpCards.SuspendLayout();
            flpCards.Controls.Clear();

            var cards = new[] { cardEmpleados, cardSolicitudes, cardReportes, cardUsuarios, cardRoles, cardBitacoras };
            var titulos = new[] { lblCardEmpTitulo, lblCardSolTitulo, lblCardRepTitulo, lblCardUsTitulo, lblCardRolTitulo, lblCardBitTitulo };
            var descripciones = new[] { lblCardEmpDesc, lblCardSolDesc, lblCardRepDesc, lblCardUsDesc, lblCardRolDesc, lblCardBitDesc };
            string[] textosTitulo = { "Empleados", "Solicitudes", "Reportes", "Usuarios", "Roles y Permisos", "Bitácoras" };
            string[] textosDescripcion = { "Gestión de empleados", "Aprobar o rechazar", "Reportes dinámicos", "Control de acceso", "Configuración de accesos", "Registro de actividad" };
            string[] nombres = { "cardEmpleados", "cardSolicitudes", "cardReportes", "cardUsuarios", "cardRoles", "cardBitacoras" };

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].BackColor = C_CARD;
                cards[i].Margin = new Padding(0, 0, 14, 14);
                cards[i].Name = nombres[i];
                cards[i].Size = new Size(200, 88);
                cards[i].Cursor = Cursors.Hand;
                cards[i].Controls.Clear();

                titulos[i].AutoSize = true;
                titulos[i].BackColor = Color.Transparent;
                titulos[i].Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                titulos[i].ForeColor = C_TEXTO;
                titulos[i].Location = new Point(14, 14);
                titulos[i].Text = textosTitulo[i];
                cards[i].Controls.Add(titulos[i]);

                descripciones[i].AutoSize = false;
                descripciones[i].BackColor = Color.Transparent;
                descripciones[i].Font = new Font("Segoe UI", 8F);
                descripciones[i].ForeColor = C_SUBTEXTO;
                descripciones[i].Location = new Point(14, 34);
                descripciones[i].Size = new Size(172, 36);
                descripciones[i].Text = textosDescripcion[i];
                cards[i].Controls.Add(descripciones[i]);

                flpCards.Controls.Add(cards[i]);
            }

            flpCards.Height = 220;
            flpCards.ResumeLayout(false);
        }


        private void MostrarCardsInicio()
        {
            flpCards.Visible = true;
            cardEmpleados.Visible = true;
            cardSolicitudes.Visible = true;
            cardReportes.Visible = true;
            cardUsuarios.Visible = true;
            cardRoles.Visible = true;
            cardBitacoras.Visible = true;
        }

        private void ConfigurarStatsDashboard()
        {
            flpStats.SuspendLayout();
            flpStats.Controls.Clear();

            var stats = new[] { statEmpleados, statPendientes, statAprobadas, statUsuarios };
            var valores = new[] { lblStatEmpVal, lblStatPenVal, lblStatAprVal, lblStatUsVal };
            var etiquetas = new[] { lblStatEmpLbl, lblStatPenLbl, lblStatAprLbl, lblStatUsLbl };
            string[] textos = { "Empleados activos", "Solicitudes pendientes", "Solicitudes aprobadas", "Usuarios activos" };
            string[] nombres = { "statEmpleados", "statPendientes", "statAprobadas", "statUsuarios" };

            for (int i = 0; i < stats.Length; i++)
            {
                stats[i].BackColor = C_CARD;
                stats[i].Margin = new Padding(0, 0, 14, 0);
                stats[i].Name = nombres[i];
                stats[i].Size = new Size(150, 62);
                stats[i].Controls.Clear();

                valores[i].AutoSize = true;
                valores[i].BackColor = Color.Transparent;
                valores[i].Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                valores[i].ForeColor = C_AMARILLO;
                valores[i].Location = new Point(14, 8);
                valores[i].Text = "0";
                stats[i].Controls.Add(valores[i]);

                etiquetas[i].AutoSize = false;
                etiquetas[i].BackColor = Color.Transparent;
                etiquetas[i].Font = new Font("Segoe UI", 7.5F);
                etiquetas[i].ForeColor = C_SUBTEXTO;
                etiquetas[i].Location = new Point(14, 38);
                etiquetas[i].Size = new Size(122, 16);
                etiquetas[i].Text = textos[i];
                stats[i].Controls.Add(etiquetas[i]);

                flpStats.Controls.Add(stats[i]);
            }

            flpStats.Height = 90;
            flpStats.ResumeLayout(false);
        }

        private void ConfigurarGruposNavegacion()
        {
            _btnGrpAdmin = CrearBotonGrupo("ADMINISTRACIÓN");
            _btnGrpVacaciones = CrearBotonGrupo("VACACIONES");
            _btnGrpReportes = CrearBotonGrupo("REPORTES");

            _flpGrpAdmin = CrearPanelGrupo("flpGrpAdmin", btnNavEmpleados, btnNavUsuarios, btnNavRoles, btnNavTiposPermiso);
            _flpGrpVacaciones = CrearPanelGrupo("flpGrpVacaciones", btnNavSolicitar, btnNavGestion);
            _flpGrpReportes = CrearPanelGrupo("flpGrpReportes", btnNavReportes, btnNavBitacoras);

            _btnGrpAdmin.Click += (s, e) => AlternarGrupo(ref _grpAdminExpandido, _btnGrpAdmin, _flpGrpAdmin);
            _btnGrpVacaciones.Click += (s, e) => AlternarGrupo(ref _grpVacacionesExpandido, _btnGrpVacaciones, _flpGrpVacaciones);
            _btnGrpReportes.Click += (s, e) => AlternarGrupo(ref _grpReportesExpandido, _btnGrpReportes, _flpGrpReportes);

            flpNav.SuspendLayout();
            flpNav.Controls.Clear();
            flpNav.Controls.Add(lblSecGeneral);
            flpNav.Controls.Add(btnNavInicio);
            flpNav.Controls.Add(_btnGrpAdmin);
            flpNav.Controls.Add(_flpGrpAdmin);
            flpNav.Controls.Add(_btnGrpVacaciones);
            flpNav.Controls.Add(_flpGrpVacaciones);
            flpNav.Controls.Add(_btnGrpReportes);
            flpNav.Controls.Add(_flpGrpReportes);
            flpNav.Controls.Add(lblSecSistema);
            flpNav.Controls.Add(btnNavAyuda);
            flpNav.Controls.Add(btnNavAcercaDe);
            flpNav.Controls.Add(btnNavCerrarSesion);
            flpNav.Controls.Add(btnNavSalir);
            flpNav.ResumeLayout(true);

            ActualizarGruposNavegacion();
        }

        private Button CrearBotonGrupo(string texto)
        {
            var btn = new Button();
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            btn.BackColor = Color.Transparent;
            btn.ForeColor = C_AMARILLO;
            btn.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btn.Size = new Size(204, 34);
            btn.Margin = new Padding(8, 8, 0, 1);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
            btn.Tag = texto;
            return btn;
        }

        private FlowLayoutPanel CrearPanelGrupo(string nombre, params Button[] botones)
        {
            var panel = new FlowLayoutPanel();
            panel.AutoSize = false;
            panel.BackColor = Color.Transparent;
            panel.FlowDirection = FlowDirection.TopDown;
            panel.WrapContents = false;
            panel.Margin = new Padding(0);
            panel.Padding = new Padding(0);
            panel.Name = nombre;
            panel.Size = new Size(220, 0);

            foreach (var btn in botones)
            {
                btn.Margin = new Padding(16, 1, 0, 1);
                btn.Size = new Size(196, 34);
                panel.Controls.Add(btn);
            }

            return panel;
        }

        private void AlternarGrupo(ref bool expandido, Button encabezado, FlowLayoutPanel panel)
        {
            expandido = !expandido;
            ActualizarGrupo(encabezado, panel, expandido);
        }

        private void ActualizarGruposNavegacion()
        {
            if (_btnGrpAdmin == null) return;

            MostrarSubmenusAdministradorDesdeDiseno();

            ActualizarVisibilidadGrupo(_btnGrpAdmin, _flpGrpAdmin, _grpAdminExpandido);
            ActualizarVisibilidadGrupo(_btnGrpVacaciones, _flpGrpVacaciones, _grpVacacionesExpandido);
            ActualizarVisibilidadGrupo(_btnGrpReportes, _flpGrpReportes, _grpReportesExpandido);
        }

        private void MostrarSubmenusAdministradorDesdeDiseno()
        {
            string rolVisible = lblUserRol.Text ?? string.Empty;
            if (rolVisible.IndexOf("admin", StringComparison.OrdinalIgnoreCase) < 0 &&
                rolVisible.IndexOf("administrador", StringComparison.OrdinalIgnoreCase) < 0)
                return;

            foreach (Control grupo in new Control[] { _flpGrpAdmin, _flpGrpVacaciones, _flpGrpReportes })
            {
                foreach (Control opcion in grupo.Controls)
                    opcion.Visible = true;
            }
        }

        private void ActualizarVisibilidadGrupo(Button encabezado, FlowLayoutPanel panel, bool expandido)
        {
            // Mantener el panel visible evita que Control.Visible devuelva false
            // solo porque el padre está oculto. El colapso se maneja con Height.
            panel.Visible = true;

            bool tieneOpcionesVisibles = false;
            foreach (Control ctrl in panel.Controls)
            {
                if (!ctrl.Visible) continue;
                tieneOpcionesVisibles = true;
                break;
            }

            encabezado.Visible = tieneOpcionesVisibles;
            ActualizarGrupo(encabezado, panel, expandido && tieneOpcionesVisibles);
        }

        private void ActualizarGrupo(Button encabezado, FlowLayoutPanel panel, bool expandido)
        {
            string texto = encabezado.Tag?.ToString() ?? encabezado.Text.TrimStart('▾', '▸', ' ');
            encabezado.Text = (expandido ? "▾  " : "▸  ") + texto;
            panel.Height = expandido ? AltoGrupoVisible(panel) : 0;
            panel.Margin = expandido ? new Padding(0, 0, 0, 4) : new Padding(0);
        }

        private int AltoGrupoVisible(FlowLayoutPanel panel)
        {
            int alto = 0;
            foreach (Control ctrl in panel.Controls)
            {
                if (!ctrl.Visible) continue;
                alto += ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom;
            }
            return alto;
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
            pnlWelcome.Region = null;

            // Paint de las cards: borde redondeado con hover amarillo
            var cards = new[] { cardEmpleados, cardSolicitudes, cardReportes,
                                 cardUsuarios,  cardRoles,       cardBitacoras };
            foreach (var card in cards)
            {
                card.Paint += Card_Paint;
                card.Region = null;
            }

            // Paint de los stats: borde redondeado
            var stats = new[] { statEmpleados, statPendientes, statAprobadas, statUsuarios };
            foreach (var st in stats)
            {
                st.Paint += Stat_Paint;
                st.Region = null;
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
            var botonesModulo = new[]
            {
                btnNavEmpleados,
                btnNavUsuarios,
                btnNavRoles,
                btnNavTiposPermiso,
                btnNavGestion,
                btnNavReportes,
                btnNavBitacoras,
            };

            try
            {
                // El administrador siempre debe ver todo el menú.
                // Si se intenta validar permisos para este rol y el SP devuelve false,
                // desaparecen todos los submenús como en la pantalla reportada.
                if (EsRolAdministrador())
                {
                    foreach (var btn in botonesModulo)
                        btn.Visible = true;

                    SincronizarCardsConMenu();
                    ActualizarGruposNavegacion();
                    return;
                }

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
                    btn.Visible = _ctrlUsr.VerificarPermiso(modulo);

                SincronizarCardsConMenu();
            }
            catch
            {
                // No bloquear ni vaciar el menú si falla la consulta de permisos.
                // En caso de duda dejamos visibles las opciones principales.
                foreach (var btn in botonesModulo)
                    btn.Visible = true;

                SincronizarCardsConMenu();
            }

            ActualizarGruposNavegacion();
        }

        private void SincronizarCardsConMenu()
        {
            cardEmpleados.Visible = btnNavEmpleados.Visible;
            cardUsuarios.Visible = btnNavUsuarios.Visible;
            cardRoles.Visible = btnNavRoles.Visible;
            cardSolicitudes.Visible = btnNavGestion.Visible;
            cardReportes.Visible = btnNavReportes.Visible;
            cardBitacoras.Visible = btnNavBitacoras.Visible;
        }

        private bool EsRolAdministrador()
        {
            string rol = SesionActual.NombreRol ?? string.Empty;
            string usuario = SesionActual.NombreUsuario ?? string.Empty;

            return SesionActual.IdRol == 1 ||
                   rol.IndexOf("admin", StringComparison.OrdinalIgnoreCase) >= 0 ||
                   rol.IndexOf("administrador", StringComparison.OrdinalIgnoreCase) >= 0 ||
                   usuario.IndexOf("admin", StringComparison.OrdinalIgnoreCase) >= 0;
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
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;

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