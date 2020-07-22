using Microsoft.EntityFrameworkCore;
using ProjetoFinal.DB;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoFinal.DAL
{
    public class PedidoDAL
    {
        public static Pedido InsertPedido(Pedido pedido)
        {
            try
            {
                using var db = new MercadoDb();

                db.Add<Pedido>(pedido);
                db.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Pedido> GetTodosPedidos()
        {
            using var db = new MercadoDb();

            return db.Pedidos.Include(a => a.PedidoDetalhamentos)
                                .ThenInclude(a => a.Produto)
                             .Include(a => a.TipoPagamento)
                             .Include(a => a.Cliente)
                             .OrderBy(a => a.DataPedido)
                             .ToList();
        }

        public static List<Pedido> GetPedidosPorData(DateTime dateTime)
        {
            using var db = new MercadoDb();

            return db.Pedidos.Include(a => a.PedidoDetalhamentos)
                                .ThenInclude(a => a.Produto)
                             .Include(a => a.TipoPagamento)
                             .Include(a => a.Cliente)
                             .OrderBy(a => a.DataPedido)
                             .Where(a => a.DataPedido == dateTime)
                             .ToList();
        }

        public static List<Pedido> GetPedidosPorNomeCliente(string nomeCliente)
        {
            using var db = new MercadoDb();

            return db.Pedidos.Include(a => a.PedidoDetalhamentos)
                                .ThenInclude(a => a.Produto)
                             .Include(a => a.TipoPagamento)
                             .Include(a => a.Cliente)
                             .OrderBy(a => a.DataPedido)
                             .Where(a => a.Cliente.Nome.Contains(nomeCliente))
                             .ToList();
        }
    }
}
