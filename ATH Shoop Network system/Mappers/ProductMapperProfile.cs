using ATH_Shoop_Network_system.Models.Product;
using AutoMapper;

namespace ATH_Shoop_Network_system.Mappers
{
    public class ProductMapperProfile: Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductIndexViewModel>().ReverseMap();
            CreateMap<ProductViewModel, ProductIndexViewModel>().ReverseMap();
            CreateMap<Product, ProductDetailsViewModel>().ReverseMap();
            CreateMap<Product, ProductCreateViewModel>().ReverseMap();
            CreateMap<Product, ProductEditViewModel>().ReverseMap();
            CreateMap<Product, ProductDeleteViewModel>().ReverseMap();
        }
    }
}
