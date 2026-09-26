using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.DTO;

namespace eCommerce.Core.Mappers;

public class RegisterRequestMappingProfile : Profile
{
    public RegisterRequestMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>().ForMember(dst => dst.Name,
            opt => opt.MapFrom(src => src.PersonName));
    }
}
