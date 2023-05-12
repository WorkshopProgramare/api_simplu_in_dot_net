using AutoMapper;
using ProductsAPI.Dtos;
using ProductsAPI.Entities;

namespace ProductsAPI.MappingProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {
            CreateMap<ProductAddDto, Product>()
                .ForMember(d => d.Height, opt => opt.MapFrom(s => s.ProductSize.Height))
                .ForMember(d => d.Width, opt => opt.MapFrom(s => s.ProductSize.Width))
                .ForMember(d => d.Depth, opt => opt.MapFrom(s => s.ProductSize.Depth))
                .ForMember(d => d.Currency, opt => opt.MapFrom(s => s.Price.Currency))
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Price.Value));
            CreateMap<Product, ProductSummaryDto>();
            CreateMap<Product, ProductViewDto>()
                .ForMember(d => d.ProductSize, opt => opt.MapFrom(s => s))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s));
            CreateMap<Product, ProductSizeDto>();
            CreateMap<Product, PriceDto>();
            CreateMap<ProductEditDto, Product>()
                .ForMember(d => d.Height, opt => opt.MapFrom(s => s.ProductSize.Height))
                .ForMember(d => d.Width, opt => opt.MapFrom(s => s.ProductSize.Width))
                .ForMember(d => d.Depth, opt => opt.MapFrom(s => s.ProductSize.Depth))
                .ForMember(d => d.Currency, opt => opt.MapFrom(s => s.Price.Currency))
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Price.Value));
        }
    }
}
