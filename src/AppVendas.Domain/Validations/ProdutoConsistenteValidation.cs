using AppVendas.Domain.Models;
using AppVendas.Domain.Specifications;
using DomainValidation.Validation;


namespace AppVendas.Domain.Validations.Produtos
{
    public class ProdutoConsistenteValidation : Validator<Produto>
    {

        public ProdutoConsistenteValidation()
        {
            var NomeProduto = new GenericSpecification<Produto>(p => !string.IsNullOrWhiteSpace(p.Nome));
            var CategoriaProduto = new GenericSpecification<Produto>(p => p.CategoriaId != null);

            Add("NomeProduto", new Rule<Produto>(NomeProduto, "O campo Nome deve ser preenhcido."));
            Add("CategoriaProduto", new Rule<Produto>(CategoriaProduto, "Selecione a categoria do produto."));
        }

    }
}
