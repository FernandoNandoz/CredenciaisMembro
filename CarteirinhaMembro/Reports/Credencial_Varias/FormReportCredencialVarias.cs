using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteirinhaMembro.Reports.Credencial_Varias
{
    public partial class FormReportCredencialVarias : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public FormReportCredencialVarias()
        {
            InitializeComponent();
        }

        private void FormReportCredencialVarias_Load(object sender, EventArgs e)
        {
            credencialMembroTableAdapter.queryImprimirVariasCredenciais(membrosCOMADEMATDataSet.CredencialMembro, "IMPRIMINDO");

            this.reportViewerFrente.RefreshReport();
            this.reportViewerVerso.RefreshReport();
        }

        private void imprimirFrente()
        {
            PrintDialog dialog = new PrintDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var rpd = new PrintReportSample.ReportPrintDocument(reportViewerFrente.LocalReport))
                {
                    rpd.Print();
                }

                labelValueStatus.Text = "Frente liberada para impressão!";
            }
            else
            {
                labelValueStatus.Text = "Processo cancelado pelo usuário!";
            }

        }

        private void imprimirVerso()
        {
            PrintDialog dialog = new PrintDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var rpd = new PrintReportSample.ReportPrintDocument(reportViewerVerso.LocalReport))
                {
                    rpd.Print();
                }

                labelValueStatus.Text = "Verso liberado para impressão!";           
            }
            else
            {
                labelValueStatus.Text = "Processo cancelado pelo usuário!";
            }
        }

        private void btnImprimirFrente_Click(object sender, EventArgs e)
        {
            labelValueStatus.Text = "Gerando e liberando impressão....";

            imprimirFrente();
        }

        private void btnImprimirVerso_Click(object sender, EventArgs e)
        {
            labelValueStatus.Text = "Gerando e liberando impressão....";

            imprimirVerso();

        }

        #region Paint

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            panelHeader.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelHeader.Width,
            panelHeader.Height, 7, 7));
        }

        private void flpContent_Paint(object sender, PaintEventArgs e)
        {
            flpContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, flpContent.Width,
            flpContent.Height, 7, 7));
        }

        private void panelCredencialFrente_Paint(object sender, PaintEventArgs e)
        {
            flpContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, flpContent.Width,
            flpContent.Height, 7, 7));
        }

        private void panelCredencialVerso_Paint(object sender, PaintEventArgs e)
        {
            flpContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, flpContent.Width,
            flpContent.Height, 7, 7));
        }

        #endregion

    }
}
