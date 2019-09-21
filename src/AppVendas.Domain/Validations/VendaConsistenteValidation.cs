using AppVendas.Domain.Models;
using AppVendas.Domain.Specifications;
using DomainValidation.Validation;


namespace AppVendas.Domain.Validations.Vendas
{
    public class VendaConsistenteValidation : Validator<Venda>
    {

        public VendaConsistenteValidation()
        {
            var ProdutoSelecionado =  new GenericSpecification<Venda>(v => v.ProdutoId != null);
           
            Add("ProdutoSelecionado", new Rule<Venda>(ProdutoSelecionado, "O produto deve ser selecionado."));
        }

    }

}
