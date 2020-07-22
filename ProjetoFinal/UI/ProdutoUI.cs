using ProjetoFinal.BLL;
using static System.Console;

namespace ProjetoFinal.UI
{
    public class ProdutoUI
    {
        public static void ProdutoOptions()
        {
            var backApp = false;

            while (!backApp)
            {
                Clear();
                WriteLine("Produto - Você deseja:\r");
                WriteLine("\t1 - Cadastrar");
                WriteLine("\t2 - Editar");
                WriteLine("\t3 - Excluir");
                WriteLine("\t4 - Listar Todos os Produtos");
                WriteLine("\t5 - Procurar um Produto");
                WriteLine("\t-----------------------------------");
                WriteLine("\t0 - Voltar para o menu principal\n");

                Write("Opção: ");
                switch (ReadLine())
                {
                    case "0":
                        return;
                    case "1":
                        ProdutoBLL.CadastrarProduto();
                        break;
                    case "2":
                        ProdutoBLL.EditarProduto();
                        break;
                    case "3":
                        ProdutoBLL.ExcluirProduto();
                        break;
                    case "4":
                        ProdutoBLL.ListarTodosProduto();
                        break;
                    case "5":
                        ProdutoBLL.ListarProdutoComNome();
                        break;
                    default:
                        WriteLine("Opção não encontrada!");
                        break;
                }
                if (ReadLine() == "0")
                    backApp = true;
            }
        }
    }
}
