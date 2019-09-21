using AppVendas.Domain.Models;
using AppVendas.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AppVendas.Infra.Data.Context;

namespace AppVendas.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(AppVendasContext context) : base(context) { }
    
        public override Produto ObterPorId(Guid id)
        {
            return Db.Produtos.AsNoTracking().Include("Categoria").FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Produto> ObterPorNome(string nome)
        {
            return Buscar(p => p.Nome.Contains(nome)).ToList();
        }

        public IEnumerable<Produto> ObterPorDescricao(string descricao)
        {
            return Buscar(p => p.Descricao.Contains(descricao)).ToList();
        }

        public override IEnumerable<Produto> ObterTodos()
        {
            return Db.Produtos.AsNoTracking().Include("Categoria").ToList();
        }

    }
}
