using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Domain.Specifications.Categorias;
using DomainValidation.Validation;


namespace AppVendas.Domain.Validations.Categorias
{
    public class CategoriaRemocaoOkValidation : Validator<Categoria>
    {

        public CategoriaRemocaoOkValidation(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            var remocaoCategoria = new VerificaRemocaoCategoria(produtoRepository, categoriaRepository);

            Add("remocaoCategoria", new Rule<Categoria>(remocaoCategoria, "A categoria não pode ser removido, pois está sendo utilizado por um produto."));
        }

    }
}
