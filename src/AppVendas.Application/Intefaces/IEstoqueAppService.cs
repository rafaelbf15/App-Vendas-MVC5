using AppVendas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Application.Intefaces
{
    public interface IEstoqueAppService : IDisposable
    {
        EstoqueViewModel Adicionar(EstoqueViewModel estoqueViewModel);

        EstoqueViewModel Atualizar(EstoqueViewModel estoqueViewModel);

        IEnumerable<EstoqueViewModel> ObterTodos();

        EstoqueViewModel ObterPorId(Guid id);

        void Remover(Guid id);
    }
}
