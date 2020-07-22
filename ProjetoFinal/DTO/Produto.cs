using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinal.DTO
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal? PrecoUnitario { get; set; }
        public short? Estoque { get; set; }
        public bool Descontinuado { get; set; }

        public virtual ICollection<PedidoDetalhamento> PedidoDetalhamentos { get; set; }
        public Produto()
        {
            this.PedidoDetalhamentos = new List<PedidoDetalhamento>();
        }

    }
}
