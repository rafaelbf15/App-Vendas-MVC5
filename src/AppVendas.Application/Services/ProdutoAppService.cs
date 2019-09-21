using AppVendas.Application.ViewModels;
using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Infra.Data.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;


namespace AppVendas.Application.Services
{
    public class ProdutoAppService : AppServicesBase, IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoRepository produtoRepository, 
                                    IProdutoService produtoService, 
                                    IUnitOfWork uow) : base(uow)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
        }
        
        public ProdutoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ProdutoViewModel>(_produtoRepository.ObterPorId(id));
        }

        public IEnumerable<ProdutoViewModel> ObterPorDescricao(string descricao)
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterPorDescricao(descricao));
        }

        public IEnumerable<ProdutoViewModel> ObterPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterPorNome(nome));
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterTodos());
        }

        public ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);

            var produtoReturn =  _produtoService.Adicionar(produto);

            if (produtoReturn.ValidationResult.IsValid)
            {
                if (!Commit())
                {
                    AdicionarErrosValidacao(produto.ValidationResult, "Ocorreu um erro ao salvar no banco de dados.");
                    
                }
            }

            produtoViewModel.ValidationResult = produtoReturn.ValidationResult;
            return produtoViewModel;
        }

        public ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);

            if (!produto.EhValido()) return produtoViewModel;

            var produtoReturn = _produtoService.Atualizar(produto);

            if (!Commit())
            {
                AdicionarErrosValidacao(produto.ValidationResult, "Ocorreu um erro ao salvar no banco de dados.");

            }

            produtoViewModel.ValidationResult = produtoReturn.ValidationResult;
            return produtoViewModel;
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
