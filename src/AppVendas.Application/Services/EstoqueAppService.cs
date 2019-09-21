using AppVendas.Application.Intefaces;
using AppVendas.Application.ViewModels;
using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppVendas.Application.Services
{
    public class EstoqueAppService : AppServicesBase, IEstoqueAppService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IEstoqueService _estoqueService;

        public EstoqueAppService(IEstoqueRepository estoqueAppService,
                                IEstoqueService estoqueService,
                                IUnitOfWork uow) : base(uow)
        {
            _estoqueRepository = estoqueAppService;
            _estoqueService = estoqueService;
        }


        public EstoqueViewModel Adicionar(EstoqueViewModel estoqueViewModel)
        {
            var estoque = Mapper.Map<Estoque>(estoqueViewModel);

            var estoqueReturn = _estoqueService.Adicionar(estoque);

            if (estoqueReturn.ValidationResult.IsValid)
            {
                if (!Commit())
                {
                    AdicionarErrosValidacao(estoque.ValidationResult, "Ocorreu um erro ao salvar no banco de dados.");

                }
            }

            estoqueViewModel.ValidationResult = estoqueReturn.ValidationResult;
            return estoqueViewModel;
        }

        public EstoqueViewModel Atualizar(EstoqueViewModel estoqueViewModel)
        {
            var estoque = Mapper.Map<Estoque>(estoqueViewModel);

            var estoqueReturn = _estoqueService.Atualizar(estoque);

            if (estoqueReturn.ValidationResult.IsValid)
            {
                if (!Commit())
                {
                    AdicionarErrosValidacao(estoque.ValidationResult, "Ocorreu um erro ao salvar no banco de dados.");

                }
            }

            estoqueViewModel.ValidationResult = estoqueReturn.ValidationResult;
            return estoqueViewModel;
        }

        public EstoqueViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<EstoqueViewModel>(_estoqueRepository.ObterPorId(id));
        }

        public IEnumerable<EstoqueViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<EstoqueViewModel>>(_estoqueRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _estoqueRepository.Remover(id);
        }

        public void Dispose()
        {
            _estoqueRepository.Dispose();
        }

    }
}
