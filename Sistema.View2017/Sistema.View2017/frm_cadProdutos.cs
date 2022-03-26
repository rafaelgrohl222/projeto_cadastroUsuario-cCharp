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
    public partial class frm_cadProdutos : Form
    {
        ProdutosEnt objTabela = new ProdutosEnt();

        public frm_cadProdutos()
        {
            InitializeComponent();
        }

        //Método GridView Usuário
        private void ListarGridProdutos()
        {
            try
            {
                //Objeto tipo List<UsuarioEnt> pertence
                List<ProdutosEnt> lista = new List<ProdutosEnt>();//Listar usuario Entidade
                lista = new ProdutoModel().Lista();//passando dados da list p/ UsuarioModel()
                gridProdutos.AutoGenerateColumns = false;//Não gerar colunas auto (só quando existir)
                gridProdutos.DataSource = lista;//DataSource recebe lista e mostra
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao listar Dados! " + ex.Message);
            }
        }
        //ListarGridiProdutos
        private void frm_cadProdutos_Load(object sender, EventArgs e)
        {
            ListarGridProdutos();
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
                        objTabela.Produto = txt_produto.Text;
                        objTabela.Descricao = txt_descricao.Text;
                        objTabela.Valor = Convert.ToDecimal(txt_valor.Text);
                        objTabela.Quantidades = Convert.ToInt32(txt_quantidades.Text);

                        int x = ProdutoModel.Inserir(objTabela);//passando dados da objTabela p/ UsuarioModel

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto [ {0} ] FOI INSERIDO! ", txt_produto.Text));//string.Format converter
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
                        objTabela.Id = Convert.ToInt32(txt_codigoProduto.Text);

                        int x = ProdutoModel.Excluir(objTabela);//passando dados da objTabela p/ UsuarioModel

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto [ {0} ] FOI EXCLUIDO! ", txt_produto.Text));//string.Format converter
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
                        objTabela.Id = Convert.ToInt32(txt_codigoProduto.Text);
                        objTabela.Produto = txt_produto.Text;
                        objTabela.Descricao = txt_descricao.Text;
                        objTabela.Valor = Convert.ToDecimal(txt_valor.Text);
                        objTabela.Quantidades = Convert.ToInt32(txt_quantidades.Text);

                        int x = ProdutoModel.Editar(objTabela);//passando dados da objTabela p/ UsuarioModel

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto [ {0} ] FOI EDITADO! ", txt_produto.Text));//string.Format converter
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
                        objTabela.Produto = txt_buscarProdutos.Text;

                        //Objeto tipo List<UsuarioEnt> pertence
                        List<ProdutosEnt> lista = new List<ProdutosEnt>();//Listar usuario Entidade
                        lista = new ProdutoModel().Buscar(objTabela);//passando dados da list p/ UsuarioModel()

                        gridProdutos.AutoGenerateColumns = false;//Não gerar colunas auto (só quando existir)
                        gridProdutos.DataSource = lista;//DataSource recebe lista e mostra
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
            txt_produto.Enabled = true;
            txt_descricao.Enabled = true;
            txt_valor.Enabled = true;
            txt_quantidades.Enabled = true;
        }

        //Metodo DesabilitarCampo
        private void DesabilitarCampos()
        {
            txt_produto.Enabled = false;
            txt_descricao.Enabled = false;
            txt_valor.Enabled = false;
            txt_quantidades.Enabled = false;
        }

        //Metodo LimparCampos();
        private void LimparCampos()
        {
            txt_produto.Text = "";
            txt_descricao.Text = "";
            txt_valor.Text = "";
            txt_quantidades.Text = "";
            txt_codigoProduto.Text = "";
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if(txt_produto.Text == "")
            {
                MessageBox.Show("Campo vazio! Inserir (Nome) do Produto, para cadastrar!");
                return;
            }
            if (txt_descricao.Text == "")
            {
                MessageBox.Show("Campo vazio! Inserir (Descriçãoa) do Produto, para cadastrar!");
                return;
            }
            if (txt_valor.Text == "")
            {
                MessageBox.Show("Campo vazio! Inserir o (Valor) do Produto, para cadastrar!");
                return;
            }
            if (txt_quantidades.Text == "")
            {
                MessageBox.Show("Campo vazio! Inserir (Quantidades) do Produto, para cadastrar!");
                return;
            }

            opc = "Salvar";
            iniciarOpc();
            ListarGridProdutos();//Litar dados ao cadastrar ao salvar na gridUsuario
            LimparCampos();//Limpar dados do campo ao salvar na grid
            DesabilitarCampos();//DesabilitarCampos ao clicar no botão "salvar"
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            //Selecionar a grid antes para excluir
            if (txt_codigoProduto.Text == "")
            {
                MessageBox.Show("Selecionar um registro, na tabela para EXCLUIR!");
                return;
            }

            opc = "Excluir";
            iniciarOpc();
            ListarGridProdutos();//Atualizar gridUsuario ao excluir
            DesabilitarCampos();//DesabilitarCampo ao excluir 
            LimparCampos();//LimparCampo ao excluir
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            //Selecionar a grid antes para editar
            if (txt_codigoProduto.Text == "")
            {
                MessageBox.Show("Selecionar um registro, na tabela para EDITAR!");
                return;
            }

            opc = "Editar";
            iniciarOpc();
            ListarGridProdutos();
            DesabilitarCampos();
            LimparCampos();
        }

        private void gridProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //campo                       linha Atual na posição [0]
            txt_codigoProduto.Text = gridProdutos.CurrentRow.Cells[0].Value.ToString();
            txt_produto.Text = gridProdutos.CurrentRow.Cells[1].Value.ToString();
            txt_descricao.Text = gridProdutos.CurrentRow.Cells[2].Value.ToString();
            txt_valor.Text = gridProdutos.CurrentRow.Cells[3].Value.ToString();
            txt_quantidades.Text = gridProdutos.CurrentRow.Cells[4].Value.ToString();
            HabilitarCampos();
        }
        //Toda vez campo estiver vazio ListarGridUsuario
        private void txt_buscarProdutos_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscarProdutos.Text == "")
            {
                ListarGridProdutos();
                return;//Busca dinâmica
            }
            //Busca dinâmica
            opc = "Buscar";
            iniciarOpc();
        }
        //btn_produtos
        private void btn_produtos_Click(object sender, EventArgs e)
        {
            frm_cadProdutos frm_prod = new frm_cadProdutos();
            this.Hide();
            frm_prod.Show();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            opc = "Buscar";
            iniciarOpc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_cadUsuario frm = new frm_cadUsuario();

            this.Close();
            frm.Show();
        }
    }
}
