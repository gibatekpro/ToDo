using System.Text.Json;
using Microsoft.Extensions.Options;
using ToDo.Config;
using ToDo.Models;

namespace ToDo.Services;

//Author: Anthony Gibah
public class WeatherIServiceImpl: IWeatherService
{
    //Using IOptions ton ensure API Key is not exposed
    private readonly WeatherApiSettings _weatherApiSettings;
    private readonly ILogger _logger; //for logging

    //Author: Anthony Gibah
    public WeatherIServiceImpl(IOptions<WeatherApiSettings> options, ILogger<WeatherIServiceImpl> logger)
    {
        _weatherApiSettings = options.Value;
        _logger = logger;
    }
    
    public async Task<Weather> GetCurrentWeather(LocationItem location)
    {
        try
        {
            //Construct the API URL using string interpolation
            var url = $"{_weatherApiSettings.BaseUrl}?key={_weatherApiSettings.ApiKey}&q={location.Latitude},{location.Longitude}";

            _logger.LogInformation("Fetching weather data from URL: {Url}", url);
    
            using var httpClient = new HttpClient();
    
            //Fetch the response from the API
            var response = await httpClient.GetFromJsonAsync<WeatherResponse>(url);

            //Log the raw JSON response for debugging
            _logger.LogInformation("Weather API Response: {Response}", JsonSerializer.Serialize(response));

            //Null checks for response and its nested properties
            if (response == null || response.Current == null || response.Current.Condition == null)
            {
                throw new Exception("Unexpected weather API response structure.");
            }

            //Return the weather information
            return new Weather
            {
                Temp_c = response.Current.Temp_c,
                Condition = response.Current.Condition.Text
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while fetching weather data.");
            throw new Exception("Failed to fetch weather data", e);
        }

    }
}