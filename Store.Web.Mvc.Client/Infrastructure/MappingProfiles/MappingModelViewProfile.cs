using System;
using System.Collections.Generic;
using AutoMapper;
using Store.Model.IdentityEntities;
using Store.Model.POCO_Entities;
using Store.Web.Mvc.Client.Areas.Auth.ViewModels;

namespace Store.Web.Mvc.Client.Infrastructure.MappingProfiles
{
    public class MappingModelViewProfile : Profile
    {
        public MappingModelViewProfile()
        {
            CreateMap<SignupModel, Customer>()
                .ForMember(c => c.CusomerPhones, cfg =>
                    cfg.MapFrom(s => new List<CustomerPhone>
                    {
                        new CustomerPhone { CustomerPhoneNumber = s.PhoneNumber }
                    }))
                .ForMember(u => u.CustomerAddress, cfg => cfg.MapFrom(s => s.Address))
                .ForMember(u => u.CustomerCity, cfg => cfg.MapFrom(s => s.City))
                .ForMember(u => u.CustomerCountry, cfg => cfg.MapFrom(s => s.Country))
                .ForMember(u => u.CustomerEmail, cfg => cfg.MapFrom(s => s.Email))
                .ForMember(u => u.CustomerName, cfg => cfg.MapFrom(s => s.FirstName))
                .ForMember(u => u.CustomerLastName, cfg => cfg.MapFrom(s => s.LastName))
                .ForMember(u => u.CustomerPatronymic, cfg => cfg.MapFrom(s => s.Patronymic))
                .ForMember(u => u.CustomerRegion, cfg => cfg.MapFrom(s => s.Region));

            CreateMap<SignupModel, ApplicationUser>()
                .ForMember(u => u.UserName, cfg => cfg.MapFrom(s => s.Email))
                .ForMember(u => u.CreatedOn, cfg => cfg.MapFrom(s => DateTime.Now))
                .ForMember(u => u.ChangedOn, cfg => cfg.MapFrom(s => DateTime.Now))
                .ForMember(u => u.SignupDate, cfg => cfg.MapFrom(s => DateTime.Now))
                .ForMember(u => u.Customer, cfg => cfg.MapFrom(s => Mapper.Map<Customer>(s)));



        }
    }
}