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
    }
}
