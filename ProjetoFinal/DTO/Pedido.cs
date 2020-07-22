using System;
using System.Collections.Generic;

namespace ProjetoFinal.DTO
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public int TipoPagamentoId { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<PedidoDetalhamento> PedidoDetalhamentos { get; set; }
        public Pedido()
        {
            this.PedidoDetalhamentos = new List<PedidoDetalhamento>();
        }
    }
}
