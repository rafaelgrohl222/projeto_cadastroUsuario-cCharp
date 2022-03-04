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

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_login.Text == "")
                {
                    MessageBox.Show("Preencher o campo 'USUÁRIO'!");
                    txt_login.Focus();//Cursor no campo txt_login
                    return;//Finaliza
                }

                if (txt_senha.Text == "")
                {
                    MessageBox.Show("Preencher o campo 'SENHA'!");
                    txt_senha.Focus();//Cursor no campo txt_senha
                    return;//Finaliza
                }

                UsuarioEnt obj = new UsuarioEnt();

                obj.Usuario = txt_login.Text;//receber o dados que estiver dentro do txt_login
                obj.Senha = txt_senha.Text;//receber o dados que estiver dentro do txt_senha

                obj = new UsuarioModel().Login(obj);//receber a classe do UsuarioModel e passar classes do obj

                //Verificação de dados do obj
                if (obj.Usuario == null)
                {
                    lbl_mensagem.Text = "Usuário ou Senha, não encontrado!";
                    lbl_mensagem.ForeColor = Color.Red;//lbl_mensagem cor vermelha
                    return;//finalizar
                }

                frm_cadUsuario frm = new frm_cadUsuario();

                this.Hide();//ocultar this=este frm_login
                frm.Show();//Mostrar o frm = frm_cadUsuario
                //this.Close();//Fechar o this = este frm_cadUsuario
            }
            catch (Exception ex)
            {//mensageem de erro ao logar
                MessageBox.Show("Erro ao Logar... " + ex.Message);
            }

            frm_cadUsuario form = new frm_cadUsuario(); 
        }
    }
}
