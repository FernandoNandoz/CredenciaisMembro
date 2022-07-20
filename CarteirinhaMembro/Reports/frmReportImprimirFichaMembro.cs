using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteirinhaMembro.Reports
{
    public partial class frmReportImprimirFichaMembro : Form
    {
        public frmReportImprimirFichaMembro()
        {
            InitializeComponent();
        }

        private void frmReportImprimirFichaMembro_Load(object sender, EventArgs e)
        {
            this.membrosTableAdapter.queryReportFicha(this.membrosCOMADEMATDataSet.Membros, Consulta._retornarID());
            this.credencialMembroTableAdapter.queryReportFicha(this.membrosCOMADEMATDataSet.CredencialMembro, Consulta._retornarID());

            this.reportViewer1.RefreshReport();
        }
    }
}
