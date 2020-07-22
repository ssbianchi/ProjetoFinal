using ProjetoFinal.DB;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;

namespace ProjetoFinal.DAL
{
    public class PedidoDetalhamentoDAL
    {
        public static bool InsertPedidoDetalhamento(List<PedidoDetalhamento> pedidoDetalhamento)
        {
            try
            {
                using var db = new MercadoDb();

                db.AddRange(pedidoDetalhamento);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
