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

namespace CarteirinhaMembro.Forms.Configurações
{
    public partial class ListAjuda : UserControl
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
        int ID = 0;
        string link;

        public ListAjuda()
        {
            InitializeComponent();
        }

        #region Header

        private int _idAjuda;
        private string _titulo;
        private string _local;
        private string _tipoAcao;
        private string _link;

        [Category("Custom Props")]
        public int IdAjuda
        {
            get { return _idAjuda; }
            set { _idAjuda = value; ID = value; }
        }

        [Category("Custom Props")]
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; labelHeaderTitulo.Text = value; }
        }

        [Category("Custom Props")]
        public string Local
        {
            get { return _local; }
            set { _local = value; labelHeaderLocal.Text = value; }
        }

        [Category("Custom Props")]
        public string TipoAcao
        {
            get { return _tipoAcao; }
            set { _tipoAcao = value; labelValueTipoAcao.Text = value; }
        }

        [Category("Custom Props")]
        public string Link
        {
            get { return _link; }
            set { _link = value; linkLabelLink.Text = value; link = value; }
        }

        #endregion

        private void ListAjuda_Load(object sender, EventArgs e)
        {
            #region Dados carregamento

            Height = 120;
            this.panelContent.Size = new Size(805, 100);
            this.panelHeader.Size = new Size(805, 100);

            #endregion

            requestDataAjuda();
        }

        private void requestDataAjuda()
        {
            string Ajuda = ("SELECT * FROM Ajuda WHERE idAjuda = @ID");
            SqlCommand exeData = new SqlCommand(Ajuda, banco.connection);

            exeData.Parameters.AddWithValue("@ID", ID);

            banco.conectar();
            SqlDataReader datareader = exeData.ExecuteReader();

            while (datareader.Read())
            {
                if (datareader[5].ToString() != "")
                {
                    using (var stream = new System.IO.MemoryStream((byte[])datareader[5]))
                    {
                        pictureBoxCapa.Image = Bitmap.FromStream(stream);
                    }
                }
                else
                {
                    pictureBoxCapa.Image = Resources.icons8_image_gallery_128px_1;
                }

            }
            banco.desconectar();
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            if (aberto == true)
            {
                aberto = false;
                Size = new Size(883, 120);
                this.panelContent.Size = new Size(805, 100);

                btnDetalhes.Text = "Mostrar detalhes do Tutorial";
            }
            else
            {
                // Valor referencia: Tamanho total de 10085, e ContentPai = 10056

                aberto = true;
                Size = new Size(883, 640);
                this.panelContent.Size = new Size(805, 626);

                btnDetalhes.Text = "Ocultar detalhes do Tutorial";
            }
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

        #endregion

        private void linkLabelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(link);
        }
    }
}
