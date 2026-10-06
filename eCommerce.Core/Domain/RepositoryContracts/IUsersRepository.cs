using eCommerce.Core.Domain.Entities;

namespace eCommerce.Core.Domain.RepositoryContracts;

public interface IUsersRepository
{
    /// <summary>
    /// Method to add a user to the data store
    /// </summary>
    /// <param name="user">User to add</param>
    /// <returns>Returns added user in database</returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);
   
    /// <summary>
    /// Method to search existing user using user email and password
    /// </summary>
    /// <param name="email">Email to search</param>
    /// <param name="password">Password to search</param>
    /// <returns>Returns retrieved user, but in case of not found then null</returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

    /// <summary>
    /// Method to search existing user using user ID
    /// </summary>
    /// <param name="userID">UserID to search</param>
    /// <returns>Returns retrieved user, but in case of not found then null</returns>
    Task<ApplicationUser?> GetUserByUserID(Guid userID);
} 