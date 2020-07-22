using ProjetoFinal.DTO;
using ProjetoFinal.DAL;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFinal.BLL
{
    public class ClienteBLL
    {
        public static void CadastrarCliente()
        {
            try
            {
                WriteLine("Nome:");
                var nome = ReadLine();

                WriteLine("CPF:");
                var cpf = ReadLine();

                WriteLine("Data de Nascimento:");
                var dataNascimento = DateTime.ParseExact(ReadLine(), "dd/MM/yyyy", null);

                var endereco = ClienteEnderecoBLL.CadastrarClienteEndereco(nome);
                var cliente = new Cliente { Nome = nome, CPF = cpf, DataNascimento = dataNascimento, ClienteEnderecos = endereco };

                ClienteDAL.InsertCliente(cliente);

                WriteLine("CLIENTE CADASTRADO COM SUCESSO!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void EditarCliente()
        {
            try
            {
                var cliente = new Cliente();

                LoadTodosCliente();

                var check = false;
                do
                {
                    WriteLine("Favor informar o Id do Cliente:");
                    var resposta = ReadLine();
                    if (Helpers.Helpers.IsNumeric(resposta.ToString()))
                    {
                        cliente = ClienteDAL.GetClienteComId(int.Parse(resposta.ToString()));
                        if (cliente != null)
                            check = true;
                    }

                } while (!check);

                //Write($"Nome: {cliente.Nome}");
                //SetCursorPosition(6, CursorTop);
                //cliente.Nome = ReadLine();

                WriteLine($"Antigo Nome: {cliente.Nome}");
                Write("Novo: ");
                var newNome = ReadLine();
                if (!string.IsNullOrWhiteSpace(newNome))
                    cliente.Nome = newNome;

                WriteLine($"Antigo CPF: {cliente.CPF}");
                Write("Novo: ");
                var newCPF = ReadLine();
                if (!string.IsNullOrWhiteSpace(newCPF))
                    cliente.CPF = newCPF;

                WriteLine($"Antigo Data de Nascimento: {cliente.DataNascimento.ToString("dd/MM/yyyy")}");
                Write("Novo: ");
                var newDataNascimento = ReadLine();
                if (!string.IsNullOrWhiteSpace(newDataNascimento))
                    cliente.DataNascimento = DateTime.ParseExact(newDataNascimento, "dd/MM/yyyy", null);

                ClienteEnderecoBLL.EditarClienteEndereco(cliente.ClienteId, cliente.Nome);

                ClienteDAL.UpdateCliente(cliente);

                WriteLine("CLIENTE EDITADO COM SUCESSO!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ExcluirCliente()
        {
            try
            {
                var cliente = new Cliente();

                LoadTodosCliente();
                var check = false;
                do
                {
                    WriteLine("Favor informar o Id do Cliente:");
                    var resposta = ReadLine();
                    if (Helpers.Helpers.IsNumeric(resposta.ToString()))
                    {
                        cliente = ClienteDAL.GetClienteComId(int.Parse(resposta.ToString()));
                        if (cliente != null)
                            check = true;
                    }
                } while (!check);

                ConsoleKeyInfo respostaSN;
                check = false;
                do
                {
                    WriteLine($"Deseja excluir o cliente {cliente.Nome}? (S/N)");
                    respostaSN = ReadKey(true);
                    check = !((respostaSN.Key == ConsoleKey.S) || (respostaSN.Key == ConsoleKey.N));
                } while (check);
                switch (respostaSN.Key)
                {
                    case ConsoleKey.S:
                        WriteLine("Sim");
                        ClienteEnderecoBLL.ExcluirTodosClienteEndereco(cliente.ClienteId);
                        ClienteDAL.DeleteCliente(cliente);
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
        public static void LoadTodosCliente()
        {
            try
            {
                var clienteList = ClienteDAL.GetTodosClientes();

                foreach (var item in clienteList)
                {
                    WriteLine();
                    WriteLine("{0,-3} {1,-20} {2,10} {3,14}", "Id", "Nome", "Data Nascimento", "CPF");
                    WriteLine("{0:000} {1,-20} {2,10} {3,30}", item.ClienteId, item.Nome, item.DataNascimento.ToString("dd/MM/yyyy"), item.CPF);

                    WriteLine("----------------------------------------------------------");
                    ClienteEnderecoBLL.ListarClienteEnderecoComClienteId(item.ClienteId);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Cliente> LoadClienteComNome()
        {
            try
            {
                WriteLine("Favor informar o nome do cliente:");
                var nomeCliente = ReadLine();

                var clientes = ClienteDAL.GetClienteComNome(nomeCliente);

                WriteLine("{0,-3} {1,-20} {2,10} {3,14}", "Id", "Nome", "Data Nascimento", "CPF");

                foreach (var item in clientes.OrderBy(a => a.Nome))
                    WriteLine("{0:000} {1,-20} {2,10} {3,30}", item.ClienteId, item.Nome, item.DataNascimento.ToString("dd/MM/yyyy"), item.CPF);

                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Cliente LoadClientePedido()
        {
            var clienteList = new List<Cliente>();

            var check = false;
            do
            {
                WriteLine("Favor informar o nome do cliente:");
                var nomeCliente = ReadLine();
                if (!string.IsNullOrWhiteSpace(nomeCliente))
                {
                    clienteList.AddRange(ClienteDAL.GetClienteComNome(nomeCliente));
                    if (clienteList.Count != 0 && clienteList != null)
                        check = true;
                }

            } while (!check);

            if (clienteList.Count > 1)
            {
                check = false;
                do
                {
                    WriteLine("Favor informar o Id do Cliente:");
                    var resposta = ReadLine();
                    if (Helpers.Helpers.IsNumeric(resposta.ToString()))
                    {
                        clienteList.Add(ClienteDAL.GetClienteComId(int.Parse(resposta.ToString())));
                        if (clienteList != null)
                            check = true;
                    }

                } while (!check);
            }

            return clienteList.First();
        }
    }
}
