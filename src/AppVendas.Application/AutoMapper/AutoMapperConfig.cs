using AutoMapper;


namespace AppVendas.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(i =>
            {
                i.AddProfile<DomaintoViewModel>();
                i.AddProfile<ViewModelToDomain>();
            });
        }


    }
}
