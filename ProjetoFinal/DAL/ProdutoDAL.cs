using ProjetoFinal.DB;
using ProjetoFinal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoFinal.DAL
{
    public class ProdutoDAL
    {
        public static void InsertProduto(Produto produto)
        {
            try
            {
                using var db = new MercadoDb();

                db.Add<Produto>(produto);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateProduto(Produto produto)
        {
            try
            {
                using var db = new MercadoDb();

                db.Update<Produto>(produto);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteProduto(Produto produto)
        {
            try
            {
                using var db = new MercadoDb();

                db.Remove<Produto>(produto);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Produto> GetTodosProdutos()
        {
            try
            {
                using var db = new MercadoDb();
                return db.Produtos.OrderBy(a => a.Nome).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Produto GetProdutoComId(int id)
        {
            try
            {
                using var db = new MercadoDb();

                return db.Produtos.FirstOrDefault(a => a.ProdutoId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<Produto> GetProdutoComNome(string produtoName)
        {
            try
            {
                using var db = new MercadoDb();
                return db.Produtos.Where(a => a.Nome.Contains(produtoName)).OrderBy(a => a.Nome).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
