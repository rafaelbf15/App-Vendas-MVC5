using AppVendas.Domain.Validations.Estoques;
using System;

namespace AppVendas.Domain.Models
{
    public class Estoque : Entity
    {

        public int? Quantidade { get; set; }

        public Guid ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new EstoqueConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
