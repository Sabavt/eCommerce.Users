using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.DTO;

namespace eCommerce.Core.Mappers;

public class RegisterRequestMappingProfile : Profile
{
    public RegisterRequestMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>().ReverseMap();
    }
} 