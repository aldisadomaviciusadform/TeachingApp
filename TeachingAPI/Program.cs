using Microsoft.Extensions.Configuration;
using Npgsql;
using ShopAPI.Interfaces;
using ShopAPI.Respositories;
using System.Data;
using TeachingAPI.Interfaces;
using TeachingAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopAPI.Data;
using ShopAPI.Services;
using Serilog;

namespace TeachingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ShopAPIContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection") ?? throw new InvalidOperationException("Connection string 'ShopAPIContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IShopItemService, ShopItemService>();
            builder.Services.AddTransient<IShopItemRepository, ShopItemRepository>();
            builder.Services.AddTransient<IShopItmesService, ShopItemsService>();

            //
            string dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");

            // Inject IDbConnection, with implementation from SqlConnection class.
            builder.Services.AddTransient<IDbConnection>(sp => new NpgsqlConnection(dbConnectionString));

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            builder.Services.AddHttpClient();

            // Register your custom services
            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}