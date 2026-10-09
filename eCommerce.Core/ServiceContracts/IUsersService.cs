using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Represents common logic for authenticating users
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Method to handle user login and return appropriate authentication response
    /// </summary>
    /// <param name="userLoginRequest">Login inputs to give</param>
    /// <returns>Returns automatically generated AuthenticationResponse if login was successful</returns>
    Task<AuthenticationResponse?> Login(LoginRequest userLoginRequest);

    /// <summary>
    /// Method to handle user registration and return appropriate authentication response
    /// </summary>
    /// <param name="userRegisterRequest">Register inputs to give</param>
    /// <returns>Returns automatically generated AuthenticationResponse if registering was successful</returns>
    Task<AuthenticationResponse?> Register(RegisterRequest userRegisterRequest);

    /// <summary>
    /// Method to get user details by userID
    /// </summary>
    /// <param name="user">UserDTO containing the userID to search</param>
    /// <returns>Returns retrieved user details, but in case of not found then null</returns>
    Task<UserDTO?> GetUserByUserID(Guid user);
}