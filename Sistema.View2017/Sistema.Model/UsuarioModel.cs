using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidade;
using Sistema.DAO;

namespace Sistema.Model
{
    public class UsuarioModel
    {
        public static int Inserir(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Inserir(objTabela);//passando dados da objTabela p/ UsuarioDAO
        }

        public List<UsuarioEnt> Lista()
        {
            return new UsuarioDAO().Lista();//passando dados da List p/ UsuarioDAO()
        }

        public UsuarioEnt Login(UsuarioEnt obj)
        {
            return new UsuarioDAO().Login(obj);
        }

        public static int Excluir(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Excluir(objTabela);
        }

        public static int Editar(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Editar(objTabela);
        }

        public List<UsuarioEnt> Buscar(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Buscar(objTabela);
        }
    }
}
