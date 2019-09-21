using AppVendas.Domain.Validations.Produtos;
using System;

namespace AppVendas.Domain.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Guid CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; } //Propriedade de navegaçao do EF.  

        public override bool EhValido() 
        {
            ValidationResult = new ProdutoConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
