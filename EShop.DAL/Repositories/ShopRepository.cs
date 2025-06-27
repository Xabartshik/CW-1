using EShop.DAL.Interfaces;
using EShop.Domain;
using EShop.Domain.Interfaces;
using Npgsql;
using System.Data;

namespace EShop.DAL.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ShopRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }


        public async Task<Shop?> GetByIdAsync(int id)
        {
            //Соединение
            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();

            //Команда
            using var command = new NpgsqlCommand("SELECT id, name, area, address, created_at, FROM shops WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Shop
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Area = reader.GetDouble("area"),
                    Address = reader.GetString("address"),
                    CreatedAt = reader.GetDateTime("created_at")
                };
            }

            return null;
        }

        public async Task<IEnumerable<Shop>> GetAllAsync()
        {
            var shops = new List<Shop>();
            //Соединение
            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();

            //Команда
            using var command = new NpgsqlCommand("SELECT * FROM shops order by ID", connection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync()) {
                shops.Add( new Shop
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Area = reader.GetDouble("area"),
                    Address = reader.GetString("address"),
                    CreatedAt = reader.GetDateTime("created_at")
                });
            }
            return shops;
        }

        public async Task AddAsync(Shop shop)
        {
            if (shop == null) {
                throw new ArgumentNullException(nameof(shop)); }
            //Соединение
            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();

            //Команда
            using var command = new NpgsqlCommand("Insert into shops (area, address, name) values (@area, @address, @name)", connection);
            command.Parameters.AddWithValue("@area", shop.Area);
            command.Parameters.AddWithValue("@address", shop.Address);
            command.Parameters.AddWithValue("@name", shop.Name);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            //Соединение
            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();

            //Команда
            using var command = new NpgsqlCommand("Delete FROM shops WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            //Возвращает число затронутых строк
            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Shop shop)
        {
            //Соединение
            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();

            //Команда
            using var command = new NpgsqlCommand("UPDATE shops Set (name = @name, area = @area, address = @address) WHERE id = @id",
                connection);
            command.Parameters.AddWithValue("@id", shop.Id);
            command.Parameters.AddWithValue("@area", shop.Area);
            command.Parameters.AddWithValue("@name", shop.Name);
            command.Parameters.AddWithValue("@address", shop.Address);

            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}