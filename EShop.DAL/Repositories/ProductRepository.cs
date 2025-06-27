using EShop.DAL.Interfaces;
using EShop.Domain;
using EShop.Domain.Interfaces;
using Npgsql;
using System.Data;

namespace EShop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProductRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("SELECT id, name, price FROM products WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Product
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Price = reader.GetDecimal("price")
                };
            }

            return null;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            int rowNumber = 0;
            var products = new List<Product>();

            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("SELECT id, name, price FROM products ORDER BY id", connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                rowNumber++; // счетчик строк
                Console.WriteLine($"Row #{rowNumber}:");
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnName = reader.GetName(i);
                    object value = reader.GetValue(i);
                    Type dataType = reader.GetFieldType(i);
                    Console.WriteLine($"  Column {i}: Name = {columnName}, Value = {value}, Type = {dataType.Name}");
                }
                products.Add(new Product
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Price = reader.GetDecimal("price")
                });
            }

            return products;
        }

        public async Task AddAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var command = new NpgsqlCommand(
                "INSERT INTO products (name, price) VALUES (@name, @price)",
                connection);

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("DELETE FROM products WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var command = new NpgsqlCommand(
                "UPDATE products SET name = @name, price = @price WHERE id = @id",
                connection);

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@id", product.Id);

            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
    }
}