using AppVendas.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace AppVendas.Application.Services
{
    public interface IProdutoAppService : IDisposable
    {
        ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel);

        ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel);

        ProdutoViewModel ObterPorId(Guid id);

        IEnumerable<ProdutoViewModel> ObterTodos();

        IEnumerable<ProdutoViewModel> ObterPorNome(string nome);

        IEnumerable<ProdutoViewModel> ObterPorDescricao(string descricao);

        void Remover(Guid id);
    }
}
