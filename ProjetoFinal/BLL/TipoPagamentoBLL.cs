using ProjetoFinal.DAL;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjetoFinal.BLL
{
    public class TipoPagamentoBLL
    {
        public static TipoPagamento LoadTipoPagamento(string cliente)
        {
            var tipoPagamentosList = TipoPagamentoDAL.GetTodosTipoPagamentos();
            WriteLine("{0,-3} {1,-20}", "Id", "Tipo de Pagamento");

            foreach (var item in tipoPagamentosList)
                WriteLine("{0:000} {1,-20}", item.TipoPagamentoId, item.Nome);

            var tipoPagamento = new TipoPagamento();
            var check = false;
            do
            {
                WriteLine($"Cliente: {cliente} -> Favor informar o Id do Produto:");
                var resposta = ReadLine();
                if (Helpers.Helpers.IsNumeric(resposta.ToString()))
                {
                    tipoPagamento = TipoPagamentoDAL.GetTipoPagamentoComId(int.Parse(resposta.ToString()));
                    if (tipoPagamento != null)
                        check = true;
                }

            } while (!check);
            return tipoPagamento;
        }
    }
}
