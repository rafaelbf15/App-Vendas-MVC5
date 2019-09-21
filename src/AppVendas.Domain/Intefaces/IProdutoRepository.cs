using AppVendas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Intefaces
{
    public interface IProdutoRepository : IRepositoryRead<Produto>, IRepositoryWrite<Produto>
    {
        IEnumerable<Produto> ObterPorNome(string nome);

        IEnumerable<Produto> ObterPorDescricao(string descricao);

    }
}
