using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Domain.Validations.Estoques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public Estoque Adicionar(Estoque estoque)
        {
            if (!estoque.EhValido()) return estoque;

            estoque.ValidationResult = new EstoqueCadastroOkVvalidation(_estoqueRepository).Validate(estoque);

            if (estoque.ValidationResult.IsValid)

            _estoqueRepository.Adicionar(estoque);

            return estoque;

        }

        public Estoque Atualizar(Estoque estoque)
        {
            if (!estoque.EhValido()) return estoque;

            _estoqueRepository.Atualizar(estoque);

            return estoque;
        }

        public void RemoverQuantidadeProdutoEstoque(Guid produtoId, int quantidade)
        {
            var estoque = _estoqueRepository.ObterPorProdutoId(produtoId);
            estoque.Quantidade = estoque.Quantidade - quantidade;
            Atualizar(estoque);
        }

        public void Dispose()
        {
            _estoqueRepository.Dispose();
        }
    }
}
