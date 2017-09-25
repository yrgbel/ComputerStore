using AutoMapper;
using Store.DomainModel.DTOs;
using Store.Model.POCO_Entities;

namespace Store.Data.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<CustomerPhone, CustomerPhoneDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderProduct, OrderProductDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(
                    dto => dto.ProductCategoryName,
                    opt => opt.MapFrom(src => src.ProductSubCategory.ProductCategory.ProductCategoryName))
                .ForMember(
                    dto => dto.ProductBrandName,
                    opt => opt.MapFrom(src => src.ProductBrand.ProductBrandName))
                .ForMember(
                    dto => dto.ProductBrandCountry,
                    opt => opt.MapFrom(src => src.ProductBrand.ProductBrandCountry))
                    .ForMember(
                    dto => dto.ProductManufacturerCountry,
                    opt => opt.MapFrom(src => src.ProductManufacturer.ProductManufacturerCountry))
                .ForMember(
                    dto => dto.ProductSubCategoryName,
                    opt => opt.MapFrom(src => src.ProductSubCategory.ProductSubCategoryName));

            CreateMap<ProductBrand, ProductBrandDto>();
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductManufacturer, ProductManufacturerDto>();
            CreateMap<ProductSubCategory, ProductSubCategoryDto>();

            // Dto to Domain
            CreateMap<CustomerPhoneDto, CustomerPhone>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<OrderProductDto, OrderProduct>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductBrandDto, ProductBrand>();
            CreateMap<ProductCategoryDto, ProductCategory>();
            CreateMap<ProductManufacturerDto, ProductManufacturer>();
            CreateMap<ProductSubCategoryDto, ProductSubCategory>();
        }
    }
}
