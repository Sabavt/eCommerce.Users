using AutoMapper;

namespace eCommerce.Core.Mappers;

public class UserDTOMappingProfile : Profile
{
    public UserDTOMappingProfile()
    {
        CreateMap<Domain.Entities.ApplicationUser, DTO.UserDTO>().ReverseMap();
    }
} 