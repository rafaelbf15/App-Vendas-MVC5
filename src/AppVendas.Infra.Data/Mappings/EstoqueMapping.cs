using AppVendas.Domain.Models;
using System.Data.Entity.ModelConfiguration;


namespace AppVendas.Infra.Data.Mappings
{
    public class EstoqueMapping : EntityTypeConfiguration<Estoque>
    {

        public EstoqueMapping()
        {

            HasKey(e => e.Id);

            HasRequired(e => e.Produto)
                .WithMany()
                .HasForeignKey(e => e.ProdutoId);

            ToTable("Estoques");
        }
    }
}
