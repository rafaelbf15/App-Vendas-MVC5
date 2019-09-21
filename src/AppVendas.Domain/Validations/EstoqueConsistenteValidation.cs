using AppVendas.Domain.Models;
using AppVendas.Domain.Specifications;
using DomainValidation.Validation;


namespace AppVendas.Domain.Validations.Estoques
{
    public class EstoqueConsistenteValidation : Validator<Estoque>
    {

        public EstoqueConsistenteValidation()
        {
            var ProdutoSelecionado = new GenericSpecification<Estoque>(e => e.ProdutoId != null);

            Add("ProdutoSelecionado", new Rule<Estoque>(ProdutoSelecionado, "O produto deve ser selecionado."));
        }

    }
}
