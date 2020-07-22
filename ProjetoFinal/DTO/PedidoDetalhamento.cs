﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinal.DTO
{
    public class PedidoDetalhamento
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int QtdProduto { get; set; }
        public decimal? Desconto { get; set; }
        public decimal PrecoTotal { get; set; }
    }
}
