using AppVendas.Domain.Models;
using AppVendas.Domain.Specifications;
using DomainValidation.Validation;

namespace AppVendas.Domain.Validations.Categorias
{
    public class CategoriaConsistenteValidation : Validator<Categoria>
    {
        public CategoriaConsistenteValidation()
        {
            var NomeCategoria = new GenericSpecification<Categoria>(c => !string.IsNullOrWhiteSpace(c.Nome));

            Add("NomeCategoria", new Rule<Categoria>(NomeCategoria, "O campo Nome deve ser preenhcido."));
        }

    }
}
