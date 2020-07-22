using ProjetoFinal.DAL;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ProjetoFinal.BLL
{
    public class PedidoBLL
    {
        public static void CadastrarPedido()
        {
            try
            {
                var cliente = ClienteBLL.LoadClientePedido();

                WriteLine("----------------------------------------------------------");
                WriteLine();

                var pedidoDetalhamento = PedidoDetalhamentoBLL.LoadPedidoDetalhamento(cliente.Nome);

                WriteLine("----------------------------------------------------------");
                WriteLine();

                LoadClienteComprando(cliente.Nome, pedidoDetalhamento);

                WriteLine("----------------------------------------------------------");
                WriteLine();

                TipoPagamento tipoPagamento = TipoPagamentoBLL.LoadTipoPagamento(cliente.Nome);

                var pedido = PedidoDAL.InsertPedido(new Pedido() { DataPedido = DateTime.Now, TipoPagamentoId = tipoPagamento.TipoPagamentoId, ClienteId = cliente.ClienteId });

                if (pedido != null)
                {
                    pedidoDetalhamento.ForEach(a => a.PedidoId = pedido.PedidoId);
                    PedidoDetalhamentoDAL.InsertPedidoDetalhamento(pedidoDetalhamento);

                    WriteLine("COMPRA EFETUADA COM SUCESSO!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void LoadClienteComprando(string cliente, List<PedidoDetalhamento> pedidoDetalhamento)
        {
            var produtos = ProdutoDAL.GetTodosProdutos();

            WriteLine($"Cliente: {cliente} -> Esta comprando:");

            WriteLine("{0,-20} {1,-20} {2,10} {3,14} {4,14}", "Produto", "Qtd", "Preço Unitário", "Desconto", "Preço Total");

            foreach (var item in pedidoDetalhamento.OrderBy(a => a.QtdProduto))
            {
                var produto = produtos.First(a => a.ProdutoId == item.ProdutoId);
                WriteLine("{0, -20} {1,-20} {2,10} {3,14} {4,14}", produto.Nome, item.QtdProduto, produto.PrecoUnitario.Value.ToString("C"), item.Desconto.Value.ToString("C"), item.PrecoTotal.ToString("C"));
            }

        }
        
        private static void LoadClientePorData()
        {
            throw new NotImplementedException();
        }

        private static void LoadClientePorCliente()
        {
            throw new NotImplementedException();
        }

        private static void LoadTodosPedidos()
        {
            throw new NotImplementedException();
        }

        private static void ExcluirPedido()
        {
            throw new NotImplementedException();
        }

        private static void EditarPedido()
        {
            throw new NotImplementedException();
        }
    }
}
