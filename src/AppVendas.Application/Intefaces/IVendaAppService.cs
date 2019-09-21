using AppVendas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Application.Intefaces
{
    public interface IVendaAppService : IDisposable
    {
        VendaViewModel Adicionar(VendaViewModel vendaViewModel);

        VendaViewModel Atualizar(VendaViewModel vendaViewModel);

        VendaViewModel ObterPorId(Guid id);

        IEnumerable<VendaViewModel> ObterTodos();

        void Remover(Guid id);
    }
}
