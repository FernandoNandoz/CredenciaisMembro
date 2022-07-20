namespace CarteirinhaMembro.Reports.Credencial_Varias
{
    partial class FormReportCredencialVarias
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
            System.Windows.Forms.Label labelLinhaHeader;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CredencialMembroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.membrosCOMADEMATDataSet = new CarteirinhaMembro.DataSource.membrosCOMADEMATDataSet();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCredencialFrente = new System.Windows.Forms.Panel();
            this.reportViewerFrente = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelCredencialVerso = new System.Windows.Forms.Panel();
            this.reportViewerVerso = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelValueStatus = new System.Windows.Forms.Label();
            this.btnImprimirVerso = new System.Windows.Forms.Button();
            this.btnImprimirFrente = new System.Windows.Forms.Button();
            this.credencialMembroTableAdapter = new CarteirinhaMembro.DataSource.membrosCOMADEMATDataSetTableAdapters.CredencialMembroTableAdapter();
            labelLinhaHeader = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CredencialMembroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membrosCOMADEMATDataSet)).BeginInit();
            this.flpContent.SuspendLayout();
            this.panelCredencialFrente.SuspendLayout();
            this.panelCredencialVerso.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLinhaHeader
            // 
            labelLinhaHeader.AutoSize = true;
            labelLinhaHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            labelLinhaHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            labelLinhaHeader.Location = new System.Drawing.Point(13, 5);
            labelLinhaHeader.Name = "labelLinhaHeader";
            labelLinhaHeader.Size = new System.Drawing.Size(830, 24);
            labelLinhaHeader.TabIndex = 78;
            labelLinhaHeader.Text = "_________________________________________________________________________________" +
    "_";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            label2.ForeColor = System.Drawing.SystemColors.Control;
            label2.Location = new System.Drawing.Point(13, 3);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(192, 22);
            label2.TabIndex = 82;
            label2.Text = "Imprimindo credenciais";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            label1.ForeColor = System.Drawing.SystemColors.Control;
            label1.Location = new System.Drawing.Point(9, 2);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(173, 22);
            label1.TabIndex = 84;
            label1.Text = "Credenciais - Frente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            label3.Location = new System.Drawing.Point(10, 4);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(820, 24);
            label3.TabIndex = 83;
            label3.Text = "_________________________________________________________________________________" +
    "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            label4.ForeColor = System.Drawing.SystemColors.Control;
            label4.Location = new System.Drawing.Point(10, 3);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(168, 22);
            label4.TabIndex = 86;
            label4.Text = "Credenciais - Verso";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            label5.Location = new System.Drawing.Point(10, 5);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(820, 24);
            label5.TabIndex = 85;
            label5.Text = "_________________________________________________________________________________" +
    "";
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
            // flpContent
            // 
            this.flpContent.AutoScroll = true;
            this.flpContent.Controls.Add(this.panelCredencialFrente);
            this.flpContent.Controls.Add(this.panelCredencialVerso);
            this.flpContent.Location = new System.Drawing.Point(8, 93);
            this.flpContent.Margin = new System.Windows.Forms.Padding(0);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(856, 580);
            this.flpContent.TabIndex = 0;
            this.flpContent.Paint += new System.Windows.Forms.PaintEventHandler(this.flpContent_Paint);
            // 
            // panelCredencialFrente
            // 
            this.panelCredencialFrente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.panelCredencialFrente.Controls.Add(label1);
            this.panelCredencialFrente.Controls.Add(label3);
            this.panelCredencialFrente.Controls.Add(this.reportViewerFrente);
            this.panelCredencialFrente.Location = new System.Drawing.Point(0, 0);
            this.panelCredencialFrente.Margin = new System.Windows.Forms.Padding(0);
            this.panelCredencialFrente.Name = "panelCredencialFrente";
            this.panelCredencialFrente.Size = new System.Drawing.Size(838, 580);
            this.panelCredencialFrente.TabIndex = 0;
            this.panelCredencialFrente.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCredencialFrente_Paint);
            // 
            // reportViewerFrente
            // 
            reportDataSource1.Name = "Credenciais";
            reportDataSource1.Value = this.CredencialMembroBindingSource;
            this.reportViewerFrente.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerFrente.LocalReport.ReportEmbeddedResource = "CarteirinhaMembro.Reports.Credencial_Varias.ReportCredencialVariasFrente.rdlc";
            this.reportViewerFrente.Location = new System.Drawing.Point(12, 31);
            this.reportViewerFrente.Name = "reportViewerFrente";
            this.reportViewerFrente.ServerReport.BearerToken = null;
            this.reportViewerFrente.Size = new System.Drawing.Size(815, 534);
            this.reportViewerFrente.TabIndex = 0;
            // 
            // panelCredencialVerso
            // 
            this.panelCredencialVerso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.panelCredencialVerso.Controls.Add(label4);
            this.panelCredencialVerso.Controls.Add(label5);
            this.panelCredencialVerso.Controls.Add(this.reportViewerVerso);
            this.panelCredencialVerso.Location = new System.Drawing.Point(0, 580);
            this.panelCredencialVerso.Margin = new System.Windows.Forms.Padding(0);
            this.panelCredencialVerso.Name = "panelCredencialVerso";
            this.panelCredencialVerso.Size = new System.Drawing.Size(838, 580);
            this.panelCredencialVerso.TabIndex = 1;
            this.panelCredencialVerso.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCredencialVerso_Paint);
            // 
            // reportViewerVerso
            // 
            reportDataSource2.Name = "CredencialMembro";
            reportDataSource2.Value = this.CredencialMembroBindingSource;
            this.reportViewerVerso.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerVerso.LocalReport.ReportEmbeddedResource = "CarteirinhaMembro.Reports.Credencial_Varias.ReportCredencialVariasVerso.rdlc";
            this.reportViewerVerso.Location = new System.Drawing.Point(12, 32);
            this.reportViewerVerso.Name = "reportViewerVerso";
            this.reportViewerVerso.ServerReport.BearerToken = null;
            this.reportViewerVerso.Size = new System.Drawing.Size(815, 541);
            this.reportViewerVerso.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.panelHeader.Controls.Add(label2);
            this.panelHeader.Controls.Add(this.labelValueStatus);
            this.panelHeader.Controls.Add(this.btnImprimirVerso);
            this.panelHeader.Controls.Add(this.btnImprimirFrente);
            this.panelHeader.Controls.Add(labelLinhaHeader);
            this.panelHeader.Location = new System.Drawing.Point(8, 8);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(856, 79);
            this.panelHeader.TabIndex = 1;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // labelValueStatus
            // 
            this.labelValueStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelValueStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.labelValueStatus.Location = new System.Drawing.Point(12, 38);
            this.labelValueStatus.Name = "labelValueStatus";
            this.labelValueStatus.Size = new System.Drawing.Size(451, 31);
            this.labelValueStatus.TabIndex = 81;
            this.labelValueStatus.Text = "Pronto para impressão!";
            this.labelValueStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnImprimirVerso.Location = new System.Drawing.Point(657, 39);
            this.btnImprimirVerso.Name = "btnImprimirVerso";
            this.btnImprimirVerso.Size = new System.Drawing.Size(171, 32);
            this.btnImprimirVerso.TabIndex = 80;
            this.btnImprimirVerso.Text = "Imprimir Verso";
            this.btnImprimirVerso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirVerso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimirVerso.UseVisualStyleBackColor = false;
            this.btnImprimirVerso.Click += new System.EventHandler(this.btnImprimirVerso_Click);
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
            this.btnImprimirFrente.Location = new System.Drawing.Point(469, 39);
            this.btnImprimirFrente.Name = "btnImprimirFrente";
            this.btnImprimirFrente.Size = new System.Drawing.Size(182, 32);
            this.btnImprimirFrente.TabIndex = 79;
            this.btnImprimirFrente.Text = "Imprimir Frente";
            this.btnImprimirFrente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirFrente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimirFrente.UseVisualStyleBackColor = false;
            this.btnImprimirFrente.Click += new System.EventHandler(this.btnImprimirFrente_Click);
            // 
            // credencialMembroTableAdapter
            // 
            this.credencialMembroTableAdapter.ClearBeforeFill = true;
            // 
            // FormReportCredencialVarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(871, 678);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.flpContent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportCredencialVarias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Credenciais";
            this.Load += new System.EventHandler(this.FormReportCredencialVarias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CredencialMembroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membrosCOMADEMATDataSet)).EndInit();
            this.flpContent.ResumeLayout(false);
            this.panelCredencialFrente.ResumeLayout(false);
            this.panelCredencialFrente.PerformLayout();
            this.panelCredencialVerso.ResumeLayout(false);
            this.panelCredencialVerso.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private System.Windows.Forms.Panel panelCredencialFrente;
        private System.Windows.Forms.Panel panelCredencialVerso;
        private System.Windows.Forms.Panel panelHeader;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerFrente;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerVerso;
        private System.Windows.Forms.Button btnImprimirFrente;
        private System.Windows.Forms.Button btnImprimirVerso;
        private System.Windows.Forms.Label labelValueStatus;
        private System.Windows.Forms.BindingSource CredencialMembroBindingSource;
        private DataSource.membrosCOMADEMATDataSet membrosCOMADEMATDataSet;
        private DataSource.membrosCOMADEMATDataSetTableAdapters.CredencialMembroTableAdapter credencialMembroTableAdapter;
    }
}