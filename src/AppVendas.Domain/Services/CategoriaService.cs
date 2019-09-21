using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Domain.Validations.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public CategoriaService(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public Categoria Remover(Guid id)
        {
            Categoria categoria = _categoriaRepository.ObterPorId(id);

            categoria.ValidationResult = new CategoriaRemocaoOkValidation(_produtoRepository, _categoriaRepository).Validate(categoria);

            if (categoria.ValidationResult.IsValid)
            _categoriaRepository.Remover(id);

            return categoria;
        }

        public void Dispose()
        {
            _categoriaRepository.Dispose();
        }

    }
}
