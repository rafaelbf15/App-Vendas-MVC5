using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AppVendas.Infra.Data.Repository
{
    public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
    {

        public EstoqueRepository(AppVendasContext context) : base(context) { }


        public override IEnumerable<Estoque> ObterTodos()
        {
            return Db.Estoques.AsNoTracking().Include("Produto").ToList();
        }

        public Estoque ObterPorProdutoId(Guid produtoId)
        {
            return Db.Estoques.AsNoTracking().Include("Produto").FirstOrDefault(e => e.ProdutoId == produtoId);
        }
    }
}
