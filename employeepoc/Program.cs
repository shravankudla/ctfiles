using Microsoft.EntityFrameworkCore;
using Employee.Models;
using System.Data;

internal class Program
{
    public static IConfiguration Configuration { get; }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSingleton<IEmployeeRepo, MyEmployeeRepo>();
        builder.Services.AddDbContext<POCContext>(item => item.UseSqlServer(Configuration.GetConnectionString("POCConStr")));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
