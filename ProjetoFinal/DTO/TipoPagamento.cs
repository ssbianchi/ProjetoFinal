using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinal.DTO
{
    public class TipoPagamento
    {
        public int TipoPagamentoId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
        public TipoPagamento()
        {
            this.Pedidos = new List<Pedido>();
        }
    }
}
