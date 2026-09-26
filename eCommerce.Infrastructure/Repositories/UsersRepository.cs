using AutoMapper;
using Dapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.Enums;
using eCommerce.Infrastructure.DatabaseContext;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository(DapperDbContext dbContext) : IUsersRepository
{
    private readonly DapperDbContext _dapperDbContext = dbContext;

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        string query = "INSERT INTO public. \"Users\"(\"UserID\", \"Email\", \"Name\", \"Phone\", \"Gender\", \"Password\" " +
            "VALUES(@UserID, @Email, @Name, @Gender, @Password, @Phone))";
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
        return new ApplicationUser()
        {
            Email = email,
            Password = password,
            UserID = Guid.NewGuid(),
            Gender = nameof(GenderOptions.Male)
        };
    }
}