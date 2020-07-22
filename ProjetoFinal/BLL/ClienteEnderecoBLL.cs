using ProjetoFinal.DAL;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ProjetoFinal.BLL
{
    public class ClienteEnderecoBLL
    {
        public static List<ClienteEndereco> CadastrarClienteEndereco(string nomeCliente)
        {
            var enderecoList = new List<ClienteEndereco>();
            try
            {
                var exitMeth = false;
                while (!exitMeth)
                {
                    Clear();
                    WriteLine($"Cliente '{nomeCliente}' - Endereço:\r");
                    WriteLine("Logradouro:");
                    var logradouro = ReadLine();

                    WriteLine("Numero:");
                    var numero = int.Parse(ReadLine());

                    WriteLine("Complemento");
                    var complemento = ReadLine();

                    WriteLine("Bairro");
                    var bairro = ReadLine();

                    WriteLine("Cidade");
                    var cidade = ReadLine();

                    WriteLine("Estado");
                    var estado = ReadLine();

                    WriteLine("CEP");
                    var cep = ReadLine();

                    var endereco = new ClienteEndereco
                    {
                        Logradouro = logradouro,
                        Numero = numero,
                        Complemento = complemento,
                        Bairro = bairro,
                        Cidade = cidade,
                        Estado = estado,
                        CEP = cep
                    };

                    enderecoList.Add(endereco);

                    ConsoleKeyInfo resposta;
                    var check = false;
                    do
                    {
                        WriteLine($"O cliente '{nomeCliente}' possui mais endereços para cadastrar? (S/N)");
                        resposta = ReadKey(true);
                        check = !((resposta.Key == ConsoleKey.S) || (resposta.Key == ConsoleKey.N));
                    } while (check);
                    switch (resposta.Key)
                    {
                        case ConsoleKey.S:
                            WriteLine("Sim");
                            break;
                        case ConsoleKey.N:
                            WriteLine("Não");
                            return enderecoList;
                    }
                }
                return enderecoList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void EditarClienteEndereco(int clienteId, string nomeCliente)
        {
            try
            {
                var clienteEndereco = new ClienteEndereco();

                var clienteEnderecoList = ListarClienteEnderecoComClienteId(clienteId);

                var check = false;
                do
                {
                    WriteLine($"Favor informar o Id do Endereço do Cliente '{nomeCliente}':");
                    var resposta = ReadLine();
                    if (Helpers.Helpers.IsNumeric(resposta.ToString()))
                    {
                        clienteEndereco = ClienteEnderecoDAL.GetClienteEnderecoComClienteEnderecoId(int.Parse(resposta.ToString()));
                        if (clienteEndereco != null)
                            check = true;
                    }

                } while (!check);

                //Write($"Nome: {cliente.Nome}");
                //SetCursorPosition(6, CursorTop);
                //cliente.Nome = ReadLine();

                WriteLine($"Antigo Logradouro: {clienteEndereco.Logradouro}");
                Write("Novo: ");
                var newLogradouro = ReadLine();
                if (!string.IsNullOrWhiteSpace(newLogradouro))
                    clienteEndereco.Logradouro = newLogradouro;

                WriteLine($"Antigo Numero: {clienteEndereco.Numero}");
                Write("Novo: ");
                var newNumero = ReadLine();
                if (!string.IsNullOrWhiteSpace(newNumero))
                    clienteEndereco.Numero = int.Parse(newNumero);

                WriteLine($"Antigo Complemento: {clienteEndereco.Complemento}");
                Write("Novo: ");
                var newComplemento = ReadLine();
                if (!string.IsNullOrWhiteSpace(newComplemento))
                    clienteEndereco.Complemento = newComplemento;

                WriteLine($"Antigo Bairro: {clienteEndereco.Bairro}");
                Write("Novo: ");
                var newBairro = ReadLine();
                if (!string.IsNullOrWhiteSpace(newBairro))
                    clienteEndereco.Bairro = newBairro;

                WriteLine($"Antigo Cidade: {clienteEndereco.Cidade}");
                Write("Novo: ");
                var newCidade = ReadLine();
                if (!string.IsNullOrWhiteSpace(newCidade))
                    clienteEndereco.Cidade = newCidade;

                WriteLine($"Antigo Estado: {clienteEndereco.Estado}");
                Write("Novo: ");
                var newEstado = ReadLine();
                if (!string.IsNullOrWhiteSpace(newEstado))
                    clienteEndereco.Estado = newEstado;

                WriteLine($"Antigo CEP: {clienteEndereco.CEP}");
                Write("Novo: ");
                var newCEP = ReadLine();
                if (!string.IsNullOrWhiteSpace(newCEP))
                    clienteEndereco.CEP = newCEP;

                ClienteEnderecoDAL.UpdateClienteEndereco(clienteEndereco);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void ExcluirTodosClienteEndereco(int clienteId)
        {
            try
            {
                var clienteEndereco = ListarClienteEnderecoComClienteId(clienteId);

                ClienteEnderecoDAL.DeleteClienteEndereco(clienteEndereco);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ClienteEndereco> ListarClienteEnderecoComClienteId(int clienteId)
        {
            try
            {
               var enderecoCliente = ClienteEnderecoDAL.GetClienteEnderecoComClienteId(clienteId);

                WriteLine("{0,-3} {1,-20} {2,10} {3,21} {4,3} {5,10} {6,10} {7,10}", "Id", "Logradouro", "Numero", "Complemento", "Bairro", "Cidade", "Estado", "CEP");

                foreach (var item in enderecoCliente.OrderBy(a => a.Logradouro))
                    WriteLine("{0:000} {1,-20} {2,10} {3,21} {4,3} {5,10} {6,10} {7,10}", item.ClienteEnderecoId, item.Logradouro, item.Numero, item.Complemento, item.Bairro, item.Cidade, item.Estado, item.CEP);

                return enderecoCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
    }

}
