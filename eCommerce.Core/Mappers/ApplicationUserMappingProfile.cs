using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.DTO;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dst => dst.PersonName,
            opt => opt.MapFrom(src => src.PersonName)
            );
    }
}