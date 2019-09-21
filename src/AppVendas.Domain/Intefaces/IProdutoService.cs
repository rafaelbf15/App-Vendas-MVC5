using AppVendas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Intefaces
{
    public interface IProdutoService : IDisposable
    {
        Produto Adicionar(Produto produto);

        Produto Atualizar(Produto produto);

        void Remover(Guid id);

    }
}
