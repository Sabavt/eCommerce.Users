using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts; 

namespace eCommerce.Core.Services;

internal class UsersService(IUsersRepository repository, IMapper mapper) : IUsersService
{
    private readonly IUsersRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<AuthenticationResponse?> Login(LoginRequest userLoginRequest)
    {
        var loggedInUser = await _repository.GetUserByEmailAndPassword(userLoginRequest.Email, userLoginRequest.Password);

        if (loggedInUser is null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(loggedInUser) with { Success = true, Token = "token" }; 
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest userRegisterRequest)
    {
        var userToAdd = _mapper.Map<ApplicationUser>(userRegisterRequest);

        var registeredUser = await _repository.AddUser(userToAdd);

        if (registeredUser is null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token" };
    }
}