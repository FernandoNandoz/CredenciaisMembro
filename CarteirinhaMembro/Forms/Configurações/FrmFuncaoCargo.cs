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
    public partial class FrmFuncaoCargo : Form
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

        public FrmFuncaoCargo()
        {
            InitializeComponent();
        }

        private void FrmFuncaoCargo_Load(object sender, EventArgs e)
        {
            requestFuncaoCargo();
        }

        private void limparValores()
        {
            textPesquisarNome.Clear();
            textBoxCadNomeFuncaoCargo.Clear();
            textBoxUpdNomeFuncaoCargo.Clear();
        }

        private void requestFuncaoCargo()
        {
            string FuncaoCargo = ("SELECT * FROM CargoFuncao ORDER BY cargoFuncao");
            SqlCommand command = new SqlCommand(FuncaoCargo, banco.connection);

            banco.conectar();
            SqlDataReader reader = command.ExecuteReader();

            dataGridViewFuncaoCargo.Rows.Clear();
            while(reader.Read())
            {
                dataGridViewFuncaoCargo.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
            banco.desconectar();
        }

        private void requestFuncaoCargoEditar()
        {
            string FuncaoCargo = ("SELECT * FROM CargoFuncao WHERE idCargoFuncao = @ID ORDER BY cargoFuncao");
            SqlCommand command = new SqlCommand(FuncaoCargo, banco.connection);

            command.Parameters.AddWithValue("@ID", dataGridViewFuncaoCargo.CurrentRow.Cells[0].Value);

            banco.conectar();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                textBoxUpdNomeFuncaoCargo.Text = reader[1].ToString();
            }
            banco.desconectar();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (textPesquisarNome.Text == "")
            {
                string FuncaoCargo = ("SELECT * FROM CargoFuncao ORDER BY cargoFuncao");
                SqlCommand command = new SqlCommand(FuncaoCargo, banco.connection);

                command.Parameters.AddWithValue("@cargoFuncao", textPesquisarNome.Text);

                banco.conectar();
                SqlDataReader reader = command.ExecuteReader();

                dataGridViewFuncaoCargo.Rows.Clear();
                while (reader.Read())
                {
                    dataGridViewFuncaoCargo.Rows.Add(reader[0].ToString(), reader[1].ToString());
                }
                banco.desconectar();
            }
            else
            {
                string FuncaoCargo = ("SELECT * FROM CargoFuncao WHERE cargoFuncao = @cargoFuncao ORDER BY cargoFuncao");
                SqlCommand command = new SqlCommand(FuncaoCargo, banco.connection);

                command.Parameters.AddWithValue("@cargoFuncao", textPesquisarNome.Text);

                banco.conectar();
                SqlDataReader reader = command.ExecuteReader();

                dataGridViewFuncaoCargo.Rows.Clear();
                while (reader.Read())
                {
                    dataGridViewFuncaoCargo.Rows.Add(reader[0].ToString(), reader[1].ToString());
                }
                banco.desconectar();
            }
        }

        private void textPesquisarNome_KeyDown(object sender, KeyEventArgs e)
        {
            if(textPesquisarNome.Text == "")
            {
                string FuncaoCargo = ("SELECT * FROM CargoFuncao ORDER BY cargoFuncao");
                SqlCommand command = new SqlCommand(FuncaoCargo, banco.connection);

                command.Parameters.AddWithValue("@cargoFuncao", textPesquisarNome.Text);

                banco.conectar();
                SqlDataReader reader = command.ExecuteReader();

                dataGridViewFuncaoCargo.Rows.Clear();
                while (reader.Read())
                {
                    dataGridViewFuncaoCargo.Rows.Add(reader[0].ToString(), reader[1].ToString());
                }
                banco.desconectar();
            }
            else
            {
                string FuncaoCargo = ("SELECT * FROM CargoFuncao WHERE (cargoFuncao LIKE @cargoFuncao + '%') ORDER BY cargoFuncao");
                SqlCommand command = new SqlCommand(FuncaoCargo, banco.connection);

                command.Parameters.AddWithValue("@cargoFuncao", textPesquisarNome.Text);

                banco.conectar();
                SqlDataReader reader = command.ExecuteReader();

                dataGridViewFuncaoCargo.Rows.Clear();
                while (reader.Read())
                {
                    dataGridViewFuncaoCargo.Rows.Add(reader[0].ToString(), reader[1].ToString());
                }
                banco.desconectar();
            }        
        }

        #region Novo Cadastro

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            if(panelNovoCadastro.Visible == false)
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
                string CargoFuncao = ("INSERT INTO CargoFuncao (cargoFuncao) VALUES (@cargoFuncao)");
                SqlCommand command = new SqlCommand(CargoFuncao, banco.connection);

                command.Parameters.AddWithValue("@cargoFuncao", textBoxCadNomeFuncaoCargo.Text);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //limpa todos os valores
                limparValores();

                requestFuncaoCargo();
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

                requestFuncaoCargoEditar();

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
                string CargoFuncao = ("UPDATE CargoFuncao SET cargoFuncao = @cargoFuncao WHERE idCargoFuncao = @ID");
                SqlCommand command = new SqlCommand(CargoFuncao, banco.connection);

                command.Parameters.AddWithValue("@cargoFuncao", textBoxUpdNomeFuncaoCargo.Text);
                command.Parameters.AddWithValue("@ID", dataGridViewFuncaoCargo.CurrentRow.Cells[0].Value);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Alteração realizada com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                requestFuncaoCargo();
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

                MessageBox.Show("Selecione uma Função/Cargo que deseja Excluir!", "Aviso de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dataGridViewFuncaoCargo.Rows.Count != 0)
                {
                    //Limpa os valores inseridos.
                    limparValores();

                    dataGridViewFuncaoCargo.Focus();

                    //Verificação dos campos exigidos e senhas para proceguir com a inserção; 
                    if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Aviso de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            string FuncaoCargo = ("DELETE FROM CargoFuncao WHERE idCargoFuncao = @ID");
                            SqlCommand delFuncaoCargo = new SqlCommand(FuncaoCargo, banco.connection);

                            delFuncaoCargo.Parameters.AddWithValue("@ID", dataGridViewFuncaoCargo.CurrentRow.Cells[0].Value);

                            banco.conectar();
                            delFuncaoCargo.ExecuteNonQuery();
                            banco.desconectar();
                        }
                        catch
                        {
                            //Menssagem de alerta, caso ocorra algum erro inesperado
                            MessageBox.Show("A Ação não pôde ser realizada." + "\n" + "Verifique os dados informados e tente novamente." + "\n" + "\n" + "Se persistir no erro, contate o suporte!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        //limpa todos os valores
                        limparValores();

                        MessageBox.Show("Função/Cargo Excluido com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        requestFuncaoCargo();
                    }
                }
                else
                {
                    //Menssagem de alerta, caso ocorra algum erro inesperado
                    MessageBox.Show("Não existe Função/Cargo Cadastrada.", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
