// ============================================================
// SIGEVAP — Views/FrmLogin.Designer.cs
// Generado para compatibilidad con el diseñador de Visual Studio
// Los controles están declarados aquí y son editables visualmente
// ============================================================

namespace SIGEVAP.Views
{
    partial class FrmLogin
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
            pnlIzquierdo = new Panel();
            picLogo = new PictureBox();
            lblSistema = new Label();
            lblSubtitulo = new Label();
            pnlDerecho = new Panel();
            btnCerrar = new Button();
            lblTitulo = new Label();
            lblBienvenida = new Label();
            lblError = new Label();
            lblLblUsuario = new Label();
            pnlWrapUsuario = new Panel();
            txtUsuario = new TextBox();
            lblLblContrasena = new Label();
            pnlWrapContrasena = new Panel();
            btnMostrar = new Button();
            txtContrasena = new TextBox();
            lblOlvide = new Label();
            btnIngresar = new Button();
            lblVersion = new Label();
            pnlIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlDerecho.SuspendLayout();
            pnlWrapUsuario.SuspendLayout();
            pnlWrapContrasena.SuspendLayout();
            SuspendLayout();
            // 
            // pnlIzquierdo
            // 
            pnlIzquierdo.BackColor = Color.FromArgb(245, 196, 0);
            pnlIzquierdo.Controls.Add(picLogo);
            pnlIzquierdo.Controls.Add(lblSistema);
            pnlIzquierdo.Controls.Add(lblSubtitulo);
            pnlIzquierdo.Location = new Point(0, 0);
            pnlIzquierdo.Margin = new Padding(4, 5, 4, 5);
            pnlIzquierdo.Name = "pnlIzquierdo";
            pnlIzquierdo.Size = new Size(443, 833);
            pnlIzquierdo.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.FromArgb(13, 13, 13);
            picLogo.Location = new Point(164, 167);
            picLogo.Margin = new Padding(4, 5, 4, 5);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(114, 133);
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblSistema
            // 
            lblSistema.BackColor = Color.Transparent;
            lblSistema.Font = new Font("Impact", 28F);
            lblSistema.ForeColor = Color.FromArgb(13, 13, 13);
            lblSistema.Location = new Point(29, 333);
            lblSistema.Margin = new Padding(4, 0, 4, 0);
            lblSistema.Name = "lblSistema";
            lblSistema.Size = new Size(386, 67);
            lblSistema.TabIndex = 1;
            lblSistema.Text = "SIGEVAP";
            lblSistema.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 80, 80);
            lblSubtitulo.Location = new Point(29, 408);
            lblSubtitulo.Margin = new Padding(4, 0, 4, 0);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(386, 67);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Sistema de Gestión de\nVacaciones y Permisos";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDerecho
            // 
            pnlDerecho.BackColor = Color.FromArgb(17, 17, 17);
            pnlDerecho.Controls.Add(btnCerrar);
            pnlDerecho.Controls.Add(lblTitulo);
            pnlDerecho.Controls.Add(lblBienvenida);
            pnlDerecho.Controls.Add(lblError);
            pnlDerecho.Controls.Add(lblLblUsuario);
            pnlDerecho.Controls.Add(pnlWrapUsuario);
            pnlDerecho.Controls.Add(lblLblContrasena);
            pnlDerecho.Controls.Add(pnlWrapContrasena);
            pnlDerecho.Controls.Add(lblOlvide);
            pnlDerecho.Controls.Add(btnIngresar);
            pnlDerecho.Controls.Add(lblVersion);
            pnlDerecho.Location = new Point(443, 0);
            pnlDerecho.Margin = new Padding(4, 5, 4, 5);
            pnlDerecho.Name = "pnlDerecho";
            pnlDerecho.Size = new Size(729, 833);
            pnlDerecho.TabIndex = 1;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 40, 40);
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 10F);
            btnCerrar.ForeColor = Color.FromArgb(100, 100, 100);
            btnCerrar.Location = new Point(669, 17);
            btnCerrar.Margin = new Padding(4, 5, 4, 5);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(43, 50);
            btnCerrar.TabIndex = 99;
            btnCerrar.Text = "✕";
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Impact", 22F);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(86, 117);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(273, 54);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Iniciar Sesión";
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.BackColor = Color.Transparent;
            lblBienvenida.Font = new Font("Segoe UI", 9F);
            lblBienvenida.ForeColor = Color.FromArgb(100, 100, 100);
            lblBienvenida.Location = new Point(86, 170);
            lblBienvenida.Margin = new Padding(4, 0, 4, 0);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(318, 25);
            lblBienvenida.TabIndex = 1;
            lblBienvenida.Text = "Ingresá tus credenciales para continuar";
            // 
            // lblError
            // 
            lblError.BackColor = Color.FromArgb(40, 20, 20);
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.FromArgb(240, 149, 149);
            lblError.Location = new Point(86, 217);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Padding = new Padding(11, 0, 0, 0);
            lblError.Size = new Size(557, 50);
            lblError.TabIndex = 2;
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            lblError.Visible = false;
            // 
            // lblLblUsuario
            // 
            lblLblUsuario.AutoSize = true;
            lblLblUsuario.BackColor = Color.Transparent;
            lblLblUsuario.Font = new Font("Segoe UI", 7.5F);
            lblLblUsuario.ForeColor = Color.FromArgb(100, 100, 100);
            lblLblUsuario.Location = new Point(86, 287);
            lblLblUsuario.Margin = new Padding(4, 0, 4, 0);
            lblLblUsuario.Name = "lblLblUsuario";
            lblLblUsuario.Size = new Size(71, 20);
            lblLblUsuario.TabIndex = 3;
            lblLblUsuario.Text = "USUARIO";
            // 
            // pnlWrapUsuario
            // 
            pnlWrapUsuario.BackColor = Color.FromArgb(26, 26, 26);
            pnlWrapUsuario.Controls.Add(txtUsuario);
            pnlWrapUsuario.Location = new Point(86, 320);
            pnlWrapUsuario.Margin = new Padding(4, 5, 4, 5);
            pnlWrapUsuario.Name = "pnlWrapUsuario";
            pnlWrapUsuario.Padding = new Padding(14, 5, 0, 5);
            pnlWrapUsuario.Size = new Size(557, 70);
            pnlWrapUsuario.TabIndex = 4;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(26, 26, 26);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Dock = DockStyle.Fill;
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtUsuario.ForeColor = Color.FromArgb(100, 100, 100);
            txtUsuario.Location = new Point(14, 5);
            txtUsuario.Margin = new Padding(4, 5, 4, 5);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(543, 27);
            txtUsuario.TabIndex = 0;
            txtUsuario.Text = "Nombre de usuario";
            // 
            // lblLblContrasena
            // 
            lblLblContrasena.AutoSize = true;
            lblLblContrasena.BackColor = Color.Transparent;
            lblLblContrasena.Font = new Font("Segoe UI", 7.5F);
            lblLblContrasena.ForeColor = Color.FromArgb(100, 100, 100);
            lblLblContrasena.Location = new Point(86, 417);
            lblLblContrasena.Margin = new Padding(4, 0, 4, 0);
            lblLblContrasena.Name = "lblLblContrasena";
            lblLblContrasena.Size = new Size(104, 20);
            lblLblContrasena.TabIndex = 5;
            lblLblContrasena.Text = "CONTRASEÑA";
            // 
            // pnlWrapContrasena
            // 
            pnlWrapContrasena.BackColor = Color.FromArgb(26, 26, 26);
            pnlWrapContrasena.Controls.Add(btnMostrar);
            pnlWrapContrasena.Controls.Add(txtContrasena);
            pnlWrapContrasena.Location = new Point(86, 450);
            pnlWrapContrasena.Margin = new Padding(4, 5, 4, 5);
            pnlWrapContrasena.Name = "pnlWrapContrasena";
            pnlWrapContrasena.Padding = new Padding(14, 5, 54, 5);
            pnlWrapContrasena.Size = new Size(557, 70);
            pnlWrapContrasena.TabIndex = 6;
            // 
            // btnMostrar
            // 
            btnMostrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMostrar.BackColor = Color.Transparent;
            btnMostrar.Cursor = Cursors.Hand;
            btnMostrar.FlatAppearance.BorderSize = 0;
            btnMostrar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMostrar.FlatStyle = FlatStyle.Flat;
            btnMostrar.Font = new Font("Segoe UI", 11F);
            btnMostrar.ForeColor = Color.FromArgb(100, 100, 100);
            btnMostrar.Location = new Point(506, 13);
            btnMostrar.Margin = new Padding(4, 5, 4, 5);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(43, 43);
            btnMostrar.TabIndex = 7;
            btnMostrar.TabStop = false;
            btnMostrar.Text = "👁";
            btnMostrar.UseVisualStyleBackColor = false;
            // 
            // txtContrasena
            // 
            txtContrasena.BackColor = Color.FromArgb(26, 26, 26);
            txtContrasena.BorderStyle = BorderStyle.None;
            txtContrasena.Dock = DockStyle.Fill;
            txtContrasena.Font = new Font("Segoe UI", 10F);
            txtContrasena.ForeColor = Color.FromArgb(100, 100, 100);
            txtContrasena.Location = new Point(14, 5);
            txtContrasena.Margin = new Padding(4, 5, 4, 5);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(489, 27);
            txtContrasena.TabIndex = 1;
            txtContrasena.Text = "Contraseña";
            // 
            // lblOlvide
            // 
            lblOlvide.AutoSize = true;
            lblOlvide.BackColor = Color.Transparent;
            lblOlvide.Cursor = Cursors.Hand;
            lblOlvide.Font = new Font("Segoe UI", 8.5F, FontStyle.Underline);
            lblOlvide.ForeColor = Color.FromArgb(245, 196, 0);
            lblOlvide.Location = new Point(86, 537);
            lblOlvide.Margin = new Padding(4, 0, 4, 0);
            lblOlvide.Name = "lblOlvide";
            lblOlvide.Size = new Size(206, 23);
            lblOlvide.TabIndex = 8;
            lblOlvide.Text = "¿Olvidaste tu contraseña?";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(245, 196, 0);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 208, 0);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Impact", 13F);
            btnIngresar.ForeColor = Color.FromArgb(13, 13, 13);
            btnIngresar.Location = new Point(86, 587);
            btnIngresar.Margin = new Padding(4, 5, 4, 5);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(557, 77);
            btnIngresar.TabIndex = 9;
            btnIngresar.Text = "INGRESAR AL SISTEMA";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.BackColor = Color.Transparent;
            lblVersion.Font = new Font("Segoe UI", 7.5F);
            lblVersion.ForeColor = Color.FromArgb(50, 50, 50);
            lblVersion.Location = new Point(243, 770);
            lblVersion.Margin = new Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(163, 20);
            lblVersion.TabIndex = 10;
            lblVersion.Text = "SIGEVAP v1.0  ·  © 2025";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 13, 13);
            ClientSize = new Size(1171, 833);
            Controls.Add(pnlIzquierdo);
            Controls.Add(pnlDerecho);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SIGEVAP — Iniciar Sesión";
            pnlIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlDerecho.ResumeLayout(false);
            pnlDerecho.PerformLayout();
            pnlWrapUsuario.ResumeLayout(false);
            pnlWrapUsuario.PerformLayout();
            pnlWrapContrasena.ResumeLayout(false);
            pnlWrapContrasena.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlIzquierdo;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblLblUsuario;
        private System.Windows.Forms.Panel pnlWrapUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblLblContrasena;
        private System.Windows.Forms.Panel pnlWrapContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Label lblOlvide;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblVersion;
    }
}