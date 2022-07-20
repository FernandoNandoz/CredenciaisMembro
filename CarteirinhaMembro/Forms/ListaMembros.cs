using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using CarteirinhaMembro.Properties;

namespace CarteirinhaMembro.Forms
{
    public partial class ListaMembros : UserControl
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

        bool aberto = false;
        int ID = 0, sizeFull = 0, sizeContent = 0;

        public ListaMembros()
        {
            InitializeComponent();

        }

        private void ListaMembros_Load(object sender, EventArgs e)
        {
            #region Dados carregamento

            Height = 120;
            this.panelContent.Size = new Size(1074, 100);
            this.panelHeader.Size = new Size(1074, 100);

            sizeContent = 2205;
            sizeFull = 2215;

            #endregion

            verificarStatus();
        }

        #region Header

        private int _idMembro;
        private string _membro;
        private string _cargoFuncao;
        private string _setorCongregacao;


        [Category("Custom Props")]
        public int IdMembro
        {
            get { return _idMembro; }
            set { _idMembro = value; ID = value; }
        }

        [Category("Custom Props")]
        public string Membro
        {
            get { return _membro; }
            set { _membro = value; labelMembro.Text = value; }
        }

        [Category("Custom Props")]
        public string CargoFuncao
        {
            get { return _cargoFuncao; }
            set { _cargoFuncao = value; labelCargoFuncao.Text = value; }
        }

        [Category("Custom Props")]
        public string SetorCongregacao
        {
            get { return _setorCongregacao; }
            set { _setorCongregacao = value; labelSetorCongregacao.Text = value; }
        }

        #endregion

        private void verificarStatus()
        {
            string membro = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE Membros.idMembro = @ID");
            SqlCommand exeData = new SqlCommand(membro, banco.connection);

            exeData.Parameters.AddWithValue("@ID", ID);

            banco.conectar();
            SqlDataReader datareader = exeData.ExecuteReader();

            while (datareader.Read())
            {
                if (datareader[23].ToString() == "ATIVO")
                {
                    pictureBoxReact.Image = Resources.icons8_cool_30px;
                    pictureBoxStatus.Image = Resources.icons8_verified_account_30px;
                }
                else
                {
                    pictureBoxReact.Image = Resources.icons8_puzzled_30px;
                    pictureBoxStatus.Image = Resources.icons8_error_30px;
                }
            }
            banco.desconectar();
        }

        private void requestDataMembros()
        {
            string membro = ("SELECT * FROM Membros INNER JOIN CredencialMembro ON Membros.idMembro = CredencialMembro.idMembroFK WHERE Membros.idMembro = @ID");
            SqlCommand exeData = new SqlCommand(membro, banco.connection);

            exeData.Parameters.AddWithValue("@ID", ID);

            banco.conectar();
            SqlDataReader datareader = exeData.ExecuteReader();

            while (datareader.Read())
            {
                if (datareader[23].ToString() == "ATIVO")
                {
                    pictureBoxReact.Image = Resources.icons8_cool_30px;
                    pictureBoxStatus.Image = Resources.icons8_verified_account_30px;
                }
                else
                {
                    pictureBoxReact.Image = Resources.icons8_puzzled_30px;
                    pictureBoxStatus.Image = Resources.icons8_error_30px;
                }

                labelValueHeaderStatus.Text = datareader[23].ToString();
                //
                labelNomeCompleto.Text = datareader[1].ToString();
                labelValueDataNascimento.Text = DateTime.Parse(datareader[2].ToString()).ToShortDateString();
                labelValueGenero.Text = datareader[3].ToString();
                labelValueEndereco.Text = datareader[4].ToString();
                labelValueTelefone.Text = datareader[5].ToString();
                labelValueNomePai.Text = datareader[6].ToString();
                labelValueNomeMae.Text = datareader[7].ToString();
                labelValueNacionalidade.Text = datareader[8].ToString();
                labelValueNaturalidade.Text = datareader[9].ToString();
                labelValueEstadoCivil.Text = datareader[10].ToString();
                labelValueRG.Text = datareader[11].ToString();
                labelValueCPF.Text = datareader[12].ToString();
                labelValueCargoFuncao.Text = datareader[13].ToString();
                labelValueSetorCongregacao.Text = datareader[14].ToString();
                labelValueBatismoAguas.Text = datareader[15].ToString();
                labelValueBatismoEspiritoSanto.Text = datareader[16].ToString();
                labelValueDataBatismoAguas.Text = DateTime.Parse(datareader[19].ToString()).ToShortDateString();
                labelMatricula.Text = datareader[22].ToString();
                labelValueCidadeResidencia.Text = datareader[20].ToString();
                //
                labelValueStatus.Text = datareader[25].ToString();
                labelValueVia.Text = datareader[30].ToString();
                labelValueSituacao.Text = datareader[24].ToString();

                #region Foto Perfil

                if (datareader[17].ToString() != "")
                {
                    using (var stream = new System.IO.MemoryStream((byte[])datareader[17]))
                    {
                        pictureBoxProfile.Image = Bitmap.FromStream(stream);
                    }
                }
                //else
                //{
                //    if (datareader[3].ToString() == "Masculino" || datareader[3].ToString() == "MASCULINO")
                //    {
                //        pictureBoxProfile.Image = Resources.icons8_user_126px;
                //    }
                //    else
                //    {
                //        pictureBoxProfile.Image = Resources.icons8_businesswoman_126px;
                //    }
                //}

                #endregion

                #region Imagem Credencial Frente

                if (datareader[27].ToString() != "")
                {
                    using (var stream = new System.IO.MemoryStream((byte[])datareader[27]))
                    {
                        pictureBoxCredencialFrente.Image = Bitmap.FromStream(stream);

                        pictureBoxCredencialFrente.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    }
                }
                else
                {
                    pictureBoxCredencialFrente.Image = Resources.Credencial___Frente___sistema;
                }

                #endregion

                #region Imagem Credencial Verso

                if (datareader[28].ToString() != "")
                {
                    using (var stream = new System.IO.MemoryStream((byte[])datareader[28]))
                    {
                        pictureBoxCredencialVerso.Image = Bitmap.FromStream(stream);

                        pictureBoxCredencialVerso.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    }
                }
                else
                {
                    pictureBoxCredencialVerso.Image = Resources.Credencial___Frente___sistema;
                }

                #endregion
            }
            banco.desconectar();
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            if (aberto == true)
            {
                aberto = false;
                Size = new Size(1150, 120);
                this.panelContent.Size = new Size(1074, 100);

                btnDetalhes.Text = "Mostrar detalhes do Membro";
 
            }
            else
            {
                // Valor referencia: Tamanho total de 10085, e ContentPai = 10056

                aberto = true;
                Size = new Size(1150, 2215);
                this.panelContent.Size = new Size(1074, 2205);

                btnDetalhes.Text = "Ocultar detalhes do Membro";

                requestDataMembros();
                flpContent.Refresh();
                panelContent.Refresh();
            }
        }

        private void btnEditarCadastro_Click(object sender, EventArgs e)
        {
            UpdateMembro.receberWindow(IdMembro, true, 1);

            frmMembros window = new frmMembros();
            window.ShowDialog();
            window.Dispose();
        }

        private void btnImprimirFicha_Click(object sender, EventArgs e)
        {
            Consulta.receberID(IdMembro);

            Reports.frmReportImprimirFichaMembro window = new Reports.frmReportImprimirFichaMembro();
            window.ShowDialog();
            window.Dispose();
        }

        private void btnVizualizarDadosPessoais_Click(object sender, EventArgs e)
        {
            if (panelDadosPessoais.Visible == false)
            {
                panelDadosPessoais.Visible = true;

                Size = new Size(1150, sizeFull = sizeFull + panelDadosPessoais.Size.Height);
                this.panelContent.Size = new Size(1074, sizeContent = sizeContent + panelDadosPessoais.Size.Height);

                btnVizualizarDadosPessoais.Image = Resources.icons8_invisible_30px;
            }
            else
            {
                panelDadosPessoais.Visible = false;

                Size = new Size(1150, sizeFull = sizeFull - panelDadosPessoais.Size.Height);
                this.panelContent.Size = new Size(1074, sizeContent = sizeContent - panelDadosPessoais.Size.Height);

                btnVizualizarDadosPessoais.Image = Resources.icons8_eye_30px;
            }
        }

        private void btnVizualizarDadosReligiosos_Click(object sender, EventArgs e)
        {
            if (panelDadosReligiosos.Visible == false)
            {
                panelDadosReligiosos.Visible = true;

                Size = new Size(1150, sizeFull = sizeFull + panelDadosReligiosos.Size.Height);
                this.panelContent.Size = new Size(1074, sizeContent = sizeContent + panelDadosReligiosos.Size.Height);

                btnVizualizarDadosReligiosos.Image = Resources.icons8_invisible_30px;
            }
            else
            {
                panelDadosReligiosos.Visible = false;

                Size = new Size(1150, sizeFull = sizeFull - panelDadosReligiosos.Size.Height);
                this.panelContent.Size = new Size(1074, sizeContent = sizeContent - panelDadosReligiosos.Size.Height);

                btnVizualizarDadosReligiosos.Image = Resources.icons8_eye_30px;
            }
        }

        private void btnVizualizarCarteirinha_Click(object sender, EventArgs e)
        {
            if (panelCarteirinha.Visible == false)
            {
                panelCarteirinha.Visible = true;

                Size = new Size(1150, sizeFull = sizeFull + panelCarteirinha.Size.Height - 50);
                this.panelContent.Size = new Size(1074, sizeContent = sizeContent + panelCarteirinha.Size.Height - 50);

                btnVizualizarCarteirinha.Image = Resources.icons8_invisible_30px;
            }
            else
            {
                panelCarteirinha.Visible = false;

                Size = new Size(1150, sizeFull = 50 + sizeFull - panelCarteirinha.Size.Height);
                this.panelContent.Size = new Size(1074, sizeContent = 50 + sizeContent - panelCarteirinha.Size.Height);

                btnVizualizarCarteirinha.Image = Resources.icons8_eye_30px;
            }
        }

        public void btnImprimirCredencial_Click(object sender, EventArgs e)
        {
            Consulta.receberID(IdMembro);

            Reports.Credencial_Individual.FormReportCredencial_Individual window = new Reports.Credencial_Individual.FormReportCredencial_Individual();
            window.ShowDialog();
            window.Dispose();
        }


        #region Paint

        private void panelData_Paint(object sender, PaintEventArgs e)
        {
            panelData.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelData.Width,
            panelData.Height, 7, 7));
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            panelContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelContent.Width,
            panelContent.Height, 9, 9));
        }

        private void flpContent_Paint(object sender, PaintEventArgs e)
        {
            flpContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, flpContent.Width,
            flpContent.Height, 9, 9));
        }

        #endregion
    }
}
