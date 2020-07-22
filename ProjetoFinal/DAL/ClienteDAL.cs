using ProjetoFinal.DB;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoFinal.DAL
{
    public class ClienteDAL
    {
        public static void InsertCliente(Cliente cliente)
        {
            try
            {
                using var db = new MercadoDb();

                db.Add<Cliente>(cliente);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void UpdateCliente(Cliente cliente)
        {
            try
            {
                using var db = new MercadoDb();

                db.Update<Cliente>(cliente);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteCliente(Cliente cliente)
        {
            try
            {
                using var db = new MercadoDb();

                db.Remove<Cliente>(cliente);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Cliente> GetTodosClientes()
        {
            try
            {
                using var db = new MercadoDb();
                return db.Clientes.OrderBy(a => a.Nome).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static Cliente GetClienteComId(int id)
        {
            try
            {
                using var db = new MercadoDb();

                return db.Clientes.FirstOrDefault(a => a.ClienteId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public static List<Cliente> GetClienteComNome(string nome)
        {
            try
            {
                using var db = new MercadoDb();
                return db.Clientes.Where(a => a.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
