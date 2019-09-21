using AppVendas.Domain.Models;
using System.Data.Entity.ModelConfiguration;


namespace AppVendas.Infra.Data.Mappings
{
    public class VendaMapping : EntityTypeConfiguration<Venda>
    {
        public VendaMapping()
        {
            HasKey(v => v.Id);

            HasRequired(v => v.Produto)
                .WithMany()
                .HasForeignKey(v => v.ProdutoId);

            ToTable("Vendas");
        }
    }
}
