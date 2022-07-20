using CarteirinhaMembro.Properties;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteirinhaMembro
{
    public partial class frmMembros : Form
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

        int cont = 0, contagem = 0, tipoAcao = 0;
        bool liberado = false;
        string status, situacao;

        public frmMembros()
        {
            InitializeComponent();
        }

        private void frmMembros_Load(object sender, EventArgs e)
        {
            dadosRequestMembros();
            verificarQuantidadeMembros();

            comboBoxFiltrarSituacao.SelectedIndex = 0;

            if(UpdateMembro._retornarWindow() == 1)
            {
                UpdateMembro.receberWindow(UpdateMembro._retornarIdMembro(), true, 2);
                //
                btnEditarCadastro_Click(sender, e);
                //
            }
        }

        private void requestComboBoxCargoFuncao()
        {
            string Membros = ("SELECT * FROM CargoFuncao");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if(tipoAcao == 1)
            {
                comboBoxCadFuncaoCargo.Items.Clear();
                while (datareader.Read())
                {
                    comboBoxCadFuncaoCargo.Items.Add(datareader[1].ToString());
                }
            }
            
            if(tipoAcao == 2)
            {
                comboBoxUpdFuncaoCargo.Items.Clear();
                while (datareader.Read())
                {
                    comboBoxUpdFuncaoCargo.Items.Add(datareader[1].ToString());
                }
            }

            banco.desconectar();
        }

        private void requestComboBoxSetorCongregacao()
        {
            string Membros = ("SELECT * FROM CongregacaoSetor");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if(tipoAcao == 1)
            {
                comboBoxCadSetorCongregacao.Items.Clear();
                while (datareader.Read())
                {
                    comboBoxCadSetorCongregacao.Items.Add(datareader[1].ToString());
                }
            }

            if(tipoAcao == 2)
            {
                comboBoxUpdSetorCongregacao.Items.Clear();
                while (datareader.Read())
                {
                    comboBoxUpdSetorCongregacao.Items.Add(datareader[1].ToString());
                }
            }     
            banco.desconectar();
        }

        private void gerarLog()
        {
            Log.gerarLog("");
        }

        private void limparValores()
        {
            textBoxPesquisarNome.Clear();
            //
            textBoxCadNomeCompleto.Clear();
            maskCadDataNascimento.Clear();
            maskCadCPF.Clear();
            textBoxCadRG.Clear();
            comboBoxCadSexo.Text = "";
            maskCadTelefone.Clear();
            combCadEstadoCivil.Text = "";
            textBoxCadNaturalidade.Clear();
            textBoxCadNacionalidade.Clear();
            textBoxCadNomePai.Clear();
            textBoxCadNomeMae.Clear();
            textBoxCadEndereco.Clear();
            comboBoxCadSetorCongregacao.Text = "";
            comboBoxCadFuncaoCargo.Text = "";
            combCadBatismoAguas.Text = "";
            maskCadDataBatismoAgua.Clear();
            combCadBatismoEspiritoSanto.Text = "";
            pictureBoxCadImgProfile.ImageLocation = null;
            linkLabelCadExcluirImagem.Visible = false;
            //
            textBoxUpdNomeCompleto.Clear();
            maskUpdDataNascimento.Clear();
            maskUpdCPF.Clear();
            textBoxUpdRG.Clear();
            comboBoxUpdSexo.Text = "";
            maskUpdTelefone.Clear();
            combUpdEstadoCivil.Text = "";
            textBoxUpdNaturalidade.Clear();
            textBoxUpdNacionalidade.Clear();
            textBoxUpdNomePai.Clear();
            textBoxUpdNomeMae.Clear();
            textBoxUpdEndereco.Clear();
            comboBoxUpdSetorCongregacao.Text = "";
            comboBoxUpdFuncaoCargo.Text = "";
            comboBoxUpdBatismoAguas.Text = "";
            maskUpdDataBatismoAguas.Clear();
            combUpdBatismoEspiritoSanto.Text = "";
            pictureBoxUpdImgProfile.Image = null;
            linkLabelUpdExcluirImagem.Visible = false;
        }

        private void verificarQuantidadeMembros()
        {
            //Ira verificar se o Cliente ja possui conta aberta, se nao houver ele ira efetuar a abertura.
            string Membros = ("SELECT COUNT(*) FROM Membros");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                contagem = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            labelContagem.Text = ("Total: " + contagem + " Registros");
        }

        private void verificarComponentesNovoCadastro()
        {
            //Verifica se todo os Campos foram preenchidos.
            if (textBoxCadNomeCompleto.Text != ("")
                && maskCadDataNascimento.Text != ("")
                && maskCadCPF.Text != ("")
                && textBoxCadRG.Text != ("")
                && comboBoxCadSexo.Text != ("")
                && maskCadTelefone.Text != ("")
                && combCadEstadoCivil.Text != ("")
                && textBoxCadNaturalidade.Text != ("")
                && textBoxCadNacionalidade.Text != ("")
                && textBoxCadNomePai.Text != ("")
                && textBoxCadNomeMae.Text != ("")
                && textBoxCadEndereco.Text != ("")
                && comboBoxCadSetorCongregacao.Text != ("")
                && comboBoxCadFuncaoCargo.Text != ("")
                && combCadBatismoAguas.Text != ("")
                && maskCadDataBatismoAgua.Text != ("")
                && combCadBatismoEspiritoSanto.Text != ("")
                && comboBoxCadSituacaoContribuicao.Text != ("")
                )
            {
                liberado = true;
            }
            else
            {
                liberado = false;
            }
        }

        private void verificarComponentesEditarCadastro()
        {
            //Verifica se todo os Campos foram preenchidos.
            if (textBoxUpdNomeCompleto.Text != ("")
                && maskUpdDataNascimento.Text != ("")
                && maskUpdCPF.Text != ("")
                && textBoxUpdRG.Text != ("")
                && comboBoxUpdSexo.Text != ("")
                && maskUpdTelefone.Text != ("")
                && combUpdEstadoCivil.Text != ("")
                && textBoxUpdNaturalidade.Text != ("")
                && textBoxUpdNacionalidade.Text != ("")
                && textBoxUpdNomePai.Text != ("")
                && textBoxUpdNomeMae.Text != ("")
                && textBoxUpdEndereco.Text != ("")
                && comboBoxUpdSetorCongregacao.Text != ("")
                && comboBoxUpdFuncaoCargo.Text != ("")
                && comboBoxUpdBatismoAguas.Text != ("")
                && maskUpdDataBatismoAguas.Text != ("")
                && combUpdBatismoEspiritoSanto.Text != ("")
                && comboBoxUpdSituacaoContribuicao.Text != ("")
                )
            {
                liberado = true;
            }
            else
            {
                liberado = false;
            }
        }

        private int gerarMatricula()
        {
            int matricula = 0;

            //Ira verificar se o Cliente ja possui conta aberta, se nao houver ele ira efetuar a abertura.
            string Membro = ("SELECT MAX(matricula) FROM CredencialMembro");
            SqlCommand exeVerificacao = new SqlCommand(Membro, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if(datareader.Read())
            {
                if(datareader[0].ToString() == "")
                {
                    matricula = 2200000;
                }
                else
                {
                    matricula = int.Parse(datareader[0].ToString());
                }
            }
            else
            {
                matricula = 2200000;
            }
            banco.desconectar();


            matricula += 1;

            return matricula;
        }

        private int verificarIdMembro()
        {
            int idMembro = 0;

            //Ira verificar se o Cliente ja possui conta aberta, se nao houver ele ira efetuar a abertura.
            string Colaborador = ("SELECT idMembro FROM Membros WHERE idMembro=(SELECT MAX(idMembro) FROM Membros)");
            SqlCommand exeVerificacao = new SqlCommand(Colaborador, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                idMembro = int.Parse(datareader[0].ToString());
            }
            banco.desconectar();

            return idMembro;
        }

        private void insertQuery()
        {
            if (combCadBatismoAguas.Text == "SIM"
                && combCadEstadoCivil.Text != "OUTROS"
                && pictureBoxCadImgProfile.Image != null
                && comboBoxCadSituacaoContribuicao.Text != "MEMBRO NAO CONTRIBUIU")
            {
                status = "ATIVO";
                situacao = "Cadastro completo e verificado!";
            }
            else
            {
                status = "PENDENTE";
                situacao = "Cadastro Pendente. Motivo(os):";

                if (combCadEstadoCivil.Text == "OUTROS")
                {
                    situacao = situacao + " Membro possui Estado Civil indefinido.";
                }

                if (combCadBatismoAguas.Text == "NAO" || combCadBatismoAguas.Text == "NÃO")
                {
                    situacao = situacao + " Membro não é batizado.";
                }

                if (pictureBoxCadImgProfile.Image == null)
                {
                    situacao = situacao + " Membro está sem foto de Perfil (Foto 3x4).";
                }

                if (comboBoxCadSituacaoContribuicao.Text == "MEMBRO NAO CONTRIBUIU")
                {
                    situacao = situacao + " Membro não contribiu com o valor.";
                }
            }

            try
            {
                string Membros = ("INSERT INTO Membros (nomeCompleto, dataNascimento, sexo, endereco, telefone, pai, mae, naturalidade, nacionalidade, estadoCivil, RG, CPF, funcaoCargo, congregacaoSetor, batismoAguas, batismoEspirito, fotoPerfil, codigoLog, dataBatismo, cidadeResidencia) VALUES (@nomeCompleto, @dataNascimento, @sexo, @endereco, @telefone, @pai, @mae, @naturalidade, @nacionalidade, @estadoCivil, @RG, @CPF, @funcaoCargo, @congregacaoSetor, @batismoAguas, @batismoEspirito, @fotoPerfil, @codigoLog, @dataBatismo, @cidadeResidencia)");
                string CredencialMembro = ("INSERT INTO CredencialMembro (matricula, status, situacao, statusEmissao, via, idMembroFK, situacaoContribuicao) VALUES (@matricula, @status, @situacao, @statusEmissao, @via, @idMembroFK, @situacaoContribuicao)");
                SqlCommand cadMembros = new SqlCommand(Membros, banco.connection);
                SqlCommand cadCredencialMembro = new SqlCommand(CredencialMembro, banco.connection);

                cadMembros.Parameters.AddWithValue("@nomeCompleto", textBoxCadNomeCompleto.Text);
                cadMembros.Parameters.AddWithValue("@dataNascimento", DateTime.Parse(maskCadDataNascimento.Text));
                cadMembros.Parameters.AddWithValue("@sexo", comboBoxCadSexo.Text);
                cadMembros.Parameters.AddWithValue("@endereco", textBoxCadEndereco.Text);
                cadMembros.Parameters.AddWithValue("@telefone", maskCadTelefone.Text);
                cadMembros.Parameters.AddWithValue("@pai", textBoxCadNomePai.Text);
                cadMembros.Parameters.AddWithValue("@mae", textBoxCadNomeMae.Text);
                cadMembros.Parameters.AddWithValue("@naturalidade", textBoxCadNaturalidade.Text);
                cadMembros.Parameters.AddWithValue("@nacionalidade", textBoxCadNacionalidade.Text);
                cadMembros.Parameters.AddWithValue("@estadoCivil", combCadEstadoCivil.Text);
                cadMembros.Parameters.AddWithValue("@RG", textBoxCadRG.Text);
                //
                maskCadCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                cadMembros.Parameters.AddWithValue("@CPF", maskCadCPF.Text);
                maskCadCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                cadMembros.Parameters.AddWithValue("@funcaoCargo", comboBoxCadFuncaoCargo.Text);
                cadMembros.Parameters.AddWithValue("@congregacaoSetor", comboBoxCadSetorCongregacao.Text);
                cadMembros.Parameters.AddWithValue("@batismoAguas", combCadBatismoAguas.Text);
                cadMembros.Parameters.AddWithValue("@batismoEspirito", combCadBatismoEspiritoSanto.Text);

                if (pictureBoxCadImgProfile.Image != null)
                {
                    cadMembros.Parameters.AddWithValue("@fotoPerfil", ImagemParaByte());
                }

                cadMembros.Parameters.AddWithValue("@codigoLog", Log._retornarLog());
                cadMembros.Parameters.AddWithValue("@dataBatismo", DateTime.Parse(maskCadDataBatismoAgua.Text));
                cadMembros.Parameters.AddWithValue("@cidadeResidencia", textBoxCadCidadeResidencia.Text);

                //
                banco.conectar();
                cadMembros.ExecuteNonQuery();
                banco.desconectar();


                //
                cadCredencialMembro.Parameters.AddWithValue("@matricula", gerarMatricula());
                cadCredencialMembro.Parameters.AddWithValue("@status", status);
                cadCredencialMembro.Parameters.AddWithValue("@situacao", situacao);
                cadCredencialMembro.Parameters.AddWithValue("@statusEmissao", "A EMITIR");
                cadCredencialMembro.Parameters.AddWithValue("@via", 0);
                cadCredencialMembro.Parameters.AddWithValue("@idMembroFK", verificarIdMembro());
                cadCredencialMembro.Parameters.AddWithValue("@situacaoContribuicao", comboBoxCadSituacaoContribuicao.Text);

                //
                banco.conectar();
                cadCredencialMembro.ExecuteNonQuery();
                banco.desconectar();
            }
            catch
            {
                //Menssagem de alerta, caso ocorra algum erro inesperado
                MessageBox.Show("A Ação não pôde ser realizada." + "\n" + "Verifique os dados informados e tente novamente." + "\n" + "\n" + "Se persistir no erro, contate o suporte!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void updateQuery()
        {
            int idMembro = 0;

            if (UpdateMembro._retornarMethodUpdate() == true)
            {
                idMembro = UpdateMembro._retornarIdMembro();
            }
            else
            {
                idMembro = int.Parse(dataGridViewMembros.CurrentRow.Cells[0].Value.ToString());
            }

            if (comboBoxUpdBatismoAguas.Text == "SIM"
                && combUpdEstadoCivil.Text != "OUTROS"  
                && pictureBoxUpdImgProfile.Image != null
                && comboBoxUpdSituacaoContribuicao.Text != "MEMBRO NAO CONTRIBUIU")
            {
                status = "ATIVO";
                situacao = "Cadastro completo e verificado!";
            }
            else
            {
                status = "PENDENTE";
                situacao = "Cadastro Pendente. Motivo(os):";

                if (combUpdEstadoCivil.Text == "OUTROS")
                {
                    situacao = situacao + " Membro possui Estado Civil indefinido.";
                }

                if (comboBoxUpdBatismoAguas.Text == "NAO" || comboBoxUpdBatismoAguas.Text == "NÃO")
                {
                    situacao = situacao + " Membro não é batizado.";
                }

                if (pictureBoxUpdImgProfile.Image == null)
                {
                    situacao = situacao + " Membro está sem foto de Perfil (Foto 3x4).";
                }

                if (comboBoxUpdSituacaoContribuicao.Text == "MEMBRO NAO CONTRIBUIU")
                {
                    situacao = situacao + " Membro não contribiu com o valor.";
                }
            }

            try
            {
                string Membros = ("UPDATE Membros SET nomeCompleto = @nomeCompleto, dataNascimento = @dataNascimento, sexo = @sexo, endereco = @endereco, telefone = @telefone, pai = @pai, mae = @mae, naturalidade = @naturalidade, nacionalidade = @nacionalidade, estadoCivil = @estadoCivil, RG = @RG, CPF = @CPF, funcaoCargo = @funcaoCargo, congregacaoSetor = @congregacaoSetor, batismoAguas = @batismoAguas, batismoEspirito = @batismoEspirito, fotoPerfil = @fotoPerfil, codigoLog = @codigoLog, dataBatismo = @dataBatismo, cidadeResidencia = @cidadeResidencia WHERE idMembro = @ID");
                string CredencialMembro = ("UPDATE CredencialMembro SET status = @status, situacao = @situacao, situacaoContribuicao = @situacaoContribuicao WHERE idMembroFK = @ID");
                SqlCommand updMembros = new SqlCommand(Membros, banco.connection);
                SqlCommand updCredencialMembro = new SqlCommand(CredencialMembro, banco.connection);

                updMembros.Parameters.AddWithValue("@nomeCompleto", textBoxUpdNomeCompleto.Text);
                updMembros.Parameters.AddWithValue("@dataNascimento", DateTime.Parse(maskUpdDataNascimento.Text));
                updMembros.Parameters.AddWithValue("@sexo", comboBoxUpdSexo.Text);
                updMembros.Parameters.AddWithValue("@endereco", textBoxUpdEndereco.Text);
                updMembros.Parameters.AddWithValue("@telefone", maskUpdTelefone.Text);
                updMembros.Parameters.AddWithValue("@pai", textBoxUpdNomePai.Text);
                updMembros.Parameters.AddWithValue("@mae", textBoxUpdNomeMae.Text);
                updMembros.Parameters.AddWithValue("@naturalidade", textBoxUpdNaturalidade.Text);
                updMembros.Parameters.AddWithValue("@nacionalidade", textBoxUpdNacionalidade.Text);
                updMembros.Parameters.AddWithValue("@estadoCivil", combUpdEstadoCivil.Text);
                updMembros.Parameters.AddWithValue("@RG", textBoxUpdRG.Text);
                //
                maskUpdCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                updMembros.Parameters.AddWithValue("@CPF", maskUpdCPF.Text);
                maskUpdCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                updMembros.Parameters.AddWithValue("@funcaoCargo", comboBoxUpdFuncaoCargo.Text);
                updMembros.Parameters.AddWithValue("@congregacaoSetor", comboBoxUpdSetorCongregacao.Text);
                updMembros.Parameters.AddWithValue("@batismoAguas", comboBoxUpdBatismoAguas.Text);
                updMembros.Parameters.AddWithValue("@batismoEspirito", combUpdBatismoEspiritoSanto.Text);
                updMembros.Parameters.AddWithValue("@fotoPerfil", ImagemParaByte());
                updMembros.Parameters.AddWithValue("@codigoLog", Log._retornarLog());
                updMembros.Parameters.AddWithValue("@dataBatismo", DateTime.Parse(maskUpdDataBatismoAguas.Text));
                updMembros.Parameters.AddWithValue("@cidadeResidencia", textBoxUpdCidadeResidencia.Text);
                updMembros.Parameters.AddWithValue("@ID", idMembro);

                //
                updCredencialMembro.Parameters.AddWithValue("@status", status);
                updCredencialMembro.Parameters.AddWithValue("@situacao", situacao);
                updCredencialMembro.Parameters.AddWithValue("@situacaoContribuicao", comboBoxUpdSituacaoContribuicao.Text);
                updCredencialMembro.Parameters.AddWithValue("@ID", idMembro);

                banco.conectar();
                updMembros.ExecuteNonQuery();
                updCredencialMembro.ExecuteNonQuery();
                banco.desconectar();
            }
            catch
            {
                //Menssagem de alerta, caso ocorra algum erro inesperado
                MessageBox.Show("A Ação não pôde ser realizada." + "\n" + "Verifique os dados informados e tente novamente." + "\n" + "\n" + "Se persistir no erro, contate o suporte!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteQuery()
        {
            try
            {
                string Membros = ("DELETE FROM Membros WHERE idMembro = @ID");
                string CredencialMembro = ("DELETE FROM CredencialMembro WHERE idMembroFK = @ID");
                SqlCommand delMembros = new SqlCommand(Membros, banco.connection);
                SqlCommand delCredencialMembro = new SqlCommand(CredencialMembro, banco.connection);

                delMembros.Parameters.AddWithValue("@ID", int.Parse(dataGridViewMembros.CurrentRow.Cells[0].Value.ToString()));

                delCredencialMembro.Parameters.AddWithValue("@ID", int.Parse(dataGridViewMembros.CurrentRow.Cells[0].Value.ToString()));

                banco.conectar();
                delMembros.ExecuteNonQuery();
                delCredencialMembro.ExecuteNonQuery();
                banco.desconectar();
            }
            catch
            {
                //Menssagem de alerta, caso ocorra algum erro inesperado
                MessageBox.Show("A Ação não pôde ser realizada." + "\n" + "Verifique os dados informados e tente novamente." + "\n" + "\n" + "Se persistir no erro, contate o suporte!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void insertQueryList()
        {
            for (int i = 0; i < dataGridViewImportarLista.Rows.Count - 0; i++)
            {
                status = "PENDENTE";
                situacao = "Cadastro Pendente. Motivo(os):";

                if (dataGridViewImportarLista.Rows[i].Cells[9].Value.ToString() != "SOLTEIRO (A)"
                    && dataGridViewImportarLista.Rows[i].Cells[9].Value.ToString() != "CASADO (A)"
                    && dataGridViewImportarLista.Rows[i].Cells[9].Value.ToString() != "VIUVO (A)"
                    && dataGridViewImportarLista.Rows[i].Cells[9].Value.ToString() != "DIVORCIADO (A)"
                    && dataGridViewImportarLista.Rows[i].Cells[18].Value.ToString() != "MEMBRO NAO CONTRIBUIU")
                {
                    situacao = situacao + " Membro possui Estado Civil indefinido.";
                }

                if (dataGridViewImportarLista.Rows[i].Cells[14].Value.ToString() == "NAO")
                {
                    situacao = situacao + " Membro não é batizado.";
                }

                situacao = situacao + " Membro está sem foto de Perfil (Foto 3x4).";

                if (dataGridViewImportarLista.Rows[i].Cells[18].Value.ToString() == "MEMBRO NAO CONTRIBUIU")
                {
                    situacao = situacao + " Membro não contribiu com o valor.";
                }

                if(dataGridViewImportarLista.Rows[i].DefaultCellStyle.BackColor != Color.Red && dataGridViewImportarLista.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                {
                    try
                    {
                        string Membros = ("INSERT INTO Membros (nomeCompleto, dataNascimento, sexo, endereco, telefone, pai, mae, naturalidade, nacionalidade, estadoCivil, RG, CPF, funcaoCargo, congregacaoSetor, batismoAguas, batismoEspirito, codigoLog, dataBatismo, cidadeResidencia) VALUES (@nomeCompleto, @dataNascimento, @sexo, @endereco, @telefone, @pai, @mae, @naturalidade, @nacionalidade, @estadoCivil, @RG, @CPF, @funcaoCargo, @congregacaoSetor, @batismoAguas, @batismoEspirito, @codigoLog, @dataBatismo, @cidadeResidencia)");
                        string CredencialMembro = ("INSERT INTO CredencialMembro (matricula, status, situacao, statusEmissao, via, idMembroFK, situacaoContribuicao) VALUES (@matricula, @status, @situacao, @statusEmissao, @via, @idMembroFK, @situacaoContribuicao)");
                        SqlCommand cadMembros = new SqlCommand(Membros, banco.connection);
                        SqlCommand cadCredencialMembro = new SqlCommand(CredencialMembro, banco.connection);

                        cadMembros.Parameters.Clear();
                        cadMembros.Parameters.AddWithValue("@nomeCompleto", dataGridViewImportarLista.Rows[i].Cells[0].Value);
                        cadMembros.Parameters.AddWithValue("@dataNascimento", DateTime.Parse(dataGridViewImportarLista.Rows[i].Cells[1].Value.ToString()));
                        cadMembros.Parameters.AddWithValue("@sexo", dataGridViewImportarLista.Rows[i].Cells[2].Value);
                        cadMembros.Parameters.AddWithValue("@endereco", dataGridViewImportarLista.Rows[i].Cells[3].Value);
                        cadMembros.Parameters.AddWithValue("@telefone", dataGridViewImportarLista.Rows[i].Cells[4].Value);
                        cadMembros.Parameters.AddWithValue("@pai", dataGridViewImportarLista.Rows[i].Cells[5].Value);
                        cadMembros.Parameters.AddWithValue("@mae", dataGridViewImportarLista.Rows[i].Cells[6].Value);
                        cadMembros.Parameters.AddWithValue("@naturalidade", dataGridViewImportarLista.Rows[i].Cells[7].Value);
                        cadMembros.Parameters.AddWithValue("@nacionalidade", dataGridViewImportarLista.Rows[i].Cells[8].Value);
                        cadMembros.Parameters.AddWithValue("@estadoCivil", dataGridViewImportarLista.Rows[i].Cells[9].Value);
                        cadMembros.Parameters.AddWithValue("@RG", dataGridViewImportarLista.Rows[i].Cells[10].Value);
                        cadMembros.Parameters.AddWithValue("@CPF", dataGridViewImportarLista.Rows[i].Cells[11].Value);
                        cadMembros.Parameters.AddWithValue("@funcaoCargo", dataGridViewImportarLista.Rows[i].Cells[12].Value);
                        cadMembros.Parameters.AddWithValue("@congregacaoSetor", dataGridViewImportarLista.Rows[i].Cells[13].Value);
                        cadMembros.Parameters.AddWithValue("@batismoAguas", dataGridViewImportarLista.Rows[i].Cells[14].Value);
                        cadMembros.Parameters.AddWithValue("@batismoEspirito", dataGridViewImportarLista.Rows[i].Cells[16].Value);
                        cadMembros.Parameters.AddWithValue("@codigoLog", Log._retornarLog());
                        cadMembros.Parameters.AddWithValue("@dataBatismo", DateTime.Parse(dataGridViewImportarLista.Rows[i].Cells[15].Value.ToString()));
                        cadMembros.Parameters.AddWithValue("@cidadeResidencia", dataGridViewImportarLista.Rows[i].Cells[17].Value);

                        banco.conectar();
                        cadMembros.ExecuteNonQuery();
                        banco.desconectar();


                        //
                        cadCredencialMembro.Parameters.Clear();
                        cadCredencialMembro.Parameters.AddWithValue("@matricula", gerarMatricula());
                        cadCredencialMembro.Parameters.AddWithValue("@status", status);
                        cadCredencialMembro.Parameters.AddWithValue("@situacao", situacao);
                        cadCredencialMembro.Parameters.AddWithValue("@statusEmissao", "A EMITIR");
                        cadCredencialMembro.Parameters.AddWithValue("@via", 0);
                        cadCredencialMembro.Parameters.AddWithValue("@idMembroFK", verificarIdMembro());
                        cadCredencialMembro.Parameters.AddWithValue("@situacaoContribuicao", dataGridViewImportarLista.Rows[i].Cells[18].Value);

                        banco.conectar();
                        cadCredencialMembro.ExecuteNonQuery();
                        banco.desconectar();
                    }
                    catch
                    {
                        //Menssagem de alerta, caso ocorra algum erro inesperado
                        MessageBox.Show("A Ação não pôde ser realizada." + "\n" + "Verifique os dados informados e tente novamente." + "\n" + "\n" + "Se persistir no erro, contate o suporte!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }            
            }
        }

        public void dadosRequestMembros()
        {
            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK ORDER BY nomeCompleto");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewMembros.Rows.Clear();
            while (datareader.Read())
            {
                dataGridViewMembros.Rows.Add(datareader[0].ToString(),
                                            datareader[1].ToString(),
                                            datareader[23].ToString(),
                                            datareader[13].ToString(),
                                            datareader[14].ToString());
            }

            banco.desconectar();
            dataGridViewMembros.Refresh();
        }

        public void dadosRequestMembrosEditar()
        {
            int idMembro = 0;

            if(UpdateMembro._retornarMethodUpdate() == true)
            {
                idMembro = UpdateMembro._retornarIdMembro();
            }
            else
            {
                idMembro = int.Parse(dataGridViewMembros.CurrentRow.Cells[0].Value.ToString());
            }

            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE Membros.idMembro = @ID ORDER BY nomeCompleto");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idMembro);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                textBoxUpdNomeCompleto.Text = datareader[1].ToString();
                maskUpdDataNascimento.Text = datareader[2].ToString();
                maskUpdCPF.Text = datareader[12].ToString();
                textBoxUpdRG.Text = datareader[11].ToString();
                comboBoxUpdSexo.Text = datareader[3].ToString();
                maskUpdTelefone.Text = datareader[5].ToString();
                combUpdEstadoCivil.Text = datareader[10].ToString();
                textBoxUpdNaturalidade.Text = datareader[9].ToString();
                textBoxUpdNacionalidade.Text = datareader[8].ToString();
                textBoxUpdNomePai.Text = datareader[6].ToString();
                textBoxUpdNomeMae.Text = datareader[7].ToString();
                textBoxUpdEndereco.Text = datareader[4].ToString();
                comboBoxUpdSetorCongregacao.Text = datareader[14].ToString();
                comboBoxUpdFuncaoCargo.Text = datareader[13].ToString();
                comboBoxUpdBatismoAguas.Text = datareader[15].ToString();
                maskUpdDataBatismoAguas.Text = datareader[19].ToString();
                combUpdBatismoEspiritoSanto.Text = datareader[16].ToString();
                textBoxUpdCidadeResidencia.Text = datareader[20].ToString();
                textBoxUpdMatricula.Text = datareader[22].ToString();
                comboBoxUpdSituacaoContribuicao.Text = datareader[31].ToString();

                if (datareader[17].ToString() != "")
                {
                    using (var stream = new System.IO.MemoryStream((byte[])datareader[17]))
                    {
                        pictureBoxUpdImgProfile.Image = Bitmap.FromStream(stream);

                        linkLabelUpdExcluirImagem.Visible = true;
                    }
                }
            }

            banco.desconectar();
        }

        private byte[] ImagemParaByte()
        {
            using (var stream = new System.IO.MemoryStream())
            {
                if (tipoAcao == 1)
                {
                    if (pictureBoxCadImgProfile.Image == null)
                    {
                        if(comboBoxCadSexo.Text == "MASCULINO")
                        {
                            pictureBoxCadImgProfile.Image = Resources.icons8_user_126px;
                        }

                        if (comboBoxCadSexo.Text == "FEMININO")
                        {
                            pictureBoxCadImgProfile.Image = Resources.icons8_businesswoman_126px;
                        }

                        if (comboBoxCadSexo.Text == "OUTRO")
                        {
                            pictureBoxCadImgProfile.Image = Resources.icons8_user_126px;
                        }
                    }

                    pictureBoxCadImgProfile.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                }

                if (tipoAcao == 2)
                {
                    if(pictureBoxUpdImgProfile.Image == null)
                    {
                        if (comboBoxUpdSexo.Text == "MASCULINO")
                        {
                            pictureBoxUpdImgProfile.Image = Resources.icons8_user_126px;
                        }

                        if (comboBoxUpdSexo.Text == "FEMININO")
                        {
                            pictureBoxUpdImgProfile.Image = Resources.icons8_businesswoman_126px;
                        }

                        if (comboBoxUpdSexo.Text == "OUTRO")
                        {
                            pictureBoxUpdImgProfile.Image = Resources.icons8_user_126px;
                        }
                    }
                    pictureBoxUpdImgProfile.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                }

                stream.Seek(0, System.IO.SeekOrigin.Begin);
                byte[] byteArray = new byte[stream.Length];
                stream.Read(byteArray, 0, System.Convert.ToInt32(stream.Length));
                return byteArray;
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (textBoxPesquisarNome.Text == "")
            {
                string Membros = ("SELECT * FROM Membros ORDER BY nomeCompleto");
                SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                dataGridViewMembros.Rows.Clear();
                while (datareader.Read())
                {
                    dataGridViewMembros.Rows.Add(datareader[0].ToString(),
                                                datareader[1].ToString(),
                                                datareader[13].ToString(),
                                                datareader[14].ToString());
                }

                banco.desconectar();
                dataGridViewMembros.Refresh();
            }
            else
            {
                string Membros = ("SELECT * FROM Membros WHERE (nomeCompleto LIKE @nome + '%') ORDER BY nomeCompleto");
                SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                banco.conectar();

                exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisarNome.Text);

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                dataGridViewMembros.Rows.Clear();
                while (datareader.Read())
                {
                    dataGridViewMembros.Rows.Add(datareader[0].ToString(),
                                                datareader[1].ToString(),
                                                datareader[13].ToString(),
                                                datareader[14].ToString());
                }

                banco.desconectar();
                dataGridViewMembros.Refresh();
            }
        }

        private void textBoxPesquisarNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxPesquisarNome.Text == "")
            {
                string Membros = ("SELECT * FROM Membros ORDER BY nomeCompleto");
                SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                dataGridViewMembros.Rows.Clear();
                while (datareader.Read())
                {
                    dataGridViewMembros.Rows.Add(datareader[0].ToString(),
                                                datareader[1].ToString(),
                                                datareader[13].ToString(),
                                                datareader[14].ToString());
                }

                banco.desconectar();
                dataGridViewMembros.Refresh();
            }
            else
            {
                string Membros = ("SELECT * FROM Membros WHERE (nomeCompleto LIKE @nome + '%') ORDER BY nomeCompleto");
                SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                banco.conectar();

                exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisarNome.Text);

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                dataGridViewMembros.Rows.Clear();
                while (datareader.Read())
                {
                    dataGridViewMembros.Rows.Add(datareader[0].ToString(),
                                                datareader[1].ToString(),
                                                datareader[13].ToString(),
                                                datareader[14].ToString());
                }

                banco.desconectar();
                dataGridViewMembros.Refresh();
            }
        }

        #region Novo Cadastro

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            //Indica a uma variavel que a Açao realizada é a de Cadastro.
            // 1 = Cadastro
            tipoAcao = 1;

            limparValores();

            textBoxCadNomeCompleto.Focus();

            if (panelNovoCadastro.Visible != true)
            {
                panelConsultarPaciente.Visible = false;
                panelImportarLista.Visible = false;
                panelEditarCadastro.Visible = false;
                panelNovoCadastro.Visible = true;

                btnCadDadosPessoais_Click(sender, e);
                //
                textBoxCadMatricula.Text = gerarMatricula().ToString();

                //Torna os componentes de pesquisa inativos durante as alteracoes
                textBoxPesquisarNome.Enabled = false;
                btnPesquisar.Enabled = false;
                btnNovoCadastro.Enabled = false;
                btnImportarListaMembro.Enabled = false;
                btnEditarCadastro.Enabled = false;
                btnExcluirCadastro.Enabled = false;

                //
                requestComboBoxCargoFuncao();
                requestComboBoxSetorCongregacao();
            }
        }

        #region Abas Cadastro

        private void btnCadDadosPessoais_Click(object sender, EventArgs e)
        {
            //
            btnCadEndereco.BackColor = Color.FromArgb(23, 24, 27);
            panelCadEndereco.Visible = false;
            //
            btnCadDadosFamiliares.BackColor = Color.FromArgb(23, 24, 27);
            panelCadDadosFamiliar.Visible = false;
            //
            btnCadDadosPessoais.BackColor = Color.FromArgb(33, 34, 38);
            panelCadDadosPessoais.Visible = true;
        }

        private void btnCadEndereco_Click(object sender, EventArgs e)
        {
            btnCadDadosPessoais.BackColor = Color.FromArgb(23, 24, 27);
            panelCadDadosPessoais.Visible = false;
            //
            btnCadDadosFamiliares.BackColor = Color.FromArgb(23, 24, 27);
            panelCadDadosFamiliar.Visible = false;
            //
            btnCadEndereco.BackColor = Color.FromArgb(33, 34, 38);
            panelCadEndereco.Visible = true;
        }

        private void btnCadDadosFamiliares_Click(object sender, EventArgs e)
        {
            btnCadDadosPessoais.BackColor = Color.FromArgb(23, 24, 27);
            panelCadDadosPessoais.Visible = false;
            //
            btnCadEndereco.BackColor = Color.FromArgb(23, 24, 27);
            panelCadEndereco.Visible = false;
            //
            btnCadDadosFamiliares.BackColor = Color.FromArgb(33, 34, 38);
            panelCadDadosFamiliar.Visible = true;
        }

        #endregion

        private void combCadEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combCadEstadoCivil.Text == "OUTROS")
            {
                combCadEstadoCivil.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                combCadEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void linkLabelCadImportImg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Filter = "Choose Image(*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
            if (image.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCadImgProfile.ImageLocation = null;
                pictureBoxCadImgProfile.ImageLocation = image.FileName;

                linkLabelCadExcluirImagem.Visible = true;
            }
        }

        private void linkLabelCadExcluirImagem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBoxCadImgProfile.ImageLocation = null;
            linkLabelCadExcluirImagem.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            verificarComponentesNovoCadastro();

            if (liberado == true)
            {
                banco.desconectar();

                //Gera o Registro interno das acoes efetuadas no sistema 
                gerarLog();

                //chama a função para inserção no banco de dados.
                insertQuery();

                dadosRequestMembros();
                this.dataGridViewMembros.Refresh();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //limpa todos os valores
                limparValores();

                btnCadDadosPessoais_Click(sender, e);

                verificarQuantidadeMembros();
            }
            else
            {
                //Menssagem de alerta caso algum dos campos esja vazio
                MessageBox.Show("O Cadastro não pôde ser realizado." + "\n" + "Verifique se todos os campos foram preenchidos" + "\n" + "\n" + "e tente novamente!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();

            textBoxPesquisarNome.Focus();

            if (panelConsultarPaciente.Visible != true)
            {
                panelNovoCadastro.Visible = false;
                panelEditarCadastro.Visible = false;
                panelImportarLista.Visible = false;
                panelConsultarPaciente.Visible = true;

                //Torna os componentes de pesquisa inativos durante as alteracoes
                textBoxPesquisarNome.Enabled = true;
                btnPesquisar.Enabled = true;
                btnNovoCadastro.Enabled = true;
                btnImportarListaMembro.Enabled = true;
                btnEditarCadastro.Enabled = true;
                btnExcluirCadastro.Enabled = true;
            }

            this.frmMembros_Load(sender, e);
        }

        #endregion

        #region ImportarLista

        private void backgroundWorkerDeterminada_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int contGrid = cont;
            int contResult = 100 / contGrid;

            for (int i = 0; i < cont - 0; i++)
            {
                progress += contResult;

                //incrementa o progresso do backgroundWorker
                //a cada passagem do loop.
                this.backgroundWorkerDeterminada.ReportProgress(progress);

                //Verifica se houve uma requisição para cancelar a operação.
                if (backgroundWorkerDeterminada.CancellationPending)
                {
                    //se sim, define a propriedade Cancel para true
                    //para que o evento WorkerCompleted saiba que a tarefa foi cancelada.
                    e.Cancel = true;

                    //zera o percentual de progresso do backgroundWorker1.
                    backgroundWorkerDeterminada.ReportProgress(0);
                    return;
                }
            }

            //Finalmente, caso tudo esteja ok, finaliza
            //o progresso em 100%.
            backgroundWorkerDeterminada.ReportProgress(100);
        }

        private void backgroundWorkerDeterminada_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Incrementa o valor da progressbar com o valor
            //atual do progresso da tarefa.
            progressBarImagemAnexo.Value = e.ProgressPercentage;

            //informa o percentual na forma de texto.
            labelPorcentagem.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorkerDeterminada_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            }

            labelStatus.Visible = false;
            labelPorcentagem.Visible = false;
            progressBarImagemAnexo.Visible = false;
        }

        private void btnImportarListaMembro_Click(object sender, EventArgs e)
        {
            limparValores();

            if (panelImportarLista.Visible != true)
            {
                panelConsultarPaciente.Visible = false;
                panelEditarCadastro.Visible = false;
                panelNovoCadastro.Visible = false;
                panelImportarLista.Visible = true;

                btnCadDadosPessoais_Click(sender, e);

                //Torna os componentes de pesquisa inativos durante as alteracoes
                textBoxPesquisarNome.Enabled = false;
                btnPesquisar.Enabled = false;
                btnNovoCadastro.Enabled = false;
                btnImportarListaMembro.Enabled = false;
                btnEditarCadastro.Enabled = false;
                btnExcluirCadastro.Enabled = false;
            }
        }

        private string importarArquivo()
        {
            var retorno = string.Empty;

            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    retorno = dialog.FileName;
                }
            }
            return retorno;
        }

        private List<Membro> carregarCSV(string csvFile)
        {
            var query = from l in File.ReadAllLines(csvFile)
                        let data = l.Split(',')
                        select new Membro
                        {
                            NomeCompleto = string.Join("", data[1].Split('"')),
                            Nascimento = string.Join("", data[2].Split('"')),
                            Genero = string.Join("", data[3].Split('"')),
                            Endereco = string.Join("", data[4].Split('"')),
                            Telefone = string.Join("", data[5].Split('"')),
                            Pai = string.Join("", data[6].Split('"')),
                            Mae = string.Join("", data[7].Split('"')),
                            Nacionalidade = string.Join("", data[8].Split('"')),
                            Naturalidade = string.Join("", data[9].Split('"')),
                            EstadoCivil = string.Join("", data[10].Split('"')),
                            RG = string.Join("", data[11].Split('"')),
                            CPF = string.Join("", data[12].Split('"')),
                            FuncaoCargo = string.Join("", data[13].Split('"')),
                            SetorCongregacao = string.Join("", data[14].Split('"')),
                            BatismoAgua = string.Join("", data[15].Split('"')),
                            DataBatismoAguas = string.Join("", data[16].Split('"')),
                            BatismoEspirito = string.Join("", data[17].Split('"')),
                            CidadeResidencia = string.Join("", data[18].Split('"')),
                            SituacaoContribuicao = string.Join("", data[19].Split('"')),
                        };

            return query.ToList();
        }

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            var arquivo = importarArquivo();
            var data = carregarCSV(arquivo);


            progressBarImagemAnexo.Visible = true;
            progressBarImagemAnexo.Style = ProgressBarStyle.Blocks;
            progressBarImagemAnexo.Value = 0;

            labelStatus.Visible = true;
            labelPorcentagem.Visible = true;
            progressBarImagemAnexo.Visible = true;


            cont = data.Count;

            backgroundWorkerDeterminada.RunWorkerAsync();

            for (int i = 1; i < data.Count - 0; i++)
            {
                string CPF, RG;

                dataGridViewImportarLista.Rows.Add(
                    data[i].NomeCompleto,
                    DateTime.Parse(data[i].Nascimento).ToShortDateString(),
                    data[i].Genero,
                    data[i].Endereco,
                    data[i].Telefone,
                    data[i].Pai,
                    data[i].Mae,
                    data[i].Nacionalidade,
                    data[i].Naturalidade,
                    data[i].EstadoCivil,
                    RG = data[i].RG.Replace(".", "").Replace(",", "").Replace("-", ""),
                    CPF = data[i].CPF.Replace(".", "").Replace(",", "").Replace("-", ""),
                    data[i].FuncaoCargo,
                    data[i].SetorCongregacao,
                    data[i].BatismoAgua,
                    DateTime.Parse(data[i].DataBatismoAguas).ToShortDateString(),
                    data[i].BatismoEspirito,
                    data[i].CidadeResidencia,
                    data[i].SituacaoContribuicao);
            }
        }

        private void btnImportarSalvar_Click(object sender, EventArgs e)
        {
            int novosMembrosCont = 0, totalRegistros = 0, totalJaCadastrados = 0;

            for (int i = 0; i < dataGridViewImportarLista.Rows.Count - 0; i++)
            {
                totalRegistros += 1;


                string VerificarMembro = ("SELECT * FROM Membros WHERE RG = @RG OR CPF = @CPF OR nomeCompleto = @nome");
                SqlCommand exeVerificacao = new SqlCommand(VerificarMembro, banco.connection);
                banco.conectar();

                exeVerificacao.Parameters.Clear();
                exeVerificacao.Parameters.AddWithValue("@RG", dataGridViewImportarLista.Rows[i].Cells[10].Value.ToString());
                exeVerificacao.Parameters.AddWithValue("@CPF", dataGridViewImportarLista.Rows[i].Cells[11].Value.ToString());
                exeVerificacao.Parameters.AddWithValue("@nome", dataGridViewImportarLista.Rows[i].Cells[0].Value.ToString());

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                if (datareader.Read())  
                {
                    dataGridViewImportarLista.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                    dataGridViewImportarLista.Refresh();
                    

                    totalJaCadastrados += 1;
                }
                else
                {
                    dataGridViewImportarLista.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    dataGridViewImportarLista.Refresh();

                    //Conta quantos novos membro foram cadastrados
                    novosMembrosCont += 1;
                }
                banco.desconectar();
            }

            //Gera o Registro interno das acoes efetuadas no sistema 
            gerarLog();

            insertQueryList();

            dataGridViewImportarLista.Rows.Clear();

            dadosRequestMembros();
            this.dataGridViewMembros.Refresh();

            MessageBox.Show("Importação realizada com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //limpa todos os valores
            limparValores();

            verificarQuantidadeMembros();

            MessageBox.Show("TOTAL DE REGISTROS IMPORTADOS: " + totalRegistros + "\n" + "TOTAL DE MEMBROS JÁ CADASTRADOS: " + totalJaCadastrados + "\n " + "\n" + "TOTAL DE NOVOS MEMBROS: " + novosMembrosCont, "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVoltarImportar_Click(object sender, EventArgs e)
        {
            limparValores();

            if (panelConsultarPaciente.Visible != true)
            {
                panelNovoCadastro.Visible = false;
                panelEditarCadastro.Visible = false;
                panelImportarLista.Visible = false;
                panelConsultarPaciente.Visible = true;

                //Torna os componentes de pesquisa inativos durante as alteracoes
                textBoxPesquisarNome.Enabled = true;
                btnPesquisar.Enabled = true;
                btnNovoCadastro.Enabled = true;
                btnImportarListaMembro.Enabled = true;
                btnEditarCadastro.Enabled = true;
                btnExcluirCadastro.Enabled = true;

                this.frmMembros_Load(sender, e);
            }
        }

        #endregion

        #region Editar Cadastro

        private void btnEditarCadastro_Click(object sender, EventArgs e)
        {
            //Indica a uma variavel que a Açao realizada é a de Cadastro.
            // 1 = Cadastro
            tipoAcao = 2;

            if (dataGridViewMembros.Rows.Count != 0)
            {
                int ID = 0;

                ID = int.Parse(dataGridViewMembros.CurrentRow.Cells[0].Value.ToString());

                limparValores();

                //
                requestComboBoxCargoFuncao();
                requestComboBoxSetorCongregacao();

                dadosRequestMembrosEditar();

                textBoxUpdNomeCompleto.Focus();

                if (panelEditarCadastro.Visible != true)
                {
                    panelConsultarPaciente.Visible = false;
                    panelImportarLista.Visible = false;
                    panelNovoCadastro.Visible = false;
                    panelEditarCadastro.Visible = true;

                    btnUpdDadosPessoais_Click(sender, e);

                    //Torna os componentes de pesquisa inativos durante as alteracoes
                    textBoxPesquisarNome.Enabled = false;
                    btnPesquisar.Enabled = false;
                    btnNovoCadastro.Enabled = false;
                    btnImportarListaMembro.Enabled = false;
                    btnEditarCadastro.Enabled = false;
                    btnExcluirCadastro.Enabled = false;
                }

                banco.desconectar();
            }
            else
            {
                //Menssagem de alerta, caso ocorra algum erro inesperado
                MessageBox.Show("Não existe Paciente Cadastrado.", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Abas Editar Cadastro

        private void btnUpdDadosPessoais_Click(object sender, EventArgs e)
        {
            btnUpdEndereco.BackColor = Color.FromArgb(23, 24, 27);
            panelUpdEndereco.Visible = false;
            //
            btnUpdDadosFamiliares.BackColor = Color.FromArgb(23, 24, 27);
            panelUpdDadosFamiliares.Visible = false;
            //
            btnUpdDadosPessoais.BackColor = Color.FromArgb(33, 34, 38);
            panelUpdDadosPessoais.Visible = true;
        }

        private void btnUpdEndereco_Click(object sender, EventArgs e)
        {
            btnUpdDadosPessoais.BackColor = Color.FromArgb(23, 24, 27);
            panelUpdDadosPessoais.Visible = false;
            //
            btnUpdDadosFamiliares.BackColor = Color.FromArgb(23, 24, 27);
            panelUpdDadosFamiliares.Visible = false;
            //
            btnUpdEndereco.BackColor = Color.FromArgb(33, 34, 38);
            panelUpdEndereco.Visible = true;
        }

        private void btnUpdDadosFamiliares_Click(object sender, EventArgs e)
        {
            btnUpdDadosPessoais.BackColor = Color.FromArgb(23, 24, 27);
            panelUpdDadosPessoais.Visible = false;
            //
            btnUpdEndereco.BackColor = Color.FromArgb(23, 24, 27);
            panelUpdEndereco.Visible = false;
            //
            btnUpdDadosFamiliares.BackColor = Color.FromArgb(33, 34, 38);
            panelUpdDadosFamiliares.Visible = true;
        }

        #endregion

        private void combUpdEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combUpdEstadoCivil.Text == "OUTROS")
            {
                combUpdEstadoCivil.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                combUpdEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void linkLabelUpdImportImg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Filter = "Choose Image(*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
            if (image.ShowDialog() == DialogResult.OK)
            {
                pictureBoxUpdImgProfile.ImageLocation = null;
                pictureBoxUpdImgProfile.ImageLocation = image.FileName;

                linkLabelUpdExcluirImagem.Visible = true;
            }
        }

        private void linkLabelUpdExcluirImagem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBoxUpdImgProfile.Image = null;
            linkLabelUpdExcluirImagem.Visible = false;
        }

        private void btnSavalEditar_Click(object sender, EventArgs e)
        {
            verificarComponentesEditarCadastro();

            if (liberado == true)
            {
                banco.desconectar();

                //Gera o Registro interno das acoes efetuadas no sistema 
                gerarLog();

                //chama a função para inserção no banco de dados.
                updateQuery();

                dadosRequestMembros();
                this.dataGridViewMembros.Refresh();

                MessageBox.Show("Alteração realizada com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnUpdDadosPessoais_Click(sender, e);
            }
            else
            {
                //Menssagem de alerta caso algum dos campos esja vazio
                MessageBox.Show("A Alteração não pôde ser realizada." + "\n" + "Verifique se todos os campos foram preenchidos" + "\n" + "\n" + "e tente novamente!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSairEditar_Click(object sender, EventArgs e)
        {
            if (UpdateMembro._retornarWindow() == 2)
            {
                UpdateMembro.receberWindow(0, false, 0);
                //
                this.Close();
            }
            else
            {
                if (panelConsultarPaciente.Visible != true)
                {
                    panelNovoCadastro.Visible = false;
                    panelEditarCadastro.Visible = false;
                    panelImportarLista.Visible = false;
                    panelConsultarPaciente.Visible = true;

                    //Torna os componentes de pesquisa inativos durante as alteracoes
                    textBoxPesquisarNome.Enabled = true;
                    btnPesquisar.Enabled = true;
                    btnNovoCadastro.Enabled = true;
                    btnImportarListaMembro.Enabled = true;
                    btnEditarCadastro.Enabled = true;
                    btnExcluirCadastro.Enabled = true;

                    this.frmMembros_Load(sender, e);

                }
            }
        }

        #endregion

        private void btnExcluirCadastro_Click(object sender, EventArgs e)
        {
            if (panelConsultarPaciente.Visible != true)
            {
                panelNovoCadastro.Visible = false;
                panelEditarCadastro.Visible = false;
                panelImportarLista.Visible = false;
                panelConsultarPaciente.Visible = true;

                MessageBox.Show("Selecione o Membro que deseja Excluir!", "Aviso de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dataGridViewMembros.Rows.Count != 0)
                {
                    banco.desconectar();

                    //Limpa os valores inseridos.
                    limparValores();

                    dataGridViewMembros.Focus();

                    //Verificação dos campos exigidos e senhas para proceguir com a inserção; 
                    if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Aviso de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //Gera o Registro interno das acoes efetuadas no sistema 
                        gerarLog();

                        //chama a função para delete na tabela.
                        deleteQuery();

                        //limpa todos os valores
                        limparValores();

                        dadosRequestMembros();
                        this.dataGridViewMembros.Refresh();

                        MessageBox.Show("Membro Excluido com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        verificarQuantidadeMembros();
                    }
                }
                else
                {
                    //Menssagem de alerta, caso ocorra algum erro inesperado
                    MessageBox.Show("Não existe Membro Cadastrado.", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void dataGridViewMembros_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditarCadastro_Click(sender, e);
        }

        private void comboBoxFiltrarSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxFiltrarSituacao.Text == "TODOS")
            {
                dadosRequestMembros();
            }

            if (comboBoxFiltrarSituacao.Text == "ATIVO")
            {
                string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.status = 'ATIVO' ORDER BY nomeCompleto");
                SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                dataGridViewMembros.Rows.Clear();
                while (datareader.Read())
                {
                    dataGridViewMembros.Rows.Add(datareader[0].ToString(),
                                                datareader[1].ToString(),
                                                datareader[23].ToString(),
                                                datareader[13].ToString(),
                                                datareader[14].ToString());
                }

                banco.desconectar();
                dataGridViewMembros.Refresh();
            }

            if (comboBoxFiltrarSituacao.Text == "PENDENTE")
            {
                string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.status = 'PENDENTE' ORDER BY nomeCompleto");
                SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                dataGridViewMembros.Rows.Clear();
                while (datareader.Read())
                {
                    dataGridViewMembros.Rows.Add(datareader[0].ToString(),
                                                datareader[1].ToString(),
                                                datareader[23].ToString(),
                                                datareader[13].ToString(),
                                                datareader[14].ToString());
                }

                banco.desconectar();
                dataGridViewMembros.Refresh();
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

        private void panelConsultarPaciente_Paint(object sender, PaintEventArgs e)
        {
            panelConsultarPaciente.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelConsultarPaciente.Width,
            panelConsultarPaciente.Height, 7, 7));
        }

        private void panelCadTitulo_Paint(object sender, PaintEventArgs e)
        {
            panelCadTitulo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelCadTitulo.Width,
            panelCadTitulo.Height, 5, 5));
        }

        private void panelCadDadosPessoais_Paint(object sender, PaintEventArgs e)
        {
            panelCadDadosPessoais.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelCadDadosPessoais.Width,
            panelCadDadosPessoais.Height, 7, 7));
        }

        private void panelCadOpcoes_Paint(object sender, PaintEventArgs e)
        {
            panelCadOpcoes.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelCadOpcoes.Width,
            panelCadOpcoes.Height, 7, 7));
        }

        private void panelCadEndereco_Paint(object sender, PaintEventArgs e)
        {
            panelCadEndereco.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelCadEndereco.Width,
            panelCadEndereco.Height, 7, 7));
        }

        private void panelCadDadosFamiliar_Paint(object sender, PaintEventArgs e)
        {
            panelCadDadosFamiliar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelCadDadosFamiliar.Width,
            panelCadDadosFamiliar.Height, 7, 7));
        }

        private void panelUpdTitulo_Paint(object sender, PaintEventArgs e)
        {
            panelUpdTitulo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelUpdTitulo.Width,
            panelUpdTitulo.Height, 5, 5));
        }

        private void panelUpdDadosPessoais_Paint(object sender, PaintEventArgs e)
        {
            panelUpdDadosPessoais.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelUpdDadosPessoais.Width,
            panelUpdDadosPessoais.Height, 7, 7));
        }

        private void panelUpdOpcoes_Paint(object sender, PaintEventArgs e)
        {
            panelUpdOpcoes.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelUpdOpcoes.Width,
            panelUpdOpcoes.Height, 7, 7));
        }

        

        private void panelUpdEndereco_Paint(object sender, PaintEventArgs e)
        {
            panelUpdEndereco.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelUpdEndereco.Width,
            panelUpdEndereco.Height, 7, 7));
        }

        private void panelUpdDadosFamiliares_Paint(object sender, PaintEventArgs e)
        {
            panelUpdDadosFamiliares.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelUpdDadosFamiliares.Width,
            panelUpdDadosFamiliares.Height, 7, 7));
        }

        #endregion
        
    }
}
