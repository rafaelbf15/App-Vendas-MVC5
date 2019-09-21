using AppVendas.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace AppVendas.Infra.Data.Mappings
{
    public class ProdutoMapping : EntityTypeConfiguration<Produto>
    {
        public ProdutoMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Descricao)
                .HasMaxLength(500);

            HasRequired(p => p.Categoria)
                .WithMany()
                .HasForeignKey(c => c.CategoriaId);
                

            ToTable("Produtos");
        }
    }
}
