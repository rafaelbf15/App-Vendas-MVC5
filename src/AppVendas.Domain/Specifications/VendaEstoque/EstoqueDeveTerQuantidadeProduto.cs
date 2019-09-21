using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using DomainValidation.Interfaces.Specification;

namespace AppVendas.Domain.Specifications.VendaEstoque
{
    public class EstoqueDeveTerQuantidadeProduto : ISpecification<Venda>
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IVendaRepository _vendaRepository;

        public EstoqueDeveTerQuantidadeProduto(IEstoqueRepository estoqueRepository, IVendaRepository vendaRepository)
        {
            _estoqueRepository = estoqueRepository;
            _vendaRepository = vendaRepository;
        }

        public bool IsSatisfiedBy(Venda venda)
        {
            var quantidadeProdutoEstoque = _estoqueRepository.ObterPorProdutoId(venda.ProdutoId).Quantidade;

            return venda.Quantidade <= quantidadeProdutoEstoque;
        }

        
    }
}
