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
    public partial class FrmAjuda : Form
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

        int contagem = 0;
        bool liberado = false;

        public FrmAjuda()
        {
            InitializeComponent();

            verificarQuantidadeAjuda();
            carregarLista();
        }

        private void FrmAjuda_Load(object sender, EventArgs e)
        {

        }

        private void verificarQuantidadeAjuda()
        {
            //Ira verificar se o Cliente ja possui conta aberta, se nao houver ele ira efetuar a abertura.
            string fichaClinica = ("SELECT COUNT(*) FROM Ajuda");
            SqlCommand exeVerificacao = new SqlCommand(fichaClinica, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                contagem = int.Parse(datareader[0].ToString());
            }
            banco.desconectar();
        }

        private void carregarLista()
        {
            if (contagem != 0)
            {
                string Ajuda = ("SELECT * FROM Ajuda");
                SqlCommand exeVerificacao = new SqlCommand(Ajuda, banco.connection);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                ListAjuda[] listaItems = new ListAjuda[contagem];

                for (int i = 0; i < listaItems.Length; i++)
                {
                    while (datareader.Read())
                    {
                        listaItems[i] = new ListAjuda();
                        listaItems[i].Titulo = Convert.ToString(datareader[1]);
                        listaItems[i].Local = Convert.ToString(datareader[2]);
                        listaItems[i].TipoAcao = Convert.ToString(datareader[3]);
                        listaItems[i].Link = Convert.ToString(datareader[4]);
                        listaItems[i].IdAjuda = int.Parse(datareader[0].ToString());

                        if (flowLayoutPanelContent.Controls.Count < 0)
                        {
                            flowLayoutPanelContent.Controls.Clear();
                        }
                        else
                            flowLayoutPanelContent.Controls.Add(listaItems[i]);

                        liberado = true;
                    }
                }
                banco.desconectar();
            }
            else
            {
                MessageBox.Show("No momento não possui nenhum Tutorial.");
            }
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            panelContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelContent.Width,
            panelContent.Height, 8, 8));
        }

        private void panelInfoHeader_Paint(object sender, PaintEventArgs e)
        {
            panelInfoHeader.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelInfoHeader.Width,
            panelInfoHeader.Height, 8, 8));
        }

        private void buttonPesquisa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("!!!!!!!!!");
        }
    }
}
