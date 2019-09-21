using AppVendas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Infra.Data.Mappings
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);

            ToTable("Categorias");

        }

    }
}
