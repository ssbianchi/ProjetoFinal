using ProjetoFinal.DB;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;
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
    }
}
