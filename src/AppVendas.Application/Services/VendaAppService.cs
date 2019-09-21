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
    public class VendaAppService : AppServicesBase, IVendaAppService
    {

        private readonly IVendaRepository _vendaRepository;
        private readonly IVendaService _vendaService;

        public VendaAppService(IVendaRepository vendaRepository, IVendaService vendaService, IUnitOfWork uow) : base(uow)
        {
            _vendaRepository = vendaRepository;
            _vendaService = vendaService;
        }

        public IEnumerable<VendaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.ObterTodos());
        }

        public VendaViewModel Adicionar(VendaViewModel vendaViewModel)
        {
            var venda = Mapper.Map<Venda>(vendaViewModel);

            var produtoReturn = _vendaService.Adicionar(venda);

            if (produtoReturn.ValidationResult.IsValid)
            {
                if (!Commit())
                {
                    AdicionarErrosValidacao(venda.ValidationResult, "Ocorreu um erro ao salvar no banco de dados.");

                }
            }

            vendaViewModel.ValidationResult = produtoReturn.ValidationResult;
            return vendaViewModel;
        }

        public VendaViewModel Atualizar(VendaViewModel vendaViewModel)
        {
            var venda = Mapper.Map<Venda>(vendaViewModel);

            if (!venda.EhValido()) return vendaViewModel;

            var produtoReturn = _vendaService.Atualizar(venda);

            if (!Commit())
            {
                AdicionarErrosValidacao(venda.ValidationResult, "Ocorreu um erro ao salvar no banco de dados.");

            }

            vendaViewModel.ValidationResult = produtoReturn.ValidationResult;
            return vendaViewModel;
        }

        public VendaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<VendaViewModel>(_vendaRepository.ObterPorId(id)); 
        }

        public void Remover(Guid id)
        {
            _vendaService.Remover(id);
        }

        public void Dispose()
        {
            _vendaService.Dispose();
        }

    }
}
