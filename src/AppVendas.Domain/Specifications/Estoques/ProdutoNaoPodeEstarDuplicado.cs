using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Specifications.Estoques
{
    public class ProdutoNaoPodeEstarDuplicado : ISpecification<Estoque>
    {

        private readonly IEstoqueRepository _estoqueRepository;
        

        public ProdutoNaoPodeEstarDuplicado(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }
        public bool IsSatisfiedBy(Estoque estoque)
        {
            var produtoSelecionado = _estoqueRepository.ObterPorProdutoId(estoque.ProdutoId);

            return produtoSelecionado == null;
        }
    }
}
