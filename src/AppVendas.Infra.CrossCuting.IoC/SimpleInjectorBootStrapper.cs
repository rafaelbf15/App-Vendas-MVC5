using AppVendas.Application.Intefaces;
using AppVendas.Application.Services;
using AppVendas.Domain.Intefaces;
using AppVendas.Domain.Services;
using AppVendas.Infra.Data.Context;
using AppVendas.Infra.Data.Repository;
using AppVendas.Infra.Data.UoW;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Infra.CrossCuting.IoC
{
    public class SimpleInjectorBootStrapper
    {

        public static void Register(Container container)
        {

            container.Register<IVendaService, VendaService>(Lifestyle.Scoped);
            container.Register<IVendaAppService, VendaAppService>(Lifestyle.Scoped);
            container.Register<IVendaRepository, VendaRepository>(Lifestyle.Scoped);

            container.Register<ICategoriaAppService, CategoriaAppService>(Lifestyle.Scoped);
            container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Scoped);
            container.Register<ICategoriaService, CategoriaService>(Lifestyle.Scoped);

            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);

            container.Register<IEstoqueRepository, EstoqueRepository>(Lifestyle.Scoped);
            container.Register<IEstoqueAppService, EstoqueAppService>(Lifestyle.Scoped);
            container.Register<IEstoqueService, EstoqueService>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register<AppVendasContext>(Lifestyle.Scoped);








        }
    }
}
