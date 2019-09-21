using AppVendas.Application.Intefaces;
using AppVendas.Application.ViewModels;
using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Infra.Data.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Application.Services
{
    public class CategoriaAppService : AppServicesBase, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaAppService(ICategoriaService categoriaService,
                                ICategoriaRepository categoriaRepository,
                                IUnitOfWork uow) : base(uow)
        {
            _categoriaService = categoriaService;
            _categoriaRepository = categoriaRepository;
        }

        public CategoriaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<CategoriaViewModel>(_categoriaRepository.ObterPorId(id));
        }

        public CategoriaViewModel ObterPorNome(string nome)
        {
            return Mapper.Map<CategoriaViewModel>(_categoriaRepository.ObterPorNome(nome));
        }

        public IEnumerable<CategoriaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaRepository.ObterTodos());
        }

        public CategoriaViewModel Adicionar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = Mapper.Map<Categoria>(categoriaViewModel);

            if (!categoria.EhValido()) return categoriaViewModel;

            _categoriaRepository.Adicionar(categoria);

            if (!Commit())
            {
                AdicionarErrosValidacao(categoria.ValidationResult, "Ocorreu um erro ao salvar no banco de dados.");

            }

            return categoriaViewModel;

        }

        public CategoriaViewModel Atualizar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = Mapper.Map<Categoria>(categoriaViewModel);

            if (!categoria.EhValido()) return categoriaViewModel;

            _categoriaRepository.Atualizar(categoria);

            if (!Commit())
            {
                AdicionarErrosValidacao(categoria.ValidationResult, "Ocorreu um erro ao salvar no banco de dados.");

            }

            return categoriaViewModel;
        }

        public CategoriaViewModel Remover(Guid id)
        {
            var categoriaReturn = _categoriaService.Remover(id);

            var categoriaViewModel = Mapper.Map<CategoriaViewModel>(categoriaReturn);

            return categoriaViewModel;

        }

        public void Dispose()
        {
            _categoriaRepository.Dispose();
        }
    }
}
