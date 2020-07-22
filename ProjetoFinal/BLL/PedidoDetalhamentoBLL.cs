using ProjetoFinal.DAL;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ProjetoFinal.BLL
{
    public class PedidoDetalhamentoBLL
    {
        public static List<PedidoDetalhamento> LoadPedidoDetalhamento(string cliente)
        {
            var pedidoDetalhamento = new List<PedidoDetalhamento>();
            var check = false;

            ConsoleKeyInfo respostaSN;
            do
            {
                var produtoList = new List<Produto>();
                do
                {
                    WriteLine($"Cliente: {cliente} -> Favor informar o produto:");
                    var nomeProduto = ReadLine();
                    if (!string.IsNullOrWhiteSpace(nomeProduto))
                    {
                        produtoList.AddRange(ProdutoDAL.GetProdutoComNome(nomeProduto));
                        if (produtoList != null)
                            check = true;
                    }

                } while (!check);

                if (produtoList.Count > 1)
                {
                    check = false;
                    do
                    {
                        WriteLine($"Cliente: {cliente} -> Favor informar o Id do Produto:");
                        var resposta = ReadLine();
                        if (Helpers.Helpers.IsNumeric(resposta.ToString()))
                        {
                            produtoList.Add(ProdutoDAL.GetProdutoComId(int.Parse(resposta.ToString())));
                            if (produtoList != null)
                                check = true;
                        }

                    } while (!check);
                }

                var produto = produtoList.First();

                //Produto ainda em estoque?
                if (produto.Estoque == 0)
                {
                    WriteLine($"Cliente: {cliente} -> O produto '{produto.Nome}' está com o estoque zerado!");
                    return null;
                }

                //Produto ainda em descontinuado?
                if (produto.Descontinuado)
                {
                    WriteLine($"Cliente: {cliente} -> O produto '{produto.Nome}' foi descontinuado!");
                    return null;
                }

                WriteLine($"Cliente: {cliente} -> Favor informar a Quantida do Produto '{produto.Nome}':");
                var qtdProduto = ReadLine();
                if (short.Parse(qtdProduto) > produto.Estoque.Value)
                {
                    WriteLine($"Cliente: {cliente} -> A quantidade escolhida é maior que o estoque!");
                    return null;
                }

                //WriteLine("Favor informar o Desconto (%):");
                //var desconto = ReadLine();
                var precoTotal = (produto.PrecoUnitario.Value * int.Parse(qtdProduto));// decimal.Parse(desconto) ;
                WriteLine($"Cliente: {cliente} -> Preço total: {precoTotal}");

                pedidoDetalhamento.Add(new PedidoDetalhamento() { ProdutoId = produto.ProdutoId, Desconto = 0, QtdProduto = int.Parse(qtdProduto), PrecoTotal = precoTotal });

                check = false;
                WriteLine($"Cliente: {cliente} -> Deseja adicionar mais algum produto? (S/N)");
                respostaSN = ReadKey(true);

                if (((respostaSN.Key == ConsoleKey.S) || (respostaSN.Key == ConsoleKey.N)))
                    if (respostaSN.Key == ConsoleKey.N)
                        check = true;
            } while (!check);

            return pedidoDetalhamento;

        }
    }
}
