using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteirinhaMembro.Forms.Configurações
{
    public partial class FrmBackup : Form
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

        Banco banco = new Banco();

        public FrmBackup()
        {
            InitializeComponent();
        }

        private void FrmBackup_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int contGrid = 100;
            int contResult = 100 / contGrid;

            for (int i = 0; i < 100 - 0; i++)
            {
                progress += contResult;

                //incrementa o progresso do backgroundWorker
                //a cada passagem do loop.
                this.backgroundWorker.ReportProgress(progress);

                string Backup = ("BACKUP DATABASE membrosCOMADEMAT TO DISK = 'C:/Users/nando/OneDrive/Backup MembrosCOMADEMAT.bak' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = 'Full Backup MembrosCOMADEMAT'");
                SqlCommand exeBackup = new SqlCommand(Backup, banco.connection);

                if (i == 95)
                {
                    //
                    banco.conectar();
                    exeBackup.ExecuteNonQuery();
                    banco.desconectar();
                }

                //Verifica se houve uma requisição para cancelar a operação.
                if (backgroundWorker.CancellationPending)
                {
                    //se sim, define a propriedade Cancel para true
                    //para que o evento WorkerCompleted saiba que a tarefa foi cancelada. 
                    e.Cancel = true;

                    //zera o percentual de progresso do backgroundWorker1.
                    backgroundWorker.ReportProgress(0);
                    return;
                }
            }      

            //Finalmente, caso tudo esteja ok, finaliza
            //o progresso em 100%.
            backgroundWorker.ReportProgress(100);

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Incrementa o valor da progressbar com o valor
            //atual do progresso da tarefa.
            progressBarBackup.Value = e.ProgressPercentage;

            //informa o percentual na forma de texto.
            labelPorcentagem.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //caso a operação seja cancelada, informa ao usuario.
                labelStatus.Text = "Operação Cancelada pelo Usuário!";

                //habilita o Botao cancelar
                //btnCancelar.Enabled = true;
                //limpa a label
                labelPorcentagem.Text = string.Empty;
            }
            else if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                labelStatus.Text = "Aconteceu um erro durante a execução do processo!";
            }
            else
            {
                //informa que a tarefa foi concluida com sucesso.
                labelStatus.Text = "Tarefa Concluida com sucesso!";

                MessageBox.Show("Backup realizado com sucesso!!!");
            }

            //labelStatus.Visible = false;
            //labelPorcentagem.Visible = false;
            //progressBarBackup.Visible = false;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        #region Paint

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            panelMenu.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelMenu.Width,
            panelMenu.Height, 7, 7));

        }

        private void panelConsultarBackup_Paint(object sender, PaintEventArgs e)
        {
            panelConsultarBackup.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelConsultarBackup.Width,
            panelConsultarBackup.Height, 7, 7));
        }

        #endregion

    }
}
