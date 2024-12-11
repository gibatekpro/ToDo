using Microsoft.EntityFrameworkCore;
using ToDo.Config;
using ToDo.Mappers;
using ToDo.Models;
using ToDo.Repos;
using ToDo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddScoped<IToDoService, ToDoServiceImpl>();
builder.Services.AddAutoMapper(typeof(ExternalToDoMapping));
builder.Services.AddScoped<ExternalToDoMapping>();
builder.Services.AddScoped<ToDoResponseMapping>();
builder.Services.AddScoped<IToDoRepo, ToDoRepoImpl>();
builder.Services.AddScoped<IWeatherService, WeatherIServiceImpl>();

//Configure DB Context
builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ConnectionLite")));

//Configure Weather API 
builder.Services.Configure<WeatherApiSettings>(
    builder.Configuration.GetSection("WeatherApi"));

//logger
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
