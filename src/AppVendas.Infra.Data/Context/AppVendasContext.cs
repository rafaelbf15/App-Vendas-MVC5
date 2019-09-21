using AppVendas.Domain.Models;
using AppVendas.Infra.Data.Mappings;
using DomainValidation.Validation;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace AppVendas.Infra.Data.Context
{
    public class AppVendasContext : DbContext
    {
        public AppVendasContext() : base("DefaultConnection")
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        public DbSet<Estoque> Estoques { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));


            modelBuilder.Configurations.Add(new ProdutoMapping());
            modelBuilder.Configurations.Add(new CategoriaMapping());
            modelBuilder.Configurations.Add(new VendaMapping());
            modelBuilder.Configurations.Add(new EstoqueMapping());

            modelBuilder.Ignore<ValidationResult>();


            base.OnModelCreating(modelBuilder);
        }


    }
}
