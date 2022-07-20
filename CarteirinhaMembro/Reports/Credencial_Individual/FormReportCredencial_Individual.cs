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

namespace CarteirinhaMembro.Reports.Credencial_Individual
{
    public partial class FormReportCredencial_Individual : Form
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

        public FormReportCredencial_Individual()
        {
            InitializeComponent();
        }

        private void FormReportCredencial_Individual_Load(object sender, EventArgs e)
        {
            credencialMembroTableAdapter.queryImprimirCredencialIndividual(membrosCOMADEMATDataSet.CredencialMembro, Consulta._retornarID());

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

                labelValueStatusFrente.Text = "Frente liberada para impressão!";
                labelValueSituacaoFrente.Text = "Liberada.";
                labelValueQntFolhasSeremImpressasFrente.Text = "0";
                labelQntFolhasImpressasFrente.Text = "1";
            }
            else
            {
                labelValueStatusFrente.Text = "Processo cancelado pelo usuário!";
                labelValueSituacaoFrente.Text = "Interrompido.";
                labelValueQntFolhasSeremImpressasFrente.Text = "0";
                labelQntFolhasImpressasFrente.Text = "0";
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

                labelValueStatusVerso.Text = "Verso liberada para impressão!";
                labelValueSituacaoVerso.Text = "Liberada.";
                labelValueQntFolhasSeremImpressasVerso.Text = "0";
                labelQntFolhasImpressasVerso.Text = "1";
            }
            else
            {
                labelValueStatusVerso.Text = "Processo cancelado pelo usuário!";
                labelValueSituacaoVerso.Text = "Interrompido.";
                labelValueQntFolhasSeremImpressasVerso.Text = "0";
                labelQntFolhasImpressasVerso.Text = "0";
            }
        }

        private void btnImprimirFrente_Click(object sender, EventArgs e)
        {
            labelValueStatusFrente.Text = "Gerando e liberando impressão....";
            labelValueSituacaoFrente.Text = "Em andamento";
            labelValueQntFolhasSeremImpressasFrente.Text = "1";
            labelQntFolhasImpressasFrente.Text = "0";

            imprimirFrente();
        }

        private void btnImprimirVerso_Click(object sender, EventArgs e)
        {
            labelValueStatusVerso.Text = "Gerando e liberando impressão....";
            labelValueSituacaoVerso.Text = "Em andamento";
            labelValueQntFolhasSeremImpressasVerso.Text = "1";
            labelQntFolhasImpressasVerso.Text = "0";

            imprimirVerso();
        }

        private void panelControle_Paint(object sender, PaintEventArgs e)
        {
            panelControle.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelControle.Width,
            panelControle.Height, 7, 7));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width,
            panel1.Height, 7, 7));
        }
      
    }
}
