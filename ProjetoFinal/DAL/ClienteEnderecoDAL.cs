using ProjetoFinal.DB;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFinal.DAL
{
    public class ClienteEnderecoDAL
    {
        public static void UpdateClienteEndereco(ClienteEndereco clienteEndereco)
        {
            try
            {
                using var db = new MercadoDb();

                db.Update<ClienteEndereco>(clienteEndereco);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteClienteEndereco(List<ClienteEndereco> clienteEndereco)
        {
            try
            {
                using var db = new MercadoDb();

                db.ClienteEnderecos.RemoveRange(clienteEndereco);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ClienteEndereco> GetTodosClienteEnderecos()
        {
            try
            {
                using var db = new MercadoDb();

                var result = db.ClienteEnderecos.ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<ClienteEndereco> GetClienteEnderecoComClienteId(int clienteId)
        {
            try
            {
                using var db = new MercadoDb();

                return db.Clientes.Where(a => a.ClienteId == clienteId).SelectMany(a => a.ClienteEnderecos).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ClienteEndereco GetClienteEnderecoComClienteEnderecoId(int clienteEnderecoId)
        {
            try
            {
                using var db = new MercadoDb();

                return db.ClienteEnderecos.FirstOrDefault(a => a.ClienteEnderecoId == clienteEnderecoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ClienteEndereco> GetClienteEnderecoComNomeCliente(string nomeCliente)
        {
            try
            {
                using var db = new MercadoDb();

                var clientes = db.Clientes.Where(a => a.Nome.Contains(nomeCliente)).ToList();

                return clientes.SelectMany(a => a.ClienteEnderecos).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
