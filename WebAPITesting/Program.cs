using Microsoft.EntityFrameworkCore;
using WebAPITesting.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
      policy =>
      {
          policy.WithOrigins("http://localhost:4200")
          .AllowAnyHeader()
          .AllowAnyMethod();
      });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();