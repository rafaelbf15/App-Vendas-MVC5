using AppVendas.Domain.Models;
using System.Collections.Generic;

namespace AppVendas.Domain.Intefaces
{
    public interface ICategoriaRepository : IRepositoryRead<Categoria>, IRepositoryWrite<Categoria>
    {
        IEnumerable<Categoria> ObterPorNome(string nome);
    }
}
