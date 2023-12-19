using EFDAL;
using ServiceLayer;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>(options =>
{
      options
     .UseSqlServer(builder.Configuration.GetConnectionString("conne"));
 });
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IServiceLayer, ServiceLayerr>();
var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.Run();