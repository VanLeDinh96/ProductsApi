using AutoMapper;
using Parts.Contract.Shared;
using Parts.Domain.Entities;

namespace Parts.Application.Mapper;
public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        // V1
        CreateMap<Product, Contract.Services.V1.Product.Response.ProductResponse>().ReverseMap();
        CreateMap<PagedResult<Product>, PagedResult<Contract.Services.V1.Product.Response.ProductResponse>>().ReverseMap();

        // V2
        CreateMap<Product, Contract.Services.V2.Product.Response.ProductResponse>().ReverseMap();
    }
}
