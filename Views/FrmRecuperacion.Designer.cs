// ============================================================
// SIGEVAP — Views/FrmRecuperacion.Designer.cs
// ============================================================

namespace SIGEVAP.Views
{
    partial class FrmRecuperacion
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

            // ── Paneles principales ──────────────────────────
            this.pnlIzquierdo = new System.Windows.Forms.Panel();
            this.pnlDerecho = new System.Windows.Forms.Panel();

            // ── Panel izquierdo ──────────────────────────────
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTituloIzq = new System.Windows.Forms.Label();
            this.lblSubtituloIzq = new System.Windows.Forms.Label();
            this.pnlPasos = new System.Windows.Forms.Panel();
            this.pnlPaso1 = new System.Windows.Forms.Panel();
            this.lblNumPaso1 = new System.Windows.Forms.Label();
            this.lblTextoPaso1 = new System.Windows.Forms.Label();
            this.pnlPaso2 = new System.Windows.Forms.Panel();
            this.lblNumPaso2 = new System.Windows.Forms.Label();
            this.lblTextoPaso2 = new System.Windows.Forms.Label();
            this.pnlPaso3 = new System.Windows.Forms.Panel();
            this.lblNumPaso3 = new System.Windows.Forms.Label();
            this.lblTextoPaso3 = new System.Windows.Forms.Label();

            // ── Panel derecho: controles compartidos ─────────
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblExito = new System.Windows.Forms.Label();

            // ── Paso 1: Correo ───────────────────────────────
            this.pnlStep1 = new System.Windows.Forms.Panel();
            this.lblTitulo1 = new System.Windows.Forms.Label();
            this.lblSub1 = new System.Windows.Forms.Label();
            this.lblLblCorreo = new System.Windows.Forms.Label();
            this.pnlWrapCorreo = new System.Windows.Forms.Panel();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.btnEnviarCodigo = new System.Windows.Forms.Button();
            this.lblVolver = new System.Windows.Forms.Label();

            // ── Paso 2: Código ───────────────────────────────
            this.pnlStep2 = new System.Windows.Forms.Panel();
            this.lblTitulo2 = new System.Windows.Forms.Label();
            this.lblSub2 = new System.Windows.Forms.Label();
            this.pnlCodigos = new System.Windows.Forms.Panel();
            this.txtCod1 = new System.Windows.Forms.TextBox();
            this.txtCod2 = new System.Windows.Forms.TextBox();
            this.txtCod3 = new System.Windows.Forms.TextBox();
            this.txtCod4 = new System.Windows.Forms.TextBox();
            this.txtCod5 = new System.Windows.Forms.TextBox();
            this.txtCod6 = new System.Windows.Forms.TextBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.lblReenviar = new System.Windows.Forms.Label();

            // ── Paso 3: Nueva contraseña ─────────────────────
            this.pnlStep3 = new System.Windows.Forms.Panel();
            this.lblTitulo3 = new System.Windows.Forms.Label();
            this.lblSub3 = new System.Windows.Forms.Label();
            this.lblLblNueva = new System.Windows.Forms.Label();
            this.pnlWrapNueva = new System.Windows.Forms.Panel();
            this.txtNueva = new System.Windows.Forms.TextBox();
            this.btnOjoNueva = new System.Windows.Forms.Button();
            this.lblLblConfirmar = new System.Windows.Forms.Label();
            this.pnlWrapConfirmar = new System.Windows.Forms.Panel();
            this.txtConfirmar = new System.Windows.Forms.TextBox();
            this.btnOjoConfirmar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();

            // ── Paso 4: Éxito ────────────────────────────────
            this.pnlStep4 = new System.Windows.Forms.Panel();
            this.picCheck = new System.Windows.Forms.PictureBox();
            this.lblTitulo4 = new System.Windows.Forms.Label();
            this.lblSub4 = new System.Windows.Forms.Label();
            this.btnIrLogin = new System.Windows.Forms.Button();

            this.SuspendLayout();
            this.pnlIzquierdo.SuspendLayout();
            this.pnlDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).BeginInit();

            // ════════════════════════════════════════════════
            // FORM
            // ════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 480);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRecuperacion";
            this.Text = "SIGEVAP — Recuperar contraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.DoubleBuffered = true;
            this.Controls.Add(this.pnlIzquierdo);
            this.Controls.Add(this.pnlDerecho);

            // ════════════════════════════════════════════════
            // PANEL IZQUIERDO (amarillo)
            // ════════════════════════════════════════════════
            this.pnlIzquierdo.BackColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.pnlIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.pnlIzquierdo.Name = "pnlIzquierdo";
            this.pnlIzquierdo.Size = new System.Drawing.Size(260, 480);
            this.pnlIzquierdo.TabIndex = 0;
            this.pnlIzquierdo.Controls.Add(this.picLogo);
            this.pnlIzquierdo.Controls.Add(this.lblTituloIzq);
            this.pnlIzquierdo.Controls.Add(this.lblSubtituloIzq);
            this.pnlIzquierdo.Controls.Add(this.pnlPasos);

            // ── picLogo ───────────────────────────────────────
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.picLogo.Location = new System.Drawing.Point(95, 50);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(70, 70);
            this.picLogo.TabStop = false;

            // ── lblTituloIzq ──────────────────────────────────
            this.lblTituloIzq.AutoSize = false;
            this.lblTituloIzq.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloIzq.Font = new System.Drawing.Font("Impact", 22F);
            this.lblTituloIzq.ForeColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.lblTituloIzq.Location = new System.Drawing.Point(10, 138);
            this.lblTituloIzq.Name = "lblTituloIzq";
            this.lblTituloIzq.Size = new System.Drawing.Size(240, 34);
            this.lblTituloIzq.Text = "Recuperar";
            this.lblTituloIzq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblSubtituloIzq ───────────────────────────────
            this.lblSubtituloIzq.AutoSize = false;
            this.lblSubtituloIzq.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtituloIzq.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSubtituloIzq.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblSubtituloIzq.Location = new System.Drawing.Point(10, 174);
            this.lblSubtituloIzq.Name = "lblSubtituloIzq";
            this.lblSubtituloIzq.Size = new System.Drawing.Size(240, 18);
            this.lblSubtituloIzq.Text = "ACCESO AL SISTEMA";
            this.lblSubtituloIzq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── pnlPasos (contenedor de los 3 pasos) ─────────
            this.pnlPasos.BackColor = System.Drawing.Color.Transparent;
            this.pnlPasos.Location = new System.Drawing.Point(30, 210);
            this.pnlPasos.Name = "pnlPasos";
            this.pnlPasos.Size = new System.Drawing.Size(200, 120);
            this.pnlPasos.Controls.Add(this.pnlPaso1);
            this.pnlPasos.Controls.Add(this.pnlPaso2);
            this.pnlPasos.Controls.Add(this.pnlPaso3);

            // ── Paso 1 indicador ──────────────────────────────
            this.pnlPaso1.BackColor = System.Drawing.Color.Transparent;
            this.pnlPaso1.Location = new System.Drawing.Point(0, 0);
            this.pnlPaso1.Size = new System.Drawing.Size(200, 34);
            this.pnlPaso1.Controls.Add(this.lblNumPaso1);
            this.pnlPaso1.Controls.Add(this.lblTextoPaso1);

            this.lblNumPaso1.AutoSize = false;
            this.lblNumPaso1.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.lblNumPaso1.ForeColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.lblNumPaso1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNumPaso1.Location = new System.Drawing.Point(0, 4);
            this.lblNumPaso1.Size = new System.Drawing.Size(26, 26);
            this.lblNumPaso1.Text = "1";
            this.lblNumPaso1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTextoPaso1.AutoSize = true;
            this.lblTextoPaso1.BackColor = System.Drawing.Color.Transparent;
            this.lblTextoPaso1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTextoPaso1.ForeColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.lblTextoPaso1.Location = new System.Drawing.Point(36, 9);
            this.lblTextoPaso1.Text = "Ingresar correo";

            // ── Paso 2 indicador ──────────────────────────────
            this.pnlPaso2.BackColor = System.Drawing.Color.Transparent;
            this.pnlPaso2.Location = new System.Drawing.Point(0, 40);
            this.pnlPaso2.Size = new System.Drawing.Size(200, 34);
            this.pnlPaso2.Controls.Add(this.lblNumPaso2);
            this.pnlPaso2.Controls.Add(this.lblTextoPaso2);

            this.lblNumPaso2.AutoSize = false;
            this.lblNumPaso2.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.lblNumPaso2.ForeColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.lblNumPaso2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNumPaso2.Location = new System.Drawing.Point(0, 4);
            this.lblNumPaso2.Size = new System.Drawing.Size(26, 26);
            this.lblNumPaso2.Text = "2";
            this.lblNumPaso2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTextoPaso2.AutoSize = true;
            this.lblTextoPaso2.BackColor = System.Drawing.Color.Transparent;
            this.lblTextoPaso2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTextoPaso2.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblTextoPaso2.Location = new System.Drawing.Point(36, 9);
            this.lblTextoPaso2.Text = "Verificar código";

            // ── Paso 3 indicador ──────────────────────────────
            this.pnlPaso3.BackColor = System.Drawing.Color.Transparent;
            this.pnlPaso3.Location = new System.Drawing.Point(0, 80);
            this.pnlPaso3.Size = new System.Drawing.Size(200, 34);
            this.pnlPaso3.Controls.Add(this.lblNumPaso3);
            this.pnlPaso3.Controls.Add(this.lblTextoPaso3);

            this.lblNumPaso3.AutoSize = false;
            this.lblNumPaso3.BackColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.lblNumPaso3.ForeColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.lblNumPaso3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNumPaso3.Location = new System.Drawing.Point(0, 4);
            this.lblNumPaso3.Size = new System.Drawing.Size(26, 26);
            this.lblNumPaso3.Text = "3";
            this.lblNumPaso3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTextoPaso3.AutoSize = true;
            this.lblTextoPaso3.BackColor = System.Drawing.Color.Transparent;
            this.lblTextoPaso3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTextoPaso3.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblTextoPaso3.Location = new System.Drawing.Point(36, 9);
            this.lblTextoPaso3.Text = "Nueva contraseña";

            // ════════════════════════════════════════════════
            // PANEL DERECHO
            // ════════════════════════════════════════════════
            this.pnlDerecho.BackColor = System.Drawing.Color.FromArgb(17, 17, 17);
            this.pnlDerecho.Location = new System.Drawing.Point(260, 0);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(520, 480);
            this.pnlDerecho.TabIndex = 1;
            this.pnlDerecho.Controls.Add(this.btnCerrar);
            this.pnlDerecho.Controls.Add(this.lblError);
            this.pnlDerecho.Controls.Add(this.lblExito);
            this.pnlDerecho.Controls.Add(this.pnlStep1);
            this.pnlDerecho.Controls.Add(this.pnlStep2);
            this.pnlDerecho.Controls.Add(this.pnlStep3);
            this.pnlDerecho.Controls.Add(this.pnlStep4);

            // ── btnCerrar ─────────────────────────────────────
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCerrar.Location = new System.Drawing.Point(478, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Text = "✕";
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;

            // ── lblError ──────────────────────────────────────
            this.lblError.AutoSize = false;
            this.lblError.BackColor = System.Drawing.Color.FromArgb(40, 20, 20);
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(240, 149, 149);
            this.lblError.Location = new System.Drawing.Point(44, 48);
            this.lblError.Name = "lblError";
            this.lblError.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblError.Size = new System.Drawing.Size(432, 30);
            this.lblError.TabIndex = 0;
            this.lblError.Text = "";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;

            // ── lblExito ──────────────────────────────────────
            this.lblExito.AutoSize = false;
            this.lblExito.BackColor = System.Drawing.Color.FromArgb(15, 40, 28);
            this.lblExito.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExito.ForeColor = System.Drawing.Color.FromArgb(93, 202, 165);
            this.lblExito.Location = new System.Drawing.Point(44, 48);
            this.lblExito.Name = "lblExito";
            this.lblExito.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblExito.Size = new System.Drawing.Size(432, 30);
            this.lblExito.Text = "";
            this.lblExito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblExito.Visible = false;

            // ════════════════════════════════════════════════
            // STEP 1 — Correo
            // ════════════════════════════════════════════════
            this.pnlStep1.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep1.Location = new System.Drawing.Point(44, 90);
            this.pnlStep1.Name = "pnlStep1";
            this.pnlStep1.Size = new System.Drawing.Size(432, 340);
            this.pnlStep1.Controls.Add(this.lblTitulo1);
            this.pnlStep1.Controls.Add(this.lblSub1);
            this.pnlStep1.Controls.Add(this.lblLblCorreo);
            this.pnlStep1.Controls.Add(this.pnlWrapCorreo);
            this.pnlStep1.Controls.Add(this.btnEnviarCodigo);
            this.pnlStep1.Controls.Add(this.lblVolver);

            this.lblTitulo1.AutoSize = true;
            this.lblTitulo1.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo1.Font = new System.Drawing.Font("Impact", 20F);
            this.lblTitulo1.ForeColor = System.Drawing.Color.White;
            this.lblTitulo1.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo1.Text = "¿Olvidaste tu contraseña?";

            this.lblSub1.AutoSize = true;
            this.lblSub1.BackColor = System.Drawing.Color.Transparent;
            this.lblSub1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSub1.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSub1.Location = new System.Drawing.Point(0, 36);
            this.lblSub1.Text = "Ingresá tu correo y te enviaremos un código de verificación";

            this.lblLblCorreo.AutoSize = true;
            this.lblLblCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblLblCorreo.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblLblCorreo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblLblCorreo.Location = new System.Drawing.Point(0, 76);
            this.lblLblCorreo.Text = "CORREO ELECTRÓNICO";

            this.pnlWrapCorreo.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.pnlWrapCorreo.Location = new System.Drawing.Point(0, 94);
            this.pnlWrapCorreo.Name = "pnlWrapCorreo";
            this.pnlWrapCorreo.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pnlWrapCorreo.Size = new System.Drawing.Size(432, 42);
            this.pnlWrapCorreo.Controls.Add(this.txtCorreo);

            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.TabIndex = 0;
            this.txtCorreo.Text = "usuario@empresa.com";

            this.btnEnviarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarCodigo.FlatAppearance.BorderSize = 0;
            this.btnEnviarCodigo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 208, 0);
            this.btnEnviarCodigo.BackColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.btnEnviarCodigo.ForeColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.btnEnviarCodigo.Font = new System.Drawing.Font("Impact", 12F);
            this.btnEnviarCodigo.Location = new System.Drawing.Point(0, 156);
            this.btnEnviarCodigo.Name = "btnEnviarCodigo";
            this.btnEnviarCodigo.Size = new System.Drawing.Size(432, 44);
            this.btnEnviarCodigo.Text = "ENVIAR CÓDIGO";
            this.btnEnviarCodigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviarCodigo.UseVisualStyleBackColor = false;

            this.lblVolver.AutoSize = true;
            this.lblVolver.BackColor = System.Drawing.Color.Transparent;
            this.lblVolver.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Underline);
            this.lblVolver.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblVolver.Location = new System.Drawing.Point(0, 212);
            this.lblVolver.Text = "← Volver al inicio de sesión";
            this.lblVolver.Cursor = System.Windows.Forms.Cursors.Hand;

            // ════════════════════════════════════════════════
            // STEP 2 — Código
            // ════════════════════════════════════════════════
            this.pnlStep2.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep2.Location = new System.Drawing.Point(44, 90);
            this.pnlStep2.Name = "pnlStep2";
            this.pnlStep2.Size = new System.Drawing.Size(432, 360);
            this.pnlStep2.Visible = false;
            this.pnlStep2.Controls.Add(this.lblTitulo2);
            this.pnlStep2.Controls.Add(this.lblSub2);
            this.pnlStep2.Controls.Add(this.pnlCodigos);
            this.pnlStep2.Controls.Add(this.lblTimer);
            this.pnlStep2.Controls.Add(this.btnVerificar);
            this.pnlStep2.Controls.Add(this.lblReenviar);

            this.lblTitulo2.AutoSize = true;
            this.lblTitulo2.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo2.Font = new System.Drawing.Font("Impact", 20F);
            this.lblTitulo2.ForeColor = System.Drawing.Color.White;
            this.lblTitulo2.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo2.Text = "Verificar código";

            this.lblSub2.AutoSize = false;
            this.lblSub2.BackColor = System.Drawing.Color.Transparent;
            this.lblSub2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSub2.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSub2.Location = new System.Drawing.Point(0, 36);
            this.lblSub2.Size = new System.Drawing.Size(432, 18);
            this.lblSub2.Text = "Ingresá el código de 6 dígitos enviado a tu correo";

            // Panel que contiene los 6 inputs del código
            this.pnlCodigos.BackColor = System.Drawing.Color.Transparent;
            this.pnlCodigos.Location = new System.Drawing.Point(0, 70);
            this.pnlCodigos.Name = "pnlCodigos";
            this.pnlCodigos.Size = new System.Drawing.Size(390, 56);
            this.pnlCodigos.Controls.Add(this.txtCod1);
            this.pnlCodigos.Controls.Add(this.txtCod2);
            this.pnlCodigos.Controls.Add(this.txtCod3);
            this.pnlCodigos.Controls.Add(this.txtCod4);
            this.pnlCodigos.Controls.Add(this.txtCod5);
            this.pnlCodigos.Controls.Add(this.txtCod6);

            // Los 6 inputs del código tienen la misma configuración
            // solo cambia Location.X
            int[] xCod = { 0, 58, 116, 174, 232, 290 };
            System.Windows.Forms.TextBox[] codigos = {
                this.txtCod1, this.txtCod2, this.txtCod3,
                this.txtCod4, this.txtCod5, this.txtCod6
            };
            string[] nombresCod = { "txtCod1", "txtCod2", "txtCod3", "txtCod4", "txtCod5", "txtCod6" };
            for (int i = 0; i < 6; i++)
            {
                codigos[i].BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                codigos[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                codigos[i].Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
                codigos[i].ForeColor = System.Drawing.Color.White;
                codigos[i].Location = new System.Drawing.Point(xCod[i], 0);
                codigos[i].MaxLength = 1;
                codigos[i].Name = nombresCod[i];
                codigos[i].Size = new System.Drawing.Size(50, 52);
                codigos[i].TabIndex = i + 10;
                codigos[i].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            }

            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimer.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblTimer.Location = new System.Drawing.Point(0, 138);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Text = "Código válido por 10:00";

            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.FlatAppearance.BorderSize = 0;
            this.btnVerificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 208, 0);
            this.btnVerificar.BackColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.btnVerificar.ForeColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.btnVerificar.Font = new System.Drawing.Font("Impact", 12F);
            this.btnVerificar.Location = new System.Drawing.Point(0, 168);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(432, 44);
            this.btnVerificar.Text = "VERIFICAR CÓDIGO";
            this.btnVerificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificar.UseVisualStyleBackColor = false;

            this.lblReenviar.AutoSize = true;
            this.lblReenviar.BackColor = System.Drawing.Color.Transparent;
            this.lblReenviar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Underline);
            this.lblReenviar.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblReenviar.Location = new System.Drawing.Point(0, 224);
            this.lblReenviar.Text = "Reenviar código";
            this.lblReenviar.Cursor = System.Windows.Forms.Cursors.Hand;

            // ════════════════════════════════════════════════
            // STEP 3 — Nueva contraseña
            // ════════════════════════════════════════════════
            this.pnlStep3.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep3.Location = new System.Drawing.Point(44, 90);
            this.pnlStep3.Name = "pnlStep3";
            this.pnlStep3.Size = new System.Drawing.Size(432, 360);
            this.pnlStep3.Visible = false;
            this.pnlStep3.Controls.Add(this.lblTitulo3);
            this.pnlStep3.Controls.Add(this.lblSub3);
            this.pnlStep3.Controls.Add(this.lblLblNueva);
            this.pnlStep3.Controls.Add(this.pnlWrapNueva);
            this.pnlStep3.Controls.Add(this.lblLblConfirmar);
            this.pnlStep3.Controls.Add(this.pnlWrapConfirmar);
            this.pnlStep3.Controls.Add(this.btnGuardar);

            this.lblTitulo3.AutoSize = true;
            this.lblTitulo3.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo3.Font = new System.Drawing.Font("Impact", 20F);
            this.lblTitulo3.ForeColor = System.Drawing.Color.White;
            this.lblTitulo3.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo3.Text = "Nueva contraseña";

            this.lblSub3.AutoSize = true;
            this.lblSub3.BackColor = System.Drawing.Color.Transparent;
            this.lblSub3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSub3.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSub3.Location = new System.Drawing.Point(0, 36);
            this.lblSub3.Text = "Elegí una contraseña segura para tu cuenta";

            // Campo nueva contraseña
            this.lblLblNueva.AutoSize = true;
            this.lblLblNueva.BackColor = System.Drawing.Color.Transparent;
            this.lblLblNueva.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblLblNueva.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblLblNueva.Location = new System.Drawing.Point(0, 72);
            this.lblLblNueva.Text = "NUEVA CONTRASEÑA";

            this.pnlWrapNueva.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.pnlWrapNueva.Location = new System.Drawing.Point(0, 90);
            this.pnlWrapNueva.Name = "pnlWrapNueva";
            this.pnlWrapNueva.Padding = new System.Windows.Forms.Padding(10, 3, 38, 3);
            this.pnlWrapNueva.Size = new System.Drawing.Size(432, 42);
            this.pnlWrapNueva.Controls.Add(this.btnOjoNueva);
            this.pnlWrapNueva.Controls.Add(this.txtNueva);

            this.txtNueva.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.txtNueva.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNueva.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNueva.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNueva.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.txtNueva.Name = "txtNueva";
            this.txtNueva.TabIndex = 20;
            this.txtNueva.Text = "Mínimo 8 caracteres";
            this.txtNueva.UseSystemPasswordChar = false;

            this.btnOjoNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOjoNueva.FlatAppearance.BorderSize = 0;
            this.btnOjoNueva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOjoNueva.BackColor = System.Drawing.Color.Transparent;
            this.btnOjoNueva.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnOjoNueva.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnOjoNueva.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.btnOjoNueva.Location = new System.Drawing.Point(396, 8);
            this.btnOjoNueva.Name = "btnOjoNueva";
            this.btnOjoNueva.Size = new System.Drawing.Size(30, 26);
            this.btnOjoNueva.TabStop = false;
            this.btnOjoNueva.Text = "👁";
            this.btnOjoNueva.Cursor = System.Windows.Forms.Cursors.Hand;

            // Campo confirmar contraseña
            this.lblLblConfirmar.AutoSize = true;
            this.lblLblConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.lblLblConfirmar.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblLblConfirmar.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblLblConfirmar.Location = new System.Drawing.Point(0, 146);
            this.lblLblConfirmar.Text = "CONFIRMAR CONTRASEÑA";

            this.pnlWrapConfirmar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.pnlWrapConfirmar.Location = new System.Drawing.Point(0, 164);
            this.pnlWrapConfirmar.Name = "pnlWrapConfirmar";
            this.pnlWrapConfirmar.Padding = new System.Windows.Forms.Padding(10, 3, 38, 3);
            this.pnlWrapConfirmar.Size = new System.Drawing.Size(432, 42);
            this.pnlWrapConfirmar.Controls.Add(this.btnOjoConfirmar);
            this.pnlWrapConfirmar.Controls.Add(this.txtConfirmar);

            this.txtConfirmar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.txtConfirmar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmar.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.TabIndex = 21;
            this.txtConfirmar.Text = "Repetí la contraseña";
            this.txtConfirmar.UseSystemPasswordChar = false;

            this.btnOjoConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOjoConfirmar.FlatAppearance.BorderSize = 0;
            this.btnOjoConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOjoConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.btnOjoConfirmar.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnOjoConfirmar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnOjoConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.btnOjoConfirmar.Location = new System.Drawing.Point(396, 8);
            this.btnOjoConfirmar.Name = "btnOjoConfirmar";
            this.btnOjoConfirmar.Size = new System.Drawing.Size(30, 26);
            this.btnOjoConfirmar.TabStop = false;
            this.btnOjoConfirmar.Text = "👁";
            this.btnOjoConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 208, 0);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.btnGuardar.Font = new System.Drawing.Font("Impact", 12F);
            this.btnGuardar.Location = new System.Drawing.Point(0, 224);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(432, 44);
            this.btnGuardar.Text = "GUARDAR CONTRASEÑA";
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.UseVisualStyleBackColor = false;

            // ════════════════════════════════════════════════
            // STEP 4 — Éxito
            // ════════════════════════════════════════════════
            this.pnlStep4.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep4.Location = new System.Drawing.Point(44, 90);
            this.pnlStep4.Name = "pnlStep4";
            this.pnlStep4.Size = new System.Drawing.Size(432, 320);
            this.pnlStep4.Visible = false;
            this.pnlStep4.Controls.Add(this.picCheck);
            this.pnlStep4.Controls.Add(this.lblTitulo4);
            this.pnlStep4.Controls.Add(this.lblSub4);
            this.pnlStep4.Controls.Add(this.btnIrLogin);

            this.picCheck.BackColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.picCheck.Location = new System.Drawing.Point(184, 20);
            this.picCheck.Name = "picCheck";
            this.picCheck.Size = new System.Drawing.Size(64, 64);
            this.picCheck.TabStop = false;

            this.lblTitulo4.AutoSize = false;
            this.lblTitulo4.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo4.Font = new System.Drawing.Font("Impact", 20F);
            this.lblTitulo4.ForeColor = System.Drawing.Color.White;
            this.lblTitulo4.Location = new System.Drawing.Point(0, 102);
            this.lblTitulo4.Size = new System.Drawing.Size(432, 34);
            this.lblTitulo4.Text = "¡Contraseña actualizada!";
            this.lblTitulo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSub4.AutoSize = false;
            this.lblSub4.BackColor = System.Drawing.Color.Transparent;
            this.lblSub4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSub4.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSub4.Location = new System.Drawing.Point(0, 142);
            this.lblSub4.Size = new System.Drawing.Size(432, 36);
            this.lblSub4.Text = "Tu contraseña fue cambiada exitosamente.\nYa podés iniciar sesión con tu nueva contraseña.";
            this.lblSub4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnIrLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrLogin.FlatAppearance.BorderSize = 0;
            this.btnIrLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 208, 0);
            this.btnIrLogin.BackColor = System.Drawing.Color.FromArgb(245, 196, 0);
            this.btnIrLogin.ForeColor = System.Drawing.Color.FromArgb(13, 13, 13);
            this.btnIrLogin.Font = new System.Drawing.Font("Impact", 12F);
            this.btnIrLogin.Location = new System.Drawing.Point(0, 196);
            this.btnIrLogin.Name = "btnIrLogin";
            this.btnIrLogin.Size = new System.Drawing.Size(432, 44);
            this.btnIrLogin.Text = "IR AL INICIO DE SESIÓN";
            this.btnIrLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIrLogin.UseVisualStyleBackColor = false;

            // ── Reanudar layout ───────────────────────────────
            this.pnlIzquierdo.ResumeLayout(false);
            this.pnlDerecho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlIzquierdo;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTituloIzq;
        private System.Windows.Forms.Label lblSubtituloIzq;
        private System.Windows.Forms.Panel pnlPasos;
        private System.Windows.Forms.Panel pnlPaso1;
        private System.Windows.Forms.Label lblNumPaso1;
        private System.Windows.Forms.Label lblTextoPaso1;
        private System.Windows.Forms.Panel pnlPaso2;
        private System.Windows.Forms.Label lblNumPaso2;
        private System.Windows.Forms.Label lblTextoPaso2;
        private System.Windows.Forms.Panel pnlPaso3;
        private System.Windows.Forms.Label lblNumPaso3;
        private System.Windows.Forms.Label lblTextoPaso3;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblExito;
        private System.Windows.Forms.Panel pnlStep1;
        private System.Windows.Forms.Label lblTitulo1;
        private System.Windows.Forms.Label lblSub1;
        private System.Windows.Forms.Label lblLblCorreo;
        private System.Windows.Forms.Panel pnlWrapCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button btnEnviarCodigo;
        private System.Windows.Forms.Label lblVolver;
        private System.Windows.Forms.Panel pnlStep2;
        private System.Windows.Forms.Label lblTitulo2;
        private System.Windows.Forms.Label lblSub2;
        private System.Windows.Forms.Panel pnlCodigos;
        private System.Windows.Forms.TextBox txtCod1;
        private System.Windows.Forms.TextBox txtCod2;
        private System.Windows.Forms.TextBox txtCod3;
        private System.Windows.Forms.TextBox txtCod4;
        private System.Windows.Forms.TextBox txtCod5;
        private System.Windows.Forms.TextBox txtCod6;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Label lblReenviar;
        private System.Windows.Forms.Panel pnlStep3;
        private System.Windows.Forms.Label lblTitulo3;
        private System.Windows.Forms.Label lblSub3;
        private System.Windows.Forms.Label lblLblNueva;
        private System.Windows.Forms.Panel pnlWrapNueva;
        private System.Windows.Forms.TextBox txtNueva;
        private System.Windows.Forms.Button btnOjoNueva;
        private System.Windows.Forms.Label lblLblConfirmar;
        private System.Windows.Forms.Panel pnlWrapConfirmar;
        private System.Windows.Forms.TextBox txtConfirmar;
        private System.Windows.Forms.Button btnOjoConfirmar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlStep4;
        private System.Windows.Forms.PictureBox picCheck;
        private System.Windows.Forms.Label lblTitulo4;
        private System.Windows.Forms.Label lblSub4;
        private System.Windows.Forms.Button btnIrLogin;
    }
}