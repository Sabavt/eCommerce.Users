using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService(IUsersRepository repository) : IUsersService
{
    private readonly IUsersRepository _repository = repository;

    public async Task<AuthenticationResponse?> Login(LoginRequest userLoginRequest)
    {
        var loggedInUser = await _repository.GetUserByEmailAndPassword(userLoginRequest.Email, userLoginRequest.Password);

        if (loggedInUser is null)
        {
            return null;
        }

        return new AuthenticationResponse(loggedInUser.UserID, loggedInUser.Email, loggedInUser.Name, loggedInUser.Gender, "", true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest userRegisterRequest)
    {
        var userToAdd = new ApplicationUser()
        {
            Name = userRegisterRequest.PersonName,
            Email = userRegisterRequest.Email,
            Gender = userRegisterRequest.Gender.ToString(),
            Password = userRegisterRequest.Password 
        };

        var registeredUser = await _repository.AddUser(userToAdd);

        if (registeredUser is null)
        {
            return null;
        }

        return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.Name, registeredUser.Gender, "", true);
    }
}