using AppVendas.Application.ViewModels;
using AppVendas.Domain.Models;
using AutoMapper;

namespace AppVendas.Application.AutoMapper
{
    public class DomaintoViewModel : Profile
    {
        public DomaintoViewModel()
        {
            CreateMap<Estoque, ProdutoViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Venda, VendaViewModel>().ReverseMap();
            CreateMap<Estoque, EstoqueViewModel>().ReverseMap();
            //CreateMap<Produto, ProdutoCategoriaViewModel>().ReverseMap();
            //CreateMap<Categoria, ProdutoCategoriaViewModel>().ReverseMap();
            //CreateMap<(Categoria, Produto), ProdutoCategoriaViewModel>().ReverseMap();
        }

    }
}
