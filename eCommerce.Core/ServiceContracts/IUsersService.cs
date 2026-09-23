using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Represents common logic for authenticating users
/// </summary>
internal interface IUsersService
{
    Task<AuthenticationResponse> Login(LoginRequest userLoginRequest);
    Task<AuthenticationResponse> Register(RegisterRequest uRegisterRequest);
}