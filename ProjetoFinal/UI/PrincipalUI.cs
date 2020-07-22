using static System.Console;

namespace ProjetoFinal.UI
{
    public class PrincipalUI
    {
        public static void MenuPrincipal()
        {
            var endApp = false;

            while (!endApp)
            {
                Clear();

                WriteLine("Digite a opção desejada:\r");
                WriteLine("------------------------\n");
                WriteLine("1 - Cliente");
                WriteLine("2 - Produto");
                WriteLine("3 - Pedido");
                WriteLine("0 - Sair");
                WriteLine();

                Write("Opção: ");
                switch (ReadLine())
                {
                    case "0":
                        return;
                    case "1":
                        ClienteUI.ClienteOptions();
                        break;
                    case "2":
                        ProdutoUI.ProdutoOptions();
                        break;
                    case "3":
                        PedidoUI.PedidoOptions();
                        break;
                    default:
                        WriteLine("Opção não encontrada!");
                        break;
                }

                if (ReadLine() == "0")
                    endApp = true;
            }
        }
    }
}
