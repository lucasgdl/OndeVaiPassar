using System.Data;
using OndeVaiPassar.Domain.Entities.Sports;
using OndeVaiPassar.Query.Sports;
using Dapper;
using OndeVaiPassar.DTOs;
using OndeVaiPassar.Persistence;

namespace OndeVaiPassar.QueryStore.Sports;

public class SportQueryStore : ISportQueryStore
{
    private readonly DbConnectionFactory _factory;

    public SportQueryStore(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<SportDto?> GetByIdAsync(int id)
    {
        const string sql = "SELECT Id, Name, LogoUrl, CreatedAt FROM Sports WHERE Id = @Id";

        using var connection = _factory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<SportDto>(sql, new { Id = id });
    }

    public async Task<IEnumerable<SportDto>> ListAllAsync()
    {
        const string sql = "SELECT Id, Name, LogoUrl, CreatedAt FROM Sports ORDER BY CreatedAt DESC";

        using var connection = _factory.CreateConnection();
        return await connection.QueryAsync<SportDto>(sql);
    }
}
