using AppVendas.Domain.Intefaces;
using AppVendas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppVendasContext _appVendasContext;

        public UnitOfWork(AppVendasContext appVendasContext)
        {
            _appVendasContext = appVendasContext;
        }

        public bool Commit()
        {
            return _appVendasContext.SaveChanges() > 0;
        }
    }
}
