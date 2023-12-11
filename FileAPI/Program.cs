
using FileAPI.Interfaces;
using FileAPI.Middlewares;
using FileAPI.Repositorities;
using FileAPI.Services;
using System.Data;
using Npgsql;

namespace FileAPI
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
            builder.Services.AddScoped<IFileService, FileService >();
            builder.Services.AddScoped<IFileRepository, FileRepository>();
            builder.Services.AddScoped<IFolderService, FolderService>();
            builder.Services.AddScoped<IFolderRepository, FolderRepository>();

            string dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");
            builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(dbConnectionString));

            var app = builder.Build();

            app.ErrorHandleMiddleware();
            app.UseMiddleware();

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
