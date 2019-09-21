using AppVendas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Domain.Intefaces
{
    public interface IVendaRepository : IRepositoryRead<Venda>, IRepositoryWrite<Venda>
    {
    }
}
