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

namespace CarteirinhaMembro.Forms
{
    public partial class frmListaMembros : Form
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


        public frmListaMembros()
        {
            InitializeComponent();
        }

        private void frmListaMembros_Load(object sender, EventArgs e)
        {
            verificarQuantidadeMembro();
            carregarLista();
        }

        private void verificarQuantidadeMembro()
        {
            //Ira verificar se o Cliente ja possui conta aberta, se nao houver ele ira efetuar a abertura.
            string fichaClinica = ("SELECT COUNT(*) FROM Membros");
            SqlCommand exeVerificacao = new SqlCommand(fichaClinica, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                contagem = int.Parse(datareader[0].ToString());
                labelQntMembros.Text = datareader[0].ToString();
            }

            banco.desconectar();

        }

        private void carregarLista()
        {
            if (contagem != 0)
            {
                //Ira verificar se o Cliente ja possui conta aberta, se nao houver ele ira efetuar a abertura.
                string fichaMembro = ("SELECT * FROM Membros ORDER BY nomeCompleto");
                SqlCommand exeVerificacao = new SqlCommand(fichaMembro, banco.connection);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                ListaMembros[] listaItems = new ListaMembros[contagem];

                flowLayoutPanelContent.Controls.Clear();

                for (int i = 0; i < listaItems.Length; i++)
                {
                    while (datareader.Read())
                    {
                        listaItems[i] = new ListaMembros();
                        listaItems[i].Membro = Convert.ToString(datareader[1]);
                        listaItems[i].CargoFuncao = Convert.ToString(datareader[13]);
                        listaItems[i].SetorCongregacao = Convert.ToString(datareader[14]);
                        listaItems[i].IdMembro = int.Parse(datareader[0].ToString());

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
                MessageBox.Show("No momento não possui nenhum Membro.");
            }
        }

        private void textBoxPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxPesquisa.Text == "")
            {
                carregarLista();
            }
            else
            {
                if (contagem != 0)
                {
                    //Ira verificar se o Cliente ja possui conta aberta, se nao houver ele ira efetuar a abertura.
                    string fichaMembro = ("SELECT * FROM Membros WHERE (nomeCompleto LIKE @nome + '%')");
                    SqlCommand exeVerificacao = new SqlCommand(fichaMembro, banco.connection);
                    banco.conectar();

                    exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisa.Text);

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    ListaMembros[] listaItems = new ListaMembros[contagem];

                    flowLayoutPanelContent.Controls.Clear();

                    for (int i = 0; i < listaItems.Length; i++)
                    {
                        while (datareader.Read())
                        {
                            listaItems[i] = new ListaMembros();
                            listaItems[i].Membro = Convert.ToString(datareader[1]);
                            listaItems[i].CargoFuncao = Convert.ToString(datareader[13]);
                            listaItems[i].SetorCongregacao = Convert.ToString(datareader[14]);
                            listaItems[i].IdMembro = int.Parse(datareader[0].ToString());

                            if (flowLayoutPanelContent.Controls.Count < 0)
                            {
                                flowLayoutPanelContent.Controls.Clear();
                            }
                            else
                            {
                                flowLayoutPanelContent.Controls.Add(listaItems[i]);
                            }

                            liberado = true;
                        }
                    }
                    banco.desconectar();
                }
                else
                {
                    MessageBox.Show("No momento não possui nenhum Membro.");
                }
            }
        }

        private void buttonPesquisa_Click(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == "")
            {
                carregarLista();
            }
            else
            {
                if (contagem != 0)
                {
                    //Ira verificar se o Cliente ja possui conta aberta, se nao houver ele ira efetuar a abertura.
                    string fichaMembro = ("SELECT * FROM Membros WHERE (nomeCompleto LIKE @nome + '%')");
                    SqlCommand exeVerificacao = new SqlCommand(fichaMembro, banco.connection);
                    banco.conectar();

                    exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisa.Text);

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    ListaMembros[] listaItems = new ListaMembros[contagem];

                    flowLayoutPanelContent.Controls.Clear();

                    for (int i = 0; i < listaItems.Length; i++)
                    {
                        while (datareader.Read())
                        {
                            listaItems[i] = new ListaMembros();
                            listaItems[i].Membro = Convert.ToString(datareader[1]);
                            listaItems[i].CargoFuncao = Convert.ToString(datareader[13]);
                            listaItems[i].SetorCongregacao = Convert.ToString(datareader[14]);
                            listaItems[i].IdMembro = int.Parse(datareader[0].ToString());

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
                    MessageBox.Show("No momento não possui nenhum Membro.");
                }
            }
        }

        #region Paint

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

        #endregion
    }
}
