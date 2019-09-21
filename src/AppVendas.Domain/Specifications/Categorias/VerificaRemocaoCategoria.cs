using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Specifications.Categorias
{
    public class VerificaRemocaoCategoria : ISpecification<Categoria>
    {

        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public VerificaRemocaoCategoria(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }


        public bool IsSatisfiedBy(Categoria categoria)
        {
            var categoriaProduto = _produtoRepository.ObterTodos().FirstOrDefault(p => p.CategoriaId == categoria.Id);

            return categoriaProduto == null;
        }
    }
}
