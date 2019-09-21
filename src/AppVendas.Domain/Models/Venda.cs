using AppVendas.Domain.Validations.Vendas;
using System;
using System.Collections.Generic;

namespace AppVendas.Domain.Models
{
    public class Venda : Entity
    {

        public int? Quantidade { get; set; }

        public DateTime DataVenda { get; set; }

        public Guid ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new VendaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
