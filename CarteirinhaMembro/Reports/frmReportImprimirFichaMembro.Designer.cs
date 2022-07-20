namespace CarteirinhaMembro.Reports
{
    partial class frmReportImprimirFichaMembro
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.MembrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.membrosCOMADEMATDataSet = new CarteirinhaMembro.DataSource.membrosCOMADEMATDataSet();
            this.CredencialMembroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.membrosTableAdapter = new CarteirinhaMembro.DataSource.membrosCOMADEMATDataSetTableAdapters.MembrosTableAdapter();
            this.credencialMembroTableAdapter = new CarteirinhaMembro.DataSource.membrosCOMADEMATDataSetTableAdapters.CredencialMembroTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.MembrosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membrosCOMADEMATDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CredencialMembroBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MembrosBindingSource
            // 
            this.MembrosBindingSource.DataMember = "Membros";
            this.MembrosBindingSource.DataSource = this.membrosCOMADEMATDataSet;
            // 
            // membrosCOMADEMATDataSet
            // 
            this.membrosCOMADEMATDataSet.DataSetName = "membrosCOMADEMATDataSet";
            this.membrosCOMADEMATDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CredencialMembroBindingSource
            // 
            this.CredencialMembroBindingSource.DataMember = "CredencialMembro";
            this.CredencialMembroBindingSource.DataSource = this.membrosCOMADEMATDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Membros";
            reportDataSource1.Value = this.MembrosBindingSource;
            reportDataSource2.Name = "Credenciais";
            reportDataSource2.Value = this.CredencialMembroBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarteirinhaMembro.Reports.ReportFichaMembro.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(871, 678);
            this.reportViewer1.TabIndex = 0;
            // 
            // membrosTableAdapter
            // 
            this.membrosTableAdapter.ClearBeforeFill = true;
            // 
            // credencialMembroTableAdapter
            // 
            this.credencialMembroTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportImprimirFichaMembro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 678);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportImprimirFichaMembro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Ficha Membro";
            this.Load += new System.EventHandler(this.frmReportImprimirFichaMembro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MembrosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membrosCOMADEMATDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CredencialMembroBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSource.membrosCOMADEMATDataSet membrosCOMADEMATDataSet;
        private DataSource.membrosCOMADEMATDataSetTableAdapters.MembrosTableAdapter membrosTableAdapter;
        private System.Windows.Forms.BindingSource MembrosBindingSource;
        private System.Windows.Forms.BindingSource CredencialMembroBindingSource;
        private DataSource.membrosCOMADEMATDataSetTableAdapters.CredencialMembroTableAdapter credencialMembroTableAdapter;
    }
}