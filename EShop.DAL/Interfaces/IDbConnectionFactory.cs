using Npgsql;

namespace EShop.DAL.Interfaces
{
    public interface IDbConnectionFactory
    {
        NpgsqlConnection CreateConnection();
    }
}