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
        var user = await _repository.GetUserByEmailAndPassword(userLoginRequest.Email, userLoginRequest.Password);

        if (user is null)
        {
            return null;
        }

        return new AuthenticationResponse(user.UserID, user.Email, user.Name, user.Gender, "", true);
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

        var user = await _repository.AddUser(userToAdd);

        if (user is null)
        {
            return null;
        }

        return new AuthenticationResponse(user.UserID, user.Email, user.Name, user.Gender, "", true);
    }
}