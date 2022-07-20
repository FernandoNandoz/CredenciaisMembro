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
    public partial class FrmCongregacaoSetor : Form
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

        public FrmCongregacaoSetor()
        {
            InitializeComponent();
        }

        private void FrmCongregacaoSetor_Load(object sender, EventArgs e)
        {
            requestCongregacaoSetor();
        }

        private void limparValores()
        {
            textPesquisarNome.Clear();
            textBoxCadCongregacaoSetor.Clear();
            textBoxUpdCongregacaoSetor.Clear();
        }

        private void requestCongregacaoSetor()
        {
            string CongregacaoSetor = ("SELECT * FROM CongregacaoSetor ORDER BY CongregacaoSetor");
            SqlCommand command = new SqlCommand(CongregacaoSetor, banco.connection);

            banco.conectar();
            SqlDataReader reader = command.ExecuteReader();

            dataGridViewCongregacaoSetor.Rows.Clear();
            while (reader.Read())
            {
                dataGridViewCongregacaoSetor.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
            banco.desconectar();
        }

        private void requestCongregacaoSetorEditar()
        {
            string CongregacaoSetor = ("SELECT * FROM CongregacaoSetor WHERE idCongregacaoSetor = @ID ORDER BY CongregacaoSetor");
            SqlCommand command = new SqlCommand(CongregacaoSetor, banco.connection);

            command.Parameters.AddWithValue("@ID", dataGridViewCongregacaoSetor.CurrentRow.Cells[0].Value);

            banco.conectar();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                textBoxUpdCongregacaoSetor.Text = reader[1].ToString();
            }
            banco.desconectar();
        }

        private void textPesquisarNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (textPesquisarNome.Text == "")
            {
                string CongregacaoSetor = ("SELECT * FROM CongregacaoSetor ORDER BY CongregacaoSetor");
                SqlCommand command = new SqlCommand(CongregacaoSetor, banco.connection);

                command.Parameters.AddWithValue("@CongregacaoSetor", textPesquisarNome.Text);

                banco.conectar();
                SqlDataReader reader = command.ExecuteReader();

                dataGridViewCongregacaoSetor.Rows.Clear();
                while (reader.Read())
                {
                    dataGridViewCongregacaoSetor.Rows.Add(reader[0].ToString(), reader[1].ToString());
                }
                banco.desconectar();
            }
            else
            {
                string CongregacaoSetor = ("SELECT * FROM CongregacaoSetor WHERE (CongregacaoSetor LIKE @CongregacaoSetor + '%') ORDER BY CongregacaoSetor");
                SqlCommand command = new SqlCommand(CongregacaoSetor, banco.connection);

                command.Parameters.AddWithValue("@CongregacaoSetor", textPesquisarNome.Text);

                banco.conectar();
                SqlDataReader reader = command.ExecuteReader();

                dataGridViewCongregacaoSetor.Rows.Clear();
                while (reader.Read())
                {
                    dataGridViewCongregacaoSetor.Rows.Add(reader[0].ToString(), reader[1].ToString());
                }
                banco.desconectar();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (textPesquisarNome.Text == "")
            {
                string CongregacaoSetor = ("SELECT * FROM CongregacaoSetor ORDER BY CongregacaoSetor");
                SqlCommand command = new SqlCommand(CongregacaoSetor, banco.connection);

                command.Parameters.AddWithValue("@CongregacaoSetor", textPesquisarNome.Text);

                banco.conectar();
                SqlDataReader reader = command.ExecuteReader();

                dataGridViewCongregacaoSetor.Rows.Clear();
                while (reader.Read())
                {
                    dataGridViewCongregacaoSetor.Rows.Add(reader[0].ToString(), reader[1].ToString());
                }
                banco.desconectar();
            }
            else
            {
                string CongregacaoSetor = ("SELECT * FROM CongregacaoSetor WHERE CongregacaoSetor = @CongregacaoSetor ORDER BY CongregacaoSetor");
                SqlCommand command = new SqlCommand(CongregacaoSetor, banco.connection);

                command.Parameters.AddWithValue("@CongregacaoSetor", textPesquisarNome.Text);

                banco.conectar();
                SqlDataReader reader = command.ExecuteReader();

                dataGridViewCongregacaoSetor.Rows.Clear();
                while (reader.Read())
                {
                    dataGridViewCongregacaoSetor.Rows.Add(reader[0].ToString(), reader[1].ToString());
                }
                banco.desconectar();
            }
        }

        #region Novo Cadastro

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            if (panelNovoCadastro.Visible == false)
            {
                panelConsultar.Visible = false;
                panelEditarCadastro.Visible = false;
                panelNovoCadastro.Visible = true;

                limparValores();

                textPesquisarNome.Enabled = false;
                btnPesquisar.Enabled = false;
                btnNovoCadastro.Enabled = false;
                btnEditarCadastro.Enabled = false;
                btnExcluirCadastro.Enabled = false;
            }
        }

        private void btnSalvarNovoCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                string CongregacaoSetor = ("INSERT INTO CongregacaoSetor (CongregacaoSetor) VALUES (@CongregacaoSetor)");
                SqlCommand command = new SqlCommand(CongregacaoSetor, banco.connection);

                command.Parameters.AddWithValue("@CongregacaoSetor", textBoxCadCongregacaoSetor.Text);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //limpa todos os valores
                limparValores();

                requestCongregacaoSetor();
            }
            catch
            {
                //Menssagem de alerta, caso ocorra algum erro inesperado
                MessageBox.Show("A Ação não pôde ser realizada." + "\n" + "Verifique os dados informados e tente novamente." + "\n" + "\n" + "Se persistir no erro, contate o suporte!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSairNovoCadastro_Click(object sender, EventArgs e)
        {
            if (panelNovoCadastro.Visible == true)
            {
                panelNovoCadastro.Visible = false;
                panelEditarCadastro.Visible = false;
                panelConsultar.Visible = true;

                limparValores();

                textPesquisarNome.Enabled = true;
                btnPesquisar.Enabled = true;
                btnNovoCadastro.Enabled = true;
                btnEditarCadastro.Enabled = true;
                btnExcluirCadastro.Enabled = true;
            }
        }

        #endregion

        #region Editar Cadastro

        private void btnEditarCadastro_Click(object sender, EventArgs e)
        {
            if (panelEditarCadastro.Visible == false)
            {
                panelConsultar.Visible = false;
                panelNovoCadastro.Visible = false;
                panelEditarCadastro.Visible = true;

                limparValores();

                requestCongregacaoSetorEditar();

                textPesquisarNome.Enabled = false;
                btnPesquisar.Enabled = false;
                btnNovoCadastro.Enabled = false;
                btnEditarCadastro.Enabled = false;
                btnExcluirCadastro.Enabled = false;
            }
        }

        private void btnSalvarEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string CongregacaoSetor = ("UPDATE CongregacaoSetor SET CongregacaoSetor = @CongregacaoSetor WHERE idCongregacaoSetor = @ID");
                SqlCommand command = new SqlCommand(CongregacaoSetor, banco.connection);

                command.Parameters.AddWithValue("@CongregacaoSetor", textBoxUpdCongregacaoSetor.Text);
                command.Parameters.AddWithValue("@ID", dataGridViewCongregacaoSetor.CurrentRow.Cells[0].Value);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Alteração realizada com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                requestCongregacaoSetor();
            }
            catch
            {
                //Menssagem de alerta, caso ocorra algum erro inesperado
                MessageBox.Show("A Ação não pôde ser realizada." + "\n" + "Verifique os dados informados e tente novamente." + "\n" + "\n" + "Se persistir no erro, contate o suporte!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVoltarEditar_Click(object sender, EventArgs e)
        {
            if (panelEditarCadastro.Visible == true)
            {
                panelEditarCadastro.Visible = false;
                panelNovoCadastro.Visible = false;
                panelConsultar.Visible = true;

                limparValores();

                textPesquisarNome.Enabled = true;
                btnPesquisar.Enabled = true;
                btnNovoCadastro.Enabled = true;
                btnEditarCadastro.Enabled = true;
                btnExcluirCadastro.Enabled = true;
            }
        }

        #endregion

        private void btnExcluirCadastro_Click(object sender, EventArgs e)
        {
            if (panelConsultar.Visible == false)
            {
                panelNovoCadastro.Visible = false;
                panelEditarCadastro.Visible = false;
                panelConsultar.Visible = true;

                MessageBox.Show("Selecione uma Congregacao/Setor que deseja Excluir!", "Aviso de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dataGridViewCongregacaoSetor.Rows.Count != 0)
                {
                    //Limpa os valores inseridos.
                    limparValores();

                    dataGridViewCongregacaoSetor.Focus();

                    //Verificação dos campos exigidos e senhas para proceguir com a inserção; 
                    if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Aviso de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            string CongregacaoSetor = ("DELETE FROM CongregacaoSetor WHERE idCongregacaoSetor = @ID");
                            SqlCommand delCongregacaoSetor = new SqlCommand(CongregacaoSetor, banco.connection);

                            delCongregacaoSetor.Parameters.AddWithValue("@ID", dataGridViewCongregacaoSetor.CurrentRow.Cells[0].Value);

                            banco.conectar();
                            delCongregacaoSetor.ExecuteNonQuery();
                            banco.desconectar();
                        }
                        catch
                        {
                            //Menssagem de alerta, caso ocorra algum erro inesperado
                            MessageBox.Show("A Ação não pôde ser realizada." + "\n" + "Verifique os dados informados e tente novamente." + "\n" + "\n" + "Se persistir no erro, contate o suporte!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        //limpa todos os valores
                        limparValores();

                        MessageBox.Show("Congregacao/Setor Excluido com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        requestCongregacaoSetor();
                    }
                }
                else
                {
                    //Menssagem de alerta, caso ocorra algum erro inesperado
                    MessageBox.Show("Não existe Congregacao/Setor Cadastrada.", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        #region Paint

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            panelMenu.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelMenu.Width,
            panelMenu.Height, 7, 7));
        }

        private void flpContainerPai_Paint(object sender, PaintEventArgs e)
        {
            flpContainerPai.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, flpContainerPai.Width,
            flpContainerPai.Height, 7, 7));
        }

        private void panelConsultarPerfil_Paint(object sender, PaintEventArgs e)
        {
            panelConsultar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelConsultar.Width,
            panelConsultar.Height, 7, 7));
        }

        private void panelEditarCadastro_Paint(object sender, PaintEventArgs e)
        {
            panelEditarCadastro.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelEditarCadastro.Width,
            panelEditarCadastro.Height, 7, 7));
        }

        private void panelNovoCadastro_Paint(object sender, PaintEventArgs e)
        {
            panelNovoCadastro.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelNovoCadastro.Width,
            panelNovoCadastro.Height, 7, 7));
        }

        #endregion

    }
}
