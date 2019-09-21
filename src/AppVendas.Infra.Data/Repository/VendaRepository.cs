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
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(AppVendasContext context) : base(context) { }

        public override IEnumerable<Venda> ObterTodos()
        {
            return Db.Vendas.AsNoTracking().Include("Produto").ToList();
        }

    }
}
