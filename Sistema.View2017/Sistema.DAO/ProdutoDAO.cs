using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidade;
using System.Data;

namespace Sistema.DAO
{
    public class ProdutoDAO
    {
        public int Inserir(ProdutosEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                //Endereço BD (Cadeia de conexão) inserir "Default"
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                //Comandos BD
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                //Abrir / Iniciar a conexão
                con.Open();

                //Código comando SQL_Server (INSERT)
                cn.CommandText = "INSERT INTO tb_produtoss ([produto], [descricao], [valor], [quantidades]) VALUES (@produto, @descricao, @valor, @quantidades)";//(CAMPOS) VALUES (VALORES)

                //Parametros de consultas
                cn.Parameters.Add("produto", SqlDbType.NVarChar).Value = objTabela.Produto;//passando valor q/ vem objTabela do campo
                cn.Parameters.Add("descricao", SqlDbType.NVarChar).Value = objTabela.Descricao;//passando valor q/ vem objTabela do campo
                cn.Parameters.Add("valor", SqlDbType.Decimal).Value = objTabela.Valor;//passando valor q/ vem objTabela do campo
                cn.Parameters.Add("quantidades", SqlDbType.Int).Value = objTabela.Quantidades;//passando valor q/ vem objTabela do campo

                //Associando cn.Command con.Connection
                cn.Connection = con;

                //Executar Comando BD
                int qtd = cn.ExecuteNonQuery();//recebe registro em 0 / 1
                Console.Write(qtd);
                return qtd;
            }
        }

        public List<ProdutosEnt> Buscar(ProdutosEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                //Endereço BD
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                //Comandos BD
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                //Abrir a conexão
                con.Open();

                //Código BD - Busca Igual                        -> nome = @nome
                //cn.CommandText = "SELECT * from tb_usuarios WHERE nome = @nome";//Busca todos registro da tabela identico

                //Código BD - Busca Aproximada                  ->     LIKE
                cn.CommandText = "SELECT * from tb_produtoss WHERE produto LIKE @produto";//Busca todos registro da tabela aproximada

                //Parâmetro - Busca Igual
                //cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome;//passando valor q/ vem objTabela do campo

                //Parâmetro -                                                       Aprocimada "%"
                cn.Parameters.Add("produto", SqlDbType.VarChar).Value = objTabela.Produto + "%";//Busca Aprocimada

                //Associar cn.Command con.Connection
                cn.Connection = con;
                //Consultas
                SqlDataReader dr;// consultas
                List<ProdutosEnt> lista = new List<ProdutosEnt>();

                dr = cn.ExecuteReader();//recebe o que vier da conexão e execute

                if (dr.HasRows)//existe dados na linhas
                {
                    //Faça leitura dos dados enquanto tiver no dataReader
                    while (dr.Read())
                    {
                        ProdutosEnt dado = new ProdutosEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);//convert ToInt32
                        dado.Produto = Convert.ToString(dr["produto"]);//convert ToSrting
                        dado.Descricao = Convert.ToString(dr["descricao"]);//convert ToSrting
                        dado.Valor = Convert.ToDecimal(dr["valor"]);//convert ToDecimal
                        dado.Quantidades = Convert.ToInt32(dr["quantidades"]);//convert ToInt32

                        lista.Add(dado);//add os dados 
                    }
                }
                return lista;
            }
        }

        public int Editar(ProdutosEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                //Endereço BD (Cadeia de conexão) inserir "Default"
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                //Comandos BD
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                //Abrir / Iniciar a conexão
                con.Open();

                //Código comando SQL_Server (UPDATE)
                //                ATUALIZAR tabela   ONDE NOME = PARAMETRO                                          QUANDO 
                cn.CommandText = "UPDATE tb_produtoss SET produto = @produto, descricao = @descricao, valor = @valor, quantidades = @quantidades where id = @id";//(CAMPOS) VALUES (VALORES)

                //Parametros de editar
                cn.Parameters.Add("produto", SqlDbType.NVarChar).Value = objTabela.Produto;//passando valor q/ vem objTabela do campo
                cn.Parameters.Add("descricao", SqlDbType.NVarChar).Value = objTabela.Descricao;//passando valor q/ vem objTabela do campo
                cn.Parameters.Add("valor", SqlDbType.Decimal).Value = objTabela.Valor;//passando valor q/ vem objTabela do campo
                cn.Parameters.Add("quantidades", SqlDbType.Int).Value = objTabela.Quantidades;//passando valor q/ vem objTabela do campo
                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;//passando valor q/ vem objTabela do campo

                //Associando cn.Command con.Connection
                cn.Connection = con;

                //Executar Comando BD
                int qtd = cn.ExecuteNonQuery();//recebe registro em 0 / 1
                Console.Write(qtd);
                return qtd;
            }
        }

        public int Excluir(ProdutosEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                //Endereço BD (Cadeia de conexão) inserir "Default"
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                //Comandos BD
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                //Abrir / Iniciar a conexão
                con.Open();

                //Código comando SQL_Server (DELETE)
                //                                        onde       parametro
                cn.CommandText = "DELETE FROM tb_produtoss where id = @id";

                //Parametros de delete
                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;

                //Associando cn.Command con.Connection
                cn.Connection = con;

                //Executar Comando BD
                int qtd = cn.ExecuteNonQuery();//recebe registro em 0 / 1
                Console.Write(qtd);
                return qtd;
            }
        }

        //Metodo List
        public List<ProdutosEnt> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                //Endereço BD
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                //Comandos BD
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                //Abrir a conexão
                con.Open();

                //Código BD
                cn.CommandText = "SELECT * from tb_produtoss ORDER BY id DESC";//Busca todos registro da tabela ordem alfabetica
                //Associar cn.Command con.Connection
                cn.Connection = con;
                //Consultas
                SqlDataReader dr;// consultas
                List<ProdutosEnt> lista = new List<ProdutosEnt>();

                dr = cn.ExecuteReader();//recebe o que vier da conexão e execute

                if (dr.HasRows)//existe dados na linhas
                {
                    //Faça leitura dos dados enquanto tiver no dataReader
                    while (dr.Read())
                    {
                        ProdutosEnt dado = new ProdutosEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);//convert ToInt32 inteiro
                        dado.Produto = Convert.ToString(dr["produto"]);//convert string
                        dado.Descricao = Convert.ToString(dr["descricao"]);//convert string
                        dado.Valor = Convert.ToDecimal(dr["valor"]);//convert Decimal
                        dado.Quantidades = Convert.ToInt32(dr["quantidades"]);////convert ToInt32 inteiro

                        lista.Add(dado);//add os dados 
                    }
                }
                return lista;
            }
        }
    }
}
