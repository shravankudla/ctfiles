using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApiCoreWithEFCore.Models;

internal class Program
{
    public static IConfiguration Configuration { get; }  //to read the values from appsettings.json file.
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

    
    // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddSingleton<ICustomerRepository,CustomerRepository>();
        builder.Services.AddDbContext<DN16DecContext>(item => item.UseSqlServer
                    (Configuration.GetConnectionString("DN16DecConStr")));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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