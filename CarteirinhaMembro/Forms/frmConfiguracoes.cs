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

namespace CarteirinhaMembro.Forms
{
    public partial class frmConfiguracoes : Form
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

        public frmConfiguracoes()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            panelContainerPai.Controls.Add(childForm);
            panelContainerPai.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void frmConfiguracoes_Load(object sender, EventArgs e)
        {

        }

        private void btnFuncaoCargo_Click(object sender, EventArgs e)
        {
            //Muda a coloração dos botoes do menu
            btnFuncaoCargo.BackColor = Color.FromArgb(23, 24, 27);
            //  
            btnCongregacaoSetor.BackColor = Color.FromArgb(33, 34, 38);
            btnAjuda.BackColor = Color.FromArgb(33, 34, 38);
            btnBackup.BackColor = Color.FromArgb(33, 34, 38);

            openChildForm(new Forms.Configurações.FrmFuncaoCargo());
        }

        private void btnCongregacaoSetor_Click(object sender, EventArgs e)
        {
            //Muda a coloração dos botoes do menu
            btnCongregacaoSetor.BackColor = Color.FromArgb(23, 24, 27);
            //  
            btnFuncaoCargo.BackColor = Color.FromArgb(33, 34, 38);
            btnAjuda.BackColor = Color.FromArgb(33, 34, 38);
            btnBackup.BackColor = Color.FromArgb(33, 34, 38);

            openChildForm(new Forms.Configurações.FrmCongregacaoSetor());
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            //Muda a coloração dos botoes do menu
            btnAjuda.BackColor = Color.FromArgb(23, 24, 27);
            //  
            btnFuncaoCargo.BackColor = Color.FromArgb(33, 34, 38);
            btnBackup.BackColor = Color.FromArgb(33, 34, 38);
            btnCongregacaoSetor.BackColor = Color.FromArgb(33, 34, 38);

            openChildForm(new Forms.Configurações.FrmAjuda());
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            //Muda a coloração dos botoes do menu
            btnBackup.BackColor = Color.FromArgb(23, 24, 27);
            //  
            btnFuncaoCargo.BackColor = Color.FromArgb(33, 34, 38);
            btnAjuda.BackColor = Color.FromArgb(33, 34, 38);
            btnCongregacaoSetor.BackColor = Color.FromArgb(33, 34, 38);

            openChildForm(new Forms.Configurações.FrmBackup());
        }

        #region Paint

        private void panelSubMenu_Paint(object sender, PaintEventArgs e)
        {
            panelSubMenu.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelSubMenu.Width,
            panelSubMenu.Height, 7, 7));
        }

        #endregion
    }
}
