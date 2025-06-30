
using EShop.Application.Services;
using EShop.Application.Settings;
using EShop.DAL.Infrastructure;
using EShop.DAL.Interfaces;
using EShop.DAL.Repositories;
using EShop.Domain.Interfaces;
using Serilog;

namespace EShop.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ��������� Serilog �� ������������
            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            // ����������� ������ �������������� ��������
            builder.Services.Configure<AppSettings>(
                builder.Configuration.GetSection(AppSettings.SectionName));

            builder.Services.Configure<ShopSettings>(builder.Configuration.GetSection(ShopSettings.SectionName));

            builder.Services.AddControllers();

            builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IShopRepository, ShopRepository>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<ShopService>();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            try
            {
                Log.Information("������ ���������� {ApplicationName} ������ {Version}",
                    builder.Configuration["AppSettings:ApplicationName"],
                    builder.Configuration["AppSettings:Version"]);

                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                    Log.Information("Swagger ������� ��� ����� ����������");
                }

                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();

                Log.Information("���������� ��������� � ������ � ������ �� ����� {Port}",
                    builder.Configuration["urls"] ?? "default");
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "����������� ������ ��� ������� ����������");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}