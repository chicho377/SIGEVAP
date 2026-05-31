namespace SIGEVAP.Views
{
    partial class FrmMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ── Estructura principal ─────────────────────────
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();

            // ── Sidebar: cabecera (logo) ─────────────────────
            this.pnlSbHeader = new System.Windows.Forms.Panel();
            this.picLogoSb = new System.Windows.Forms.PictureBox();
            this.lblSbNombre = new System.Windows.Forms.Label();
            this.lblSbVersion = new System.Windows.Forms.Label();

            // ── Sidebar: usuario ─────────────────────────────
            this.pnlSbUser = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblUserNombre = new System.Windows.Forms.Label();
            this.lblUserRol = new System.Windows.Forms.Label();

            // ── Sidebar: nav (FlowLayoutPanel vertical) ──────
            this.flpNav = new System.Windows.Forms.FlowLayoutPanel();

            // Labels de sección
            this.lblSecGeneral = new System.Windows.Forms.Label();
            this.lblSecAdmin = new System.Windows.Forms.Label();
            this.lblSecVacaciones = new System.Windows.Forms.Label();
            this.lblSecReportes = new System.Windows.Forms.Label();
            this.lblSecSistema = new System.Windows.Forms.Label();

            // Botones de navegación
            this.btnNavInicio = new System.Windows.Forms.Button();
            this.btnNavEmpleados = new System.Windows.Forms.Button();
            this.btnNavUsuarios = new System.Windows.Forms.Button();
            this.btnNavRoles = new System.Windows.Forms.Button();
            this.btnNavTiposPermiso = new System.Windows.Forms.Button();
            this.btnNavSolicitar = new System.Windows.Forms.Button();
            this.btnNavGestion = new System.Windows.Forms.Button();
            this.btnNavReportes = new System.Windows.Forms.Button();
            this.btnNavBitacoras = new System.Windows.Forms.Button();
            this.btnNavAyuda = new System.Windows.Forms.Button();
            this.btnNavAcercaDe = new System.Windows.Forms.Button();
            this.btnNavCerrarSesion = new System.Windows.Forms.Button();
            this.btnNavSalir = new System.Windows.Forms.Button();

            // ── TopBar ───────────────────────────────────────
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblTopBarTitulo = new System.Windows.Forms.Label();
            this.lblTopBarFecha = new System.Windows.Forms.Label();
            this.btnTopBarCerrar = new System.Windows.Forms.Button();
            this.btnTopBarMax = new System.Windows.Forms.Button();
            this.btnTopBarMin = new System.Windows.Forms.Button();

            // ── Área de contenido ────────────────────────────
            this.pnlContent = new System.Windows.Forms.Panel();

            // ── Panel Inicio ─────────────────────────────────
            this.pnlInicio = new System.Windows.Forms.Panel();

            // Welcome bar
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.picWelcomeIcon = new System.Windows.Forms.PictureBox();
            this.lblWelcomeTitulo = new System.Windows.Forms.Label();
            this.lblWelcomeSub = new System.Windows.Forms.Label();

            // Cards (FlowLayoutPanel)
            this.flpCards = new System.Windows.Forms.FlowLayoutPanel();
            this.cardEmpleados = new System.Windows.Forms.Panel();
            this.lblCardEmpTitulo = new System.Windows.Forms.Label();
            this.lblCardEmpDesc = new System.Windows.Forms.Label();
            this.cardSolicitudes = new System.Windows.Forms.Panel();
            this.lblCardSolTitulo = new System.Windows.Forms.Label();
            this.lblCardSolDesc = new System.Windows.Forms.Label();
            this.cardReportes = new System.Windows.Forms.Panel();
            this.lblCardRepTitulo = new System.Windows.Forms.Label();
            this.lblCardRepDesc = new System.Windows.Forms.Label();
            this.cardUsuarios = new System.Windows.Forms.Panel();
            this.lblCardUsTitulo = new System.Windows.Forms.Label();
            this.lblCardUsDesc = new System.Windows.Forms.Label();
            this.cardRoles = new System.Windows.Forms.Panel();
            this.lblCardRolTitulo = new System.Windows.Forms.Label();
            this.lblCardRolDesc = new System.Windows.Forms.Label();
            this.cardBitacoras = new System.Windows.Forms.Panel();
            this.lblCardBitTitulo = new System.Windows.Forms.Label();
            this.lblCardBitDesc = new System.Windows.Forms.Label();

            // Stats (FlowLayoutPanel)
            this.flpStats = new System.Windows.Forms.FlowLayoutPanel();
            this.statEmpleados = new System.Windows.Forms.Panel();
            this.lblStatEmpVal = new System.Windows.Forms.Label();
            this.lblStatEmpLbl = new System.Windows.Forms.Label();
            this.statPendientes = new System.Windows.Forms.Panel();
            this.lblStatPenVal = new System.Windows.Forms.Label();
            this.lblStatPenLbl = new System.Windows.Forms.Label();
            this.statAprobadas = new System.Windows.Forms.Panel();
            this.lblStatAprVal = new System.Windows.Forms.Label();
            this.lblStatAprLbl = new System.Windows.Forms.Label();
            this.statUsuarios = new System.Windows.Forms.Panel();
            this.lblStatUsVal = new System.Windows.Forms.Label();
            this.lblStatUsLbl = new System.Windows.Forms.Label();

            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeIcon)).BeginInit();

            // ════════════════════════════════════════════════
            // FORM
            // ════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 680);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenu";
            this.Text = "SIGEVAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.DoubleBuffered = true;
            // Sidebar va primero (Left), Main llena el resto (Fill)
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);

            // ════════════════════════════════════════════════
            // SIDEBAR — ancho fijo, fill alto
            // ════════════════════════════════════════════════
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(17, 17, 17);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 220;
            this.pnlSidebar.Name = "pnlSidebar";
            // ORDEN DE CONTROLES EN SIDEBAR:
            // Agregar Header primero (Dock=Top), luego User (Dock=Top),
            // luego flpNav (Dock=Fill)
            this.pnlSidebar.Controls.Add(this.flpNav);      // Fill — debe agregarse ANTES
            this.pnlSidebar.Controls.Add(this.pnlSbUser);   // Top
            this.pnlSidebar.Controls.Add(this.pnlSbHeader); // Top

            // ── pnlSbHeader ───────────────────────────────────
            this.pnlSbHeader.BackColor = System.Drawing.Color.FromArgb(17, 17, 17);
            this.pnlSbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSbHeader.Height = 64;
            this.pnlSbHeader.Name = "pnlSbHeader";
            this.pnlSbHeader.Controls.Add(this.lblSbVersion);
            this.pnlSbHeader.Controls.Add(this.lblSbNombre);
            this.pnlSbHeader.Controls.Add(this.picLogoSb);

            this.picLogoSb.BackColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.picLogoSb.Location = new System.Drawing.Point(14, 14);
            this.picLogoSb.Size = new System.Drawing.Size(36, 36);
            this.picLogoSb.Name = "picLogoSb";
            this.picLogoSb.TabStop = false;

            this.lblSbNombre.AutoSize = true;
            this.lblSbNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblSbNombre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSbNombre.ForeColor = System.Drawing.Color.White;
            this.lblSbNombre.Location = new System.Drawing.Point(58, 16);
            this.lblSbNombre.Text = "SIGEVAP";

            this.lblSbVersion.AutoSize = true;
            this.lblSbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblSbVersion.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblSbVersion.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblSbVersion.Location = new System.Drawing.Point(60, 34);
            this.lblSbVersion.Text = "v1.0";

            // ── pnlSbUser ─────────────────────────────────────
            this.pnlSbUser.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.pnlSbUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSbUser.Height = 56;
            this.pnlSbUser.Name = "pnlSbUser";
            this.pnlSbUser.Controls.Add(this.lblUserRol);
            this.pnlSbUser.Controls.Add(this.lblUserNombre);
            this.pnlSbUser.Controls.Add(this.picAvatar);

            this.picAvatar.BackColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.picAvatar.Location = new System.Drawing.Point(14, 12);
            this.picAvatar.Size = new System.Drawing.Size(32, 32);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.TabStop = false;

            this.lblUserNombre.AutoSize = true;
            this.lblUserNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblUserNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserNombre.ForeColor = System.Drawing.Color.White;
            this.lblUserNombre.Location = new System.Drawing.Point(54, 13);
            this.lblUserNombre.Name = "lblUserNombre";
            this.lblUserNombre.Text = "Usuario";

            this.lblUserRol.AutoSize = true;
            this.lblUserRol.BackColor = System.Drawing.Color.Transparent;
            this.lblUserRol.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblUserRol.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblUserRol.Location = new System.Drawing.Point(54, 30);
            this.lblUserRol.Name = "lblUserRol";
            this.lblUserRol.Text = "Rol";

            // ── flpNav (FlowLayoutPanel vertical) ─────────────
            // FlowLayoutPanel resuelve el problema de orden de Dock=Top
            this.flpNav.AutoScroll = true;
            this.flpNav.BackColor = System.Drawing.Color.Transparent;
            this.flpNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNav.WrapContents = false;
            this.flpNav.Name = "flpNav";
            this.flpNav.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);

            // Agregar controles al flpNav EN ORDEN CORRECTO (de arriba hacia abajo)
            this.flpNav.Controls.Add(this.lblSecGeneral);
            this.flpNav.Controls.Add(this.btnNavInicio);
            this.flpNav.Controls.Add(this.lblSecAdmin);
            this.flpNav.Controls.Add(this.btnNavEmpleados);
            this.flpNav.Controls.Add(this.btnNavUsuarios);
            this.flpNav.Controls.Add(this.btnNavRoles);
            this.flpNav.Controls.Add(this.btnNavTiposPermiso);
            this.flpNav.Controls.Add(this.lblSecVacaciones);
            this.flpNav.Controls.Add(this.btnNavSolicitar);
            this.flpNav.Controls.Add(this.btnNavGestion);
            this.flpNav.Controls.Add(this.lblSecReportes);
            this.flpNav.Controls.Add(this.btnNavReportes);
            this.flpNav.Controls.Add(this.btnNavBitacoras);
            this.flpNav.Controls.Add(this.lblSecSistema);
            this.flpNav.Controls.Add(this.btnNavAyuda);
            this.flpNav.Controls.Add(this.btnNavAcercaDe);
            this.flpNav.Controls.Add(this.btnNavCerrarSesion);
            this.flpNav.Controls.Add(this.btnNavSalir);

            // Configurar labels de sección
            ConfigLblSeccion(this.lblSecGeneral, "GENERAL");
            ConfigLblSeccion(this.lblSecAdmin, "ADMINISTRACIÓN");
            ConfigLblSeccion(this.lblSecVacaciones, "VACACIONES");
            ConfigLblSeccion(this.lblSecReportes, "REPORTES");
            ConfigLblSeccion(this.lblSecSistema, "SISTEMA");

            // Configurar botones de navegación
            ConfigBtnNav(this.btnNavInicio, "   Inicio");
            ConfigBtnNav(this.btnNavEmpleados, "   Empleados");
            ConfigBtnNav(this.btnNavUsuarios, "   Usuarios");
            ConfigBtnNav(this.btnNavRoles, "   Roles y Permisos");
            ConfigBtnNav(this.btnNavTiposPermiso, "   Tipos de Permiso");
            ConfigBtnNav(this.btnNavSolicitar, "   Solicitar Vacaciones");
            ConfigBtnNav(this.btnNavGestion, "   Gestión Solicitudes");
            ConfigBtnNav(this.btnNavReportes, "   Reportes");
            ConfigBtnNav(this.btnNavBitacoras, "   Bitácoras");
            ConfigBtnNav(this.btnNavAyuda, "   Ayuda");
            ConfigBtnNav(this.btnNavAcercaDe, "   Acerca de");
            ConfigBtnNav(this.btnNavCerrarSesion, "   Cerrar Sesión");
            ConfigBtnNav(this.btnNavSalir, "   Salir");

            // Color rojo para cerrar sesión y salir
            this.btnNavCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(180, 80, 80);
            this.btnNavSalir.ForeColor = System.Drawing.Color.FromArgb(180, 80, 80);
            this.btnNavCerrarSesion.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(40, 180, 60, 60);
            this.btnNavSalir.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(40, 180, 60, 60);

            // ════════════════════════════════════════════════
            // PANEL MAIN
            // ════════════════════════════════════════════════
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Name = "pnlMain";
            // Fill debe agregarse primero, luego Top
            this.pnlMain.Controls.Add(this.pnlContent);  // Fill
            this.pnlMain.Controls.Add(this.pnlTopBar);   // Top

            // ── pnlTopBar ─────────────────────────────────────
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(17, 17, 17);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height = 52;
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Controls.Add(this.btnTopBarCerrar);
            this.pnlTopBar.Controls.Add(this.btnTopBarMax);
            this.pnlTopBar.Controls.Add(this.btnTopBarMin);
            this.pnlTopBar.Controls.Add(this.lblTopBarFecha);
            this.pnlTopBar.Controls.Add(this.lblTopBarTitulo);

            this.lblTopBarTitulo.AutoSize = true;
            this.lblTopBarTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTopBarTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTopBarTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTopBarTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTopBarTitulo.Name = "lblTopBarTitulo";
            this.lblTopBarTitulo.Text = "Inicio";

            this.lblTopBarFecha.AutoSize = true;
            this.lblTopBarFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblTopBarFecha.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTopBarFecha.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblTopBarFecha.Location = new System.Drawing.Point(20, 30);
            this.lblTopBarFecha.Name = "lblTopBarFecha";
            this.lblTopBarFecha.Text = "";

            // Botones de ventana con Dock=Right (se agregan en orden: X, □, ─)
            ConfigBtnVentana(this.btnTopBarCerrar, "✕",
                System.Drawing.Color.FromArgb(180, 70, 70),
                System.Drawing.Color.FromArgb(40, 180, 60, 60));
            ConfigBtnVentana(this.btnTopBarMax, "□",
                System.Drawing.Color.FromArgb(70, 70, 70),
                System.Drawing.Color.FromArgb(40, 40, 40));
            ConfigBtnVentana(this.btnTopBarMin, "─",
                System.Drawing.Color.FromArgb(70, 70, 70),
                System.Drawing.Color.FromArgb(40, 40, 40));
            this.btnTopBarCerrar.Name = "btnTopBarCerrar";
            this.btnTopBarMax.Name = "btnTopBarMax";
            this.btnTopBarMin.Name = "btnTopBarMin";

            // ── pnlContent ────────────────────────────────────
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(24);
            this.pnlContent.Controls.Add(this.pnlInicio);

            // ── pnlInicio ─────────────────────────────────────
            this.pnlInicio.BackColor = System.Drawing.Color.Transparent;
            this.pnlInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInicio.Name = "pnlInicio";
            // Fill antes, luego los Top de abajo hacia arriba
            this.pnlInicio.Controls.Add(this.flpStats);   // queda al fondo (Fill o Top)
            this.pnlInicio.Controls.Add(this.flpCards);
            this.pnlInicio.Controls.Add(this.pnlWelcome);

            // ── pnlWelcome ────────────────────────────────────
            this.pnlWelcome.BackColor = System.Drawing.Color.FromArgb(22, 20, 0);
            this.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWelcome.Height = 70;
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Controls.Add(this.lblWelcomeSub);
            this.pnlWelcome.Controls.Add(this.lblWelcomeTitulo);
            this.pnlWelcome.Controls.Add(this.picWelcomeIcon);

            this.picWelcomeIcon.BackColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.picWelcomeIcon.Location = new System.Drawing.Point(16, 13);
            this.picWelcomeIcon.Size = new System.Drawing.Size(44, 44);
            this.picWelcomeIcon.Name = "picWelcomeIcon";
            this.picWelcomeIcon.TabStop = false;

            this.lblWelcomeTitulo.AutoSize = true;
            this.lblWelcomeTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeTitulo.ForeColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.lblWelcomeTitulo.Location = new System.Drawing.Point(74, 14);
            this.lblWelcomeTitulo.Name = "lblWelcomeTitulo";
            this.lblWelcomeTitulo.Text = "Bienvenido";

            this.lblWelcomeSub.AutoSize = false;
            this.lblWelcomeSub.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblWelcomeSub.Location = new System.Drawing.Point(74, 36);
            this.lblWelcomeSub.Size = new System.Drawing.Size(500, 18);
            this.lblWelcomeSub.Name = "lblWelcomeSub";
            this.lblWelcomeSub.Text = "Cargando información...";

            // ── flpCards ──────────────────────────────────────
            this.flpCards.AutoSize = false;
            this.flpCards.BackColor = System.Drawing.Color.Transparent;
            this.flpCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCards.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpCards.WrapContents = true;
            this.flpCards.Name = "flpCards";
            this.flpCards.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.flpCards.Height = 320;

            // ── flpStats ──────────────────────────────────────
            this.flpStats.AutoSize = false;
            this.flpStats.BackColor = System.Drawing.Color.Transparent;
            this.flpStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpStats.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpStats.WrapContents = true;
            this.flpStats.Name = "flpStats";
            this.flpStats.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.flpStats.Height = 150;

            // ── Reanudar layout ───────────────────────────────
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeIcon)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Helpers del Designer ──────────────────────────────
        private void ConfigLblSeccion(System.Windows.Forms.Label lbl, string texto)
        {
            lbl.AutoSize = false;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.FromArgb(55, 55, 55);
            lbl.Size = new System.Drawing.Size(204, 22);
            lbl.Margin = new System.Windows.Forms.Padding(8, 10, 0, 2);
            lbl.Text = texto;
            lbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
        }

        private void ConfigBtnNav(System.Windows.Forms.Button btn, string texto)
        {
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            btn.Size = new System.Drawing.Size(204, 34);
            btn.Margin = new System.Windows.Forms.Padding(8, 1, 0, 1);
            btn.Text = texto;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        private void ConfigBtnVentana(System.Windows.Forms.Button btn,
                                      string texto,
                                      System.Drawing.Color fore,
                                      System.Drawing.Color hoverBg)
        {
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = hoverBg;
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.ForeColor = fore;
            btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            btn.Size = new System.Drawing.Size(36, 52);
            btn.Dock = System.Windows.Forms.DockStyle.Right;
            btn.Text = texto;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        #endregion

        // Declaraciones
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSbHeader;
        private System.Windows.Forms.PictureBox picLogoSb;
        private System.Windows.Forms.Label lblSbNombre;
        private System.Windows.Forms.Label lblSbVersion;
        private System.Windows.Forms.Panel pnlSbUser;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblUserNombre;
        private System.Windows.Forms.Label lblUserRol;
        private System.Windows.Forms.FlowLayoutPanel flpNav;
        private System.Windows.Forms.Label lblSecGeneral;
        private System.Windows.Forms.Button btnNavInicio;
        private System.Windows.Forms.Label lblSecAdmin;
        private System.Windows.Forms.Button btnNavEmpleados;
        private System.Windows.Forms.Button btnNavUsuarios;
        private System.Windows.Forms.Button btnNavRoles;
        private System.Windows.Forms.Button btnNavTiposPermiso;
        private System.Windows.Forms.Label lblSecVacaciones;
        private System.Windows.Forms.Button btnNavSolicitar;
        private System.Windows.Forms.Button btnNavGestion;
        private System.Windows.Forms.Label lblSecReportes;
        private System.Windows.Forms.Button btnNavReportes;
        private System.Windows.Forms.Button btnNavBitacoras;
        private System.Windows.Forms.Label lblSecSistema;
        private System.Windows.Forms.Button btnNavAyuda;
        private System.Windows.Forms.Button btnNavAcercaDe;
        private System.Windows.Forms.Button btnNavCerrarSesion;
        private System.Windows.Forms.Button btnNavSalir;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblTopBarTitulo;
        private System.Windows.Forms.Label lblTopBarFecha;
        private System.Windows.Forms.Button btnTopBarMin;
        private System.Windows.Forms.Button btnTopBarMax;
        private System.Windows.Forms.Button btnTopBarCerrar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlInicio;
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.PictureBox picWelcomeIcon;
        private System.Windows.Forms.Label lblWelcomeTitulo;
        private System.Windows.Forms.Label lblWelcomeSub;
        private System.Windows.Forms.FlowLayoutPanel flpCards;
        private System.Windows.Forms.Panel cardEmpleados;
        private System.Windows.Forms.Label lblCardEmpTitulo;
        private System.Windows.Forms.Label lblCardEmpDesc;
        private System.Windows.Forms.Panel cardSolicitudes;
        private System.Windows.Forms.Label lblCardSolTitulo;
        private System.Windows.Forms.Label lblCardSolDesc;
        private System.Windows.Forms.Panel cardReportes;
        private System.Windows.Forms.Label lblCardRepTitulo;
        private System.Windows.Forms.Label lblCardRepDesc;
        private System.Windows.Forms.Panel cardUsuarios;
        private System.Windows.Forms.Label lblCardUsTitulo;
        private System.Windows.Forms.Label lblCardUsDesc;
        private System.Windows.Forms.Panel cardRoles;
        private System.Windows.Forms.Label lblCardRolTitulo;
        private System.Windows.Forms.Label lblCardRolDesc;
        private System.Windows.Forms.Panel cardBitacoras;
        private System.Windows.Forms.Label lblCardBitTitulo;
        private System.Windows.Forms.Label lblCardBitDesc;
        private System.Windows.Forms.FlowLayoutPanel flpStats;
        private System.Windows.Forms.Panel statEmpleados;
        private System.Windows.Forms.Label lblStatEmpVal;
        private System.Windows.Forms.Label lblStatEmpLbl;
        private System.Windows.Forms.Panel statPendientes;
        private System.Windows.Forms.Label lblStatPenVal;
        private System.Windows.Forms.Label lblStatPenLbl;
        private System.Windows.Forms.Panel statAprobadas;
        private System.Windows.Forms.Label lblStatAprVal;
        private System.Windows.Forms.Label lblStatAprLbl;
        private System.Windows.Forms.Panel statUsuarios;
        private System.Windows.Forms.Label lblStatUsVal;
        private System.Windows.Forms.Label lblStatUsLbl;
    }
}