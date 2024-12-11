using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Repos;

//Author: Anthony Gibah
public class ToDoRepoImpl : IToDoRepo
{
    private readonly ToDoContext _context; //Dependency injection
    private readonly ILogger _logger; //Dependency Injection
    
    public ToDoRepoImpl(ToDoContext context, ILogger<ToDoRepoImpl> logger)
    {
        _context = context;
        _logger = logger;
    }

    //Author: Anthony Gibah
    //Method Implementation for saving list to db
    public async Task SaveToDoList(List<ToDoItem> todos)
    {
        _logger.LogInformation("Attempting to save {Count} ToDo items to the database.", todos.Count);

        try
        {
            _context.ToDoItems.AddRange(todos);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            //Log Exception for debugging
            _logger.LogError(ex, "An error occurred while saving ToDo items to the database.");
            throw;
        }
    }

    public async Task<List<ToDoItem>> FetchToDoList()
    {
        try
        {
            return await _context.ToDoItems.ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while fetching the ToDo list from the database.");
            throw;
        }
    }
    
    public async Task<ToDoItem> FetchToDoItem(long id)
    {
        try
        {
            return await _context.ToDoItems.FindAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while fetching the ToDo item from the database.");
            throw;
        }
    }

    //Author: Anthony Gibah
    public async Task UpdateToDoItem(long id, ToDoItem toDoItem)
    {
        _context.Entry(toDoItem).State = EntityState.Modified;
        
        if (toDoItem.Location != null)
        {
            _context.Entry(toDoItem.Location).State = EntityState.Modified;
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ToDoItemExists(id))
            {
                throw new ArgumentException("The ToDo Item was not found.");
            } {
                throw;
            }
        }

    }

    public async Task DeleteToDoItem(ToDoItem toDoItem)
    {
        try
        {
            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while deleting the ToDo item.");
            throw;
        }
    }

    //Author: Anthony Gibah
    public async Task<ToDoItem?> GetToDoItemById(long id)
    {
        return await _context.ToDoItems.FindAsync(id);
    }

    public async Task PostToDoItem(ToDoItem toDoItem)
    {
        try
        {
            _logger.LogInformation("Start: Adding item to Db in Repo.");
            _context.ToDoItems.Add(toDoItem);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while posting the ToDo item.");
            throw;
        }
    }

    public async Task<IEnumerable<ToDoItem>> SearchToDoItems(string? title, int? priority, DateTime? dueDate)
    {
        IQueryable<ToDoItem> query = _context.ToDoItems;

        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(todo => todo.Todo.ToLower().Contains(title.ToLower()));
        }

        if (priority.HasValue)
        {
            query = query.Where(todo => todo.Priority == priority.Value);
        }

        if (dueDate.HasValue)
        {
            query = query.Where(todo => todo.DueDate.HasValue && todo.DueDate.Value.Date == dueDate.Value.Date);
        }

        return await query.ToListAsync();
    }

    //Author: Anthony Gibah
    private bool ToDoItemExists(long id)
    {
        return _context.ToDoItems.Any(e => e.Id == id);
    }
}
