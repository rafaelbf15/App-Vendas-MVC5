using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Domain.Specifications.Estoques;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Validations.Estoques
{
    public class EstoqueCadastroOkVvalidation : Validator<Estoque>
    {
        public EstoqueCadastroOkVvalidation(IEstoqueRepository estoqueRepository)
        {
            var produtoDuplicado = new ProdutoNaoPodeEstarDuplicado(estoqueRepository);

            Add("produtoDuplicado", new Rule<Estoque>(produtoDuplicado, "Produto já cadastradado no estoque."));
        }

    }
}
