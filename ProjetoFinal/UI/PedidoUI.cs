using ProjetoFinal.BLL;
using static System.Console;

namespace ProjetoFinal.UI
{
    class PedidoUI
    {
        public static void PedidoOptions()
        {
            var backApp = false;

            while (!backApp)
            {
                Clear();
                WriteLine("Pedido - Você deseja:\r");
                WriteLine("\t1 - Cadastrar");
                WriteLine("\t2 - Editar");
                WriteLine("\t3 - Excluir");
                WriteLine("\t4 - Listar Todos os Pedidos");
                WriteLine("\t5 - Listar Pedidos pelo Cliente");
                WriteLine("\t6 - Listar Pedidos pela Data");
                WriteLine("\t-----------------------------------");
                WriteLine("\t0 - Voltar para o menu principal\n");

                Write("Opção: ");
                switch (ReadLine())
                {
                    case "0":
                        return;
                    case "1":
                        PedidoBLL.CadastrarPedido();
                        break;
                    case "2":
                        //EditarPedido();
                        break;
                    case "3":
                        //ExcluirPedido();
                        break;
                    case "4":
                        PedidoBLL.LoadTodosPedidos();
                        break;
                    case "5":
                        PedidoBLL.LoadClientePorCliente();
                        break;
                    case "6":
                        PedidoBLL.LoadClientePorData();
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
