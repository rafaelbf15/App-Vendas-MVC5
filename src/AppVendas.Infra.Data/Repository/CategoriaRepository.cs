using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Infra.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {

        public CategoriaRepository(AppVendasContext context) : base(context) { }

        public IEnumerable<Categoria> ObterPorNome(string nome)
        {
            return Buscar(c => c.Nome.Contains(nome)).ToList();
        }
    }
}
