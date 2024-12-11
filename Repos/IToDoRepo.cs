using ToDo.Models;

namespace ToDo.Repos;

//Author: Anthony Gibah
public interface IToDoRepo
{
    //IMethod for saving list to db
    Task SaveToDoList(List<ToDoItem> todos);
    
    //Fetch ToDoList
    Task<List<ToDoItem>> FetchToDoList();
    
    //Fetch ToDoItem
    Task<ToDoItem> FetchToDoItem(long id);

    //Author: Anthony Gibah
    //Update ToDos Item
    public Task UpdateToDoItem(long id, ToDoItem toDoItem);
    
    //Deleting TodoItems
    public Task DeleteToDoItem(ToDoItem toDoItem);
    
    //To Know if item exists
    public Task<ToDoItem?> GetToDoItemById(long id);
    
    //Post Single ToDoItem
    public Task PostToDoItem(ToDoItem toDoItem);
    
    //Author: Anthony Gibah
    //Search Item by Query
    public Task<IEnumerable<ToDoItem>> SearchToDoItems(string? title, int? priority, DateTime? dueDate);
}