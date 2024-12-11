using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Repos;

namespace ToDo.Services;

//Author: Anthony Gibah
public class ToDoServiceImpl : IToDoService
{
    private readonly IToDoRepo _toDoRepo; //Dependency Injection
    private readonly IMapper _mapper; //Dependency Injection
    private readonly ILogger _logger; //Dependency Injection
    private readonly IWeatherService _weatherService; //Dependency Injection

    //Author: Anthony Gibah
    public ToDoServiceImpl(IToDoRepo toDoRepo, IMapper mapper, ILogger<ToDoServiceImpl> logger,
        IWeatherService weatherService)
    {
        _toDoRepo = toDoRepo;
        _mapper = mapper;
        _logger = logger;
        _weatherService = weatherService;
    }

    //Author: Anthony Gibah
    //Implementation of method for fetching and storing the data
    public async Task FetchAndStoreToDos()
    {
        using var httpClient = new HttpClient();
        try
        {
            var response = await httpClient.GetFromJsonAsync<ExternalToDoResponse>("https://dummyjson.com/todos");

            if (response == null || response.Todos == null)
            {
                _logger.LogError("No todos found in the response from URL: {Url}", "https://dummyjson.com/todos");
                throw new Exception("Failed to fetch todos data from URL");
            }

            _logger.LogInformation("Successfully fetched {Count} todos from URL: {Url}", response.Todos.Count,
                "https://dummyjson.com/todos");

            //Map response to ToDoItem
            var todos = _mapper.Map<List<ToDoItem>>(response.Todos);
            _logger.LogInformation("Successfully mapped todos to ToDoItem model.");

            //Save To-Do items using the repository
            await _toDoRepo.SaveToDoList(todos);
            _logger.LogInformation("Successfully saved {Count} todos to the database.", todos.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching and saving todos.");
            throw; //Throw the exception to maintain the original stack trace
        }
    }

    //Author: Anthony Gibah
    public async Task<List<ToDoResponse>> FetchToDoList()
    {
        try
        {
            var todoItems = await _toDoRepo.FetchToDoList();

            //ToDoItem to ToDoResponse
            var toDoResponses = _mapper.Map<List<ToDoResponse>>(todoItems);

            _logger.LogInformation("Checking if has location, to set weather and temperature");
            foreach (var toDo in toDoResponses)
            {
                await AddWeatherInfo(toDo);
            }

            return toDoResponses;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while fetching the ToDo list.");
            throw;
        }
    }

    public async Task<ToDoResponse> FetchToDoItem(long id)
    {
        try
        {
            var toDoItem = await _toDoRepo.FetchToDoItem(id);

            // Map ToDoItem to ToDoResponse
            var toDoResponse = _mapper.Map<ToDoResponse>(toDoItem);

            _logger.LogInformation("Checking if has location, to set weather and temperature");
            await AddWeatherInfo(toDoItem, toDoResponse);

            return toDoResponse;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while fetching the ToDo list.");
            throw;
        }
    }

    public async Task UpdateToDoItem(long id, ToDoItem toDoItem)
    {
        if (id != toDoItem.Id)
        {
            throw new ArgumentException("The provided ID does not match the ToDoItem ID.");
        }

        try
        {
            await _toDoRepo.UpdateToDoItem(id, toDoItem);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteToDoItem(long id)
    {
        //Check if the item exists
        var toDoItem = await _toDoRepo.GetToDoItemById(id);
        if (toDoItem == null)
        {
            throw new KeyNotFoundException($"ToDo item with ID {id} not found.");
        }

        try
        {
            //delete using repository
            await _toDoRepo.DeleteToDoItem(toDoItem);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while deleting the ToDo item with ID {Id}.", id);
            throw;
        }
    }

    public async Task<ToDoResponse> PostToDoItem(ToDoItem toDoItem)
    {
        try
        {
            _logger.LogInformation("Start: Adding item in Service");

            //Save the ToDoItem using the repository
            await _toDoRepo.PostToDoItem(toDoItem);

            _logger.LogInformation("Item saved successfully. Fetching weather data.");

            //AutoMapper to map the ToDoItem to a ToDoResponse
            var toDoResponse = _mapper.Map<ToDoResponse>(toDoItem);

            await AddWeatherInfo(toDoItem, toDoResponse);
            
            _logger.LogInformation("Weather data added to the ToDo response: {WeatherData}", JsonSerializer.Serialize(toDoResponse.Weather));

            return toDoResponse;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while posting the ToDo item in Service.");
            throw;
        }
    }

    //Author: Anthony Gibah
    public async Task<IEnumerable<ToDoResponse>> SearchToDoItems(string? title, int? priority, DateTime? dueDate)
    {
        try
        {
            
            var results = await _toDoRepo.SearchToDoItems(title, priority, dueDate);

            //ToDoItems to ToDoResponses
            var toDoResponses = _mapper.Map<IEnumerable<ToDoResponse>>(results);

            _logger.LogInformation("Checking if ToDo items have location to set weather and temperature.");
            foreach (var toDo in toDoResponses)
            {
                await AddWeatherInfo(toDo);
            }

            _logger.LogInformation("{Count} ToDo items found and processed.", results.Count());

            return toDoResponses;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while searching ToDo items.");
            throw;
        }
    }

    private async Task AddWeatherInfo(ToDoItem toDoItem, ToDoResponse toDoResponse)
    {
        //Fetch weather data if location is provided
        if (toDoItem.Location != null &&
            toDoItem.Location.Latitude != 0 &&
            toDoItem.Location.Longitude != 0)
        {
            try
            {
                var weather = await _weatherService.GetCurrentWeather(toDoItem.Location);
                toDoResponse.Weather = weather;
                _logger.LogInformation("Weather data added to the ToDo response: {WeatherData}", JsonSerializer.Serialize(toDoResponse.Weather));

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to fetch weather data for the ToDo item.");
            }
        }
    }
    
    //Author: Anthony Gibah
    private async Task AddWeatherInfo(ToDoResponse toDoResponse)
    {
        //Fetch weather data if location is provided
        if (toDoResponse.Location != null &&
            toDoResponse.Location.Latitude != 0 &&
            toDoResponse.Location.Longitude != 0)
        {
            try
            {
                var weather = await _weatherService.GetCurrentWeather(toDoResponse.Location);
                toDoResponse.Weather = weather;
                _logger.LogInformation("Weather data added to the ToDo response.");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to fetch weather data for the ToDo item.");
            }
        }
    }
}