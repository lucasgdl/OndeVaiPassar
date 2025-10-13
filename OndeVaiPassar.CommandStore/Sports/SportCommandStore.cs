using OndeVaiPassar.Command.Sports;
using OndeVaiPassar.Domain.Entities.Sports;
using Dapper;
using OndeVaiPassar.Persistence;

namespace OndeVaiPassar.CommandStore.Sports;

public class SportCommandStore : ISportCommandStore
{
    private readonly DbConnectionFactory _factory;

    public SportCommandStore(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<int> CreateAsync(SportEntity sport)
    {
        const string sql = @"
                INSERT INTO Sports (Id, Name, Category, CreatedAt)
                VALUES (@Id, @Name, @Category, @CreatedAt);
            ";

        using var connection = _factory.CreateConnection();
        int id = await connection.ExecuteAsync(sql, sport);
        sport.SetId(id);
        return id;
    }

    public async Task<int> UpdateAsync(SportEntity sport)
    {
        const string sql = @"
                UPDATE Sports
                SET Name = @Name,
                    Category = @Category
                WHERE Id = @Id;
            ";

        using var connection = _factory.CreateConnection();
        int id = await connection.ExecuteAsync(sql, sport);
        sport.SetId(id);
        return id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM Sports WHERE Id = @Id;";
        using var connection = _factory.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
        return id;
    }
}
