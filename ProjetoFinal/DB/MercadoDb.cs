using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjetoFinal.DTO;
using System.Linq;

namespace ProjetoFinal.DB
{
    public class MercadoDb : DbContext
    {
        //ConnectionString
        protected readonly string _connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ProjetoFinalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //ConfigureConnectionString
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Cliente
            builder.Entity<Cliente>().Property(a => a.Nome).IsRequired().HasMaxLength(150);
            builder.Entity<Cliente>().Property(a => a.CPF).IsRequired().HasMaxLength(14);
            builder.Entity<Cliente>().Property(a => a.DataNascimento).IsRequired();

            //EnderecoCliente
            builder.Entity<ClienteEndereco>().Property(a => a.Logradouro).IsRequired().HasMaxLength(150);
            builder.Entity<ClienteEndereco>().Property(a => a.Numero).IsRequired();
            builder.Entity<ClienteEndereco>().Property(a => a.Complemento).IsRequired(false).HasMaxLength(150);
            builder.Entity<ClienteEndereco>().Property(a => a.Bairro).IsRequired().HasMaxLength(50);
            builder.Entity<ClienteEndereco>().Property(a => a.Cidade).IsRequired().HasMaxLength(50);
            builder.Entity<ClienteEndereco>().Property(a => a.Estado).IsRequired().HasMaxLength(2);
            builder.Entity<ClienteEndereco>().Property(a => a.CEP).IsRequired().HasMaxLength(9);

            //Produto
            builder.Entity<Produto>().Property(a => a.Nome).IsRequired().HasMaxLength(150);
            builder.Entity<Produto>().Property(a => a.PrecoUnitario).IsRequired(false).HasColumnType("money");
            builder.Entity<Produto>().Property(a => a.Estoque).IsRequired(false);
            builder.Entity<Produto>().Property(a => a.Descontinuado).IsRequired();

            //Pedido
            //builder.Entity<TipoPagamento>().HasOne<Pedido>(e => e.Pedido).WithOne(ca => ca.TipoPagamento).HasForeignKey<Pedido>(ca => ca.TipoPagamentoId);
            builder.Entity<Pedido>().Property(a => a.DataPedido).IsRequired();


            //Tipo Pagamento
            builder.Entity<TipoPagamento>().Property(a => a.Nome).IsRequired();

            //Pedido Detalhamento
            builder.Entity<PedidoDetalhamento>().HasKey(dp => new { dp.PedidoId, dp.ProdutoId });
            builder.Entity<PedidoDetalhamento>().Property(a => a.QtdProduto).IsRequired();
            builder.Entity<PedidoDetalhamento>().Property(a => a.Desconto).IsRequired(false);
            builder.Entity<PedidoDetalhamento>().Property(a => a.PrecoTotal).IsRequired().HasColumnType("money");
        }

        #region Tables
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteEndereco> ClienteEnderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<TipoPagamento> TipoPagamentos { get; set; }
        public DbSet<PedidoDetalhamento> PedidoDetalhamentos { get; set; }
        #endregion
    }
}
