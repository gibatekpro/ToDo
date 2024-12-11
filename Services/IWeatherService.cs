using Microsoft.CodeAnalysis;
using ToDo.Models;

namespace ToDo.Services;

public interface IWeatherService
{
    Task<Weather> GetCurrentWeather(LocationItem location);
    
}