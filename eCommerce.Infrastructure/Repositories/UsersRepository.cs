using Dapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts; 
using eCommerce.Infrastructure.DatabaseContext; 

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository(DapperDbContext dbContext) : IUsersRepository
{
    private readonly DapperDbContext _dapperDbContext = dbContext;

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        string query = """
            INSERT INTO public."Users"
            ("UserID", "Email", "PersonName", "Gender", "Password")
            VALUES
            (@UserID, @Email, @PersonName, @Gender, @Password);
            """;
        int rowsAffected = await _dapperDbContext.DbConnection.ExecuteAsync(query, user);

        if (rowsAffected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = """
    SELECT *
    FROM "Users"
    WHERE "Email" = @Email AND "Password" = @Password
    """;

        var result = await _dapperDbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new {Email = email, Password = password});

        return result;
    }
}