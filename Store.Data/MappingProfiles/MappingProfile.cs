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

            CreateMap<Customer, CustomerDto>()
                .ForMember(dto => dto.OrderProducts, opt => opt.Ignore());

            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderProduct, OrderProductDto>();
            CreateMap<Product, ProductDto>();
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
