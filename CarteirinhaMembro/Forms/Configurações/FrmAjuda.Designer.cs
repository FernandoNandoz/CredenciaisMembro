﻿namespace CarteirinhaMembro.Forms.Configurações
{
    partial class FrmAjuda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label labelLinhaHeader;
            System.Windows.Forms.Label labelTituloHeaderContent;
            System.Windows.Forms.Label labelLinhaHeaderContent;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAjuda));
            this.panelInfoHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelNamePatientHeader = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonPesquisa = new System.Windows.Forms.Button();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelContent = new System.Windows.Forms.FlowLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            labelLinhaHeader = new System.Windows.Forms.Label();
            labelTituloHeaderContent = new System.Windows.Forms.Label();
            labelLinhaHeaderContent = new System.Windows.Forms.Label();
            this.panelInfoHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            label2.Location = new System.Drawing.Point(125, 51);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(719, 22);
            label2.TabIndex = 45;
            label2.Text = "Sistema de gestão de dados cadastrais e emissão da Carteirinha de Membro dos irmã" +
    "os.";
            // 
            // labelLinhaHeader
            // 
            labelLinhaHeader.AutoSize = true;
            labelLinhaHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            labelLinhaHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            labelLinhaHeader.Location = new System.Drawing.Point(20, 68);
            labelLinhaHeader.Name = "labelLinhaHeader";
            labelLinhaHeader.Size = new System.Drawing.Size(860, 24);
            labelLinhaHeader.TabIndex = 33;
            labelLinhaHeader.Text = "_________________________________________________________________________________" +
    "____";
            // 
            // labelTituloHeaderContent
            // 
            labelTituloHeaderContent.AutoSize = true;
            labelTituloHeaderContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            labelTituloHeaderContent.ForeColor = System.Drawing.SystemColors.Control;
            labelTituloHeaderContent.Location = new System.Drawing.Point(19, 8);
            labelTituloHeaderContent.Name = "labelTituloHeaderContent";
            labelTituloHeaderContent.Size = new System.Drawing.Size(142, 24);
            labelTituloHeaderContent.TabIndex = 15;
            labelTituloHeaderContent.Text = "Lista de tutoriais";
            // 
            // labelLinhaHeaderContent
            // 
            labelLinhaHeaderContent.AutoSize = true;
            labelLinhaHeaderContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            labelLinhaHeaderContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            labelLinhaHeaderContent.Location = new System.Drawing.Point(19, 18);
            labelLinhaHeaderContent.Name = "labelLinhaHeaderContent";
            labelLinhaHeaderContent.Size = new System.Drawing.Size(860, 24);
            labelLinhaHeaderContent.TabIndex = 16;
            labelLinhaHeaderContent.Text = "_________________________________________________________________________________" +
    "____";
            // 
            // panelInfoHeader
            // 
            this.panelInfoHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInfoHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.panelInfoHeader.Controls.Add(this.pictureBox1);
            this.panelInfoHeader.Controls.Add(label2);
            this.panelInfoHeader.Controls.Add(this.labelNamePatientHeader);
            this.panelInfoHeader.Controls.Add(labelLinhaHeader);
            this.panelInfoHeader.Location = new System.Drawing.Point(8, 10);
            this.panelInfoHeader.Name = "panelInfoHeader";
            this.panelInfoHeader.Size = new System.Drawing.Size(900, 100);
            this.panelInfoHeader.TabIndex = 43;
            this.panelInfoHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelInfoHeader_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // labelNamePatientHeader
            // 
            this.labelNamePatientHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelNamePatientHeader.ForeColor = System.Drawing.SystemColors.Control;
            this.labelNamePatientHeader.Location = new System.Drawing.Point(109, 13);
            this.labelNamePatientHeader.Name = "labelNamePatientHeader";
            this.labelNamePatientHeader.Size = new System.Drawing.Size(680, 31);
            this.labelNamePatientHeader.TabIndex = 38;
            this.labelNamePatientHeader.Text = "Assembléia de Deus - COMADEMAT - (Tutoriais)";
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.panelContent.Controls.Add(this.buttonPesquisa);
            this.panelContent.Controls.Add(this.textBoxPesquisa);
            this.panelContent.Controls.Add(this.flowLayoutPanelContent);
            this.panelContent.Controls.Add(labelTituloHeaderContent);
            this.panelContent.Controls.Add(labelLinhaHeaderContent);
            this.panelContent.Location = new System.Drawing.Point(8, 116);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(900, 528);
            this.panelContent.TabIndex = 44;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // buttonPesquisa
            // 
            this.buttonPesquisa.FlatAppearance.BorderSize = 0;
            this.buttonPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("buttonPesquisa.Image")));
            this.buttonPesquisa.Location = new System.Drawing.Point(834, 10);
            this.buttonPesquisa.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPesquisa.Name = "buttonPesquisa";
            this.buttonPesquisa.Size = new System.Drawing.Size(37, 24);
            this.buttonPesquisa.TabIndex = 352;
            this.buttonPesquisa.UseVisualStyleBackColor = true;
            this.buttonPesquisa.Click += new System.EventHandler(this.buttonPesquisa_Click);
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.textBoxPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisa.ForeColor = System.Drawing.SystemColors.Control;
            this.textBoxPesquisa.Location = new System.Drawing.Point(455, 8);
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(419, 29);
            this.textBoxPesquisa.TabIndex = 19;
            // 
            // flowLayoutPanelContent
            // 
            this.flowLayoutPanelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelContent.AutoScroll = true;
            this.flowLayoutPanelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.flowLayoutPanelContent.Location = new System.Drawing.Point(0, 47);
            this.flowLayoutPanelContent.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.flowLayoutPanelContent.Name = "flowLayoutPanelContent";
            this.flowLayoutPanelContent.Size = new System.Drawing.Size(900, 481);
            this.flowLayoutPanelContent.TabIndex = 17;
            // 
            // FrmAjuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(916, 656);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelInfoHeader);
            this.Name = "FrmAjuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAjuda";
            this.Load += new System.EventHandler(this.FrmAjuda_Load);
            this.panelInfoHeader.ResumeLayout(false);
            this.panelInfoHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInfoHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelNamePatientHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContent;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.Button buttonPesquisa;
    }
}