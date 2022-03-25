using Sistema.DAO;
using Sistema.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{
    public class ProdutoModel
    {
        //Metodo Inserir
        public static int Inserir(ProdutosEnt objTabela)
        {
            return new ProdutoDAO().Inserir(objTabela);//passando dados da objTabela p/ UsuarioDAO
        }

        //Metodo Lista
        public List<ProdutosEnt> Lista()
        {
            return new ProdutoDAO().Lista();//passando dados da List p/ UsuarioDAO()
        }

        //Metodo Excluir
        public static int Excluir(ProdutosEnt objTabela)
        {
            return new ProdutoDAO().Excluir(objTabela);
        }

        //Metodo Editar
        public static int Editar(ProdutosEnt objTabela)
        {
            return new ProdutoDAO().Editar(objTabela);
        }

        //Metodo Buscar
        public List<ProdutosEnt> Buscar(ProdutosEnt objTabela)
        {
            return new ProdutoDAO().Buscar(objTabela);
        }
    }
}
