using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model;
using Sistema.Entidade;

namespace Sistema.View2017
{
    public partial class c : Form
    {
        public c()
        {
            InitializeComponent();
        }

        private void lnk_cadastraUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_cadUsuario form = new frm_cadUsuario();
            form.Show();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
