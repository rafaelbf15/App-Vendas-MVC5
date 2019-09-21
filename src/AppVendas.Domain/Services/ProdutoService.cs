using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto Adicionar(Produto produto)
        {
            if (!produto.EhValido()) return produto;

            if (produto.ValidationResult.IsValid) _produtoRepository.Adicionar(produto);

            return produto;
        }

        public Produto Atualizar(Produto produto)
        {
            if (!produto.EhValido()) return produto;

            if (produto.ValidationResult.IsValid) _produtoRepository.Atualizar(produto);

            return produto;
        }

        public void Remover(Guid id)
        {
            _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
