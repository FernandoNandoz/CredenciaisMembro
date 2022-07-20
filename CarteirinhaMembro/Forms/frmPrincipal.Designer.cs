namespace CarteirinhaMembro
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label labelTitulo;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panelMenuContent = new System.Windows.Forms.Panel();
            this.btnImpressões = new System.Windows.Forms.Button();
            this.btnMembros = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.labelNomeUsuarioHeader = new System.Windows.Forms.Label();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            labelTitulo = new System.Windows.Forms.Label();
            this.panelMenuContent.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            labelTitulo.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold);
            labelTitulo.ForeColor = System.Drawing.SystemColors.Control;
            labelTitulo.Location = new System.Drawing.Point(19, -9);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(189, 57);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Secretaria";
            // 
            // panelMenuContent
            // 
            this.panelMenuContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.panelMenuContent.Controls.Add(this.btnImpressões);
            this.panelMenuContent.Controls.Add(this.btnMembros);
            this.panelMenuContent.Controls.Add(this.btnDashboard);
            this.panelMenuContent.Controls.Add(this.btnConfiguracoes);
            this.panelMenuContent.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuContent.Location = new System.Drawing.Point(0, 40);
            this.panelMenuContent.Name = "panelMenuContent";
            this.panelMenuContent.Size = new System.Drawing.Size(180, 657);
            this.panelMenuContent.TabIndex = 6;
            // 
            // btnImpressões
            // 
            this.btnImpressões.FlatAppearance.BorderSize = 0;
            this.btnImpressões.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImpressões.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnImpressões.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.btnImpressões.Image = ((System.Drawing.Image)(resources.GetObject("btnImpressões.Image")));
            this.btnImpressões.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImpressões.Location = new System.Drawing.Point(0, 116);
            this.btnImpressões.Name = "btnImpressões";
            this.btnImpressões.Size = new System.Drawing.Size(180, 50);
            this.btnImpressões.TabIndex = 7;
            this.btnImpressões.Text = "  Credenciais";
            this.btnImpressões.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImpressões.UseVisualStyleBackColor = true;
            this.btnImpressões.Click += new System.EventHandler(this.btnImpressões_Click);
            // 
            // btnMembros
            // 
            this.btnMembros.FlatAppearance.BorderSize = 0;
            this.btnMembros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnMembros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.btnMembros.Image = ((System.Drawing.Image)(resources.GetObject("btnMembros.Image")));
            this.btnMembros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembros.Location = new System.Drawing.Point(0, 63);
            this.btnMembros.Name = "btnMembros";
            this.btnMembros.Size = new System.Drawing.Size(180, 50);
            this.btnMembros.TabIndex = 6;
            this.btnMembros.Text = "  Membros";
            this.btnMembros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMembros.UseVisualStyleBackColor = true;
            this.btnMembros.Click += new System.EventHandler(this.btnMembros_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 11);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(180, 50);
            this.btnDashboard.TabIndex = 5;
            this.btnDashboard.Text = "  Home";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.btnConfiguracoes.FlatAppearance.BorderSize = 0;
            this.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.btnConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("btnConfiguracoes.Image")));
            this.btnConfiguracoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracoes.Location = new System.Drawing.Point(0, 605);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(180, 50);
            this.btnConfiguracoes.TabIndex = 4;
            this.btnConfiguracoes.Text = "   Configurações";
            this.btnConfiguracoes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfiguracoes.UseVisualStyleBackColor = false;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelMenu.Controls.Add(this.labelNomeUsuarioHeader);
            this.panelMenu.Controls.Add(labelTitulo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1359, 40);
            this.panelMenu.TabIndex = 5;
            // 
            // labelNomeUsuarioHeader
            // 
            this.labelNomeUsuarioHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNomeUsuarioHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelNomeUsuarioHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelNomeUsuarioHeader.Location = new System.Drawing.Point(816, 6);
            this.labelNomeUsuarioHeader.Name = "labelNomeUsuarioHeader";
            this.labelNomeUsuarioHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelNomeUsuarioHeader.Size = new System.Drawing.Size(527, 30);
            this.labelNomeUsuarioHeader.TabIndex = 1;
            this.labelNomeUsuarioHeader.Text = "Assembleia de Deus COMADEMAT em Boca do Acre";
            this.labelNomeUsuarioHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelDashboard
            // 
            this.panelDashboard.Controls.Add(this.panel2);
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Location = new System.Drawing.Point(180, 40);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(1179, 657);
            this.panelDashboard.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1179, 657);
            this.panel2.TabIndex = 4;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 697);
            this.Controls.Add(this.panelDashboard);
            this.Controls.Add(this.panelMenuContent);
            this.Controls.Add(this.panelMenu);
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carteirinha de Membro";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panelMenuContent.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelDashboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenuContent;
        private System.Windows.Forms.Button btnMembros;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label labelNomeUsuarioHeader;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnImpressões;
    }
}

