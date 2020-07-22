using ProjetoFinal.DAL;
using ProjetoFinal.DTO;
using System;
using static System.Console;

namespace ProjetoFinal.BLL
{
    public class ProdutoBLL
    {
        public static void CadastrarProduto()
        {
            try
            {
                WriteLine("Nome:");
                var nome = ReadLine();

                WriteLine("Preco Unitario:");
                var precoUnitario = ReadLine();

                WriteLine("Qtd Total Estoque:");
                var estoque = ReadLine();

                WriteLine("Descontinuado (S/N):");
                var respostaSN = ReadKey(true);
                var descontinuado = false;

                switch (respostaSN.Key)
                {
                    case ConsoleKey.S:
                        WriteLine("Sim");
                        descontinuado = true;
                        break;
                    case ConsoleKey.N:
                        WriteLine("Não");
                        break;
                }

                var produto = new Produto { Nome = nome, PrecoUnitario = decimal.Parse(precoUnitario), Estoque = short.Parse(estoque), Descontinuado = descontinuado };

                ProdutoDAL.InsertProduto(produto);

                WriteLine("PRODUTO CADASTRADO COM SUCESSO!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditarProduto()
        {
            try
            {
                var produto = new Produto();

                ListarTodosProduto();

                var check = false;
                do
                {
                    WriteLine("Favor informar o Id do Produto:");
                    var resposta = ReadLine();
                    if (Helpers.Helpers.IsNumeric(resposta.ToString()))
                    {
                        produto = ProdutoDAL.GetProdutoComId(int.Parse(resposta.ToString()));
                        if (produto != null)
                            check = true;
                    }

                } while (!check);

                WriteLine($"Antigo Nome: {produto.Nome}");
                Write("Novo: ");
                var newNome = ReadLine();
                if (!string.IsNullOrWhiteSpace(newNome))
                    produto.Nome = newNome;

                WriteLine($"Antigo Preço Unitário: {produto.PrecoUnitario.Value.ToString("C")}");
                Write("Novo: ");
                var newPrecoUnitario = ReadLine();
                if (!string.IsNullOrWhiteSpace(newPrecoUnitario))
                    produto.PrecoUnitario = decimal.Parse(newPrecoUnitario);

                WriteLine($"Antigo Estoque: {produto.Estoque}");
                Write("Novo: ");
                var newEstoque = ReadLine();
                if (!string.IsNullOrWhiteSpace(newEstoque))
                    produto.PrecoUnitario = short.Parse(newEstoque);


                WriteLine(string.Format("Antigo Descontinuado (S/N): {0}", produto.Descontinuado == false ? "N" : "S"));
                Write("Novo: ");
                var newDescontinuado = ReadLine();
                var descontinuado = false;
                if (!string.IsNullOrWhiteSpace(newDescontinuado))
                {
                    switch (newDescontinuado)
                    {
                        case "S":
                            WriteLine("Sim");
                            descontinuado = true;
                            break;
                        case "N":
                            WriteLine("Não");
                            break;
                    }
                }

                ProdutoDAL.UpdateProduto(produto);

                Write("PRODUTO EDITADO COM SUCESSO!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ExcluirProduto()
        {
            try
            {
                var produto = new Produto();

                ListarTodosProduto();
                var check = false;
                do
                {
                    WriteLine("Favor informar o Id do Produto:");
                    var resposta = ReadLine();
                    if (Helpers.Helpers.IsNumeric(resposta.ToString()))
                    {
                        produto = ProdutoDAL.GetProdutoComId(int.Parse(resposta.ToString()));
                        if (produto != null)
                            check = true;
                    }
                } while (!check);

                ConsoleKeyInfo respostaSN;
                check = false;
                do
                {
                    WriteLine($"Deseja excluir o produto {produto.Nome}? (S/N)");
                    respostaSN = ReadKey(true);
                    check = !((respostaSN.Key == ConsoleKey.S) || (respostaSN.Key == ConsoleKey.N));
                } while (check);
                switch (respostaSN.Key)
                {
                    case ConsoleKey.S:
                        WriteLine("Sim");
                        ProdutoDAL.DeleteProduto(produto);
                        break;
                    case ConsoleKey.N:
                        WriteLine("Não");
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ListarTodosProduto()
        {
            try
            {
                var produtos = ProdutoDAL.GetTodosProdutos();

                WriteLine("{0,-3} {1,-20} {2,10} {3,14} {4,14}", "Id", "Nome", "Preço Unitário", "Qtd Estoque", "Descontinuado");

                foreach (var item in produtos)
                    WriteLine("{0:000} {1,-20} {2,10} {3,14} {4,14}", item.ProdutoId, item.Nome, item.PrecoUnitario.Value.ToString("C"), item.Estoque == null ? 0 : item.Estoque.Value, item.Descontinuado == false ? "N" : "S");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ListarProdutoComNome()
        {
            try
            {
                WriteLine("Favor informar o nome do produto que deseja pesquisar:");
                var produtoName = ReadLine();

                var produtos = ProdutoDAL.GetProdutoComNome(produtoName);

                WriteLine("{0,-3} {1,-20} {2,10} {3,14} {4,14}", "Id", "Nome", "Preço Unitário", "Qtd Estoque", "Descontinuado");

                foreach (var item in produtos)
                    WriteLine("{0:000} {1,-20} {2,10} {3,14} {4,14}", item.ProdutoId, item.Nome, item.PrecoUnitario.Value.ToString("C"), item.Estoque == null ? 0 : item.Estoque.Value, item.Descontinuado == false ? "N" : "S");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}
