using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Models;
using AppVendas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {

        protected AppVendasContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(AppVendasContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }


        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Remover(Guid id)
        {
            var entity = DbSet.Find(id);

            DbSet.Remove(entity);

            SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterTodosPaginado(int s, int t)
        {
            return DbSet.Take(t).Skip(s);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
