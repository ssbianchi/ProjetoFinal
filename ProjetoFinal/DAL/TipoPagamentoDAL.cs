using ProjetoFinal.DB;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFinal.DAL
{
    public class TipoPagamentoDAL
    {
        public static List<TipoPagamento> GetTodosTipoPagamentos()
        {
            try
            {
                using var db = new MercadoDb();
                return db.TipoPagamentos.OrderBy(a => a.Nome).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static TipoPagamento GetTipoPagamentoComId(int tipoPagamentoId)
        {
            try
            {
                using var db = new MercadoDb();
                return db.TipoPagamentos.FirstOrDefault(a => a.TipoPagamentoId == tipoPagamentoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
