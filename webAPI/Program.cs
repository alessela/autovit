using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webAPI.Context;
using webAPI.Models;
using webAPI.Services;
using System.Configuration.Provider;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builderr =>
        {
            builderr.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

string? mySqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add context
builder.Services.AddDbContext<BrandContext>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<ModelContext>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<UserContext>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));

// Add services to the container.
builder.Services.AddScoped<IService<Brand>, BrandService>();
builder.Services.AddScoped<IService<User>, UserService>();
builder.Services.AddControllers();

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

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello, world");

app.Run();
