
using AppVendas.Domain.Validations.Categorias;

namespace AppVendas.Domain.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new CategoriaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
