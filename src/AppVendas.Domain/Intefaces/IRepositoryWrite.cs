using AppVendas.Domain.Models;
using System;

namespace AppVendas.Domain.Intefaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity obj);

        void Atualizar(TEntity obj);

        void Remover(Guid id);

        int SaveChanges();

    }


}
