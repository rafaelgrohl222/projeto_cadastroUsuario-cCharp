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
                    try
                    {
                        objTabela.Id =  Convert.ToInt32(txt_codigo.Text);

                        int x = UsuarioModel.Excluir(objTabela);//passando dados da objTabela p/ UsuarioModel

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário [ {0} ] FOI EXCLUIDO! ", txt_nome.Text));//string.Format converter
                        }
                        else
                        {
                            MessageBox.Show("[NÃO EXCLUIDO!]");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um ERRO ao [EXCLUIR] " + ex.Message);
                    }
                    break;

                case "Editar":
                    try
                    {
                        objTabela.Id = Convert.ToInt32(txt_codigo.Text);
                        objTabela.Nome = txt_nome.Text;
                        objTabela.Usuario = txt_usuario.Text;
                        objTabela.Senha = txt_senha.Text;

                        int x = UsuarioModel.Editar(objTabela);//passando dados da objTabela p/ UsuarioModel

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário [ {0} ] FOI EDITADO! ", txt_nome.Text));//string.Format converter
                        }
                        else
                        {
                            MessageBox.Show("[NÃO EDITADO!]");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um ERRO ao [EDITAR] " + ex.Message);
                    }
                    break;

                case "Buscar":
                    try
                    {
                        objTabela.Nome = txt_buscar.Text;

                        //Objeto tipo List<UsuarioEnt> pertence
                        List<UsuarioEnt> lista = new List<UsuarioEnt>();//Listar usuario Entidade
                        lista = new UsuarioModel().Buscar(objTabela);//passando dados da list p/ UsuarioModel()

                        gridUsuario.AutoGenerateColumns = false;//Não gerar colunas auto (só quando existir)
                        gridUsuario.DataSource = lista;//DataSource recebe lista e mostra
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERRO ao listar Dados! " + ex.Message);
                    }
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

        //Metodo DesabilitarCampo
        private void DesabilitarCampos()
        {
            txt_nome.Enabled = false;
            txt_usuario.Enabled = false;
            txt_senha.Enabled = false;
        }

        //Metodo LimparCampos();
        private void LimparCampos()
        {
            txt_nome.Text = "";
            txt_usuario.Text = "";
            txt_senha.Text = "";
            txt_codigo.Text = "";
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            iniciarOpc();
            ListarGridUsuario();//Litar dados ao cadastrar ao salvar na gridUsuario
            LimparCampos();//Limpar dados do campo ao salvar na grid
            DesabilitarCampos();//DesabilitarCampos ao clicar no botão "salvar"
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            //Selecionar a grid antes para excluir
            if(txt_codigo.Text == "")
            {
                MessageBox.Show("Selecionar um registro, na tabela para EXCLUIR!");
                return;
            }

            opc = "Excluir";
            iniciarOpc();
            ListarGridUsuario();//Atualizar gridUsuario ao excluir
            DesabilitarCampos();//DesabilitarCampo ao excluir 
            LimparCampos();//LimparCampo ao excluir
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            //Selecionar a grid antes para editar
            if (txt_codigo.Text == "")
            {
                MessageBox.Show("Selecionar um registro, na tabela para EDITAR!");
                return;
            }

            opc = "Editar";
            iniciarOpc();
            ListarGridUsuario();
            DesabilitarCampos();
            LimparCampos();
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
            ListarGridUsuario();//Carregar / exibir a lista quando entrar
        }

        //frm_cadUsuario/comportamento/SelectionModel/FullRowSelect - Seleção de toda linha
        //Exibir dados da linha no form - Propridades CellClick
        private void gridUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //campo                       linha Atual na posição [0]
            txt_codigo.Text = gridUsuario.CurrentRow.Cells[0].Value.ToString();
            txt_nome.Text = gridUsuario.CurrentRow.Cells[1].Value.ToString();
            txt_usuario.Text = gridUsuario.CurrentRow.Cells[2].Value.ToString();
            txt_senha.Text = gridUsuario.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
        }
        //Botão Buscar
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            opc = "Buscar";
            iniciarOpc();
        }
    }
}
