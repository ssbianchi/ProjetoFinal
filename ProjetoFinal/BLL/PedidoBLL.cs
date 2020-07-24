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
        public static void ExcluirPedido()
        {
            try
            {
                var pedido = new Pedido();
                LoadClientePorCliente();
                var check = false;
                do
                {
                    WriteLine("Favor informar o Id do Pedido:");
                    var resposta = ReadLine();
                    if (Helpers.Helpers.IsNumeric(resposta.ToString()))
                    {
                        pedido = PedidoDAL.GetPedidoComId(int.Parse(resposta.ToString()));
                        if (pedido != null)
                            check = true;
                    }
                } while (!check);

                ConsoleKeyInfo respostaSN;
                check = false;
                do
                {
                    WriteLine($"Deseja excluir pedido do cliente {pedido.Cliente.Nome}? (S/N)");
                    respostaSN = ReadKey(true);
                    check = !((respostaSN.Key == ConsoleKey.S) || (respostaSN.Key == ConsoleKey.N));
                } while (check);
                switch (respostaSN.Key)
                {
                    case ConsoleKey.S:
                        WriteLine("Sim");
                        PedidoDAL.DeletePedido(pedido);
                        break;
                    case ConsoleKey.N:
                        WriteLine("Não");
                        break;
                }

                WriteLine($"PEDIDO DO CLIENTE {pedido.Cliente.Nome} DELETADO COM SUCESSO!");

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void EditarPedido()
        {
            throw new NotImplementedException();
        }
        public static void LoadTodosPedidos()
        {
            var pedidoDetalhamento = PedidoDAL.GetTodosPedidos();

            WriteLine("{0, -3} {1,-20} {2,-20} {3,10} ", "Id", "Cliente", "DataPedido", "TipoPagamento");
            foreach (var pedido in pedidoDetalhamento)
            {
                WriteLine("{0:000} {1, -20} {2,-20} {3,10} ", pedido.PedidoId, pedido.Cliente.Nome, pedido.DataPedido, pedido.TipoPagamento.Nome);
                WriteLine("----------------------------------------------------------");
                WriteLine("{0,-20} {1,-20} {2,10} {3,14} {4,14}", "Produto", "Qtd", "Preço Unitário", "Desconto", "Preço Total");

                foreach (var item in pedido.PedidoDetalhamentos)
                    WriteLine("{0, -20} {1,-20} {2,10} {3,14} {4,14}", item.Produto.Nome, item.QtdProduto, item.Produto.PrecoUnitario.Value.ToString("C"), item.Desconto, item.PrecoTotal.ToString("C"));


                WriteLine("----------------------------------------------------------");
                WriteLine();
            }
        }
        public static void LoadClientePorData()
        {
            WriteLine($"Favor informar a DATA DO PEDIDO:");
            var dataPedido = ReadLine();

            var pedidoDetalhamento = PedidoDAL.GetPedidosPorData(DateTime.Parse(dataPedido));

            WriteLine("{0, -3} {1,-20} {2,-20} {3,10} ", "Id", "Cliente", "DataPedido", "TipoPagamento");
            foreach (var pedido in pedidoDetalhamento)
            {
                WriteLine("{0:000} {1, -20} {2,-20} {3,10} ", pedido.PedidoId, pedido.Cliente.Nome, pedido.DataPedido, pedido.TipoPagamento.Nome);
                WriteLine("----------------------------------------------------------");
                WriteLine("{0,-20} {1,-20} {2,10} {3,14} {4,14}", "Produto", "Qtd", "Preço Unitário", "Desconto", "Preço Total");

                foreach (var item in pedido.PedidoDetalhamentos)
                    WriteLine("{0, -20} {1,-20} {2,10} {3,14} {4,14}", item.Produto.Nome, item.QtdProduto, item.Produto.PrecoUnitario.Value.ToString("C"), item.Desconto, item.PrecoTotal.ToString("C"));


                WriteLine("----------------------------------------------------------");
                WriteLine();
            }
        }
        public static void LoadClientePorCliente()
        {
            WriteLine($"Favor informar o NOME DO CLIENTE:");
            var nomeCliente = ReadLine();

            var pedidoDetalhamento = PedidoDAL.GetPedidosPorNomeCliente(nomeCliente);

            WriteLine("{0, -3} {1,-20} {2,-20} {3,10} ", "Id", "Cliente", "DataPedido", "TipoPagamento");
            foreach (var pedido in pedidoDetalhamento)
            {
                WriteLine("{0:000} {1, -20} {2,-20} {3,10} ", pedido.PedidoId, pedido.Cliente.Nome, pedido.DataPedido, pedido.TipoPagamento.Nome);
                WriteLine("----------------------------------------------------------");
                WriteLine("{0,-20} {1,-20} {2,10} {3,14} {4,14}", "Produto", "Qtd", "Preço Unitário", "Desconto", "Preço Total");

                foreach (var item in pedido.PedidoDetalhamentos)
                    WriteLine("{0, -20} {1,-20} {2,10} {3,14} {4,14}", item.Produto.Nome, item.QtdProduto, item.Produto.PrecoUnitario.Value.ToString("C"), item.Desconto, item.PrecoTotal.ToString("C"));


                WriteLine("----------------------------------------------------------");
                WriteLine();
            }
        }
    }
}
