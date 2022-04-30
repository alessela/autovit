using Microsoft.EntityFrameworkCore;
using webAPI.Context;
using webAPI.Models;
using webAPI.Services;

var builder = WebApplication.CreateBuilder(args);
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        build =>
        {
            build.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var mySqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add context
builder.Services.AddDbContext<BrandContext>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<ModelContext>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<UserContext>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BodyStyleContext>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<FuelContext>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<TransmissionContext>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<ColorContext>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));

// Add services to the container.
builder.Services.AddScoped<IService<Brand>, BrandService>();
builder.Services.AddScoped<IService<User>, UserService>();
builder.Services.AddScoped<IService<Model>, ModelService>();
builder.Services.AddScoped<IService<BodyStyle>, BodyStyleService>();
builder.Services.AddScoped<IService<Fuel>, FuelService>();
builder.Services.AddScoped<IService<Transmission>, TransmissionService>();
builder.Services.AddScoped<IService<Color>, ColorService>();
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

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
