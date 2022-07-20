using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteirinhaMembro
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            resolucao();
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
            panelDashboard.Controls.Add(childForm);
            panelDashboard.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            btnDashboard_Click(sender, e);
        }

        private void resolucao()
        {
            int c = Screen.PrimaryScreen.BitsPerPixel;
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            if(w > 1366 && h > 768)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            //Muda a coloração dos botoes do menu
            btnDashboard.BackColor = Color.FromArgb(23, 24, 27);
            //  
            btnMembros.BackColor = Color.FromArgb(33, 34, 38);
            btnImpressões.BackColor = Color.FromArgb(33, 34, 38);
            btnConfiguracoes.BackColor = Color.FromArgb(33, 34, 38);

            openChildForm(new Forms.frmListaMembros());
        }

        private void btnMembros_Click(object sender, EventArgs e)
        {
            //Muda a coloração dos botoes do menu
            btnMembros.BackColor = Color.FromArgb(23, 24, 27);
            //  
            btnDashboard.BackColor = Color.FromArgb(33, 34, 38);
            btnImpressões.BackColor = Color.FromArgb(33, 34, 38);
            btnConfiguracoes.BackColor = Color.FromArgb(33, 34, 38);

            openChildForm(new frmMembros());
        }

        private void btnImpressões_Click(object sender, EventArgs e)
        {
            //Muda a coloração dos botoes do menu
            btnImpressões.BackColor = Color.FromArgb(23, 24, 27);
            //  
            btnDashboard.BackColor = Color.FromArgb(33, 34, 38);
            btnMembros.BackColor = Color.FromArgb(33, 34, 38);
            btnConfiguracoes.BackColor = Color.FromArgb(33, 34, 38);   

            openChildForm(new Forms.frmCredenciais());
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            //Muda a coloração dos botoes do menu
            btnConfiguracoes.BackColor = Color.FromArgb(23, 24, 27);
            //  
            btnImpressões.BackColor = Color.FromArgb(33, 34, 38);
            btnDashboard.BackColor = Color.FromArgb(33, 34, 38);
            btnMembros.BackColor = Color.FromArgb(33, 34, 38);

            openChildForm(new Forms.frmConfiguracoes());
        }

    }
}
