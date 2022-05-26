using Microsoft.AspNetCore.ResponseCompression;
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

builder.Services.AddScoped<BaseContext<Brand>, BrandContext>();
builder.Services.AddScoped<BaseContext<Model>, ModelContext>();
builder.Services.AddScoped<BaseContext<User>, UserContext>();
builder.Services.AddScoped<BaseContext<BodyStyle>, BodyStyleContext>();
builder.Services.AddScoped<BaseContext<Fuel>, FuelContext>();
builder.Services.AddScoped<BaseContext<Transmission>, TransmissionContext>();
builder.Services.AddScoped<BaseContext<Color>, ColorContext>();
builder.Services.AddScoped<BaseContext<County>, CountyContext>();
builder.Services.AddScoped<BaseContext<City>, CityContext>();
builder.Services.AddScoped<BaseContext<Car>, CarContext>();
builder.Services.AddScoped<BaseContext<SoldCar>, SoldCarContext>();
builder.Services.AddScoped<BaseContext<CarEvent>, CarEventContext>();
builder.Services.AddScoped<BaseContext<Message>, MessageContext>();

builder.Services.AddDbContext<BaseContext<Brand>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<Model>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<User>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<BodyStyle>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<Fuel>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<Transmission>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<Color>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<County>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<City>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<Car>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<SoldCar>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<CarEvent>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddDbContext<BaseContext<Message>>(options =>
    options.UseMySql(mySqlConnectionString!, ServerVersion.AutoDetect(mySqlConnectionString)));

// Add services to the container.
builder.Services.AddScoped<BaseService<Brand>, BrandService>();
builder.Services.AddScoped<BaseService<User>, UserService>();
builder.Services.AddScoped<BaseService<Model>, ModelService>();
builder.Services.AddScoped<BaseService<BodyStyle>, BodyStyleService>();
builder.Services.AddScoped<BaseService<Fuel>, FuelService>();
builder.Services.AddScoped<BaseService<Transmission>, TransmissionService>();
builder.Services.AddScoped<BaseService<Color>, ColorService>();
builder.Services.AddScoped<BaseService<County>, CountyService>();
builder.Services.AddScoped<BaseService<City>, CityService>();
builder.Services.AddScoped<BaseService<Car>, CarService>();
builder.Services.AddScoped<BaseService<SoldCar>, SoldCarService>();
builder.Services.AddScoped<BaseService<CarEvent>, CarEventService>();
builder.Services.AddScoped<BaseService<Message>, MessageService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options => options.MimeTypes = ResponseCompressionDefaults.MimeTypes
    .Concat(new []{ "application/octet-stream"}));

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
