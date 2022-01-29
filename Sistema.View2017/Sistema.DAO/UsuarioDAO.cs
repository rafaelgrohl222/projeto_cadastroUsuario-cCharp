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
    public class UsuarioDAO
    {
        public int Inserir(UsuarioEnt objTabela)
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
                cn.CommandText = "INSERT INTO tb_usuarios ([nome], [usuario], [senha]) VALUES (@nome, @usuario, @senha)";//(CAMPOS) VALUES (VALORES)

                //Parametros de consultas
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome;//passando valor q/ vem objTabela do campo
                cn.Parameters.Add("usuario", SqlDbType.VarChar).Value = objTabela.Usuario;//passando valor q/ vem objTabela do campo
                cn.Parameters.Add("senha", SqlDbType.VarChar).Value = objTabela.Senha;//passando valor q/ vem objTabela do campo

                //Associando cn.Command con.Connection
                cn.Connection = con;

                //Executar Comando BD
                int qtd = cn.ExecuteNonQuery();//recebe registro em 0 / 1
                Console.Write(qtd);
                return qtd;
            }
        }

        //Metodo List
        public List<UsuarioEnt> Lista()
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
                cn.CommandText = "SELECT * from tb_usuarios ORDER BY Nome DESC";//Busca todos registro da tabela ordem alfabetica
                //Associar cn.Command con.Connection
                cn.Connection = con;
                //Consultas
                SqlDataReader dr;// consultas
                List<UsuarioEnt> lista = new List<UsuarioEnt>();

                dr = cn.ExecuteReader();//recebe o que vier da conexão e execute

                if (dr.HasRows)//existe dados na linhas
                {
                    //Faça leitura dos dados enquanto tiver no dataReader
                    while (dr.Read())
                    {
                            UsuarioEnt dado = new UsuarioEnt();
                            dado.Id = Convert.ToInt32(dr["id"]);//convert ToInt32 inteiro
                            dado.Nome = Convert.ToString(dr["nome"]);//convert string
                            dado.Usuario = Convert.ToString(dr["usuario"]);//convert string
                            dado.Senha = Convert.ToString(dr["senha"]);//convert string

                            lista.Add(dado);//add os dados 
                    } 
                }
                return lista;
            }
        }
    }
}
