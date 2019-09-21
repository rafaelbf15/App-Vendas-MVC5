using AppVendas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Application.Intefaces
{
    public interface ICategoriaAppService : IDisposable
    {

        CategoriaViewModel Adicionar(CategoriaViewModel categoriaViewModel);

        CategoriaViewModel Atualizar(CategoriaViewModel categoriaViewModel);

        CategoriaViewModel ObterPorId(Guid id);

        CategoriaViewModel ObterPorNome(string nome);

        IEnumerable<CategoriaViewModel> ObterTodos();

        CategoriaViewModel Remover(Guid id);
    }
}
