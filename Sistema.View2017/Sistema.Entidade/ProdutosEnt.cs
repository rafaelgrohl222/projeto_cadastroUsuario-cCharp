using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidade
{
    public class ProdutosEnt
    {
        private int id;
        private string produto;
        private string descricao;
        private decimal valor;
        private int quantidades;

        public int Id { get => id; set => id = value; }
        public string Produto { get => produto; set => produto = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public int Quantidades { get => quantidades; set => quantidades = value; }
    }
}
