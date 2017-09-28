﻿using System;
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

            CreateMap<Product, ProductDetailsDto>()
                .ForMember(dto => dto.ProductBrandCountry,
                    cfg => cfg.MapFrom(dest => dest.ProductBrand.ProductBrandCountry))
                .ForMember(dto => dto.ProductBrandName,
                    cfg => cfg.MapFrom(dest => dest.ProductBrand.ProductBrandName))
                .ForMember(dto => dto.ProductCategoryName,
                    cfg => cfg.MapFrom(dest => dest.ProductSubCategory.ProductCategory.ProductCategoryName))
                .ForMember(dto => dto.ProductManufacturerCountry,
                    cfg => cfg.MapFrom(dest => dest.ProductManufacturer.ProductManufacturerCountry))
                .ForMember(dto => dto.ProductSubCategoryName,
                    cfg => cfg.MapFrom(dest => dest.ProductSubCategory.ProductSubCategoryName));

            CreateMap<ProductBrand, ProductBrandDto>();
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductManufacturer, ProductManufacturerDto>();
            CreateMap<ProductSubCategory, ProductSubCategoryDto>();

            // Dto to Domain
            CreateMap<CustomerPhoneDto, CustomerPhone>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<OrderProductDto, OrderProduct>();
            CreateMap<ProductDetailsDto, Product>();
            CreateMap<ProductBrandDto, ProductBrand>();
            CreateMap<ProductCategoryDto, ProductCategory>();
            CreateMap<ProductManufacturerDto, ProductManufacturer>();
            CreateMap<ProductSubCategoryDto, ProductSubCategory>();
        }
    }
}
