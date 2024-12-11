using Microsoft.CodeAnalysis;
using ToDo.Models;

namespace ToDo.Services;

//Author: Anthony Gibah
public interface IWeatherService
{
    //Author: Anthony Gibah
    Task<Weather> GetCurrentWeather(LocationItem location);
    
}