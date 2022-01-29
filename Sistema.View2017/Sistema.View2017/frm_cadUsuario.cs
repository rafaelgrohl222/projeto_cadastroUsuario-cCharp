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
    public partial class frm_cadUsuario : Form
    {
        UsuarioEnt objTabela = new UsuarioEnt();

        public frm_cadUsuario()
        {
            InitializeComponent();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            opc = "Novo";//passa valor p/ variavel
            iniciarOpc();//executar
        }
        private string opc = "";

        //Metodo iniciarOpc();
        private void iniciarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "Salvar":
                    try
                    {
                        objTabela.Nome = txt_nome.Text;
                        objTabela.Usuario = txt_usuario.Text;
                        objTabela.Senha = txt_senha.Text;

                        int x = UsuarioModel.Inserir(objTabela);//passando dados da objTabela p/ UsuarioModel

                        if(x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário [ {0} ] FOI INSERIDO! ", txt_nome.Text));//string.Format converter
                        }
                        else
                        {
                            MessageBox.Show("[NÃO INSERIDO!]");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um ERRO ao [SALVAR] " + ex.Message);
                    }
                    break;

                case "Excluir":
                    break;

                case "Editar":
                    break;
            }
        }

        //Metodo HabilitarCampos();
        private void HabilitarCampos()
        {
            txt_nome.Enabled = true;
            txt_usuario.Enabled = true;
            txt_senha.Enabled = true;
        }

        //Metodo LimparCampos();
        private void LimparCampos()
        {
            txt_nome.Text = "";
            txt_usuario.Text = "";
            txt_senha.Text = "";
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            iniciarOpc();
            ListarGridUsuario();//Litar ao salvar
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            opc = "Excluir";
            iniciarOpc();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            opc = "Editar";
            iniciarOpc();
        }
        
        //Método GridView Usuário
        private void ListarGridUsuario()
        {
            try
            {
                //Objeto tipo List<UsuarioEnt> pertence
                List<UsuarioEnt>lista = new List<UsuarioEnt>();//Listar usuario Entidade
                lista = new UsuarioModel().Lista();//passando dados da list p/ UsuarioModel()
                gridUsuario.AutoGenerateColumns = false;//Não gerar colunas auto (só quando existir)
                gridUsuario.DataSource = lista;//DataSource recebe lista e mostra
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao listar Dados! " + ex.Message);
            }
        }
        //2 cliques no formulário: Carregar a lista quando entrar
        private void frm_cadUsuario_Load(object sender, EventArgs e)
        {
            ListarGridUsuario();//Carregar a lista quando entrar
        }
        


        //Propriedades da GridView inserido auto: DataBindings/DataSource

    }
}
