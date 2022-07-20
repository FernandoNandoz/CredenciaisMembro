using CarteirinhaMembro.Properties;
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
    public partial class frmCredenciais : Form
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

        int contadorMembros = 0, tipoAcao = 0;

        public frmCredenciais()
        {
            InitializeComponent();
        }

        private void frmImpressoes_Load(object sender, EventArgs e)
        {
            RequestGerarCredencialSelecionados();
            updStatusCarteira();
            gerarDataHeaders();
        }

        private void requestComboBoxCargoFuncao()
        {
            string Membros = ("SELECT * FROM CargoFuncao ORDER BY cargoFuncao ASC");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            comboBoxCargo.Items.Clear();
            comboBoxCargo.Items.Insert(0, "TODOS");

            while (datareader.Read())
            {
                comboBoxCargo.Items.Add(datareader[1].ToString());
            }
            banco.desconectar();
        }

        private void requestComboBoxSetorCongregacao()
        {
            string Membros = ("SELECT * FROM CongregacaoSetor ORDER BY CongregacaoSetor ASC");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            comboBoxSetorCongregacao.Items.Clear();
            comboBoxSetorCongregacao.Items.Insert(0, "TODOS");

            while (datareader.Read())
            {
                comboBoxSetorCongregacao.Items.Add(datareader[1].ToString());
            }
            banco.desconectar();
        }

        //Membros Gerar Novos Membros
        private void RequestGerarCredencialPesquisa()
        {
            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO'");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewVizualizacaoPesquisa.Rows.Clear();
            while (datareader.Read())
            {
                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                datareader[22].ToString(),
                                                datareader[1].ToString(),
                                                datareader[13].ToString(),
                                                datareader[14].ToString(),
                                                Resources.icons8_group_layouts_25px,
                                                datareader[30].ToString());
            }
            banco.desconectar();

            dataGridViewVizualizacaoPesquisa.Refresh();
        }

        private void RequestGerarCredencialSelecionados()
        {
            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'EM ANDAMENTO'");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewVizualizacaoMembros.Rows.Clear();
            while (datareader.Read())
            {
                dataGridViewVizualizacaoMembros.Rows.Add(datareader[0].ToString(),
                                                datareader[1].ToString(),
                                                datareader[13].ToString(),
                                                datareader[14].ToString(),
                                                Resources.icons8_vision_25px,
                                                Resources.icons8_Remove_25px_1,
                                                datareader[30].ToString());
            }

            banco.desconectar();
            dataGridViewVizualizacaoMembros.Refresh();
        }

        //Membros Reemprimir Membros
        private void RequestReemprimirCredencialPesquisa()
        {
            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO'");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewVizualizacaoPesquisa.Rows.Clear();
            while (datareader.Read())
            {
                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                datareader[22].ToString(),
                                                datareader[1].ToString(),
                                                datareader[13].ToString(),
                                                datareader[14].ToString(),
                                                Resources.icons8_group_layouts_25px,
                                                datareader[30].ToString());

            }
            banco.desconectar();

            dataGridViewVizualizacaoPesquisa.Refresh();
        }

        private void RequestReemprimirCredencialSelecionados()
        {
            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EM ANDAMENTO'");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewVizualizacaoMembros.Rows.Clear();
            while (datareader.Read())
            {
                dataGridViewVizualizacaoMembros.Rows.Add(datareader[0].ToString(),
                                                datareader[1].ToString(),
                                                datareader[13].ToString(),
                                                datareader[14].ToString(),
                                                Resources.icons8_vision_25px,
                                                Resources.icons8_Remove_25px_1,
                                                datareader[30].ToString());
            }

            banco.desconectar();
            dataGridViewVizualizacaoMembros.Refresh();
        }

        private void StatusImpressao()
        {
            for (int i = 0; i < dataGridViewVizualizacaoMembros.Rows.Count - 0; i++)
            {
                string MembrosUpd = ("UPDATE CredencialMembro SET statusEmissao = @status WHERE idMembroFK = @ID");
                SqlCommand command = new SqlCommand(MembrosUpd, banco.connection);

                command.Parameters.Clear();
                command.Parameters.AddWithValue("@status", "IMPRIMINDO");
                command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.Rows[i].Cells[0].Value);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();
            }
        }

        private void updStatusCarteira()
        {
            for (int i = 0; i < dataGridViewVizualizacaoMembros.Rows.Count - 0; i++)
            {
                string MembrosUpd = ("UPDATE CredencialMembro SET statusEmissao = @status WHERE idMembroFK = @ID");
                SqlCommand command = new SqlCommand(MembrosUpd, banco.connection);

                int via = int.Parse(dataGridViewVizualizacaoMembros.Rows[i].Cells[6].Value.ToString());

                if(via == 0)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@status", "A EMITIR");
                    command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.Rows[i].Cells[0].Value);
                }
                else
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@status", "EMITIDO");
                    command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.Rows[i].Cells[0].Value);
                }

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();
            }

            if(tipoAcao == 1)
            {
                RequestGerarCredencialPesquisa();
                RequestGerarCredencialSelecionados();
                dataGridViewVizualizacaoMembros.Refresh();
                dataGridViewVizualizacaoPesquisa.Refresh();
            }

            if(tipoAcao == 2)
            {
                RequestReemprimirCredencialPesquisa();
                RequestReemprimirCredencialSelecionados();
                dataGridViewVizualizacaoMembros.Refresh();
                dataGridViewVizualizacaoPesquisa.Refresh();
            }
            
        }

        private void gerarDataHeaders()
        {
            int QntMembros = 0, QntFolhasImpressas = 1, valueResultMenos = 0;

            QntMembros = dataGridViewVizualizacaoMembros.Rows.Count;
        
            //if (QntMembros > 10)
            //{
            //    QntFolhasImpressasPapelFilme = (QntMembros / 10) * 2;   
            //}
            //else
            //{
            //    if (QntMembros != 0)
            //    {
            //        QntFolhasImpressasPapelFilme = 2;
            //    }
            //}

            if (QntMembros > 10)
            {
                valueResultMenos = QntMembros - 10;

                QntFolhasImpressas += 1;

                if (valueResultMenos >= 10)
                {
                    QntFolhasImpressas += 1;
                }
                              
            }
            else
            {
                if (QntMembros != 0)
                {
                    QntFolhasImpressas = 1;
                }
                else
                {
                    QntFolhasImpressas = 0;
                }
            }

            labelValueTotalMembrosSelecionados.Text = QntMembros.ToString();
            labelValueQntFolhasImpressaoFrente.Text = QntFolhasImpressas.ToString();
            labelValueQntFolhasImpressaoVerso.Text = QntFolhasImpressas.ToString();
            labelValueQntFolhasImpressaoPVC.Text = QntFolhasImpressas.ToString();
            //
            labelValueQntFolhaAuto.Text = QntFolhasImpressas.ToString();
        }

        private void DesenharCredencialFrente()
        {
            string membro = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE Membros.idMembro = @ID AND CredencialMembro.status = 'ATIVO'");
            SqlCommand exeData = new SqlCommand(membro, banco.connection);

            exeData.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.CurrentRow.Cells[0].Value);

            banco.conectar();
            SqlDataReader datareader = exeData.ExecuteReader();

            while (datareader.Read())
            {
                Image image1 = pictureBoxFrente.Image;
                Graphics credencial = Graphics.FromImage(image1);

                //Nome Completo

                string StringNome = datareader[1].ToString();
                // fonte e cor
                Font Font_NomeCompleto = new Font("Calibri", 10, FontStyle.Bold);
                SolidBrush Cor_NomeCompleto = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_NomeCompleto = 53.0F;
                float y_NomeCompleto = 275.0F;
                // esxrever na imagem
                credencial.DrawString(
                    StringNome.ToUpper(),
                    Font_NomeCompleto,
                    Cor_NomeCompleto,
                    x_NomeCompleto,
                    y_NomeCompleto
                );

                //Matricula

                string StringMatricula = datareader[22].ToString();
                // fonte e cor
                Font Font_Matricula = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_Matricula = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_Matricula = 57.0F;
                float y_Matricula = 425.0F;
                // esxrever na imagem
                credencial.DrawString(
                    StringMatricula.ToUpper(),
                    Font_Matricula,
                    Cor_Matricula,
                    x_Matricula,
                    y_Matricula
                );

                //RG

                // fonte e cor
                Font Font_RG = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_RG = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_RG = 57.0F;
                float y_RG = 520.0F;
                // esxrever na imagem
                credencial.DrawString(
                    datareader[11].ToString(),
                    Font_RG,
                    Cor_RG,
                    x_RG,
                    y_RG
                );


                //CPF

                // fonte e cor
                Font Font_CPF = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_CPF = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_CPF = 250.0F;
                float y_CPF = 520.0F;
                // esxrever na imagem
                credencial.DrawString(
                    String.Format(@"{0:000\.000\.000\-00}", Convert.ToInt64(datareader[12].ToString())),
                    Font_CPF,
                    Cor_CPF,
                    x_CPF,
                    y_CPF
                );


                //CARGO/FUNCAO

                string StringCargoFuncao = datareader[13].ToString();
                // fonte e cor
                Font Font_CargoFuncao = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_CargoFuncao = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_CargoFuncao = 495.0F;
                float y_CargoFuncao = 520.0F;
                // esxrever na imagem
                credencial.DrawString(
                    StringCargoFuncao.ToUpper(),
                    Font_CargoFuncao,
                    Cor_CargoFuncao,
                    x_CargoFuncao,
                    y_CargoFuncao
                );


                //FOTO PERFIL
                if (datareader[17].ToString() == "")
                {
                    if (datareader[3].ToString() == "MASCULINO" || datareader[3].ToString() == "Masculino")
                    {
                        // fonte e cor
                        float x_Foto = 775.0F;
                        float y_Foto = 365.0F;
                        // esxrever na imagem
                        credencial.DrawImage(Resources.icons8_user_126px, x_Foto, y_Foto, 173, 205);
                    }

                    if (datareader[3].ToString() == "FEMININO" || datareader[3].ToString() == "Feminino")
                    {
                        // fonte e cor
                        float x_Foto = 775.0F;
                        float y_Foto = 365.0F;
                        // esxrever na imagem
                        credencial.DrawImage(Resources.icons8_businesswoman_126px, x_Foto, y_Foto, 173, 205);
                    }
                }
                else
                {
                    using (var stream = new System.IO.MemoryStream((byte[])datareader[17]))
                    {
                        // fonte e cor
                        float x_Foto = 775.0F;
                        float y_Foto = 365.0F;
                        // esxrever na imagem
                        credencial.DrawImage(Bitmap.FromStream(stream), x_Foto, y_Foto, 173, 205);
                    }
                }

                // salvar como PNG
                pictureBoxFrente.Image = image1;

            }

            banco.desconectar();
        }

        private void DesenharCredencialVerso()
        {
            string membro = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE Membros.idMembro = @ID AND CredencialMembro.status = 'ATIVO'");
            SqlCommand exeData = new SqlCommand(membro, banco.connection);

            exeData.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.CurrentRow.Cells[0].Value);

            banco.conectar();
            SqlDataReader datareader = exeData.ExecuteReader();

            while (datareader.Read())
            {
                Image image1 = pictureBoxVerso.Image;
                Graphics credencial = Graphics.FromImage(image1);

                //Pai

                string StringPai = datareader[6].ToString();
                // fonte e cor
                Font Font_Pai = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_Pai = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_Pai = 47.0F;
                float y_Pai = 127.0F;
                // esxrever na imagem
                credencial.DrawString(
                    StringPai.ToUpper(),
                    Font_Pai,
                    Cor_Pai,
                    x_Pai,
                    y_Pai
                );

                //Mae

                string StringMae = datareader[7].ToString();
                // fonte e cor
                Font Font_Mae = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_Mae = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_Mae = 47.0F;
                float y_Mae = 202.0F;
                // esxrever na imagem
                credencial.DrawString(
                    StringMae.ToUpper(),
                    Font_Mae,
                    Cor_Mae,
                    x_Mae,
                    y_Mae
                );

                //Nascimento

                // fonte e cor
                Font Font_Nascimento = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_Nascimento = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_Nascimento = 47.0F;
                float y_Nascimento = 288.0F;
                // esxrever na imagem
                credencial.DrawString(
                    DateTime.Parse(datareader[2].ToString()).ToShortDateString(),
                    Font_Nascimento,
                    Cor_Nascimento,
                    x_Nascimento,
                    y_Nascimento
                );


                //Estado Civil

                string StringEstadoCivil = datareader[10].ToString();
                // fonte e cor
                Font Font_EstadoCivil = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_EstadoCivil = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_EstadoCivil = 384.0F;
                float y_EstadoCivil = 288.0F;
                // esxrever na imagem
                credencial.DrawString(
                    StringEstadoCivil.ToUpper(),
                    Font_EstadoCivil,
                    Cor_EstadoCivil,
                    x_EstadoCivil,
                    y_EstadoCivil
                );


                //Naturalidade

                string StringNaturalidade = datareader[9].ToString();
                // fonte e cor
                Font Font_Naturalidade = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_Naturalidade = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_Naturalidade = 675.0F;
                float y_Naturalidade = 288.0F;
                // esxrever na imagem
                credencial.DrawString(
                    StringNaturalidade.ToUpper(),
                    Font_Naturalidade,
                    Cor_Naturalidade,
                    x_Naturalidade,
                    y_Naturalidade
                );


                //Data Batismo

                // fonte e cor
                Font Font_DataBatismo = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_DataBatismo = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_DataBatismo = 47.0F;
                float y_DataBatismo = 375.0F;
                // esxrever na imagem
                credencial.DrawString(
                    DateTime.Parse(datareader[19].ToString()).ToShortDateString(),
                    Font_DataBatismo,
                    Cor_DataBatismo,
                    x_DataBatismo,
                    y_DataBatismo
                );


                //Data de Emissao

                // fonte e cor
                Font Font_Emissao = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_Emissao = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_Emissao = 384.0F;
                float y_Emissao = 375.0F;
                // esxrever na imagem
                credencial.DrawString(
                    DateTime.Now.ToShortDateString(),
                    Font_Emissao,
                    Cor_Emissao,
                    x_Emissao,
                    y_Emissao
                );


                //Cidade Residencia

                string StringResidencia = datareader[20].ToString();
                // fonte e cor
                Font Font_Residencia = new Font("Calibri", 8, FontStyle.Bold);
                SolidBrush Cor_Residencia = new SolidBrush(Color.White);
                // onde escrever na imagem
                float x_Residencia = 675.0F;
                float y_Residencia = 375.0F;
                // esxrever na imagem
                credencial.DrawString(
                    StringResidencia.ToUpper(),
                    Font_Residencia,
                    Cor_Residencia,
                    x_Residencia,
                    y_Residencia
                );


                // salvar como PNG
                pictureBoxVerso.Image = image1;      
            }

            banco.desconectar();
        }

        private void gerarCredencialFrente()
        {
            for (int i = 0; i < dataGridViewVizualizacaoMembros.Rows.Count - 0; i++)
            {
                pictureBoxFrente.Image = Resources.Credencial___Frente___sistema;

                string membro = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE Membros.idMembro = @ID AND CredencialMembro.status = 'ATIVO'");
                SqlCommand exeData = new SqlCommand(membro, banco.connection);

                exeData.Parameters.Clear();
                exeData.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.Rows[i].Cells[0].Value);

                banco.conectar();
                SqlDataReader datareader = exeData.ExecuteReader();

                while (datareader.Read())
                {
                    Image image1 = pictureBoxFrente.Image;
                    Graphics credencial = Graphics.FromImage(image1);

                    //Nome Completo

                    string StringNome = datareader[1].ToString();
                    // fonte e cor
                    Font Font_NomeCompleto = new Font("Calibri", 10, FontStyle.Bold);
                    SolidBrush Cor_NomeCompleto = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_NomeCompleto = 53.0F;
                    float y_NomeCompleto = 275.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        StringNome.ToUpper(),
                        Font_NomeCompleto,
                        Cor_NomeCompleto,
                        x_NomeCompleto,
                        y_NomeCompleto
                    );

                    //Matricula

                    string StringMatricula = datareader[22].ToString();
                    // fonte e cor
                    Font Font_Matricula = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_Matricula = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_Matricula = 57.0F;
                    float y_Matricula = 425.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        StringMatricula.ToUpper(),
                        Font_Matricula,
                        Cor_Matricula,
                        x_Matricula,
                        y_Matricula
                    );

                    //RG

                    // fonte e cor
                    Font Font_RG = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_RG = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_RG = 57.0F;
                    float y_RG = 520.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        datareader[11].ToString(),
                        Font_RG,
                        Cor_RG,
                        x_RG,
                        y_RG
                    );


                    //CPF

                    // fonte e cor
                    Font Font_CPF = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_CPF = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_CPF = 250.0F;
                    float y_CPF = 520.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        String.Format(@"{0:000\.000\.000\-00}", Convert.ToInt64(datareader[12].ToString())),
                        Font_CPF,
                        Cor_CPF,
                        x_CPF,
                        y_CPF
                    );


                    //CARGO/FUNCAO

                    string StringCargoFuncao = datareader[13].ToString();
                    // fonte e cor
                    Font Font_CargoFuncao = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_CargoFuncao = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_CargoFuncao = 495.0F;
                    float y_CargoFuncao = 520.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        StringCargoFuncao.ToUpper(),
                        Font_CargoFuncao,
                        Cor_CargoFuncao,
                        x_CargoFuncao,
                        y_CargoFuncao
                    );


                    //FOTO PERFIL
                    if (datareader[17].ToString() == "")
                    {
                        if (datareader[3].ToString() == "MASCULINO" || datareader[3].ToString() == "Masculino")
                        {
                            // fonte e cor
                            float x_Foto = 775.0F;
                            float y_Foto = 365.0F;
                            // esxrever na imagem
                            credencial.DrawImage(Resources.icons8_user_126px, x_Foto, y_Foto, 173, 205);
                        }

                        if (datareader[3].ToString() == "FEMININO" || datareader[3].ToString() == "Feminino")
                        {
                            // fonte e cor
                            float x_Foto = 775.0F;
                            float y_Foto = 365.0F;
                            // esxrever na imagem
                            credencial.DrawImage(Resources.icons8_businesswoman_126px, x_Foto, y_Foto, 173, 205);
                        }
                    }
                    else
                    {
                        using (var stream = new System.IO.MemoryStream((byte[])datareader[17]))
                        {
                            // fonte e cor
                            float x_Foto = 775.0F;
                            float y_Foto = 365.0F;
                            // esxrever na imagem
                            credencial.DrawImage(Bitmap.FromStream(stream), x_Foto, y_Foto, 173, 205);
                        }
                    }

                    // salvar como PNG
                    pictureBoxFrente.Image = image1;
                    
                }
                banco.desconectar();

                //Convert a nova imagem em Byte
                using (var stream = new System.IO.MemoryStream())
                {
                    string MembrosUpd = ("UPDATE CredencialMembro SET credencialFrenteImage = @imageFrente, dataEmissao = @data, via = @via, statusEmissao = @statusEmissao WHERE idMembroFK = @ID");
                    SqlCommand command = new SqlCommand(MembrosUpd, banco.connection);

                    //
                    int Via = 0; Convert.ToInt16(dataGridViewVizualizacaoMembros.Rows[i].Cells[6].Value);

                    //
                    Via = Convert.ToInt16(dataGridViewVizualizacaoMembros.Rows[i].Cells[6].Value);
                    Via += 1;

                    pictureBoxFrente.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

                    //
                    pictureBoxFrente.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                    //
                    stream.Seek(0, System.IO.SeekOrigin.Begin);
                    byte[] byteArray = new byte[stream.Length];
                    stream.Read(byteArray, 0, System.Convert.ToInt32(stream.Length));

                    //
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@imageFrente", byteArray);
                    command.Parameters.AddWithValue("@data", DateTime.Now);
                    command.Parameters.AddWithValue("@statusEmissao", "EMITIDO");
                    command.Parameters.AddWithValue("@via", Via);
                    command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.Rows[i].Cells[0].Value);

                    banco.conectar();
                    command.ExecuteNonQuery();
                    banco.desconectar();
                }
            }
        }

        private void gerarCredencialVerso()
        {
            for (int i = 0; i < dataGridViewVizualizacaoMembros.Rows.Count - 0; i++)
            {
                pictureBoxVerso.Image = Resources.Credencial___Costa___sistema;

                string membro = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE Membros.idMembro = @ID AND CredencialMembro.status = 'ATIVO'");
                SqlCommand exeData = new SqlCommand(membro, banco.connection);

                exeData.Parameters.Clear();
                exeData.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.Rows[i].Cells[0].Value);

                banco.conectar();
                SqlDataReader datareader = exeData.ExecuteReader();

                while (datareader.Read())
                {
                    Image image1 = pictureBoxVerso.Image;
                    Graphics credencial = Graphics.FromImage(image1);

                    //Pai

                    string StringPai = datareader[6].ToString();
                    // fonte e cor
                    Font Font_Pai = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_Pai = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_Pai = 47.0F;
                    float y_Pai = 127.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        StringPai.ToUpper(),
                        Font_Pai,
                        Cor_Pai,
                        x_Pai,
                        y_Pai
                    );

                    //Mae

                    string StringMae = datareader[7].ToString();
                    // fonte e cor
                    Font Font_Mae = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_Mae = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_Mae = 47.0F;
                    float y_Mae = 202.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        StringMae.ToUpper(),
                        Font_Mae,
                        Cor_Mae,
                        x_Mae,
                        y_Mae
                    );

                    //Nascimento

                    // fonte e cor
                    Font Font_Nascimento = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_Nascimento = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_Nascimento = 47.0F;
                    float y_Nascimento = 288.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        DateTime.Parse(datareader[2].ToString()).ToShortDateString(),
                        Font_Nascimento,
                        Cor_Nascimento,
                        x_Nascimento,
                        y_Nascimento
                    );


                    //Estado Civil

                    string StringEstadoCivil = datareader[10].ToString();
                    // fonte e cor
                    Font Font_EstadoCivil = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_EstadoCivil = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_EstadoCivil = 384.0F;
                    float y_EstadoCivil = 288.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        StringEstadoCivil.ToUpper(),
                        Font_EstadoCivil,
                        Cor_EstadoCivil,
                        x_EstadoCivil,
                        y_EstadoCivil
                    );


                    //Naturalidade

                    string StringNaturalidade = datareader[9].ToString();
                    // fonte e cor
                    Font Font_Naturalidade = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_Naturalidade = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_Naturalidade = 675.0F;
                    float y_Naturalidade = 288.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        StringNaturalidade.ToUpper(),
                        Font_Naturalidade,
                        Cor_Naturalidade,
                        x_Naturalidade,
                        y_Naturalidade
                    );


                    //Data Batismo

                    // fonte e cor
                    Font Font_DataBatismo = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_DataBatismo = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_DataBatismo = 47.0F;
                    float y_DataBatismo = 375.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        DateTime.Parse(datareader[19].ToString()).ToShortDateString(),
                        Font_DataBatismo,
                        Cor_DataBatismo,
                        x_DataBatismo,
                        y_DataBatismo
                    );


                    //Data de Emissao

                    // fonte e cor
                    Font Font_Emissao = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_Emissao = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_Emissao = 384.0F;
                    float y_Emissao = 375.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        DateTime.Parse(datareader[26].ToString()).ToShortDateString(),
                        Font_Emissao,
                        Cor_Emissao,
                        x_Emissao,
                        y_Emissao
                    );


                    //Cidade Residencia

                    string StringResidencia = datareader[20].ToString();
                    // fonte e cor
                    Font Font_Residencia = new Font("Calibri", 8, FontStyle.Bold);
                    SolidBrush Cor_Residencia = new SolidBrush(Color.White);
                    // onde escrever na imagem
                    float x_Residencia = 675.0F;
                    float y_Residencia = 375.0F;
                    // esxrever na imagem
                    credencial.DrawString(
                        StringResidencia.ToUpper(),
                        Font_Residencia,
                        Cor_Residencia,
                        x_Residencia,
                        y_Residencia
                    );

                    // salvar como PNG
                    pictureBoxVerso.Image = image1;
 
                }
                banco.desconectar();

                //Convert a nova imagem em Byte
                using (var stream = new System.IO.MemoryStream())
                {
                    string MembrosUpd = ("UPDATE CredencialMembro SET credencialVersoImage = @imageVerso WHERE idMembroFK = @ID");
                    SqlCommand command = new SqlCommand(MembrosUpd, banco.connection);

                    pictureBoxVerso.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

                    //
                    pictureBoxVerso.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                    //
                    stream.Seek(0, System.IO.SeekOrigin.Begin);
                    byte[] byteArray = new byte[stream.Length];
                    stream.Read(byteArray, 0, System.Convert.ToInt32(stream.Length));

                    //
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@imageVerso", byteArray);
                    command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.Rows[i].Cells[0].Value);

                    banco.conectar();
                    command.ExecuteNonQuery();
                    banco.desconectar();
                }
            }
        }

        private void comboBoxSetorCongregacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSetorCongregacao.Text == "TODOS" || comboBoxSetorCongregacao.Text == "")
            {
                if (comboBoxCargo.Text == "TODOS" || comboBoxCargo.Text == "")
                {
                    if (tipoAcao == 1)
                    {
                        RequestGerarCredencialPesquisa();
                    }

                    if (tipoAcao == 2)
                    {
                        RequestReemprimirCredencialPesquisa();
                    }
                }
                else
                {
                    if (tipoAcao == 1)
                    {
                        string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                        SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                        banco.conectar();

                        exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewVizualizacaoPesquisa.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                            datareader[22].ToString(),
                                                            datareader[1].ToString(),
                                                            datareader[13].ToString(),
                                                            datareader[14].ToString(),
                                                            Resources.icons8_group_layouts_25px,
                                                            datareader[30].ToString());
                        }
                        banco.desconectar();

                        dataGridViewVizualizacaoPesquisa.Refresh();
                    }

                    if (tipoAcao == 2)
                    {
                        string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                        SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                        banco.conectar();

                        exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewVizualizacaoPesquisa.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                            datareader[22].ToString(),
                                                            datareader[1].ToString(),
                                                            datareader[13].ToString(),
                                                            datareader[14].ToString(),
                                                            Resources.icons8_group_layouts_25px,
                                                            datareader[30].ToString());

                        }
                        banco.desconectar();

                        dataGridViewVizualizacaoPesquisa.Refresh();
                    }
                }
            }
            else
            {
                if (tipoAcao == 1)
                {
                    string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND congregacaoSetor = @setor ORDER BY nomeCompleto");
                    SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                    banco.conectar();

                    exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    dataGridViewVizualizacaoPesquisa.Rows.Clear();
                    while (datareader.Read())
                    {
                        dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                        datareader[22].ToString(),
                                                        datareader[1].ToString(),
                                                        datareader[13].ToString(),
                                                        datareader[14].ToString(),
                                                        Resources.icons8_group_layouts_25px,
                                                        datareader[30].ToString());
                    }
                    banco.desconectar();

                    dataGridViewVizualizacaoPesquisa.Refresh();
                }

                if (tipoAcao == 2)
                {
                    string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND congregacaoSetor = @setor ORDER BY nomeCompleto");
                    SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                    banco.conectar();

                    exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    dataGridViewVizualizacaoPesquisa.Rows.Clear();
                    while (datareader.Read())
                    {
                        dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                        datareader[22].ToString(),
                                                        datareader[1].ToString(),
                                                        datareader[13].ToString(),
                                                        datareader[14].ToString(),
                                                        Resources.icons8_group_layouts_25px,
                                                        datareader[30].ToString());

                    }
                    banco.desconectar();

                    dataGridViewVizualizacaoPesquisa.Refresh();
                }
            }
        }

        private void comboBoxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxCargo.Text == "TODOS" || comboBoxCargo.Text == "")
            {
                if (comboBoxSetorCongregacao.Text == "TODOS" || comboBoxSetorCongregacao.Text == "")
                {
                    if (tipoAcao == 1)
                    {
                        RequestGerarCredencialPesquisa();
                    }

                    if (tipoAcao == 2)
                    {
                        RequestReemprimirCredencialPesquisa();
                    }
                }
                else
                {
                    if (tipoAcao == 1)
                    {
                        string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND congregacaoSetor = @setor ORDER BY nomeCompleto");
                        SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                        banco.conectar();

                        exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewVizualizacaoPesquisa.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                            datareader[22].ToString(),
                                                            datareader[1].ToString(),
                                                            datareader[13].ToString(),
                                                            datareader[14].ToString(),
                                                            Resources.icons8_group_layouts_25px,
                                                            datareader[30].ToString());
                        }
                        banco.desconectar();

                        dataGridViewVizualizacaoPesquisa.Refresh();
                    }

                    if (tipoAcao == 2)
                    {
                        string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND congregacaoSetor = @setor ORDER BY nomeCompleto");
                        SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                        banco.conectar();

                        exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewVizualizacaoPesquisa.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                            datareader[22].ToString(),
                                                            datareader[1].ToString(),
                                                            datareader[13].ToString(),
                                                            datareader[14].ToString(),
                                                            Resources.icons8_group_layouts_25px,
                                                            datareader[30].ToString());

                        }
                        banco.desconectar();

                        dataGridViewVizualizacaoPesquisa.Refresh();
                    }
                }
            }
            else
            {
                if (tipoAcao == 1)
                {
                    string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                    SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                    banco.conectar();

                    exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    dataGridViewVizualizacaoPesquisa.Rows.Clear();
                    while (datareader.Read())
                    {
                        dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                        datareader[22].ToString(),
                                                        datareader[1].ToString(),
                                                        datareader[13].ToString(),
                                                        datareader[14].ToString(),
                                                        Resources.icons8_group_layouts_25px,
                                                        datareader[30].ToString());
                    }
                    banco.desconectar();

                    dataGridViewVizualizacaoPesquisa.Refresh();
                }

                if (tipoAcao == 2)
                {
                    string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                    SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                    banco.conectar();

                    exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    dataGridViewVizualizacaoPesquisa.Rows.Clear();
                    while (datareader.Read())
                    {
                        dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                        datareader[22].ToString(),
                                                        datareader[1].ToString(),
                                                        datareader[13].ToString(),
                                                        datareader[14].ToString(),
                                                        Resources.icons8_group_layouts_25px,
                                                        datareader[30].ToString());

                    }
                    banco.desconectar();

                    dataGridViewVizualizacaoPesquisa.Refresh();
                }
            }
        }

        private void textBoxPesquisarNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxPesquisarNome.Text == "")
            {
                #region Pesquisa Vazia

                if (comboBoxCargo.Text == "TODOS" || comboBoxCargo.Text == "")
                {
                    if (comboBoxSetorCongregacao.Text == "TODOS" || comboBoxSetorCongregacao.Text == "")
                    {
                        if(tipoAcao == 1)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO'");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());
                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }
                        
                        if(tipoAcao == 2)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO'");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());

                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }
                        
                    }
                    else
                    {
                        if (tipoAcao == 1)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND congregacaoSetor = @setor ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());
                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }

                        if (tipoAcao == 2)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND congregacaoSetor = @setor ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());

                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }
                    }
                }
                else
                {
                    if (comboBoxSetorCongregacao.Text == "TODOS" || comboBoxSetorCongregacao.Text == "")
                    {
                        if (tipoAcao == 1)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());
                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }

                        if (tipoAcao == 2)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());

                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }
                    }
                    else
                    {
                        if (tipoAcao == 1)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND congregacaoSetor = @setor AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);
                            exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());
                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }

                        if (tipoAcao == 2)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND congregacaoSetor = @setor AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);
                            exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());

                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }
                    }
                }

                #endregion
            }
            else
            {
                #region Pesquisa com caracteres

                if (comboBoxCargo.Text == "TODOS" || comboBoxCargo.Text == "")
                {
                    if (comboBoxSetorCongregacao.Text == "TODOS" || comboBoxSetorCongregacao.Text == "")
                    {
                        if (tipoAcao == 1)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND (nomeCompleto LIKE @nome + '%') ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisarNome.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());
                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }

                        if (tipoAcao == 2)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND (nomeCompleto LIKE @nome + '%') ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisarNome.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());

                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }

                    }
                    else
                    {
                        if (tipoAcao == 1)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND (nomeCompleto LIKE @nome + '%') AND congregacaoSetor = @setor ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisarNome.Text);
                            exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());
                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }

                        if (tipoAcao == 2)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND (nomeCompleto LIKE @nome + '%') AND congregacaoSetor = @setor ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisarNome.Text);
                            exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());

                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }
                    }
                }
                else
                {
                    if (comboBoxSetorCongregacao.Text == "")
                    {
                        if (tipoAcao == 1)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND (nomeCompleto LIKE @nome + '%') AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisarNome.Text);
                            exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());
                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }

                        if (tipoAcao == 2)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND (nomeCompleto LIKE @nome + '%') AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisarNome.Text);
                            exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());

                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }
                    }
                    else
                    {
                        if (tipoAcao == 1)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via = '0' AND CredencialMembro.statusEmissao = 'A EMITIR' AND CredencialMembro.status = 'ATIVO' AND (nomeCompleto LIKE @nome + '%') AND congregacaoSetor = @setor AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisarNome.Text);
                            exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);
                            exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());
                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }

                        if (tipoAcao == 2)
                        {
                            string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE CredencialMembro.via > '0' AND CredencialMembro.statusEmissao = 'EMITIDO' AND CredencialMembro.status = 'ATIVO' AND (nomeCompleto LIKE @nome + '%') AND congregacaoSetor = @setor AND funcaoCargo = @funcao ORDER BY nomeCompleto");
                            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                            banco.conectar();

                            exeVerificacao.Parameters.AddWithValue("@nome", textBoxPesquisarNome.Text);
                            exeVerificacao.Parameters.AddWithValue("@funcao", comboBoxCargo.Text);
                            exeVerificacao.Parameters.AddWithValue("@setor", comboBoxSetorCongregacao.Text);

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewVizualizacaoPesquisa.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewVizualizacaoPesquisa.Rows.Add(datareader[0].ToString(),
                                                                datareader[22].ToString(),
                                                                datareader[1].ToString(),
                                                                datareader[13].ToString(),
                                                                datareader[14].ToString(),
                                                                Resources.icons8_group_layouts_25px,
                                                                datareader[30].ToString());

                            }
                            banco.desconectar();

                            dataGridViewVizualizacaoPesquisa.Refresh();
                        }
                    }
                }

                #endregion
            }
        }

        private void btnbtnGerarNovasCredenciais_Click(object sender, EventArgs e)
        {
            if (panelPesquisaMembro.Visible == false)
            {
                //Gerar Nova Credencial
                tipoAcao = 1;

                labelTituloPanelPesquisaMembro.Text = "Gerar Novas Credenciais de Membro";
                labelTituloDataGridPesquisaMembros.Text = "Quadro de Vizualização de Membros Cadastrados sem Credencial:";

                panelVizualizarCarteirinha.Visible = false;
                panelMembrosSelecionados.Visible = false;
                flpContentMembros.Visible = true;
                panelPesquisaMembro.Visible = true;
                panelSelecionarAutomaticoPesquisa.Visible = true;

                btnGerarCredencial.Enabled = false;
                btnImprimirCredencial.Enabled = false;
                //
                labelDivisorHeader.Visible = false;
                btnGerarCredencial.Visible = false;
                btnImprimirCredencial.Visible = false;
            }
            else
            {
                //Gerar Nova Credencial
                tipoAcao = 1;

                labelTituloPanelPesquisaMembro.Text = "Gerar Novas Credenciais de Membro";
                labelTituloDataGridPesquisaMembros.Text = "Quadro de Vizualização de Membros Cadastrados sem Credencial:";

                panelPesquisaMembro.Visible = false;
                panelVizualizarCarteirinha.Visible = false;
                panelMembrosSelecionados.Visible = false;
                flpContentMembros.Visible = true;
                panelPesquisaMembro.Visible = true;
                panelSelecionarAutomaticoPesquisa.Visible = true;

                btnGerarCredencial.Enabled = false;
                btnImprimirCredencial.Enabled = false;
                //
                labelDivisorHeader.Visible = false;
                btnGerarCredencial.Visible = false;
                btnImprimirCredencial.Visible = false;
            }

            RequestGerarCredencialPesquisa();
            requestComboBoxCargoFuncao();
            requestComboBoxSetorCongregacao();
            gerarDataHeaders();
        }

        private void btnReemprimirCredencial_Click(object sender, EventArgs e)
        {
            if (panelPesquisaMembro.Visible == false)
            {
                //Reemprimir Credencial
                tipoAcao = 2;

                labelTituloPanelPesquisaMembro.Text = "Reemprimir Credenciais de Membro";
                labelTituloDataGridPesquisaMembros.Text = "Quadro de Vizualização de Membros Cadastrados com Credencial:";

                panelVizualizarCarteirinha.Visible = false;
                panelMembrosSelecionados.Visible = false;
                panelSelecionarAutomaticoPesquisa.Visible = false;
                flpContentMembros.Visible = true;
                panelPesquisaMembro.Visible = true;

                btnGerarCredencial.Enabled = false;
                btnImprimirCredencial.Enabled = false;
                //
                labelDivisorHeader.Visible = false;
                btnGerarCredencial.Visible = false;
                btnImprimirCredencial.Visible = false;
            }
            else
            {
                //Reemprimir Credencial
                tipoAcao = 2;

                labelTituloPanelPesquisaMembro.Text = "Reemprimir Credenciais de Membro";
                labelTituloDataGridPesquisaMembros.Text = "Quadro de Vizualização de Membros Cadastrados com Credencial:";

                panelPesquisaMembro.Visible = false;
                panelVizualizarCarteirinha.Visible = false;
                panelMembrosSelecionados.Visible = false;
                panelSelecionarAutomaticoPesquisa.Visible = false;
                flpContentMembros.Visible = true;
                panelPesquisaMembro.Visible = true;

                btnGerarCredencial.Enabled = false;
                btnImprimirCredencial.Enabled = false;
                //
                labelDivisorHeader.Visible = false;
                btnGerarCredencial.Visible = false;
                btnImprimirCredencial.Visible = false;
            }

            updStatusCarteira();
            gerarDataHeaders();
            RequestReemprimirCredencialPesquisa();
            requestComboBoxCargoFuncao();
            requestComboBoxSetorCongregacao();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewVizualizacaoMembros.Rows.Count - 0; i++)
            {
                string Membros = ("UPDATE CredencialMembro SET statusEmissao = @status WHERE idMembroFK = @ID");
                SqlCommand command = new SqlCommand(Membros, banco.connection);

                int via = int.Parse(dataGridViewVizualizacaoMembros.Rows[i].Cells[6].Value.ToString());

                if(via == 0)
                {
                    command.Parameters.AddWithValue("@status", "A EMITIR");
                    command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.Rows[i].Cells[0].Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@status", "EMITIDO");
                    command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.Rows[i].Cells[0].Value);
                }

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();
            }

            if(tipoAcao == 1)
            {
                RequestGerarCredencialPesquisa();
                RequestGerarCredencialSelecionados();
                dataGridViewVizualizacaoMembros.Refresh();
                dataGridViewVizualizacaoPesquisa.Refresh();
                gerarDataHeaders();
            }

            if(tipoAcao == 2)
            {
                RequestReemprimirCredencialPesquisa();
                RequestReemprimirCredencialSelecionados();
                dataGridViewVizualizacaoMembros.Refresh();
                dataGridViewVizualizacaoPesquisa.Refresh();
                gerarDataHeaders();
            }
            
        }

        private void btnGerarCredencial_Click(object sender, EventArgs e)
        {
            if (dataGridViewVizualizacaoMembros.Rows.Count != 0)
            {
                if(tipoAcao == 1)
                {
                    gerarCredencialFrente();
                    gerarCredencialVerso();

                }

                if (tipoAcao == 2)
                {
  
                    RequestReemprimirCredencialPesquisa();
                    RequestReemprimirCredencialSelecionados();
                    dataGridViewVizualizacaoMembros.Refresh();
                    dataGridViewVizualizacaoPesquisa.Refresh();
                    updStatusCarteira();
                    gerarDataHeaders();
                }
                

                MessageBox.Show("Credenciais geradas com Sucesso!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("Para finalizar Clique em Vizualizar e Imprimir!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnGerarCredencial.Enabled = false;
                btnImprimirCredencial.Enabled = true;
            }
            else
            {
                MessageBox.Show("Não foi possivel iniciar a operação." + "\n" + "Selecione um ou mais Membros e tente novamente!", "Aviso do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimirCredencial_Click(object sender, EventArgs e)
        {
            StatusImpressao();

            Reports.Credencial_Varias.FormReportCredencialVarias windows = new Reports.Credencial_Varias.FormReportCredencialVarias();
            windows.ShowDialog();
            windows.Dispose();

            for (int i = 0; i < dataGridViewVizualizacaoMembros.Rows.Count - 0; i++)
            {
                string MembrosUpd = ("UPDATE CredencialMembro SET statusEmissao = @status WHERE idMembroFK = @ID");
                SqlCommand command = new SqlCommand(MembrosUpd, banco.connection);

                command.Parameters.Clear();
                command.Parameters.AddWithValue("@status", "EMITIDO");
                command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.Rows[i].Cells[0].Value);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();
            }

            RequestGerarCredencialPesquisa();
            RequestGerarCredencialSelecionados();
            dataGridViewVizualizacaoMembros.Refresh();
            dataGridViewVizualizacaoPesquisa.Refresh();
            gerarDataHeaders();
        }

        private void buttonOcultarVizualizarMembro_Click(object sender, EventArgs e)
        {
            if (panelMembrosSelecionados.Visible == true)
            {
                panelVizualizarCarteirinha.Visible = false;
                panelMembrosSelecionados.Visible = false;
                flpContentMembros.Visible = true;
                panelPesquisaMembro.Visible = true;

                btnGerarCredencial.Enabled = false;
                btnImprimirCredencial.Enabled = false;
                //
                labelDivisorHeader.Visible = false;
                btnGerarCredencial.Visible = false;
                btnImprimirCredencial.Visible = false;

                if(dataGridViewVizualizacaoMembros.Rows.Count == 0)
                {
                    updStatusCarteira();
                    gerarDataHeaders();
                    RequestReemprimirCredencialPesquisa();
                    requestComboBoxCargoFuncao();
                    requestComboBoxSetorCongregacao();
                }
            }
   
        }

        private void btnVizualizarMembroSelecionado_Click(object sender, EventArgs e)
        {
            if (panelMembrosSelecionados.Visible == false)
            {
                panelVizualizarCarteirinha.Visible = false;
                panelPesquisaMembro.Visible = false;
                flpContentMembros.Visible = true;
                panelMembrosSelecionados.Visible = true;

                if(tipoAcao == 1)
                {
                    RequestGerarCredencialSelecionados();

                    if (dataGridViewVizualizacaoMembros.Rows.Count != 0)
                    {
                        btnGerarCredencial.Enabled = true;
                        
                        //
                        labelDivisorHeader.Visible = true;
                        btnGerarCredencial.Visible = true;
                        btnImprimirCredencial.Visible = true;
                    }
                }

                if(tipoAcao == 2)
                {
                    RequestReemprimirCredencialSelecionados();

                    if (dataGridViewVizualizacaoMembros.Rows.Count != 0)
                    {
                        btnImprimirCredencial.Enabled = true;
                        //
                        labelDivisorHeader.Visible = true;
                        btnImprimirCredencial.Visible = true;
                    }
                }

                gerarDataHeaders();

            }
        }

        private void dataGridViewVizualizacaoPesquisa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewVizualizacaoPesquisa.Rows.Count != 0)
            {
                string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE Membros.idMembro = @ID");
                SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                banco.conectar();

                exeVerificacao.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoPesquisa.CurrentRow.Cells[0].Value);

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                while (datareader.Read())
                {
                    labelValueNomeCompleto.Text = datareader[1].ToString();
                    labelValueFuncaoCargo.Text = datareader[13].ToString();
                    labelValueSetorCongregacao.Text = datareader[14].ToString();
                    labelValueHeaderStatus.Text = datareader[23].ToString();

                    //var dataRowView = datareader[0] as DataRowView;
                    if (datareader[17].ToString() == "")
                    {
                        if (datareader[3].ToString() == "MASCULINO" || datareader[3].ToString() == "Masculino")
                        {
                            pictureBoxPerfil.Image = Resources.icons8_user_126px;
                        }

                        if (datareader[3].ToString() == "FEMININO" || datareader[3].ToString() == "Feminino")
                        {
                            pictureBoxPerfil.Image = Resources.icons8_businesswoman_126px;
                        }

                    }
                    else
                    {
                        using (var stream = new System.IO.MemoryStream((byte[])datareader[17]))
                        {
                            pictureBoxPerfil.Image = Bitmap.FromStream(stream);
                        }
                    }

                }

                banco.desconectar();
            }

            if (e.ColumnIndex == 5)
            {
                string Membros = ("UPDATE CredencialMembro SET statusEmissao = @status WHERE idMembroFK = @ID");
                SqlCommand command = new SqlCommand(Membros, banco.connection);

                command.Parameters.AddWithValue("@status", "EM ANDAMENTO");
                command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoPesquisa.CurrentRow.Cells[0].Value);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();


                if (tipoAcao == 1)
                {
                    RequestGerarCredencialPesquisa();
                    RequestGerarCredencialSelecionados();
                    dataGridViewVizualizacaoMembros.Refresh();
                    dataGridViewVizualizacaoPesquisa.Refresh();
                    gerarDataHeaders();
                }

                if (tipoAcao == 2)
                {
                    RequestReemprimirCredencialPesquisa();
                    RequestReemprimirCredencialSelecionados();
                    dataGridViewVizualizacaoMembros.Refresh();
                    dataGridViewVizualizacaoPesquisa.Refresh();
                    gerarDataHeaders();
                }
            }
        }

        private void dataGridViewVizualizacaoMembros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewVizualizacaoMembros.Rows.Count != 0)
            {
                string Membros = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE Membros.idMembro = @ID");
                SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                banco.conectar();

                exeVerificacao.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.CurrentRow.Cells[0].Value);

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                while (datareader.Read())
                {
                    labelValueNomeCompleto.Text = datareader[1].ToString();
                    labelValueFuncaoCargo.Text = datareader[13].ToString();
                    labelValueSetorCongregacao.Text = datareader[14].ToString();
                    labelValueHeaderStatus.Text = datareader[23].ToString();

                    //var dataRowView = datareader[0] as DataRowView;
                    if (datareader[17].ToString() == "")
                    {
                        if (datareader[3].ToString() == "MASCULINO" || datareader[3].ToString() == "Masculino")
                        {
                            pictureBoxPerfil.Image = Resources.icons8_user_126px;
                        }

                        if (datareader[3].ToString() == "FEMININO" || datareader[3].ToString() == "Feminino")
                        {
                            pictureBoxPerfil.Image = Resources.icons8_businesswoman_126px;
                        }

                    }
                    else
                    {
                        using (var stream = new System.IO.MemoryStream((byte[])datareader[17]))
                        {
                            pictureBoxPerfil.Image = Bitmap.FromStream(stream);
                        }
                    }

                }
                banco.desconectar();
            }

            if (e.ColumnIndex == 4)
            {
                if(panelVizualizarCarteirinha.Visible == false)
                {
                    flpContentMembros.Visible = false;
                    panelPesquisaMembro.Visible = false;
                    panelMembrosSelecionados.Visible = false;
                    panelVizualizarCarteirinha.Visible = true;

                    string Membros = ("SELECT * FROM CredencialMembro WHERE idMembroFK = @ID");
                    SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
                    banco.conectar();

                    exeVerificacao.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.CurrentRow.Cells[0].Value);

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    if (datareader.Read())
                    {
                        labelValueStatus.Text = datareader[2].ToString();
                        labelValueSituacao.Text = datareader[3].ToString();
                        labelValueVia.Text = datareader[9].ToString();
                    }
                    banco.desconectar();

                    DesenharCredencialFrente();
                    DesenharCredencialVerso();
                    gerarDataHeaders();
                }
            }

            if (e.ColumnIndex == 5)
            {
                string Membros = ("UPDATE CredencialMembro SET statusEmissao = @status WHERE idMembroFK = @ID");
                SqlCommand command = new SqlCommand(Membros, banco.connection);

                int via = int.Parse(dataGridViewVizualizacaoMembros.CurrentRow.Cells[6].Value.ToString());

                if(via == 0)
                {
                    command.Parameters.AddWithValue("@status", "A EMITIR");
                    command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.CurrentRow.Cells[0].Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@status", "EMITIDO");
                    command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoMembros.CurrentRow.Cells[0].Value);
                }

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();


                if(tipoAcao == 1)
                {
                    RequestGerarCredencialPesquisa();
                    RequestGerarCredencialSelecionados();
                    dataGridViewVizualizacaoMembros.Refresh();
                    dataGridViewVizualizacaoPesquisa.Refresh();
                }

                if (tipoAcao == 2)
                {
                    RequestReemprimirCredencialPesquisa();
                    RequestReemprimirCredencialSelecionados();
                    dataGridViewVizualizacaoMembros.Refresh();
                    dataGridViewVizualizacaoPesquisa.Refresh();
                }

                gerarDataHeaders();
            }
        }

        private void btnSairVizualizarCarteirinha_Click(object sender, EventArgs e)
        {
            if (panelVizualizarCarteirinha.Visible == true)
            {
                panelVizualizarCarteirinha.Visible = false;
                panelPesquisaMembro.Visible = false;
                flpContentMembros.Visible = true;
                panelMembrosSelecionados.Visible = true;

                pictureBoxFrente.Image = Resources.Credencial___Frente___sistema;
                pictureBoxVerso.Image = Resources.Credencial___Costa___sistema;
            }
        }

        private void btnAdicionarMembro_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBoxQntMembroAuto.Text) <= dataGridViewVizualizacaoPesquisa.Rows.Count)
            {
                if (textBoxQntMembroAuto.Text != "")
                {
                    contadorMembros = int.Parse(textBoxQntMembroAuto.Text);
                }

                for (int i = 0; i < contadorMembros - 0; i++)
                {
                    string Membros = ("UPDATE CredencialMembro SET statusEmissao = @status WHERE idMembroFK = @ID");
                    SqlCommand command = new SqlCommand(Membros, banco.connection);

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@status", "EM ANDAMENTO");
                    command.Parameters.AddWithValue("@ID", dataGridViewVizualizacaoPesquisa.Rows[i].Cells[0].Value);

                    banco.conectar();
                    command.ExecuteNonQuery();
                    banco.desconectar();
                }

                textBoxQntMembroAuto.Clear();

                if(tipoAcao == 1)
                {
                    RequestGerarCredencialPesquisa();
                }

                if(tipoAcao == 2)
                {
                    RequestReemprimirCredencialPesquisa();
                }
            }
            else
            {
                MessageBox.Show("O numero informado excede a quantidade de Membros cadastrados." + "\n" + "Informe outro valor e tente novamente!");
            }
        }

        private void frmImpressoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            updStatusCarteira();
        }

        #region Paint

        private void panelControle_Paint(object sender, PaintEventArgs e)
        {
            panelControle.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelControle.Width,
            panelControle.Height, 7, 7));
        }

        private void panelMembrosSelecionados_Paint(object sender, PaintEventArgs e)
        {
            panelMembrosSelecionados.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelMembrosSelecionados.Width,
            panelMembrosSelecionados.Height, 7, 7));
        }

        private void panelVizualizarCarteirinha_Paint(object sender, PaintEventArgs e)
        {
            panelVizualizarCarteirinha.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelVizualizarCarteirinha.Width,
            panelVizualizarCarteirinha.Height, 7, 7));
        }

        private void panelPesquisaMembro_Paint(object sender, PaintEventArgs e)
        {
            panelPesquisaMembro.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelPesquisaMembro.Width,
            panelPesquisaMembro.Height, 7, 7));
        }

        private void btnAdicionarMembro_Paint(object sender, PaintEventArgs e)
        {
            btnAdicionarMembro.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAdicionarMembro.Width,
            btnAdicionarMembro.Height, 5, 5));
        }

        #endregion

    }
}
