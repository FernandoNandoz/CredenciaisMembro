namespace CarteirinhaMembro.Reports.Credencial_Individual
{
    partial class FormReportCredencial_Individual
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label labelPerfilColaborador;
            System.Windows.Forms.Label labelLinhaHeader;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label9;
            this.panelControle = new System.Windows.Forms.Panel();
            this.btnImprimirFrente = new System.Windows.Forms.Button();
            this.labelValueSituacaoFrente = new System.Windows.Forms.Label();
            this.labelValueQntFolhasSeremImpressasFrente = new System.Windows.Forms.Label();
            this.labelValueStatusFrente = new System.Windows.Forms.Label();
            this.reportViewerFrente = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewerVerso = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnImprimirVerso = new System.Windows.Forms.Button();
            this.labelValueSituacaoVerso = new System.Windows.Forms.Label();
            this.labelValueQntFolhasSeremImpressasVerso = new System.Windows.Forms.Label();
            this.labelValueStatusVerso = new System.Windows.Forms.Label();
            this.CredencialMembroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.membrosCOMADEMATDataSet = new CarteirinhaMembro.DataSource.membrosCOMADEMATDataSet();
            this.credencialMembroTableAdapter = new CarteirinhaMembro.DataSource.membrosCOMADEMATDataSetTableAdapters.CredencialMembroTableAdapter();
            this.labelQntFolhasImpressasFrente = new System.Windows.Forms.Label();
            this.labelQntFolhasImpressasVerso = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            labelPerfilColaborador = new System.Windows.Forms.Label();
            labelLinhaHeader = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            this.panelControle.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CredencialMembroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membrosCOMADEMATDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControle
            // 
            this.panelControle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.panelControle.Controls.Add(this.labelQntFolhasImpressasFrente);
            this.panelControle.Controls.Add(label4);
            this.panelControle.Controls.Add(this.reportViewerFrente);
            this.panelControle.Controls.Add(this.btnImprimirFrente);
            this.panelControle.Controls.Add(this.labelValueSituacaoFrente);
            this.panelControle.Controls.Add(label25);
            this.panelControle.Controls.Add(this.labelValueQntFolhasSeremImpressasFrente);
            this.panelControle.Controls.Add(this.labelValueStatusFrente);
            this.panelControle.Controls.Add(labelPerfilColaborador);
            this.panelControle.Controls.Add(labelLinhaHeader);
            this.panelControle.Location = new System.Drawing.Point(9, 9);
            this.panelControle.Name = "panelControle";
            this.panelControle.Size = new System.Drawing.Size(953, 292);
            this.panelControle.TabIndex = 6;
            this.panelControle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControle_Paint);
            // 
            // btnImprimirFrente
            // 
            this.btnImprimirFrente.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnImprimirFrente.FlatAppearance.BorderSize = 0;
            this.btnImprimirFrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirFrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnImprimirFrente.ForeColor = System.Drawing.SystemColors.Control;
            this.btnImprimirFrente.Image = global::CarteirinhaMembro.Properties.Resources.icons8_print_24px;
            this.btnImprimirFrente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirFrente.Location = new System.Drawing.Point(511, 242);
            this.btnImprimirFrente.Name = "btnImprimirFrente";
            this.btnImprimirFrente.Size = new System.Drawing.Size(406, 32);
            this.btnImprimirFrente.TabIndex = 77;
            this.btnImprimirFrente.Text = "Imprimir Frente";
            this.btnImprimirFrente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirFrente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimirFrente.UseVisualStyleBackColor = false;
            this.btnImprimirFrente.Click += new System.EventHandler(this.btnImprimirFrente_Click);
            // 
            // labelValueSituacaoFrente
            // 
            this.labelValueSituacaoFrente.AutoSize = true;
            this.labelValueSituacaoFrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelValueSituacaoFrente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.labelValueSituacaoFrente.Location = new System.Drawing.Point(736, 76);
            this.labelValueSituacaoFrente.Name = "labelValueSituacaoFrente";
            this.labelValueSituacaoFrente.Size = new System.Drawing.Size(169, 20);
            this.labelValueSituacaoFrente.TabIndex = 76;
            this.labelValueSituacaoFrente.Text = "Aguardando liberação.";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label25.ForeColor = System.Drawing.SystemColors.Control;
            label25.Location = new System.Drawing.Point(535, 73);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(205, 24);
            label25.TabIndex = 75;
            label25.Text = "Situação da impressão:";
            // 
            // labelValueQntFolhasSeremImpressasFrente
            // 
            this.labelValueQntFolhasSeremImpressasFrente.AutoSize = true;
            this.labelValueQntFolhasSeremImpressasFrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelValueQntFolhasSeremImpressasFrente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.labelValueQntFolhasSeremImpressasFrente.Location = new System.Drawing.Point(825, 106);
            this.labelValueQntFolhasSeremImpressasFrente.Name = "labelValueQntFolhasSeremImpressasFrente";
            this.labelValueQntFolhasSeremImpressasFrente.Size = new System.Drawing.Size(18, 20);
            this.labelValueQntFolhasSeremImpressasFrente.TabIndex = 8;
            this.labelValueQntFolhasSeremImpressasFrente.Text = "0";
            // 
            // labelValueStatusFrente
            // 
            this.labelValueStatusFrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelValueStatusFrente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.labelValueStatusFrente.Location = new System.Drawing.Point(511, 25);
            this.labelValueStatusFrente.Name = "labelValueStatusFrente";
            this.labelValueStatusFrente.Size = new System.Drawing.Size(406, 31);
            this.labelValueStatusFrente.TabIndex = 7;
            this.labelValueStatusFrente.Text = "Pronto para impressão!";
            // 
            // labelPerfilColaborador
            // 
            labelPerfilColaborador.AutoSize = true;
            labelPerfilColaborador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            labelPerfilColaborador.ForeColor = System.Drawing.SystemColors.Control;
            labelPerfilColaborador.Location = new System.Drawing.Point(535, 103);
            labelPerfilColaborador.Name = "labelPerfilColaborador";
            labelPerfilColaborador.Size = new System.Drawing.Size(289, 24);
            labelPerfilColaborador.TabIndex = 3;
            labelPerfilColaborador.Text = "Qnt de folhas a serem impressas:";
            // 
            // labelLinhaHeader
            // 
            labelLinhaHeader.AutoSize = true;
            labelLinhaHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            labelLinhaHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            labelLinhaHeader.Location = new System.Drawing.Point(499, 210);
            labelLinhaHeader.Name = "labelLinhaHeader";
            labelLinhaHeader.Size = new System.Drawing.Size(430, 24);
            labelLinhaHeader.TabIndex = 69;
            labelLinhaHeader.Text = "__________________________________________";
            // 
            // reportViewerFrente
            // 
            reportDataSource1.Name = "CredencialMembros";
            reportDataSource1.Value = this.CredencialMembroBindingSource;
            this.reportViewerFrente.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerFrente.LocalReport.ReportEmbeddedResource = "CarteirinhaMembro.Reports.Credencial_Individual.ReportCredencial_Individual_Frent" +
    "e.rdlc";
            this.reportViewerFrente.Location = new System.Drawing.Point(28, 11);
            this.reportViewerFrente.Name = "reportViewerFrente";
            this.reportViewerFrente.ServerReport.BearerToken = null;
            this.reportViewerFrente.Size = new System.Drawing.Size(454, 267);
            this.reportViewerFrente.TabIndex = 78;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.labelQntFolhasImpressasVerso);
            this.panel1.Controls.Add(this.reportViewerVerso);
            this.panel1.Controls.Add(label9);
            this.panel1.Controls.Add(this.btnImprimirVerso);
            this.panel1.Controls.Add(this.labelValueSituacaoVerso);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.labelValueQntFolhasSeremImpressasVerso);
            this.panel1.Controls.Add(this.labelValueStatusVerso);
            this.panel1.Controls.Add(label7);
            this.panel1.Controls.Add(label8);
            this.panel1.Location = new System.Drawing.Point(9, 309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 292);
            this.panel1.TabIndex = 79;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // reportViewerVerso
            // 
            reportDataSource2.Name = "CredencialMembro";
            reportDataSource2.Value = this.CredencialMembroBindingSource;
            this.reportViewerVerso.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerVerso.LocalReport.ReportEmbeddedResource = "CarteirinhaMembro.Reports.Credencial_Individual.ReportCredencial_Individual_Verso" +
    ".rdlc";
            this.reportViewerVerso.Location = new System.Drawing.Point(28, 11);
            this.reportViewerVerso.Name = "reportViewerVerso";
            this.reportViewerVerso.ServerReport.BearerToken = null;
            this.reportViewerVerso.Size = new System.Drawing.Size(454, 267);
            this.reportViewerVerso.TabIndex = 78;
            // 
            // btnImprimirVerso
            // 
            this.btnImprimirVerso.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnImprimirVerso.FlatAppearance.BorderSize = 0;
            this.btnImprimirVerso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirVerso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnImprimirVerso.ForeColor = System.Drawing.SystemColors.Control;
            this.btnImprimirVerso.Image = global::CarteirinhaMembro.Properties.Resources.icons8_print_24px;
            this.btnImprimirVerso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirVerso.Location = new System.Drawing.Point(511, 241);
            this.btnImprimirVerso.Name = "btnImprimirVerso";
            this.btnImprimirVerso.Size = new System.Drawing.Size(406, 32);
            this.btnImprimirVerso.TabIndex = 77;
            this.btnImprimirVerso.Text = "Imprimir Verso";
            this.btnImprimirVerso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirVerso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimirVerso.UseVisualStyleBackColor = false;
            this.btnImprimirVerso.Click += new System.EventHandler(this.btnImprimirVerso_Click);
            // 
            // labelValueSituacaoVerso
            // 
            this.labelValueSituacaoVerso.AutoSize = true;
            this.labelValueSituacaoVerso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelValueSituacaoVerso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.labelValueSituacaoVerso.Location = new System.Drawing.Point(724, 78);
            this.labelValueSituacaoVerso.Name = "labelValueSituacaoVerso";
            this.labelValueSituacaoVerso.Size = new System.Drawing.Size(169, 20);
            this.labelValueSituacaoVerso.TabIndex = 76;
            this.labelValueSituacaoVerso.Text = "Aguardando liberação.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label2.ForeColor = System.Drawing.SystemColors.Control;
            label2.Location = new System.Drawing.Point(535, 75);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(183, 24);
            label2.TabIndex = 75;
            label2.Text = "Status da impressão:";
            // 
            // labelValueQntFolhasSeremImpressasVerso
            // 
            this.labelValueQntFolhasSeremImpressasVerso.AutoSize = true;
            this.labelValueQntFolhasSeremImpressasVerso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelValueQntFolhasSeremImpressasVerso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.labelValueQntFolhasSeremImpressasVerso.Location = new System.Drawing.Point(824, 110);
            this.labelValueQntFolhasSeremImpressasVerso.Name = "labelValueQntFolhasSeremImpressasVerso";
            this.labelValueQntFolhasSeremImpressasVerso.Size = new System.Drawing.Size(18, 20);
            this.labelValueQntFolhasSeremImpressasVerso.TabIndex = 8;
            this.labelValueQntFolhasSeremImpressasVerso.Text = "0";
            // 
            // labelValueStatusVerso
            // 
            this.labelValueStatusVerso.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelValueStatusVerso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.labelValueStatusVerso.Location = new System.Drawing.Point(511, 25);
            this.labelValueStatusVerso.Name = "labelValueStatusVerso";
            this.labelValueStatusVerso.Size = new System.Drawing.Size(406, 31);
            this.labelValueStatusVerso.TabIndex = 7;
            this.labelValueStatusVerso.Text = "Pronto para impressão!";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label7.ForeColor = System.Drawing.SystemColors.Control;
            label7.Location = new System.Drawing.Point(535, 107);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(289, 24);
            label7.TabIndex = 3;
            label7.Text = "Qnt de folhas a serem impressas:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            label8.Location = new System.Drawing.Point(499, 209);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(430, 24);
            label8.TabIndex = 69;
            label8.Text = "__________________________________________";
            // 
            // CredencialMembroBindingSource
            // 
            this.CredencialMembroBindingSource.DataMember = "CredencialMembro";
            this.CredencialMembroBindingSource.DataSource = this.membrosCOMADEMATDataSet;
            // 
            // membrosCOMADEMATDataSet
            // 
            this.membrosCOMADEMATDataSet.DataSetName = "membrosCOMADEMATDataSet";
            this.membrosCOMADEMATDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // credencialMembroTableAdapter
            // 
            this.credencialMembroTableAdapter.ClearBeforeFill = true;
            // 
            // labelQntFolhasImpressasFrente
            // 
            this.labelQntFolhasImpressasFrente.AutoSize = true;
            this.labelQntFolhasImpressasFrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelQntFolhasImpressasFrente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.labelQntFolhasImpressasFrente.Location = new System.Drawing.Point(753, 140);
            this.labelQntFolhasImpressasFrente.Name = "labelQntFolhasImpressasFrente";
            this.labelQntFolhasImpressasFrente.Size = new System.Drawing.Size(18, 20);
            this.labelQntFolhasImpressasFrente.TabIndex = 80;
            this.labelQntFolhasImpressasFrente.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label4.ForeColor = System.Drawing.SystemColors.Control;
            label4.Location = new System.Drawing.Point(536, 136);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(216, 24);
            label4.TabIndex = 79;
            label4.Text = "Qnt de folhas impressas:";
            // 
            // labelQntFolhasImpressasVerso
            // 
            this.labelQntFolhasImpressasVerso.AutoSize = true;
            this.labelQntFolhasImpressasVerso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelQntFolhasImpressasVerso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.labelQntFolhasImpressasVerso.Location = new System.Drawing.Point(752, 144);
            this.labelQntFolhasImpressasVerso.Name = "labelQntFolhasImpressasVerso";
            this.labelQntFolhasImpressasVerso.Size = new System.Drawing.Size(18, 20);
            this.labelQntFolhasImpressasVerso.TabIndex = 82;
            this.labelQntFolhasImpressasVerso.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label9.ForeColor = System.Drawing.SystemColors.Control;
            label9.Location = new System.Drawing.Point(535, 140);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(216, 24);
            label9.TabIndex = 81;
            label9.Text = "Qnt de folhas impressas:";
            // 
            // FormReportCredencial_Individual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(973, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportCredencial_Individual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Credencial Individual";
            this.Load += new System.EventHandler(this.FormReportCredencial_Individual_Load);
            this.panelControle.ResumeLayout(false);
            this.panelControle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CredencialMembroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membrosCOMADEMATDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControle;
        private System.Windows.Forms.Button btnImprimirFrente;
        private System.Windows.Forms.Label labelValueSituacaoFrente;
        private System.Windows.Forms.Label labelValueQntFolhasSeremImpressasFrente;
        private System.Windows.Forms.Label labelValueStatusFrente;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerFrente;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerVerso;
        private System.Windows.Forms.Button btnImprimirVerso;
        private System.Windows.Forms.Label labelValueSituacaoVerso;
        private System.Windows.Forms.Label labelValueQntFolhasSeremImpressasVerso;
        private System.Windows.Forms.Label labelValueStatusVerso;
        private System.Windows.Forms.BindingSource CredencialMembroBindingSource;
        private DataSource.membrosCOMADEMATDataSet membrosCOMADEMATDataSet;
        private DataSource.membrosCOMADEMATDataSetTableAdapters.CredencialMembroTableAdapter credencialMembroTableAdapter;
        private System.Windows.Forms.Label labelQntFolhasImpressasFrente;
        private System.Windows.Forms.Label labelQntFolhasImpressasVerso;
    }
}