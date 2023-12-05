using Microsoft.Extensions.Configuration;
using Npgsql;
using ShopAPI.Interfaces;
using ShopAPI.Respositories;
using System.Data;
using TeachingAPI.Interfaces;
using TeachingAPI.Services;

namespace TeachingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IShopItemService, ShopItemService>();
            builder.Services.AddTransient<IShopItemRepository, ShopItemRepository>();

            string dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");

            // Inject IDbConnection, with implementation from SqlConnection class.
            builder.Services.AddTransient<IDbConnection>(sp => new NpgsqlConnection(dbConnectionString));


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