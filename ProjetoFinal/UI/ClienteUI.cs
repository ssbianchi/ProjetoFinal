using static System.Console;
using ProjetoFinal.BLL;

namespace ProjetoFinal.UI
{
    public class ClienteUI
    {
        public static void ClienteOptions()
        {
            var backApp = false;

            while (!backApp)
            {
                Clear();
                WriteLine("Cliente - Você deseja:\r");
                WriteLine("\t1 - Cadastrar");
                WriteLine("\t2 - Editar");
                WriteLine("\t3 - Excluir");
                WriteLine("\t4 - Listar Todos os Clientes");
                WriteLine("\t5 - Procurar um Cliente");
                WriteLine("\t-----------------------------------");
                WriteLine("\t0 - Voltar para o menu principal\n");

                Write("Opção: ");
                switch (ReadLine())
                {
                    case "0":
                        return;
                    case "1":
                        ClienteBLL.CadastrarCliente();
                        break;
                    case "2":
                        ClienteBLL.EditarCliente();
                        break;
                    case "3":
                        ClienteBLL.ExcluirCliente();
                        break;
                    case "4":
                        ClienteBLL.LoadTodosCliente();
                        break;
                    case "5":
                        ClienteBLL.LoadClienteComNome();
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
